using AutoMapper;
using Elsha3er_Domain.Models;
using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Services.Mapping_Profiles
{
    public class ScreenProfile : Profile
    {
        public ScreenProfile()
        {
            CreateMap<Screen,ScreenResultDto>().ReverseMap().ForMember(S => S.Id, SO => SO.MapFrom(Src => Src.ScreenId));
            CreateMap<ScreenResultDto,Screen>().ReverseMap().ForMember(S => S.ScreenId, SO => SO.MapFrom(Src => Src.Id));

            CreateMap<AddScreenResultDto, Screen>().ReverseMap();
        }
    }
}
