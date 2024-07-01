using System;
using System.Collections.Generic;

namespace userLoginBackend.models;

public partial class BorrowApprovalRequest
{
    public int RequestId { get; set; }

    public int ItemId { get; set; }

    public int UserId { get; set; }

    public int RequestStatus { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public virtual User User { get; set; }
}
