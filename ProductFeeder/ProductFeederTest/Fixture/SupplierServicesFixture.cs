using ProductFeederCoreLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederTest.Fixture
{
    public class SupplierServicesFixture
    {
        private readonly SupplierServices _service;

        public SupplierServicesFixture()
        {
            FeederProductsDbContextFixture fixtureDbContext= new FeederProductsDbContextFixture();
            _service = new SupplierServices(fixtureDbContext.GetDbContext());
        }

        public SupplierServices GetService()
        {
            return _service;
        }
    }
}
