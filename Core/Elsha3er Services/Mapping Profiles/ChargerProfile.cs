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
    public class ChargerProfile : Profile
    {
        public ChargerProfile()
        {
            CreateMap<Charger, ChargerResultDto>().ReverseMap().ForMember(S => S.Id, SO => SO.MapFrom(Src => Src.ChargerId));
            CreateMap<ChargerResultDto, Charger>().ReverseMap().ForMember(S => S.ChargerId, SO => SO.MapFrom(Src => Src.Id));

            CreateMap<AddChargerResultDto, Charger>().ReverseMap();
        }
    }
}
