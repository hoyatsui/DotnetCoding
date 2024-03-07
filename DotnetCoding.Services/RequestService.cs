using DotnetCoding.Core.Interfaces;
using DotnetCoding.Core.Models;
using DotnetCoding.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoding.Services
{
    public class RequestService : IRequestService
    {

        public IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddToRequestQueue(string newProductname, int newProductPrice, string newProductDescription, string reason, string reqeustType)
        {

            
            var request = new Request
            {

                RequestType = reqeustType,
                RequestReason = reason,
                RequestDate = DateTime.Now,
                NewProductDescription = newProductDescription,
                NewProductName = newProductname,
                NewProductPrice = newProductPrice,
            };
            await _unitOfWork.Requests.AddRequest(request);
        }
        public async Task AddToRequestQueue(int productId, string newProductname, int newProductPrice, string newProductDescription, string reason, string reqeustType)
        {

            var request = new Request
            {

                RequestType = reqeustType,
                RequestReason = reason,
                RequestDate = DateTime.Now,
                NewProductDescription = newProductDescription,
                NewProductName = newProductname,
                NewProductPrice = newProductPrice,
                ProductId = productId
            };
            await _unitOfWork.Requests.AddRequest(request);
        }
        public async Task AddToRequestQueue(int productId, string reason, string reqeustType)
        {

            var request = new Request
            {

                RequestType = reqeustType,
                RequestReason = reason,
                RequestDate = DateTime.Now,
                ProductId = productId
            };
            await _unitOfWork.Requests.AddRequest(request);
        }

        public async Task<IEnumerable<Request>> GetAllRequests()
        {
            return await _unitOfWork.Requests.GetRequests();
        }


       public async Task ApproveRequest(int requestId)
        {
            var request = await _unitOfWork.Requests.GetRequestById(requestId) ?? throw new Exception("Request not found.");
            if (request.RequestType == "Create")
            {
                var productDetails = new ProductDetails
                {
                    ProductName = request.NewProductName,
                    ProductPrice = (int)request.NewProductPrice,
                    ProductDescription = request.NewProductDescription,
                    PostDate = DateTime.Now,
                    IsActive = true
                };
                await _unitOfWork.Products.AddProduct(productDetails);

            } else if (request.RequestType == "Update") {
                int productId = (int)request.ProductId;
                var productDetails = new ProductDetails
                    {
                        Id = productId,
                        ProductName = request.NewProductName,
                        ProductPrice = (int)request.NewProductPrice,
                        ProductDescription = request.NewProductDescription,
                        PostDate = DateTime.Now,
                        IsActive = true
                    };
                    await _unitOfWork.Products.Update(productDetails);
                }
            else // delete
            {
                int productId = (int)request.ProductId;
                await _unitOfWork.Products.Delete(productId);
            }
            await _unitOfWork.Requests.Delete(requestId);
            await _unitOfWork.SaveAsync();
        }

        public async Task RejectRequest(int requestId)
        {
            var request = await _unitOfWork.Requests.GetRequestById(requestId);
            if (request == null) throw new Exception("Request not found.");

            await _unitOfWork.Requests.Delete(requestId);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteRequest(int requestId)
        {
            await _unitOfWork.Requests.Delete(requestId);
            await _unitOfWork.SaveAsync();
        }
    }
}
