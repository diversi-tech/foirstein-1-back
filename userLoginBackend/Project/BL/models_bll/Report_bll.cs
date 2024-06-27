using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.models_bll
{
    public class Report_bll
    {
        public int ReportId { get; set; }

        public string ReportName { get; set; }

        public string ReportData { get; set; }

        public int? GeneratedBy { get; set; }

        public DateTime? GeneratedAt { get; set; }

    }
}
