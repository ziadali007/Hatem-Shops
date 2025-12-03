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
    public class CableProfile : Profile
    {
        public CableProfile()
        {
            CreateMap<Cable, CableResultDto>().ReverseMap().ForMember(S=>S.Id,SO=>SO.MapFrom(Src=>Src.CableId));
            CreateMap<CableResultDto, Cable>().ReverseMap().ForMember(S => S.CableId, SO => SO.MapFrom(Src => Src.Id));

            CreateMap<AddCableResultDto, Cable>().ReverseMap();
        }
    }
}
