namespace ColegioSanJose.Models
{
    public class GraficaPromedioViewModel
    {
        public string Alumno { get; set; } = string.Empty;
        public decimal Promedio { get; set; }
        public int CantidadMaterias { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}