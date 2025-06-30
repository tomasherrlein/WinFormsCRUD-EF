using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class AsistenciasInvestigadoresDbContext : DbContext
{
    public AsistenciasInvestigadoresDbContext()
    {
    }

    public AsistenciasInvestigadoresDbContext(DbContextOptions<AsistenciasInvestigadoresDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Investigador> Investigadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LQP2J5V\\SQLEXPRESS;DataBase=AsistenciasInvestigadoresDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.Idasistencia).HasName("PK_Asistencia");

            entity.Property(e => e.Idasistencia).HasColumnName("IDAsistencia");
            entity.Property(e => e.Idinvestigador).HasColumnName("IDInvestigador");

            entity.HasOne(d => d.IdinvestigadorNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.Idinvestigador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asistencia_Investigador");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Iddepartamento).HasName("PK_Departamento");

            entity.Property(e => e.Iddepartamento).HasColumnName("IDDepartamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Investigador>(entity =>
        {
            entity.HasKey(e => e.Idinvestigador);

            entity.ToTable("Investigador");

            entity.Property(e => e.Idinvestigador).HasColumnName("IDInvestigador");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.Iddepartamentos).WithMany(p => p.Idinvestigadors)
                .UsingEntity<Dictionary<string, object>>(
                    "InvestigadoresDepartamento",
                    r => r.HasOne<Departamento>().WithMany()
                        .HasForeignKey("Iddepartamento")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_InvestigadorXDepartamento_Departamento"),
                    l => l.HasOne<Investigador>().WithMany()
                        .HasForeignKey("Idinvestigador")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_InvestigadorXDepartamento_Investigador"),
                    j =>
                    {
                        j.HasKey("Idinvestigador", "Iddepartamento").HasName("PK_InvestigadorXDepartamento");
                        j.ToTable("InvestigadoresDepartamentos");
                        j.IndexerProperty<int>("Idinvestigador").HasColumnName("IDInvestigador");
                        j.IndexerProperty<int>("Iddepartamento").HasColumnName("IDDepartamento");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
