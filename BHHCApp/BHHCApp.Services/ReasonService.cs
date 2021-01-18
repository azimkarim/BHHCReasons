using BHHCApp.Core;
using BHHCApp.Core.Models;
using BHHCApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BHHCApp.Services
{
    public class ReasonService : IReasonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReasonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reason> CreateReason(Reason reason)
        {
            await _unitOfWork.Reasons.AddAsync(reason);
            await _unitOfWork.CommitAsync();

            return reason;
        }

        public async Task<IEnumerable<Reason>> GetAllReasons()
        {
            return await _unitOfWork.Reasons.GetAllReasonsAsync();
        }

        public async Task<Reason> GetReasonById(int id)
        {
            return await _unitOfWork.Reasons.GetReasonByIdAsync(id);
        }

        public async Task UpdateReason(Reason updateReason, Reason reason)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteReason(Reason reason)
        {
            throw new NotImplementedException();
        }
    }
}
