using PuntoVenta_API.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuraci�n de servicios
// ----------------------------

// Habilitar controladores API (necesario para tus endpoints REST)
builder.Services.AddControllers();

// Configurar CORS para permitir conexiones desde WPF
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Permite cualquier origen (en producci�n deber�as restringirlo)
              .AllowAnyMethod()  // GET, POST, PUT, DELETE, etc.
              .AllowAnyHeader(); // Cabeceras como Content-Type
    });
});


builder.Services.AddRazorPages();
// En Program.cs o Startup.cs, antes de builder.Build()
builder.Services.AddSingleton<List<Producto>>();


var app = builder.Build();

// 2. Configuraci�n del pipeline HTTP
// --------------------------------

// Middleware para manejo de errores
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // P�ginas de error detalladas en desarrollo
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Middleware para redirecci�n HTTPS y archivos est�ticos
app.UseHttpsRedirection();
app.UseStaticFiles();

// Middleware de enrutamiento
app.UseRouting();

// Middleware de autenticaci�n/autorizaci�n
app.UseAuthorization();

// 3. Configuraci�n de endpoints
// ---------------------------

// IMPORTANTE: El orden de estos middlewares es crucial

// 1. Primero CORS
app.UseCors("AllowAll");

// 2. Luego los endpoints
app.MapControllers(); // Para tus controladores API (ProductosController, VentasController)

//  Endpoint de prueba
app.MapGet("/api/test", () => "�API funciona!");


app.MapRazorPages();

app.Run();