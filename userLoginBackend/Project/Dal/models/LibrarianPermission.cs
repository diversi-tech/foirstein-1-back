using System;
using System.Collections.Generic;

namespace DAL.models;
public enum itemtype_enum
{
    Book,
    File,
    Physical
}
public partial class LibrarianPermission
{
    public int? UserId { get; set; }
    public itemtype_enum[] permissions;

    public virtual User User { get; set; }
}
