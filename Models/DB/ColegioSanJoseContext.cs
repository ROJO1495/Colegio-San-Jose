using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ColegioSanJose.Models;

namespace ColegioSanJose.Models.DB;

public partial class ColegioSanJoseContext : DbContext
{
    public ColegioSanJoseContext()
    {
    }

    public ColegioSanJoseContext(DbContextOptions<ColegioSanJoseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }
    public virtual DbSet<Expediente> Expedientes { get; set; }
    public virtual DbSet<Materia> Materias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumnos__3214EC07A560DDDF");

            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Expedien__3214EC0777FEFBDB");

            entity.Property(e => e.FechaInscripcion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NotaFinal).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Observaciones).HasMaxLength(500);

            entity.HasOne(d => d.Alumno).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.AlumnoId)
                .OnDelete(DeleteBehavior.Cascade)  // Cambiado de ClientSetNull a Cascade
                .HasConstraintName("FK_Expedientes_Alumnos");

            entity.HasOne(d => d.Materia).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.Cascade)  // Cambiado de ClientSetNull a Cascade
                .HasConstraintName("FK_Expedientes_Materias");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materias__3214EC07B5F51A06");

            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
        });

        // ===== TUS DATOS INICIALES =====
        modelBuilder.Entity<Alumno>().HasData(
            new Alumno { Id = 1, Nombre = "Nicole", Apellido = "Serrano", FechaNacimiento = new DateTime(2012, 4, 27), Email = "nicole.serrano@colegio.edu", Telefono = "1234-5678" },
            new Alumno { Id = 2, Nombre = "Claudia", Apellido = "Rivera", FechaNacimiento = new DateTime(1987, 3, 23), Email = "claudia.rivera@colegio.edu", Telefono = "2345-6789" },
            new Alumno { Id = 3, Nombre = "Amilcar", Apellido = "Torres", FechaNacimiento = new DateTime(1985, 3, 30), Email = "amilcar.torres@colegio.edu", Telefono = "3456-7890" }
        );

        modelBuilder.Entity<Materia>().HasData(
            new Materia { Id = 1, Nombre = "Matematicas", Codigo = "MAT101", Creditos = 4, Descripcion = "Algebra y calculo basico" },
            new Materia { Id = 2, Nombre = "Ciencias Naturales", Codigo = "CNT201", Creditos = 3, Descripcion = "Biologia, fisica y quimica" },
            new Materia { Id = 3, Nombre = "Historia", Codigo = "HIS301", Creditos = 2, Descripcion = "Historia universal y nacional" },
            new Materia { Id = 4, Nombre = "Literatura", Codigo = "LIT401", Creditos = 3, Descripcion = "Analisis literario y redaccion" }
        );

        modelBuilder.Entity<Expediente>().HasData(
            new Expediente { Id = 1, AlumnoId = 1, MateriaId = 1, NotaFinal = 85.5m, Observaciones = "Buen desempeño en examenes", FechaInscripcion = new DateTime(2024, 1, 15) },
            new Expediente { Id = 2, AlumnoId = 1, MateriaId = 2, NotaFinal = 90.0m, Observaciones = "Excelente participacion", FechaInscripcion = new DateTime(2024, 1, 15) },
            new Expediente { Id = 3, AlumnoId = 2, MateriaId = 1, NotaFinal = 78.0m, Observaciones = "Necesita mejorar en tareas", FechaInscripcion = new DateTime(2024, 1, 16) },
            new Expediente { Id = 4, AlumnoId = 3, MateriaId = 3, NotaFinal = 92.5m, Observaciones = "Destacado en debates", FechaInscripcion = new DateTime(2024, 1, 17) }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}