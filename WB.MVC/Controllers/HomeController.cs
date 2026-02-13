using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WB.Entidades;
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

       
        public IActionResult Index()
        {            
            var listaEmpleados = _empleadoBL.ObtenerEmpleados();           
            return View(listaEmpleados);
        }
        
        public IActionResult Crear()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult Crear(Empleado emp)
        {
            if (ModelState.IsValid)
            {
                _empleadoBL.CrearEmpleado(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
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
