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
