using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WB.LogicaNegocio;
using WB.MVC.Models;

namespace WB.MVC.Controllers
{
    public class HomeController : Controller
    {
        // 2. Campo privado para almacenar la referencia de la capa de negocio
        private readonly EmpleadoBL _empleadoBL;

        // 3. Constructor: Recibe la instancia por Inyección de Dependencias
        // .NET lee el Program.cs y sabe que debe entregar un objeto EmpleadoBL aquí.
        public HomeController(EmpleadoBL empleadoBL)
        {
            _empleadoBL = empleadoBL;
        }

        // 4. Acción que se ejecuta al entrar a la página principal
        public IActionResult Index()
        {
            // Ejecutamos el método que viaja hasta SQL y trae la lista
            var listaEmpleados = _empleadoBL.ObtenerEmpleados();

            // Pasamos la lista de objetos a la Vista para que los muestre
            return View(listaEmpleados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
