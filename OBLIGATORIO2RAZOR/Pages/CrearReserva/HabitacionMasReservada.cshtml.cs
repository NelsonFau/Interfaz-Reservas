using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO2RAZOR.Datos;

namespace OBLIGATORIO2RAZOR.Pages.CrearReserva
{
    public class HabitacionMasReservadaModel : PageModel
    {
        private readonly AplicationDbContext _context;

        public HabitacionMasReservadaModel(AplicationDbContext context)
        {
            _context = context;
        }

        public List<HabitacionEstadistica> HabitacionesEstadisticas { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            HabitacionesEstadisticas = await _context.Reservas
                .GroupBy(r => r.numeroHabitacion)
                .Select(g => new HabitacionEstadistica
                {
                    HabitacionId = g.Key,
                    NumeroHabitacion = g.FirstOrDefault().numeroHabitacion, 
                    CantidadReservas = g.Count()
                })
                .OrderByDescending(h => h.CantidadReservas) 
                .ToListAsync();

            return Page();
        }
    }

    public class HabitacionEstadistica
    {
        public int HabitacionId { get; set; }
        public int NumeroHabitacion { get; set; }
        public int CantidadReservas { get; set; }
    }
}
