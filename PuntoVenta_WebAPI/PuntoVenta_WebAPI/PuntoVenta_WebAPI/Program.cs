var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de controladores
builder.Services.AddControllers();

// Agregar CORS para permitir acceso desde la app WPF
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Usar CORS
app.UseCors("PermitirTodo");

// Middleware de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Seguridad
app.UseHttpsRedirection();

app.UseAuthorization();

// Usar controladores
app.MapControllers();

app.Run();
