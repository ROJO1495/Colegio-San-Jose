using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using ColegioSanJose.Data;
using ColegioSanJose.Models;
using ColegioSanJose.Models.DB;

namespace ColegioSanJose.Controllers
{
    public class ReportesController : Controller
    {
        private readonly ColegioSanJoseContext _context;

        public ReportesController(ColegioSanJoseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> PromediosAlumnos()
        {
            var promedios = await _context.Alumnos
                .Select(a => new
                {
                    Alumno = a,
                    Promedio = a.Expedientes.Any() ?
                        a.Expedientes.Average(e => e.NotaFinal) : 0,
                    CantidadMaterias = a.Expedientes.Count
                })
                .OrderByDescending(p => p.Promedio)
                .ToListAsync();

            ViewBag.Promedios = promedios;
            return View();
        }

        public async Task<IActionResult> GraficasPromedios()
        {
            var promedios = await _context.Alumnos
                .Include(a => a.Expedientes)
                .Select(a => new GraficaPromedioViewModel
                {
                    Alumno = a.NombreCompleto,
                    Promedio = a.Expedientes.Any() ?
                        a.Expedientes.Average(e => e.NotaFinal) : 0,
                    CantidadMaterias = a.Expedientes.Count,
                    Estado = a.Expedientes.Any() && a.Expedientes.Average(e => e.NotaFinal) >= 70 ? "Aprobado" : "Reprobado"
                })
                .OrderByDescending(p => p.Promedio)
                .ToListAsync();

            var aprobados = promedios.Count(p => p.Promedio >= 70);
            var reprobados = promedios.Count(p => p.Promedio < 70);

            ViewBag.Aprobados = aprobados;
            ViewBag.Reprobados = reprobados;
            ViewBag.TotalAlumnos = promedios.Count;

            return View(promedios);
        }
    }
}