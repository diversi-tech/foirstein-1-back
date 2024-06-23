using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public string Role { get; set; }

    public string ProfilePicture { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
