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
    public class HeadPhoneService : Profile
    {
        public HeadPhoneService()
        {
            CreateMap<HeadPhone, HeadPhoneResultDto>().ReverseMap().ForMember(S => S.Id, SO => SO.MapFrom(Src => Src.HeadPhoneId));
            CreateMap<HeadPhoneResultDto, HeadPhone>().ReverseMap().ForMember(S => S.HeadPhoneId, SO => SO.MapFrom(Src => Src.Id));

            CreateMap<AddHeadPhoneResultDto, HeadPhone>().ReverseMap();
        }
    }
}
