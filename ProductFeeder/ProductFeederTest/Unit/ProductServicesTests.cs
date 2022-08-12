using ProductFeederCoreLib.Models;
using ProductFeederCoreLib.Services;
using ProductFeederTest.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ProductFeederTest.Unit
{
    public class SupplierServicesTests : IClassFixture<SupplierServicesFixture>
    {
        private readonly SupplierServices _service;
        private readonly ITestOutputHelper _output;

        public SupplierServicesTests(SupplierServicesFixture fixtureSupplierServices,ITestOutputHelper output)
        {
            _service= fixtureSupplierServices.GetService();
            _output= output;
        }


        [Fact]
        public async void AddSupplierAsync_AddItemToDatabase()
        {
            Assert.True(await AddSupplierTest());
        }

        [Fact]
        public async void UpdateSupplierAsync_UpdateItemInDatabase()
        {
            await AddSupplierTest();

            Supplier supplierAdded = await _service.GetSupplierByNameAsync("RADEC");
            supplierAdded.Email = "radec@gmail.com";

            Assert.True(await _service.UpdateSupplierAsync(supplierAdded));
        }

        [Fact]
        public async void GetByIdAsync_GetSupplierById()
        {
            await AddSupplierTest();

            Supplier supplierAdded = await _service.GetSupplierByNameAsync("RADEC");

            Supplier? found =  await _service.GetByIdAsync(supplierAdded.Id);

            Assert.InRange(supplierAdded.Id, 1, 1000000);
            Assert.InRange(found.Id, 1, 1000000);
        }

        [Fact]
        public async void GetByIdAsync_SupplierNotFound_ReturnNullValue()
        {
            Supplier? found = await _service.GetByIdAsync(9378);

            Assert.Null(found);
        }

        [Fact]
        public async void GetSupplierByNameAsync_SupplierNotFoud_ReturnNoElements()
        {
           
            Supplier? found = await _service.GetSupplierByNameAsync("perenganito");
            Assert.Null(found);
        }

        [Theory]
        [InlineData("BREMBO",true,true)]
        [InlineData("FLOTAMEX", false, false)]
        public async void ChangeActivationSupplierAsync_ChangeStatusOnRecord(string supplierName,bool value, bool expected)
        {
            await AddSupplierTest(supplierName);
            Supplier supplierAdded = await _service.GetSupplierByNameAsync(supplierName);
            supplierAdded.Active = value;

            var response = await _service.ChangeActivationSupplierAsync(supplierAdded.Id, value);

            Supplier? changed = await _service.GetByIdAsync(supplierAdded.Id);

            Assert.NotNull(changed);
            Assert.Equal(changed.Active, value);

        }

        [Fact]
        public async void GetAllActiveSuppliers_GetListOfSuppliers()
        {
            await AddSupplierTest();
            List<Supplier> suppliers =(await _service.GetAllActiveSuppliers()).ToList();

            Assert.InRange(suppliers.Count,1,10);
        }

        public async Task<bool> AddSupplierTest(string name="RADEC")
        {
            Supplier newSupplier = new Supplier()
            {
                SupplierName = name,

            };

            return await _service.AddSupplierAsync(newSupplier);
        }
    }
}
