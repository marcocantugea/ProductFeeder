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
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int limit = 100)
        {
            return await _dbContext.Products.Where(prop => prop.Active == true)
                .Include(prop=> prop.Brand)
                .Include(prop=>prop.Prices)
                .Take(limit)
                .ToListAsync();
        }


    }
}
