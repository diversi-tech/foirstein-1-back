using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class User
{
    //public User()
    //{
    //    ActivityLogs = new HashSet<ActivityLog>();
    //}

    public int UserId { get; set; }

    public string Tz { get; set; }

    public string UserName { get; set; }

    public string Fname { get; set; }

    public string Lname { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public string Role { get; set; }

    public string ProfilePicture { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime UserDob { get; set; }

    public string PhoneNumber { get; set; }

    public string Megama { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<BorrowApprovalRequest> BorrowApprovalRequests { get; set; } = new List<BorrowApprovalRequest>();

    public virtual ICollection<BorrowRequest> BorrowRequests { get; set; } = new List<BorrowRequest>();

    public virtual ICollection<RatingNote> RatingNotes { get; set; } = new List<RatingNote>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<SearchLog> SearchLogs { get; set; } = new List<SearchLog>();
}
