using System;
using System.Collections.Generic;

namespace Colegio_San_Jose.Models.DB;

public partial class Expediente
{
    public int Id { get; set; }

    public int AlumnoId { get; set; }

    public int MateriaId { get; set; }

    public decimal NotaFinal { get; set; }

    public string? Observaciones { get; set; }

    public DateOnly FechaInscripcion { get; set; }

    public virtual Alumno Alumno { get; set; } = null!;

    public virtual Materia Materia { get; set; } = null!;
}
