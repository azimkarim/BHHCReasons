using AutoMapper;
using BHHCApp.API.DTOs;
using BHHCApp.Core.Models;

namespace BHHCApp.API.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Reason, ReasonDTO>();
        }
    }
}
