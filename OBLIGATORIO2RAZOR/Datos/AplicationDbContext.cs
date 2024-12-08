using Microsoft.EntityFrameworkCore;
using OBLIGATORIO2RAZOR.Modelos;

namespace OBLIGATORIO2RAZOR.Datos
{
	public class AplicationDbContext : DbContext
	{
		public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
			: base(options)
		{

		}
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Reserva> Reservas { get; set; }
		public DbSet<Habitacion> Habitaciones { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Insertar datos de Habitaciones
			modelBuilder.Entity<Habitacion>().HasData(
				new Habitacion { Numero = 101, TipoHabitacion = "Individual", Capacidad = 1, Tarifa = 50 },
				new Habitacion { Numero = 102, TipoHabitacion = "Doble", Capacidad = 2, Tarifa = 75 },
				new Habitacion { Numero = 103, TipoHabitacion = "Triple", Capacidad = 3, Tarifa = 100 },
				new Habitacion { Numero = 104, TipoHabitacion = "Suite", Capacidad = 4, Tarifa = 150 }
			);

			// Insertar datos de Usuarios (Huespedes)
			modelBuilder.Entity<Usuario>().HasData(
				new Usuario { ID = 1, Nombre = "Juan Perez", Telefono = "1234567890", User = "juan@correo.com", Contrasenia = "password" },
				new Usuario { ID = 2, Nombre = "Maria Lopez", Telefono = "1234567890", User = "maria@correo.com", Contrasenia = "password123" },
				new Usuario { ID = 3, Nombre = "Carlos Gomez", Telefono = "1234567890", User = "carlos@correo.com", Contrasenia = "password456" }
			);

			// Configuración de la relación entre Reserva y Habitacion
			modelBuilder.Entity<Reserva>()
				.HasOne(r => r.Habitacion)        // Una Reserva tiene una Habitacion
				.WithMany()                       // Una Habitacion puede tener muchas Reservas
				.HasForeignKey(r => r.numeroHabitacion)   // La clave foránea es el campo numeroHabitacion en Reserva
				.OnDelete(DeleteBehavior.Restrict);  // Comportamiento al eliminar (puedes cambiar esto según tu necesidad)
													 // Configuración de la relación entre Reserva y Usuario
			modelBuilder.Entity<Reserva>()
			.HasOne(r => r.Usuario)
			.WithMany()
			.HasForeignKey(r => r.HuespedId)
			.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
