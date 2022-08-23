using ProductFeederRESTfulAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Services
{
    public class ProductFeederService
    {
        private readonly ProductsServices _productsService;
        private string _tmpPath = "tmp";
        private string _tmpPrefixJsonFileName = "tmp";
        private string _fileName = "";

        public ProductFeederService(ProductsServices productsService)
        {
            _productsService = productsService;
        }

        public async Task ProcessProductFeed(IEnumerable<ProductDTO> products)
        {
            //1. Save the products to process on the tmp file
            SaveJsonFile(JsonSerializer.Serialize(products));

            //2. We create the schedule process to upload the files to database

            //3. we save the ids on database to return to the user on request

            //4. return the info of the feed

        }

        public async void SaveJsonFile(string content)
        {
            if(!Directory.Exists(Directory.GetCurrentDirectory()+"\\"+_tmpPath)) 
                Directory.CreateDirectory(Directory.GetCurrentDirectory()+"\\"+_tmpPath);

            await File.WriteAllTextAsync(getFilePath(), content);
        }

        public string GetFilePathSaved()
        {
            return Directory.GetCurrentDirectory()+$"\\{_tmpPath}\\{_fileName}";
        }

        private string getFilePath()
        {
            Guid guid = Guid.NewGuid();
            _fileName= $"{_tmpPrefixJsonFileName}_products_{guid}.json";
            return $"./{_tmpPath}/{_fileName}";
        }

        public void SetTmpPath(string path)
        {
            _tmpPath = path;
        }
    }
}
