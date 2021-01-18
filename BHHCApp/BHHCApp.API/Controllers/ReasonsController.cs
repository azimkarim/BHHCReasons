using AutoMapper;
using BHHCApp.API.DTOs;
using BHHCApp.Core.Models;
using BHHCApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BHHCApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonsController : ControllerBase
    {
        private readonly IReasonService _reasonService;
        private readonly IMapper _mapper;

        public ReasonsController(IReasonService reasonService, IMapper mapper)
        {
            _mapper = mapper;
            _reasonService = reasonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reason>>> GetAllReasons()
        {
            var reasons = await _reasonService.GetAllReasons();
            var result = _mapper.Map<IEnumerable<Reason>, IEnumerable<ReasonDTO>>(reasons);

            return Ok(result);
        }
    }
}
