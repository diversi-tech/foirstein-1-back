﻿using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Report
{
    public int ReportId { get; set; }

    public string ReportName { get; set; }

    public string ReportData { get; set; }

    public int? GeneratedBy { get; set; }

    public DateTime? GeneratedAt { get; set; }

    public virtual User GeneratedByNavigation { get; set; }
}
