using Core.Entities.Products;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public ProductRepository(StoreDbContext storeDbContext)
        {
            this._storeDbContext = storeDbContext;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _storeDbContext.productBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _storeDbContext.Products
                .Include(x => x.productBrand)
                .Include(x => x.productType)
                .FirstOrDefaultAsync(x=>x.Id == id);
            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storeDbContext.Products
                .Include(x=>x.productBrand)
                .Include(x => x.productType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
           return  await _storeDbContext.productTypes.ToListAsync();
        }

        
    }
}
