using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO2RAZOR.Datos;
using OBLIGATORIO2RAZOR.Modelos;

var builder = WebApplication.CreateBuilder(args);

//Configurar conexion
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    // Aqu�, obtenemos la cadena de conexi�n desde la configuraci�n de la aplicaci�n.

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});




// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
