using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WB.Entidades;
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


        // POST: api/Empleado
        [HttpPost]
        public IActionResult Crear([FromBody] Empleado nuevoEmpleado)
        {
            try
            {
                
                if (nuevoEmpleado == null)
                {
                    return BadRequest(new { mensaje = "Los datos del empleado son nulos." });
                }

                if (string.IsNullOrEmpty(nuevoEmpleado.Nombres) || string.IsNullOrEmpty(nuevoEmpleado.Email))
                {
                    return BadRequest(new { mensaje = "El Nombre y el Email son campos obligatorios." });
                }
                
                _empleadoBL.CrearEmpleado(nuevoEmpleado);
                
                return StatusCode(201, new { mensaje = "Empleado creado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al intentar guardar", detalle = ex.Message });
            }
        }



    }
}
