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
    public class BrandsServices : IServices<BrandsServices>
    {
        private readonly FeederProductsDbContext _dbContext;

        public BrandsServices(FeederProductsDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<bool> AddBrandAsync(Brand model)
        {
            await _dbContext.AddAsync(model);
            var response = await _dbContext.SaveChangesAsync();

            return Convert.ToBoolean(response);
        }

        public async Task<bool> UpdateBrandAsync(Brand model)
        {
            _dbContext.Update(model);
            var response = await _dbContext.SaveChangesAsync();

            return Convert.ToBoolean(response);
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            Brand? brandFound = null;

            try
            {
                brandFound= await _dbContext.Brands.Where(prop => (prop.Id == id && prop.Active == true)).FirstAsync();
            }
            catch (Exception)
            {
                return brandFound;
            }

            return brandFound;
        }

        public async Task<bool> ChangeActivationBrandAsync(int id, bool activation = true)
        {
            Brand? brand = await GetByIdAsync(id);
            if (brand == null) return false;

            if(brand.Active==false && activation==false) return false;

            brand.Active = activation;
            if (!activation) brand.DeletionDateTimeStamp = DateTime.Now;
            if (brand.DeletionDateTimeStamp != null && activation) brand.DeletionDateTimeStamp = null;

            _dbContext.Brands.Update(brand);
            var response = await _dbContext.SaveChangesAsync();

            return Convert.ToBoolean(response);
        }


        public async Task<Brand?> GetBrandByNameAsync(string name)
        {
            Brand? brandFound = null;

            try
            {
                brandFound = await _dbContext.Brands.Where(prop=>prop.Name==name).FirstAsync();
            }
            catch (Exception e)
            {
                return brandFound;
            }

            return brandFound;
        }


        public async Task<IEnumerable<Brand>> GetActiveBrands()
        {
            return await _dbContext.Brands.Where(prop => prop.Active == true).ToListAsync();
        }

        public static implicit operator BrandsServices(SupplierServices v)
        {
            throw new NotImplementedException();
        }
    }
}
