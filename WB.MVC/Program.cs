using WB.AccesoDatos;
using WB.LogicaNegocio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// 1. Leemos la cadena "CadenaSQL" de tu appsettings.json
string cadenaConexion = builder.Configuration.GetConnectionString("CadenaSQL");

// 2. Registramos DB_Acceso como un "Singleton" (Una sola llave para toda la app)
builder.Services.AddSingleton(new DB_Acceso(cadenaConexion));

// 3. Registramos el Gerente (EmpleadoBL) para que la Web pueda usarlo
builder.Services.AddScoped<EmpleadoBL>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
