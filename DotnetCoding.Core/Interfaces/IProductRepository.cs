using DotnetCoding.Core.Models;

namespace DotnetCoding.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<ProductDetails>
    {
        Task<IEnumerable<ProductDetails>> GetActiveProducts(string productName, int? minPrice, int? maxPrice, DateTime? startDate, DateTime? endDate);
        Task<IEnumerable<ProductDetails>> GetActiveProducts();
        Task AddProduct(ProductDetails producDetails);
    }

}
