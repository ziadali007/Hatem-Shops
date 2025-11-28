using Apple1_Domain.Models;
using AutoMapper;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Services.Mapping_Profiles
{
    public class CoverProfile : Profile
    {
        public CoverProfile()
        {
            CreateMap<Cover, CoverResultDto>().ReverseMap();
            CreateMap<AddCoverResultDto, Cover>().ReverseMap();
        }
    }
}
