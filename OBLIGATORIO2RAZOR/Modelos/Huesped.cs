using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OBLIGATORIO2RAZOR.Modelos
{
    public class Huesped
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Range(1, int.MaxValue, ErrorMessage = "El ID debe ser un valor mayor que 0.")]
		public int ID { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio.")]
		[StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
		public string Nombre { get; set; } = string.Empty;

		[Required(ErrorMessage = "El documento es obligatorio.")]
		[StringLength(20, ErrorMessage = "El documento no puede tener más de 20 caracteres.")]
		public string Documento { get; set; } = string.Empty;

		[Required(ErrorMessage = "La fecha es obligatoria.")]
		[DataType(DataType.Date)]
		[Range(typeof(DateTime), "01/01/1900", "12/31/2100", ErrorMessage = "La fecha debe estar entre 01/01/1900 y 12/31/2100.")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "El teléfono es obligatorio.")]
		[Range(100000000, 999999999, ErrorMessage = "El teléfono debe tener entre 9 y 9 dígitos.")]
		public int Telefono { get; set; }

		[Required(ErrorMessage = "El país es obligatorio.")]
		[StringLength(50, ErrorMessage = "El país no puede tener más de 50 caracteres.")]
		public string Pais { get; set; } = string.Empty;
	}
}
