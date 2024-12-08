using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO2RAZOR.Datos;
using OBLIGATORIO2RAZOR.Modelos;

namespace OBLIGATORIO2RAZOR.Pages.CrearReserva
{
    public class CrearReservaModel : PageModel
    {
        private readonly AplicationDbContext _context;

        public CrearReservaModel(AplicationDbContext context)
        {
            _context = context;
        }

        public List<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        [BindProperty]
        public Reserva NuevaReserva { get; set; } 
        public string ErrorMessage { get; set; }  

        public void OnGet()
        {
            Habitaciones = _context.Habitaciones.ToList(); 
            Usuarios = _context.Usuarios.ToList();

                Console.WriteLine($"Número de habitaciones: {Habitaciones.Count()}");

        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            Habitaciones = _context.Habitaciones.ToList();
            Usuarios = _context.Usuarios.ToList();
            if (NuevaReserva.FechaI < DateTime.Now.Date)
            {
                ModelState.AddModelError("FechaI", "La fecha de inicio no puede ser anterior a la fecha actual.");
            }

            if (NuevaReserva.FechaF <= NuevaReserva.FechaI)
            {
                ModelState.AddModelError("FechaF", "La fecha de fin debe ser posterior a la fecha de inicio.");
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine($"Número de Habitación: {NuevaReserva.numeroHabitacion}");
                Console.WriteLine($"Huésped: {NuevaReserva.HuespedId}");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }

            var habitacionReservada = await _context.Reservas
                .Where(r => r.numeroHabitacion == NuevaReserva.numeroHabitacion &&
                            ((r.FechaI <= NuevaReserva.FechaF && r.FechaF >= NuevaReserva.FechaI) ||
                             (r.FechaI >= NuevaReserva.FechaI && r.FechaI <= NuevaReserva.FechaF)))
                .AnyAsync();

            if (habitacionReservada)
            {
                ErrorMessage = "La habitación ya está reservada en el rango de fechas seleccionado.";
                return Page();
            }

            var habitacionSeleccionada = await _context.Habitaciones
            .FirstOrDefaultAsync(h => h.Numero == NuevaReserva.numeroHabitacion);

            if (habitacionSeleccionada == null)
            {
                ModelState.AddModelError("Numero", "La habitación seleccionada no existe.");
                return Page();
            }

            NuevaReserva.FechaR = DateTime.Now;

            _context.Reservas.Add(NuevaReserva);
            await _context.SaveChangesAsync();

            return RedirectToPage("IndexReservas");

        }
    }
}