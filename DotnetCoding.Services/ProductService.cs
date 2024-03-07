using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetCoding.Core.Exceptions;
using DotnetCoding.Core.Interfaces;
using DotnetCoding.Core.Models;
using DotnetCoding.Services.Interfaces;

namespace DotnetCoding.Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfWork;
        public IRequestService _requestService;

        public ProductService(IUnitOfWork unitOfWork, IRequestService requestService)
        {
            _unitOfWork = unitOfWork;
            _requestService = requestService;
        }

        public async Task<IEnumerable<ProductDetails>> GetAllProducts()
        {
            var productDetailsList = await _unitOfWork.Products.GetAll();
            return productDetailsList;
        }
       public async Task<IEnumerable<ProductDetails>> GetActiveProducts()
       {
            return await _unitOfWork.Products.GetActiveProducts();
            
       }

        public async Task<IEnumerable<ProductDetails>> SearchProducts(string? productName, int? minPrice, int? maxPrice, DateTime? startDate, DateTime? endDate)
        {

            return await _unitOfWork.Products.GetActiveProducts(productName,  minPrice,  maxPrice, startDate, endDate);
        }

        public async Task<ProductDetails> CreateProduct(ProductDetails productDetails)
        {
            
            if(productDetails.ProductPrice> 10000)
            {
                throw new ArgumentException("Product price exceeds the maximum allowed limit of $10,000.");
            }
            if(productDetails.ProductPrice > 5000)
            {
                string NewProductName = productDetails.ProductName;
                int NewProductPrice = productDetails.ProductPrice;
                string NewProductDescription = productDetails.ProductDescription;
                await _requestService.AddToRequestQueue(NewProductName, NewProductPrice, NewProductDescription,"Product price over $5,000.", "Create");
                throw new ApprovalRequiredException("Product creation is pending due to price over &5,000.");
            }
            else
            {
                productDetails.IsActive= true;
                try
                {
                    await _unitOfWork.Products.AddProduct(productDetails);
                    await _unitOfWork.SaveAsync();
                    return productDetails;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("An error occurs when saving the product" + ex.Message);
                }
            }
         
        }


        public async Task<bool> UpdateProduct(ProductDetails productDetails)
        {
            var product = await _unitOfWork.Products.GetById(productDetails.Id);
            int productId = product.Id;
            if (product == null)
            {
                throw new KeyNotFoundException("Product doesn't exist");
            }

            if (!product.IsActive) throw new Exception("Product is not active.");
            int previousPrice = product.ProductPrice;
            // need approval
            if((productDetails.ProductPrice - previousPrice) / previousPrice > 0.5 || productDetails.ProductPrice > 5000)
            {

                await _requestService.AddToRequestQueue(productId, productDetails.ProductName, productDetails.ProductPrice, productDetails.ProductDescription,"Price update","Update");
                product.IsActive = false;
                await _unitOfWork.SaveAsync();
                return false;
            } else // update directly
            {
                product.ProductPrice = productDetails.ProductPrice;
                await _unitOfWork.Products.Update(productDetails);
                return true;
            }
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _unitOfWork.Products.GetById(productId);
            if (product == null) throw new KeyNotFoundException("Product doesn't exist");
            //if (!product.IsActive) throw new Exception("Product is not active.");
            await _requestService.AddToRequestQueue(productId, "Product Deletion", "Delete");
            product.IsActive = false;
            await _unitOfWork.SaveAsync();
        }


    }
}
