using BHHCApp.Core.Models;
using BHHCApp.Core.Repositories;
using BHHCApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHHCApp.Infrastructure.Repositories
{
    public class ReasonRepository : Repository<Reason>, IReasonRepository
    {
        private readonly AppDbContext _dbContext;
        public ReasonRepository(AppDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Reason>> GetAllReasonsAsync()
        {
           return await _dbContext.Reasons.ToListAsync();
        }

        public async Task<Reason> GetReasonByIdAsync(int id)
        {
            return await _dbContext.Reasons.SingleOrDefaultAsync(x => x.id == id);
        }
    }
}
