using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OBLIGATORIO2RAZOR.Datos;
using OBLIGATORIO2RAZOR.Modelos;

namespace OBLIGATORIO2RAZOR.Pages.LoginUsuario
{
	public class LoginUsuarioModel : PageModel
	{
		private readonly AplicationDbContext _context;

		public LoginUsuarioModel(AplicationDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Usuario Usuario { get; set; }

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
                Console.WriteLine("Errores de validación:");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                {
					return Page();
				}
			}
            try
            {
                _context.Usuarios.Add(Usuario);
                await _context.SaveChangesAsync();

                Console.WriteLine($"Usuario creado con ID: {Usuario.ID}");

                if (Usuario.ID == 0)
                {
                    Console.WriteLine("Error: El ID del usuario no fue asignado correctamente.");
                    return Page(); 
                }

                return RedirectToPage("/CrearReserva/CrearReserva");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Page(); 
            }

        }
	}
}
