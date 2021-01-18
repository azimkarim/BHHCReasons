using BHHCApp.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace BHHCApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IReasonRepository Reasons { get; }
        Task<int> CommitAsync();
    }
}
