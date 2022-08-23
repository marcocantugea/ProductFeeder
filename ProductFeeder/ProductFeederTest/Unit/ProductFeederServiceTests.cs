using ProductFeederCoreLib.Services;
using ProductFeederTest.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederTest.Unit
{
    public class ProductFeederServiceTests:IClassFixture<ProductFeederServiceFixture>
    {
        private readonly ProductFeederService _service;

        public ProductFeederServiceTests(ProductFeederServiceFixture fixture)
        {
            _service = fixture.GetService();
        }

        [Fact]
        public void SaveJsonFile_CreateJsonFileOnTmpFolder()
        {
            _service.SetTmpPath("./tmp");
            _service.SaveJsonFile("contenido del arhcivo");

            Assert.True(File.Exists(_service.GetFilePathSaved()));
        }

    }
}
