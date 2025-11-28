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
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<AddSaleResultDto, Sale>();
            CreateMap<Sale, SaleResultDto>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Quantity * src.Price));
        }
    }
}
