using DotnetCoding.Core.Interfaces;
using DotnetCoding.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoding.Infrastructure.Repositories
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(DbContextClass _dbContext) : base(_dbContext)
        {
        }

        public async Task AddRequest(Request request)
        {
            if(request == null)
            {
                throw new ArgumentException("reqeust cannot be null.");
            }
           await _dbContext.Requests.AddAsync(request);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Request>> GetRequests()
        {
            return await _dbContext.Requests.OrderBy(r => r.RequestDate).ToListAsync();
        }

        public async Task<Request> GetRequestById(int id)
        {
            return await _dbContext.Requests.FirstOrDefaultAsync(r=>r.Id ==id);
        }
    }
}
