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
    public class BrandServicesTests: IClassFixture<BrandsServicesFixture>, IClassFixture<SupplierServicesFixture>
    {
        private readonly BrandsServices _brandServices;
        private readonly SupplierServices _supplierServices;
        private readonly ITestOutputHelper _output;

        public BrandServicesTests(BrandsServicesFixture brandServicesFixture, SupplierServicesFixture supplierServicesFixture, ITestOutputHelper output)
        {
            _brandServices = brandServicesFixture.GetService();
            _supplierServices = supplierServicesFixture.GetService();
            _output = output;
        }

        [Fact]
        public async void AddBrandAsync_AddItemToDataBase()
        {
            string[] brands = new string[] { "brand1" };
            List<Brand>  brandsToProcess = (await CreateBrandData(brands)).ToList();

            var response = await _brandServices.AddBrandAsync(brandsToProcess.First());

            Assert.True(response);
        }

        [Fact]
        public async void UpdateBrandAsync_UpdateItemToDatabase()
        {
            string[] brands = new string[] { "brand2" };
            List<Brand> brandsToProcess = (await CreateBrandData(brands)).ToList();
            var responseAdded = await _brandServices.AddBrandAsync(brandsToProcess.First());

            Brand brandFound = await _brandServices.GetBrandByNameAsync("brand2");

            brandFound.Prefix = "234";

            var response = await _brandServices.UpdateBrandAsync(brandFound);
            Assert.True(response);

        }

        [Theory]
        [InlineData("LIQUIMOLY", true, true)]
        [InlineData("BREMBO", false, false)]
        public async void ChangeActivationSupplierAsync_ChangeStatusOnRecord(string brandName, bool value, bool expected)
        {

            string[] brands = new string[] { brandName };
            List<Brand> brandsToProcess = (await CreateBrandData(brands)).ToList();

            await _brandServices.AddBrandAsync(brandsToProcess.First());
            Brand brandAdded= await _brandServices.GetBrandByNameAsync(brandName);
            brandAdded.Active = value;

            var response = await _brandServices.ChangeActivationBrandAsync(brandAdded.Id, value);

            Brand? changed = await _brandServices.GetByIdAsync(brandAdded.Id);

            Assert.NotNull(changed);
            Assert.Equal(changed.Active, value);

        }

        [Fact]
        public async void GetSupplierWithBrands_GetBrandsOfSupplier()
        {
            string[] brands = new string[] { "brand1", "brand2", "brand3", "brand4" };
            List<Brand> brandsToProcess = (await CreateBrandData(brands,"supplierfake")).ToList();

            foreach(Brand brand in brandsToProcess)
            {
                await _brandServices.AddBrandAsync(brand);
            }

            int supplierId = brandsToProcess.First().SupplierId;

            await _brandServices.ChangeActivationBrandAsync(brandsToProcess.Last().Id,false);

            _output.WriteLine(supplierId.ToString());

            Supplier? supplier = await _supplierServices.GetSupplierWithBrands(supplierId);

            Assert.NotNull(supplier);
            Assert.InRange(supplier.brands.Count(), 1, 5);
            Assert.Equal(3, supplier.brands.Count());

            _output.WriteLine(supplier.Id.ToString());
            _output.WriteLine(supplier.SupplierName);
            foreach (Brand brand in supplier.brands) _output.WriteLine(brand.Name);
        }

        public async Task<IEnumerable<Brand>> CreateBrandData(IEnumerable<string> brands,string supplierName="Parito" )
        {
            Supplier? newSupplier = new Supplier()
            {
                SupplierName=supplierName
            };

            await _supplierServices.AddSupplierAsync(newSupplier);

            newSupplier = await _supplierServices.GetSupplierByNameAsync(supplierName);

            IList<Brand> addedBrands = new List<Brand>();

            foreach (string brand in brands)
            {
                addedBrands.Add(new Brand()
                {
                    Name = brand,
                    SupplierId = (newSupplier==null)? 0 : newSupplier.Id
                });
            }


            return addedBrands;
            
        }

    }
}
