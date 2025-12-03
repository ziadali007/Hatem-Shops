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
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<AddSaleResultDto, Sale>();
            CreateMap<Sale, SaleResultDto>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Quantity * src.Price))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
            CreateMap<SaleResultDto,Sale>()
               .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Quantity * src.Price))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
               .ReverseMap();
        }
    }
}
