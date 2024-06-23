using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.functions
{
    public class logDal : Ilog
    {
        LoginContext _LoginContext;

        public logDal(LoginContext _LoginContext)
        {
            this._LoginContext = _LoginContext;
        }
        public ActivityLog Add(ActivityLog log)
        {
            try
            {
                _LoginContext.ActivityLogs.Add(log);
                _LoginContext.SaveChanges();
                //החזרת הקוד האוטומטי שנוסף
                return log;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(ActivityLog log)
        {
            try
            {
                _LoginContext.Remove(log);
                _LoginContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ActivityLog> GetAll()
        {
            return _LoginContext.ActivityLogs.ToList();
        }


        bool Ilog.Update(ActivityLog log)
        {
            try
            {
                _LoginContext.ActivityLogs.Update(log);
                _LoginContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
