using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NewsPortal.Entities.Dtos;
using NewsPortal.Mvc.Areas.Admin.Models;

namespace NewsPortal.Mvc.AutoMapper.Profiles
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ReportAddViewModel, ReportAddDto>();
            CreateMap<ReportUpdateDto, ReportUpdateViewModel>().ReverseMap();//reversemap ile tersinede map eklenebilir.
        }
    }
}