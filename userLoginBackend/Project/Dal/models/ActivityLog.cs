using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class ActivityLog
{
    public int LogId { get; set; }

    public string UserId { get; set; }

    public string Activity { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual User User { get; set; }
}
