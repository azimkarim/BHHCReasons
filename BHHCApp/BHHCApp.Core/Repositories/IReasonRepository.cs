using BHHCApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BHHCApp.Core.Repositories
{
    public interface IReasonRepository : IRepository<Reason>
    {
        Task<IEnumerable<Reason>> GetAllReasonsAsync();
        Task<Reason> GetReasonByIdAsync(int id);
    }
}
