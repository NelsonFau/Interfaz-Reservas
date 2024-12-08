﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OBLIGATORIO2RAZOR.Datos;

#nullable disable

namespace OBLIGATORIO2RAZOR.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OBLIGATORIO2RAZOR.Modelos.Habitacion", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"), 1L, 1);

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Tarifa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoHabitacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Numero");

                    b.ToTable("Habitaciones");

                    b.HasData(
                        new
                        {
                            Numero = 101,
                            Capacidad = 1,
                            Tarifa = 50m,
                            TipoHabitacion = "Individual"
                        },
                        new
                        {
                            Numero = 102,
                            Capacidad = 2,
                            Tarifa = 75m,
                            TipoHabitacion = "Doble"
                        },
                        new
                        {
                            Numero = 103,
                            Capacidad = 3,
                            Tarifa = 100m,
                            TipoHabitacion = "Triple"
                        },
                        new
                        {
                            Numero = 104,
                            Capacidad = 4,
                            Tarifa = 150m,
                            TipoHabitacion = "Suite"
                        });
                });

            modelBuilder.Entity("OBLIGATORIO2RAZOR.Modelos.Reserva", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("FechaF")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaI")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaR")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HabitacionNumero")
                        .HasColumnType("int");

                    b.Property<int>("HuespedId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioID")
                        .HasColumnType("int");

                    b.Property<int>("numeroHabitacion")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HabitacionNumero");

                    b.HasIndex("HuespedId");

                    b.HasIndex("UsuarioID");

                    b.HasIndex("numeroHabitacion");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("OBLIGATORIO2RAZOR.Modelos.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Correo Electronico");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Contrasenia = "password",
                            Nombre = "Juan Perez",
                            Telefono = "1234567890",
                            User = "juan@correo.com"
                        },
                        new
                        {
                            ID = 2,
                            Contrasenia = "password123",
                            Nombre = "Maria Lopez",
                            Telefono = "1234567890",
                            User = "maria@correo.com"
                        },
                        new
                        {
                            ID = 3,
                            Contrasenia = "password456",
                            Nombre = "Carlos Gomez",
                            Telefono = "1234567890",
                            User = "carlos@correo.com"
                        });
                });

            modelBuilder.Entity("OBLIGATORIO2RAZOR.Modelos.Reserva", b =>
                {
                    b.HasOne("OBLIGATORIO2RAZOR.Modelos.Habitacion", null)
                        .WithMany("Reservas")
                        .HasForeignKey("HabitacionNumero");

                    b.HasOne("OBLIGATORIO2RAZOR.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("HuespedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBLIGATORIO2RAZOR.Modelos.Usuario", null)
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioID");

                    b.HasOne("OBLIGATORIO2RAZOR.Modelos.Habitacion", "Habitacion")
                        .WithMany()
                        .HasForeignKey("numeroHabitacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Habitacion");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("OBLIGATORIO2RAZOR.Modelos.Habitacion", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("OBLIGATORIO2RAZOR.Modelos.Usuario", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
