using AutoMapper;
using CsvHelper;
using Hangfire;
using Hangfire.Common;
using Hangfire.Storage;
using Microsoft.EntityFrameworkCore;
using ProductFeederCoreLib.Data;
using ProductFeederCoreLib.Interfaces;
using ProductFeederCoreLib.Mappers;
using ProductFeederCoreLib.Models;
using ProductFeederRESTfulAPI.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Services
{
    public class ProductFeederService : IServices<ProductFeederService>
    {
        private readonly ProductsServices _productsService;
        private readonly FeederProductsDbContext _dbContext;
        private string _tmpPath = "tmp";
        private string _tmpPrefixJsonFileName = "tmp";
        private string _fileName = "";
        private IMapper _mapper;

        private IBackgroundJobClient _backgroundJob { get; }

        public ProductFeederService(IServices<ProductsServices> productsService, IBackgroundJobClient backgroundJob, FeederProductsDbContext dbContext, IMapper mapper)
        {
            _productsService = (ProductsServices)productsService;
            _backgroundJob = backgroundJob;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Feed> ProcessProductFeed(IEnumerable<Product> products)
        {
            //1. Save the products to process on the tmp file
            SaveJsonFile(JsonSerializer.Serialize(products));

            //2. We create the schedule process to upload the files to database
            var idjob=_backgroundJob.Schedule(() => ProcessProducts(GetAbsPathSaved()),TimeSpan.FromMinutes(5) );

            //3. we save the ids on database to return to the user on request
            Feed newFeed = new Feed() { 
                feedUid = Guid.NewGuid().ToString(),
                Active = true,
                CreationDateTimeStamp = DateTime.Now,
                file= GetAbsPathSaved(),
                processId=Int32.Parse(idjob),
                status=0

            };
            await _dbContext.Feeds.AddAsync(newFeed);
            await _dbContext.SaveChangesAsync();

            //4. return the info of the feed
            return newFeed;
        }

        public async Task<Feed> ProcessProductFeedCsv(string csvFilePath, IMapper mapper)
        {

            var idjob = _backgroundJob.Schedule(() => ProcessProductsFromCsv(csvFilePath), TimeSpan.FromMinutes(5));

            Feed newFeed = new Feed()
            {
                feedUid = Guid.NewGuid().ToString(),
                Active = true,
                CreationDateTimeStamp = DateTime.Now,
                file = csvFilePath,
                processId = Int32.Parse(idjob),
                status = 0

            };
            await _dbContext.Feeds.AddAsync(newFeed);
            await _dbContext.SaveChangesAsync();

            return newFeed;
        }

        public async Task ProcessProducts(string jsonFilePath)
        {
            List<Product> products = JsonSerializer.Deserialize<IEnumerable<Product>>(File.ReadAllText(jsonFilePath)).ToList();

            if (products.Count == 0) return;
            await _productsService.AddProductsAsync(products);
        }

        public async Task ProcessProductsFromCsv(string csvFilePath)
        {
            List<Product> productsFromCsv = GetProductsFromCsv(csvFilePath);
            if (productsFromCsv.Count == 0) throw new Exception("no records to process");
            await _productsService.AddProductsAsync(productsFromCsv);
        }

        private List<Product> GetProductsFromCsv(string csvFilePath)
        {
            List<ProductDTO> productsDto = new List<ProductDTO>();

            using (var reader = new StreamReader(csvFilePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<ProductDTOCsvMapper>();
                    productsDto = csv.GetRecords<ProductDTO>().ToList();
                }
            }

            List<Product> products = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<Product>>(productsDto).ToList();

            return products;
        }

        public async void SaveJsonFile(string content)
        {
            if(!Directory.Exists(Directory.GetCurrentDirectory()+"\\"+_tmpPath)) 
                Directory.CreateDirectory(Directory.GetCurrentDirectory()+"\\"+_tmpPath);

            await File.WriteAllTextAsync(GetFilePath(), content);
        }

        public string GetFilePathSaved()
        {
            return Directory.GetCurrentDirectory()+$"\\{_tmpPath}\\{_fileName}";
        }

        public string GetAbsPathSaved()
        {
            return $"./{_tmpPath}/{_fileName}";
        }
        private string GetFilePath()
        {
            Guid guid = Guid.NewGuid();
            _fileName= $"{_tmpPrefixJsonFileName}_products_{guid}.json";
            return $"./{_tmpPath}/{_fileName}";
        }

        public void SetTmpPath(string path)
        {
            _tmpPath = path;
        }

        public async Task<Feed?> CheckStatusFeed(string uid)
        {
            
            Feed? feed=  await _dbContext.Feeds.Where(prop => prop.feedUid == uid).FirstOrDefaultAsync();

            if (feed == null) return null;
            JobData Job = JobStorage.Current.GetConnection().GetJobData(feed.processId.ToString());

            if (feed.status == (int)FeedStatus.COMPLETED) return feed;

            if(Job.State== Hangfire.States.SucceededState.StateName) feed.status = (int)FeedStatus.COMPLETED;
            if(Job.State == Hangfire.States.ProcessingState.StateName) feed.status = (int)FeedStatus.IN_PROGRESS;
            if (Job.State == Hangfire.States.FailedState.StateName) feed.status = (int)FeedStatus.FAILED;
            if (Job.State == Hangfire.States.ScheduledState.StateName) feed.status = (int)FeedStatus.CREATED;

            _dbContext.Feeds.Update(feed);
            await _dbContext.SaveChangesAsync();

            return feed;
        }

        public async Task<IEnumerable<Product>> GetFeedDetail(string uid,int limit=100, int offset=0)
        {

            if(limit>100) limit=100;

            Feed? feed = await _dbContext.Feeds.Where(prop => prop.feedUid == uid).FirstOrDefaultAsync();

            if (feed == null) return new List<Product>();


            List<Product> products = new List<Product>();

            if (feed.file.Contains(".csv"))
            {
                products = GetProductsFromCsv(feed.file);
            }
            else
            {
                products = JsonSerializer.Deserialize<IEnumerable<Product>>(File.ReadAllText(feed.file)).ToList();
            }
                
            var skus = products.Select(item => item.sku).ToList();

            return await _dbContext.Products.Where(prop => skus.Contains(prop.sku) && prop.Active==true)
                .Include(prop => prop.Brand).ThenInclude(brandProp => brandProp.Supplier)
                .Include(prop => prop.Condition)
                .Include(prop => prop.Shipping)
                .Include(prop => prop.Prices)
                .Select(prop =>
                    new Product()
                    {
                        Id = prop.Id,
                        sku = prop.sku,
                        Brand = new Brand()
                        {
                            Id = prop.Brand.Id,
                            Name = prop.Brand.Name,
                            Prefix = prop.Brand.Prefix,
                            CreationDateTimeStamp = prop.CreationDateTimeStamp,
                            Supplier = new Supplier()
                            {
                                Id = prop.Brand.Supplier.Id,
                                SupplierName = prop.Brand.Supplier.SupplierName,
                                CreationDateTimeStamp = prop.Brand.Supplier.CreationDateTimeStamp,
                                Prefix = prop.Brand.Supplier.Prefix,
                                RazonSocial = prop.Brand.Supplier.RazonSocial,
                                RFC = prop.Brand.Supplier.RFC,
                                Email = prop.Brand.Supplier.Email
                            },
                        },
                        ShortDescription = prop.ShortDescription,
                        LongDescription = prop.LongDescription,
                        CreationDateTimeStamp = prop.CreationDateTimeStamp,
                        Active = prop.Active,
                        Condition = prop.Condition,
                        Shipping = prop.Shipping
                    }
                 )
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

        }

        public async Task<int> GetFeedTotalItemsAdded(string uid)
        {
            Feed? feed = await _dbContext.Feeds.Where(prop => prop.feedUid == uid).FirstOrDefaultAsync();

            if (feed == null) return 0;
            List<Product> products = new List<Product>();
            if (feed.file.Contains(".csv"))
            {
                products = GetProductsFromCsv(feed.file);
            }
            else
            {
                products = JsonSerializer.Deserialize<IEnumerable<Product>>(File.ReadAllText(feed.file)).ToList();
            }
            var skus = products.Select(item => item.sku).ToList();

            return await _dbContext.Products.Where(prop => skus.Contains(prop.sku) && prop.Active == true).CountAsync();
        }
    }
}

public enum FeedStatus
{
    CREATED=0,
    IN_PROGRESS = 2,
    COMPLETED =10,
    FAILED =50,
}
