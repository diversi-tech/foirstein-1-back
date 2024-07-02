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

        Ilog _Ilog;
        Ireport _Ireport;
        static IMapper mapper;
        public ActivityLog_bll(Ilog Ilog, Ireport Ireport)
        {
            _Ireport = Ireport;
            _Ilog = Ilog;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
        }

        public List<ActivityLog_modelBll> getall()
        {

            List<ActivityLog> activityLogs = _Ilog.GetAll();
            return mapper.Map<List<ActivityLog_modelBll>>(activityLogs);
        }


        //public List<UserActivityCount> GetActivityLogs(string reportName)
        //{
        //    try
        //    {
        //        var oneMonthAgo = DateTime.Now.AddMonths(-1);
        //        var logs = _Ilog.GetAll();

        //        Console.WriteLine("Total logs: " + logs.Count);

        //        var filteredLogs = logs.Where(log => log.Timestamp >= oneMonthAgo).ToList();

        //        Console.WriteLine("Logs in the last month: " + filteredLogs.Count);

        //        var groupedLogs = filteredLogs
        //            .Where(log => !string.IsNullOrEmpty(log.UserId))
        //            .GroupBy(log => log.UserId)
        //            .ToList();

        //        Console.WriteLine("Grouped logs count: " + groupedLogs.Count);

        //        var result = groupedLogs
        //            .Select(group => new UserActivityCount
        //            {
        //                UserId = group.Key,
        //                ActivityCount = group.Count()
        //            })
        //            .OrderByDescending(x => x.ActivityCount)
        //            .ToList();

        //        Console.WriteLine("Result count: " + result.Count);

        //        // יצירת רשומת דו"ח חדשה
        //        var newReport = new Report
        //        {
        //            ReportName = reportName,
        //            // המרת התוצאה ל-XML או כל פורמט טקסט אחר
        //            ReportData = ConvertToCustomFormat(result),
        //            GeneratedAt = DateTime.Now
        //        };

        //        _Ireport.Add(newReport);

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //        throw;
        //    }
        //}

        //private string ConvertToCustomFormat(List<UserActivityCount> result)
        //{
        //    // כאן אפשר להמיר את הרשימה לפורמט טקסטואלי לפי הצורך שלך
        //    // לדוגמה, אפשר להשתמש ב-StringBuilder כדי ליצור פורמט מותאם אישית
        //    var sb = new System.Text.StringBuilder();
        //    foreach (var item in result)
        //    {
        //        sb.AppendLine($"UserId: {item.UserId}, ActivityCount: {item.ActivityCount}");
        //    }
        //    return sb.ToString();
        //}
    }
}
    
