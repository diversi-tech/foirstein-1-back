using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.models;

public partial class LiberiansDbContext : DbContext
{
    public LiberiansDbContext()
    {
    }

    public LiberiansDbContext(DbContextOptions<LiberiansDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<BorrowApprovalRequest> BorrowApprovalRequests { get; set; }

    public virtual DbSet<BorrowRequest> BorrowRequests { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemTag> ItemTags { get; set; }

    public virtual DbSet<RatingNote> RatingNotes { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<SearchLog> SearchLogs { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=liberiansDB;user id=sa; password=Foir100#;TrustServerCertificate=True;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("Activity_Logs");

            entity.Property(e => e.Activity).IsRequired();

            entity.HasOne(d => d.UserId1Navigation).WithMany(p => p.ActivityLogs).HasForeignKey(d => d.UserId1);
        });

        modelBuilder.Entity<BorrowApprovalRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("Borrow_Approval_Requests");

            entity.HasOne(d => d.User).WithMany(p => p.BorrowApprovalRequests).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BorrowRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("Borrow_Requests");

            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Item).WithMany(p => p.BorrowRequests).HasForeignKey(d => d.ItemId);

            entity.HasOne(d => d.User).WithMany(p => p.BorrowRequests).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.Author).IsRequired();
            entity.Property(e => e.Category).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.FilePath).IsRequired();
            entity.Property(e => e.Title).IsRequired();
        });

        modelBuilder.Entity<ItemTag>(entity =>
        {
            entity.ToTable("ItemTag");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemTags).HasForeignKey(d => d.ItemId);

            entity.HasOne(d => d.Tag).WithMany(p => p.ItemTags).HasForeignKey(d => d.TagId);
        });

        modelBuilder.Entity<RatingNote>(entity =>
        {
            entity.ToTable("Rating_Notes");

            entity.HasOne(d => d.Item).WithMany(p => p.RatingNotes).HasForeignKey(d => d.ItemId);

            entity.HasOne(d => d.User).WithMany(p => p.RatingNotes).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.Property(e => e.ReportData).IsRequired();
            entity.Property(e => e.ReportName).IsRequired();

            entity.HasOne(d => d.GeneratedByNavigationUser).WithMany(p => p.Reports).HasForeignKey(d => d.GeneratedByNavigationUserId);
        });

        modelBuilder.Entity<SearchLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("Search_Logs");

            entity.Property(e => e.SearchQuery).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.SearchLogs).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Fname).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.PhoneNumber).IsRequired();
            entity.Property(e => e.Role).IsRequired();
            entity.Property(e => e.Tz)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnName("tz");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
