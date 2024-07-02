using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using DAL.Interfaces;
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
            Ilog = Ilog;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
        }
    }
}
