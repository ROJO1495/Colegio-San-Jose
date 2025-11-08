using System.ComponentModel.DataAnnotations;

namespace ColegioSanJose.Models
{
    public class Expediente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El alumno es obligatorio")]
        public int AlumnoId { get; set; }

        [Required(ErrorMessage = "La materia es obligatoria")]
        public int MateriaId { get; set; }

        [Required(ErrorMessage = "La nota final es obligatoria")]
        [Range(0, 100, ErrorMessage = "La nota debe estar entre 0 y 100")]
        public decimal NotaFinal { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        public string? Observaciones { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;

        // Propiedades de navegación
        public Alumno? Alumno { get; set; }
        public Materia? Materia { get; set; }
    }
}