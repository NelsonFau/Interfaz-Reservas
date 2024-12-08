using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO2RAZOR.Datos;

namespace OBLIGATORIO2RAZOR.Pages.CrearReserva
{
    public class EstadisticasHuespedModel : PageModel
    {
        private readonly AplicationDbContext _context;

        public EstadisticasHuespedModel(AplicationDbContext context)
        {
            _context = context;
        }

        public List<UsuarioEstadistica> UsuariosEstadisticas { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            UsuariosEstadisticas = await _context.Reservas
                .GroupBy(r => new { r.HuespedId, r.numeroHabitacion })
                .Select(g => new UsuarioEstadistica
                {
                    HuespedId = g.Key.HuespedId,
                    NumeroHabitacion = g.Key.numeroHabitacion,
                    CantidadReservas = g.Count()
                })
                .OrderByDescending(h => h.CantidadReservas) 
                .ToListAsync();

            return Page();
        }
    }

    public class UsuarioEstadistica
    {
        public int HuespedId { get; set; }
        public int NumeroHabitacion { get; set; }
        public int CantidadReservas { get; set; }
        public string? NombreUsuario { get; set; }  
    }
}

