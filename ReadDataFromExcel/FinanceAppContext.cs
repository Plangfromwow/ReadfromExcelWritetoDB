using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReadDataFromExcel;

public partial class FinanceAppContext : DbContext
{
    public FinanceAppContext()
    {
    }

    public FinanceAppContext(DbContextOptions<FinanceAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FinanceInfo> FinanceInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8IQ7I56;Initial Catalog=FinanceApp; TrustServerCertificate=True; Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FinanceInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FinanceI__3213E83FE6DA66A3");

            entity.ToTable("FinanceInfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.Category)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Memo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("memo");
            entity.Property(e => e.PostDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("postDate");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
