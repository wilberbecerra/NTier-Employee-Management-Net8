using WB.AccesoDatos;
using WB.LogicaNegocio;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

string cadenaConexion = builder.Configuration.GetConnectionString("CadenaSQL");
builder.Services.AddSingleton(new DB_Acceso(cadenaConexion));
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
