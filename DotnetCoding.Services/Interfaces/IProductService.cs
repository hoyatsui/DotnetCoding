using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetCoding.Core.Models;

namespace DotnetCoding.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDetails>> GetAllProducts();

        Task<IEnumerable<ProductDetails>> GetActiveProducts();

        Task<ProductDetails> CreateProduct(ProductDetails productDetails);
       
        Task<IEnumerable<ProductDetails>> SearchProducts(string? productName, int? minPrice, int? maxPrice, DateTime? startDate, DateTime? endDate);
        
        Task<bool> UpdateProduct(ProductDetails productDetails );

        Task DeleteProduct(int productId);

       
    
    }
}
