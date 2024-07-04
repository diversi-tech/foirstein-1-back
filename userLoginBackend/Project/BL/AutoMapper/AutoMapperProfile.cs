﻿using AutoMapper;
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
            CreateMap<User, User_modelBll>()
                .ReverseMap()
                .ForMember(dest => dest.ActivityLogs, opt => opt.Ignore())
                .ForMember(dest => dest.SearchLogs, opt => opt.Ignore())
                .ForMember(dest => dest.Reports, opt => opt.Ignore())
                .ForMember(dest => dest.RatingNotes, opt => opt.Ignore())
                .ForMember(dest => dest.BorrowRequests, opt => opt.Ignore())
                .ForMember(dest => dest.BorrowApprovalRequests, opt => opt.Ignore());


            // המרה בין Report ו-Report_bll
            CreateMap<Report, Report_modelBll>()
                .ForMember(dest => dest.GeneratedByNavigationUserId, opt => opt.MapFrom(src => src.GeneratedByNavigationUser.UserId));
                //.ReverseMap()
               

            // המרה בין ActivityLog ו-ActivityLog_bll
            CreateMap<ActivityLog, ActivityLog_modelBll>()
             .ForMember(dest => dest.UserId1, opt => opt.MapFrom(src => src.UserId1Navigation.UserId))
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId1Navigation.Tz))
             .ReverseMap();
            // המרה בין BorrowApprovalRequest ו-ApprovalRequestBll
            CreateMap<BorrowApprovalRequest, ApprovalRequestBll>().ReverseMap()
            .ForMember(dest => dest.User , opt => opt.Ignore());

            // המרה בין Item ו-Item_bll
            CreateMap<Item, Item_bll>().ReverseMap();
            //.ForMember(dest => dest.BorrowRequests, opt => opt.Ignore())
            //.ForMember(dest => dest.ItemTags, opt => opt.Ignore())
            //.ForMember(dest => dest.RatingNotes, opt => opt.Ignore());

            // המרה בין RatingNote ו-RatingNote_bll
            CreateMap<RatingNote, RatingNote_bll>().ReverseMap()
          .ForMember(dest => dest.User, opt => opt.Ignore())
          .ForMember(dest => dest.Item, opt => opt.Ignore());

        }
    }

}
