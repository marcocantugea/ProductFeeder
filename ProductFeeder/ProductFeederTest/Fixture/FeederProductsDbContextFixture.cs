using Microsoft.EntityFrameworkCore;
using ProductFeederCoreLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederTest.Fixture
{
    public class FeederProductsDbContextFixture
    {
        private readonly FeederProductsDbContext _fixture;

        public FeederProductsDbContextFixture()
        {
            var options = new DbContextOptionsBuilder<FeederProductsDbContext>().UseInMemoryDatabase(databaseName: "feederproducts_dev").Options;
            _fixture = new FeederProductsDbContext(options);
            _fixture.Database.EnsureCreated();
        }

        public FeederProductsDbContext GetDbContext()
        {
            return _fixture;
        }
    }
}
