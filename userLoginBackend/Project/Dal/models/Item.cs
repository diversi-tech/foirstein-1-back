using System;
using System.Collections.Generic;

namespace DAL.models;

public partial class Item
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public string FilePath { get; set; }

    public bool IsApproved { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int PublishingYear { get; set; }

    public virtual ICollection<BorrowRequest> BorrowRequests { get; set; } = new List<BorrowRequest>();

    public virtual ICollection<ItemTag> ItemTags { get; set; } = new List<ItemTag>();

    public virtual ICollection<RatingNote> RatingNotes { get; set; } = new List<RatingNote>();
}
