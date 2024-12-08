using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO2RAZOR.Datos;
using OBLIGATORIO2RAZOR.Modelos;
using OBLIGATORIO2RAZOR.Pages.LoginUsuario;

namespace OBLIGATORIO2RAZOR.Pages.InicioSesionUser
{
    public class InicioSesionModel : PageModel
    {
        private readonly AplicationDbContext _context;
        public InicioSesionModel(AplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public LoginViewModel Login { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
          
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.User == Login.Username);

            if (usuario == null)
            {
                ErrorMessage = "Usuario no encontrado.";
                return Page(); 
            }


            if (usuario.Contrasenia == Login.Password)
            {
                return RedirectToPage("/CrearReserva/CrearReserva");
            }
            else
            {
                ErrorMessage = "Contraseña incorrecta.";
                return Page();
            }
        }
    }

    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}