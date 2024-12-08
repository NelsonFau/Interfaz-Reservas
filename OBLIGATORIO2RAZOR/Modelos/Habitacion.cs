using System.ComponentModel.DataAnnotations;

namespace OBLIGATORIO2RAZOR.Modelos
{
    public class Habitacion
    {
        [Key]
        public int Numero { get; set; }
        [Required]
        public string TipoHabitacion { get; set; } = string.Empty;
        [Required]
        [Range(1, 6)]
        public int Capacidad { get; set; }
        [Required]
        public decimal Tarifa { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

    }
}
