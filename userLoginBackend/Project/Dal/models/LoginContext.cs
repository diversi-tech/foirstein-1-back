using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.models;

public partial class LoginContext : DbContext
{
    public LoginContext()
    {
    }

    public LoginContext(DbContextOptions<LoginContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L9S4R74;Database=Login;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Activity__7839F64DB11CC6A9");

            entity.ToTable("Activity_Logs");

            entity.Property(e => e.LogId).HasColumnName("logId");
            entity.Property(e => e.Activity)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("activity");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.ActivityLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Activity___userI__403A8C7D");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reports__1C9B4E2DB70235FA");

            entity.Property(e => e.ReportId).HasColumnName("reportId");
            entity.Property(e => e.GeneratedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("generatedAt");
            entity.Property(e => e.GeneratedBy).HasColumnName("generatedBy");
            entity.Property(e => e.ReportData)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("reportData");
            entity.Property(e => e.ReportName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("reportName");

            entity.HasOne(d => d.GeneratedByNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.GeneratedBy)
                .HasConstraintName("FK__Reports__generat__440B1D61");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFF8DDF7FA4");

            entity.ToTable(tb => tb.HasTrigger("trgUpdateTimestamp"));

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164C826B575").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5727FEB2F2D").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwordHash");
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profilePicture");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updatedAt");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
