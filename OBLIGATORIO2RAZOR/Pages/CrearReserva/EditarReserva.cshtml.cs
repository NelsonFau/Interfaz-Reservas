using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO2RAZOR.Datos;
using OBLIGATORIO2RAZOR.Modelos;

namespace OBLIGATORIO2RAZOR.Pages.CrearReserva
{
    public class EditarReservaModel : PageModel
    {
		private readonly AplicationDbContext _contexto;
		[BindProperty]
		public Reserva Reserva { get; set; } 

		public List<Habitacion> Habitaciones { get; set; } 
		public List<Usuario> Usuarios { get; set; }

		public string ErrorMessage { get; set; }

		public EditarReservaModel(AplicationDbContext context)
		{
			_contexto = context;
		}

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Reserva = await _contexto.Reservas
                .FirstOrDefaultAsync(r => r.ID == id); 

            if (Reserva == null)
            {
                return NotFound();  
            }

            Habitaciones = await _contexto.Habitaciones.ToListAsync();
            Usuarios = await _contexto.Usuarios.ToListAsync();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				ErrorMessage = "Hubo un error en el formulario.";
				return Page();
			}

			_contexto.Update(Reserva);
			await _contexto.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
