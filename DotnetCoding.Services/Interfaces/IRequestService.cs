using DotnetCoding.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoding.Services.Interfaces
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> GetAllRequests();
        Task AddToRequestQueue(string newProductname, int newProductPrice, string newProductDescription, string reason, string reqeustType);
        Task AddToRequestQueue(int productId,string newProductname, int newProductPrice, string newProductDescription, string reason, string reqeustType);
        Task AddToRequestQueue(int productId, string reason, string reqeustType);
        Task ApproveRequest(int requestId);
        Task RejectRequest(int requestId);
        Task DeleteRequest(int requestId);
    }
}
