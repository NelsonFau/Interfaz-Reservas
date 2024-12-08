using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO2RAZOR.Datos;
using OBLIGATORIO2RAZOR.Modelos;

namespace OBLIGATORIO2RAZOR.Pages.CrearReserva
{
    public class IndexReservasModel : PageModel
    {
		private readonly AplicationDbContext _contexto;
		public IndexReservasModel(AplicationDbContext contexto)
		{
			_contexto = contexto;
		}
		public IEnumerable<Reserva> Reservas { get; set; }
		public async Task OnGet()
		{
			Reservas = await _contexto.Reservas.ToListAsync();
		}
		public async Task<IActionResult> OnPostBorrar(int id)
		{
			var reserva = await _contexto.Reservas.FindAsync(id);
			if (reserva == null)
			{
				return NotFound();
			}
			_contexto.Reservas.Remove(reserva);
			await _contexto.SaveChangesAsync();
			return RedirectToPage();
		}


	}
}
