using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Ireport
    {
        List<Report> GetAll();
        Report Add(Report report);
        Report Update(Report report, string id);
        int Delete(Report report);
    }
}
