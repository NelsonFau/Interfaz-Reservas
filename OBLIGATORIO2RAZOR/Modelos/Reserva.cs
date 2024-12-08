using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OBLIGATORIO2RAZOR.Modelos
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Habitacion")]
        public int numeroHabitacion { get; set; }
        public Habitacion? Habitacion { get; set; }

        [ForeignKey("Usuario")]
        public int HuespedId { get; set; }
        public Usuario? Usuario { get; set; }

        public DateTime FechaI { get; set; }

        public DateTime FechaF { get; set; }
        public DateTime FechaR { get; set; }


    }
} 
