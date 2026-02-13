using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WB.LogicaNegocio;

namespace WB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase 
    {
        private readonly EmpleadoBL _empleadoBL;
       
        public EmpleadoController(EmpleadoBL empleadoBL)
        {
            _empleadoBL = empleadoBL;
        }

        
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {                
                var listaEmpleados = _empleadoBL.ObtenerEmpleados();                
                return Ok(listaEmpleados);
            }
            catch (Exception ex)
            {                
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }
    }
}
