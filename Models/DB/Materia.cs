using System;
using System.Collections.Generic;

namespace Colegio_San_Jose.Models.DB;

public partial class Materia
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public int Creditos { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
