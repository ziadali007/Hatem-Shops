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
    public class OthersProfile : Profile
    {
        public OthersProfile()
        {
            CreateMap<AddOthersResultDto, Others>().ReverseMap();
            CreateMap<Others, OthersResultDto>().ReverseMap();
        }
    }
}
