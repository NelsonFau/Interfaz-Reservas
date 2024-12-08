using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OBLIGATORIO2RAZOR.Modelos
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(12)]
        public string Telefono { get; set; } = string.Empty;
        [Required]
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
		ErrorMessage = "El formato del correo electrónico no es válido")]
		[Column("Correo Electronico")]
		[Display(Name = "Correo Electronico")]
		public string User { get; set; } = string.Empty;
        [Required]
		[Display(Name = "Contraseña")]  
		public string Contrasenia { get; set; } = string.Empty;

        public List<Reserva> Reservas { get; set; } = new List<Reserva>(); 
    }
}
