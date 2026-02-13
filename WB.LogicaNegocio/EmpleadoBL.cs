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
            var dal = new EmpleadoDAL(_db);
            
            dal.Insertar(emp);
        }

    }
}

