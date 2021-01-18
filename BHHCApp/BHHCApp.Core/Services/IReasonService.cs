using BHHCApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BHHCApp.Core.Services
{
    // services interfaces
    public interface IReasonService
    {
        Task<IEnumerable<Reason>> GetAllReasons();
        Task<Reason> GetReasonById(int id);
        Task<Reason> CreateReason(Reason reason);
        Task UpdateReason(Reason updateReason, Reason reason);
        Task DeleteReason(Reason reason);
    }
}
