using AutoMapper;
using BLL.models_bll;
using DAL.functions;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // המרה בין User ו-User_bll
            CreateMap<User, User_bll>()
                .ReverseMap()
                .ForMember(dest => dest.ActivityLogs, opt => opt.Ignore())
                .ForMember(dest => dest.Reports, opt => opt.Ignore());

            // המרה בין Report ו-Report_bll
            //CreateMap<Report, Report_bll>()
            //    .ForMember(dest => dest.GeneratedBy, opt => opt.MapFrom(src => src.GeneratedByNavigation.UserId))
            //    .ReverseMap()
            //    .ForMember(dest => dest.GeneratedByNavigation, opt => opt.MapFrom(src => new User { UserId = src. }));

            // המרה בין ActivityLog ו-ActivityLog_bll
            CreateMap<ActivityLog, ActivityLog_bll>().ReverseMap();
        }
    }

}
