using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainingUserLibrary.Models;

public partial class TrainingUserDBContext : DbContext
{
    public TrainingUserDBContext()
    {
    }

    public TrainingUserDBContext(DbContextOptions<TrainingUserDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TrainingUser> TrainingUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB; database=TrainingUserDB; integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrainingUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Training__1788CC4CF678DA4C");

            entity.ToTable("TrainingUser");

            entity.Property(e => e.UserId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserRole)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
