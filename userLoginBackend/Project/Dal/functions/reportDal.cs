using DAL.Interfaces;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class reportDal: Ireport
    {
        LoginContext _LoginContext;

        public reportDal(LoginContext _LoginContext)
        {
            this._LoginContext = _LoginContext;
        }

        public List<Report> GetAll()
        {
            return _LoginContext.Reports.ToList();
        }

        public Report Add(Report report)
        {
            _LoginContext.Reports.Add(report);
            _LoginContext.SaveChanges();
            return report;
        }

        public bool Update(Report report)
        {
            var existingReport = _LoginContext.Reports.Find(report.ReportId);
            if (existingReport == null)
            {
                return false;
            }
            // עדכני תכונות נוספות לפי הצורך

            _LoginContext.Reports.Update(existingReport);
            _LoginContext.SaveChanges();
            return true;
        }

        public bool Delete(Report report)
        {
            var existingReport = _LoginContext.Reports.Find(report.ReportId);
            if (existingReport == null)
            {
                return false;
            }

            _LoginContext.Reports.Remove(existingReport);
            _LoginContext.SaveChanges();
            return true;
        }
    }
}

