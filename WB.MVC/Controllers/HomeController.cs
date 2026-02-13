using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WB.Entidades;
using WB.LogicaNegocio;
using WB.MVC.Models;

namespace WB.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly EmpleadoBL _empleadoBL;

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

        public IActionResult Eliminar(int id)
        {
            _empleadoBL.EliminarEmpleado(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult Editar(int id)
        {
            var emp = _empleadoBL.BuscarEmpleado(id);
            return View(emp);
        }

        
        [HttpPost]
        public IActionResult Editar(Empleado emp)
        {
            _empleadoBL.EditarEmpleado(emp);
            return RedirectToAction("Index");
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
