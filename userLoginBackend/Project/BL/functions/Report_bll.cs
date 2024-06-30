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
    public class Report_bll:IReport_bll
    {
        Ireport _Ireport;
        static IMapper mapper;
        public Report_bll(Ireport Ireport)
        {
            _Ireport = Ireport;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
        }
    }
}
