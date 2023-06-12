using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightDocs.Model;

public partial class FlightDocsContext : DbContext
{
    public FlightDocsContext()
    {
    }

    public FlightDocsContext(DbContextOptions<FlightDocsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-STBL12G\\SQLEXPRESS;Initial Catalog=Flight_Docs;User ID=sa;Password=123456;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>(entity =>
        {
            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DocumentName).HasMaxLength(255);
            entity.Property(e => e.FlightId)
                .HasMaxLength(255)
                .HasColumnName("FlightID");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Version).HasMaxLength(255);

            entity.HasOne(d => d.Flight).WithMany(p => p.Documents)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documents_Flights");

            entity.HasOne(d => d.Type).WithMany(p => p.Documents)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documents_DocumentTypes");

            entity.HasOne(d => d.User).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documents_Users");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.TyleName).HasMaxLength(255);
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.Property(e => e.FlightId)
                .HasMaxLength(255)
                .HasColumnName("FlightID");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");
            entity.Property(e => e.FlightFrom).HasMaxLength(255);
            entity.Property(e => e.FlightTo).HasMaxLength(255);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.GroupId);

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permissions_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(10);
            entity.Property(e => e.TokenExpire).HasColumnType("datetime");
            entity.Property(e => e.VeryfiedAt).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
