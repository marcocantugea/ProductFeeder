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
    public class SupplierServices :IServices<SupplierServices>
    {
        private readonly FeederProductsDbContext _dbContext;
        public SupplierServices(FeederProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddSupplierAsync(Supplier model)
        {
            await _dbContext.AddAsync<Supplier>(model);
            var response = await _dbContext.SaveChangesAsync();
            return Convert.ToBoolean(response);
        }

        public async Task<bool> UpdateSupplierAsync(Supplier model)
        {
            _dbContext.Update<Supplier>(model);
            var response = await _dbContext.SaveChangesAsync();
            return Convert.ToBoolean(response);
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            Supplier? suppilerFound = null;

            try
            {
                suppilerFound = await _dbContext.Suppliers.FindAsync(id);
            }
            catch (Exception)
            {
                return suppilerFound;
                
            }

            return suppilerFound;
        }

        public async Task<bool> ChangeActivationSupplierAsync(int id, bool activation=true)
        {
            Supplier? supplier = await GetByIdAsync(id);
            if (supplier == null) return false;
            if (supplier.Active == false && activation == false) return false;
            supplier.Active = activation;
            if (!activation) supplier.DeletionDateTimeStamp = DateTime.Now;
            if (supplier.DeletionDateTimeStamp != null && activation) supplier.DeletionDateTimeStamp = null;

            _dbContext.Suppliers.Update(supplier);
            var response= await _dbContext.SaveChangesAsync();

            return Convert.ToBoolean(response);
        }

        public async Task<Supplier?> GetSupplierByNameAsync(string supplierName)
        {
            Supplier? found=null;
            try
            {
                found = await _dbContext.Suppliers.Where(prop => prop.SupplierName == supplierName).FirstAsync();
            }
            catch (Exception e)
            {
                return found;
            }
            
            return found;
        }

        public async Task<IEnumerable<Supplier>> GetAllActiveSuppliers()
        {
            return await _dbContext.Suppliers.Where(prop => prop.Active == true).ToListAsync();
        }

        public async Task<Supplier?> GetSupplierWithBrands(int id)
        {
            Supplier? found = await _dbContext.Suppliers
                                    .Include(prop => prop.brands)
                                    .Where(prop => prop.Id == id && prop.Active==true)
                                    
                                    .Select(prop=> new Supplier()
                                    {
                                        Id=prop.Id,
                                        SupplierName=prop.SupplierName,
                                        brands = prop.brands.Where(brand=> brand.Active== true).Select(bprop=> 
                                                new Brand() { 
                                                    Id=bprop.Id,
                                                    Name=bprop.Name,
                                                    Prefix=bprop.Prefix,
                                                    CreationDateTimeStamp=bprop.CreationDateTimeStamp
                                                }
                                        ),
                                        Email=prop.Email,
                                        CreationDateTimeStamp=prop.CreationDateTimeStamp,
                                        Prefix =prop.Prefix,
                                        RazonSocial=prop.RazonSocial,
                                        RFC=prop.RFC
                                    }
                                    ).FirstOrDefaultAsync();
            return found;
        }
    }
}
