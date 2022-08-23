using ProductFeederCoreLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederTest.Fixture
{
    public class ProductFeederServiceFixture
    {
        private readonly ProductFeederService _service;

        public ProductFeederServiceFixture()
        {

            ProductsServices productService = new ProductsServices((new FeederProductsDbContextFixture()).GetDbContext());
            _service = new ProductFeederService(productService);
        }

       public ProductFeederService GetService()
        {
            return _service;
        }
    }
}
