using DotnetCoding.Core.Interfaces;
using DotnetCoding.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoding.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<ProductDetails>, IProductRepository
    {
        public ProductRepository(DbContextClass _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<ProductDetails>> GetActiveProducts()
        {
            return await _dbContext.Products.Where(p => p.IsActive).OrderByDescending(p => p.PostDate).ToListAsync();
        }
        public async Task<IEnumerable<ProductDetails>> GetActiveProducts(string? productName, int? minPrice, int? maxPrice, DateTime? startDate, DateTime? endDate)
        {
            var query = _dbContext.Products.Where(p => p.IsActive);
            if(!string.IsNullOrEmpty(productName))
            {
                query = query.Where(p => p.ProductName.Contains(productName));
            }
            if(minPrice.HasValue)
            {
                query = query.Where(p => p.ProductPrice >= minPrice.Value);
            }
            if(maxPrice.HasValue)
            {
                query = query.Where(p=>p.ProductPrice <= maxPrice.Value);
            }
            if(startDate.HasValue)
            {
                query = query.Where(p=>p.PostDate>=startDate.Value);
            }
            if(endDate.HasValue)
            {
                query =query.Where(p=>p.PostDate<=endDate.Value);
            }

            return await query.OrderByDescending(p => p.PostDate).ToListAsync();
        }

        public async Task AddProduct(ProductDetails producDetails)
        {
            if(producDetails == null)
            {
                throw new ArgumentException("ProductDetails cannot be null.");
            }
            await _dbContext.Products.AddAsync(producDetails);
            await _dbContext.SaveChangesAsync();
        }
               
    }
}
