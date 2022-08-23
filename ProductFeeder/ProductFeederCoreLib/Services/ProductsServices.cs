using Microsoft.EntityFrameworkCore;
using ProductFeederCoreLib.Data;
using ProductFeederCoreLib.Interfaces;
using ProductFeederCoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Services
{
    public class ProductsServices : IServices<ProductsServices>
    {
        private readonly FeederProductsDbContext _dbContext;

        public ProductsServices(FeederProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddProductAsync(Product model)
        {
            await _dbContext.AddAsync(model);            
            var response = await _dbContext.SaveChangesAsync();

            return Convert.ToBoolean(response);
        }

        public async Task<bool> AddProductsAsync(IEnumerable<Product> products)
        {
            await _dbContext.AddRangeAsync(products);
            var response = await _dbContext.SaveChangesAsync();

            return Convert.ToBoolean(response);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _dbContext.Products.Where(prop=>prop.Id==id)
                .Include(prop => prop.Brand).ThenInclude(brandProp => brandProp.Supplier)
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
                            }
                        },
                        ShortDescription = prop.ShortDescription,
                        LongDescription = prop.LongDescription,
                        CreationDateTimeStamp = prop.CreationDateTimeStamp,
                        Active = prop.Active
                    }
                 )
                .FirstAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int limit = 100)
        {
            return await _dbContext.Products.Where(prop => prop.Active == true)
                .Include(prop=> prop.Brand).ThenInclude(brandProp=>brandProp.Supplier)
                .Include(prop=>prop.Prices)
                .Select(prop =>
                    new Product()
                    {
                        Id = prop.Id,
                        sku = prop.sku,
                        Brand = new Brand()
                        {
                            Id=prop.Brand.Id,
                            Name=prop.Brand.Name,
                            Prefix=prop.Brand.Prefix,
                            CreationDateTimeStamp= prop.CreationDateTimeStamp,
                            Supplier= new Supplier()
                            {
                                Id=prop.Brand.Supplier.Id,
                                SupplierName= prop.Brand.Supplier.SupplierName,
                                CreationDateTimeStamp=prop.Brand.Supplier.CreationDateTimeStamp,
                                Prefix= prop.Brand.Supplier.Prefix,
                                RazonSocial= prop.Brand.Supplier.RazonSocial,
                                RFC= prop.Brand.Supplier.RFC,
                                Email= prop.Brand.Supplier.Email
                            }
                        },
                        ShortDescription = prop.ShortDescription,
                        LongDescription = prop.LongDescription,
                        CreationDateTimeStamp = prop.CreationDateTimeStamp,
                        Active = prop.Active
                    }
                 )
                .Take(limit)
                .ToListAsync();
        }


    }
}
