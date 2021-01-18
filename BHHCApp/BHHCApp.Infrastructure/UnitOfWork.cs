using BHHCApp.Core;
using BHHCApp.Core.Repositories;
using BHHCApp.Infrastructure.Data;
using BHHCApp.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace BHHCApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ReasonRepository _reasonRepository;

        // Unit of work to share single db context when using multiple repositories
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IReasonRepository Reasons
        {
            get
            {
                return _reasonRepository ?? (_reasonRepository = new ReasonRepository(_context));
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
