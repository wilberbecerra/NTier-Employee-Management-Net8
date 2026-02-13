using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.Entidades;
using WB.AccesoDatos;

namespace WB.LogicaNegocio
{
    public class EmpleadoBL
    {
        
        private readonly DB_Acceso _db;

        public EmpleadoBL(DB_Acceso db)
        {
            _db = db;
        }

        public List<Empleado> ObtenerEmpleados()
        {
            var dal = new EmpleadoDAL(_db);

            return dal.ObtenerTodos();
        }

        public void CrearEmpleado(Empleado emp)
        {
            if (emp.Sueldo <= 0) throw new Exception("El sueldo debe ser mayor a cero");
            if (!emp.Email.Contains("@")) throw new Exception("Email inválido");
            var dal = new EmpleadoDAL(_db);
            
            dal.Insertar(emp);
        }

        public void EliminarEmpleado(int id)
        {
            var dal = new EmpleadoDAL(_db);
            dal.EliminarLogico(id);
        }

        public Empleado BuscarEmpleado(int id)
        {
            var dal = new EmpleadoDAL(_db);
            return dal.ObtenerPorId(id);
        }

        public void EditarEmpleado(Empleado emp)
        {
            var dal = new EmpleadoDAL(_db);
            dal.Actualizar(emp);
        }

    }
}

