using DotnetCoding.Core.Interfaces;
using DotnetCoding.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoding.Infrastructure.Repositories
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(DbContextClass context) : base(context)
        {
        }

        public async Task AddRequest(Request request)
        {
            if(request == null)
            {
                throw new ArgumentException("reqeust cannot be null.");
            }
           await _dbContext.Requests.AddAsync(request);
        
        }
    }
}
