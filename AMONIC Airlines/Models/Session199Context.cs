using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AMONIC_Airlines.Models;

public partial class Session199Context : DbContext
{
    public Session199Context()
    {
    }

    public Session199Context(DbContextOptions<Session199Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CrashLog> CrashLogs { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=desktop-vl5556l\\sqlexpress;Initial Catalog=Session1_99;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Country");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CrashLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CrashLog");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Error).HasMaxLength(50);
            entity.Property(e => e.Login).HasColumnType("datetime");
            entity.Property(e => e.Logout).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.CrashLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_CrashLogs");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Office");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contact).HasMaxLength(250);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Offices)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Office_Country");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserRole");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.OfficeId).HasColumnName("OfficeID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Office).WithMany(p => p.Users)
                .HasForeignKey(d => d.OfficeId)
                .HasConstraintName("FK_Users_Offices");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
