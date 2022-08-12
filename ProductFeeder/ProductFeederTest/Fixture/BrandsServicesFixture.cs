using ProductFeederCoreLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederTest.Fixture
{
    public class BrandsServicesFixture
    {
        private readonly BrandsServices _service;

        public BrandsServicesFixture()
        {
            FeederProductsDbContextFixture fixtureDbContext = new FeederProductsDbContextFixture();
            _service = new BrandsServices(fixtureDbContext.GetDbContext());
        }

        public BrandsServices GetService()
        {
            return _service;
        }
    }
}
