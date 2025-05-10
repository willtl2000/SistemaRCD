using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DPA.Ticona.API.Models;

public partial class CanchasDeportivasBdContext : DbContext
{
    public CanchasDeportivasBdContext()
    {
    }

    public CanchasDeportivasBdContext(DbContextOptions<CanchasDeportivasBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Canchas> Canchas { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Laptop1;Database=CanchasDeportivasBD;User=sa;Pwd=123456789;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Canchas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Canchas__3214EC07728208A0");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.Ubicacion).HasMaxLength(200);
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservas__3214EC0782FAD864");

            entity.Property(e => e.ClienteNombre).HasMaxLength(100);

            entity.HasOne(d => d.Cancha).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.CanchaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Canchas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
