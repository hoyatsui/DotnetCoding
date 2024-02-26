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
        Task AddRequest(Request request);
        
    }
}
