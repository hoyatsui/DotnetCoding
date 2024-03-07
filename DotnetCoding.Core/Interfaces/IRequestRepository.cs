using DotnetCoding.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoding.Core.Interfaces
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<IEnumerable<Request>> GetRequests();
       
        Task AddRequest(Request request);
        Task<Request> GetRequestById(int id);
    }
}
