using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functions
{
    public class ActivityLog_bll:IActivityLog_bll
    {

        Ilog Ilog;
        static IMapper mapper;
        public ActivityLog_bll(Ilog Ilog)
        {
            this.Ilog = Ilog;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
        }

        public List<ActivityLog_modelBll> getall()
        {
            List<ActivityLog> logs= Ilog.GetAll();
            return mapper.Map<List<ActivityLog_modelBll>>(logs);

        }
    }



}
