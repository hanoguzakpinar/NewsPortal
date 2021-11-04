using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NewsPortal.Entities.Concrete;
using NewsPortal.Entities.Dtos;

namespace NewsPortal.Services.AutoMapper.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportAddDto, Report>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ReportUpdateDto, Report>().ForMember(dest => dest.ModifiedDate,
                opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Report, ReportUpdateDto>();
        }
    }
}
