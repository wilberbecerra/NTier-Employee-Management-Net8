using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.Entidades;

namespace WB.AccesoDatos
{
    public class EmpleadoDAL
    {
       
        private readonly DB_Acceso _db;
        
        public EmpleadoDAL(DB_Acceso db)
        {
            _db = db;
        }
        
        public List<Empleado> ObtenerTodos()
        {
            var lista = new List<Empleado>();

            using (var conexion = _db.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
                    SELECT 
                        e.ID_EMPLEADO, e.NOMBRES, e.APELLIDOS, e.EMAIL, e.TELEFONO, 
                        e.FECHA_INGRESO, e.SUELDO, e.PCT_COMISION, e.ID_DPTO, e.ID_CARGOS, e.ID_GERENTE,
                        d.NOMBRE_DPTO, 
                        c.NOMBRE_CARGO
                    FROM CL_EMPLEADOS e
                    INNER JOIN CL_DEPARTAMENTOS d ON e.ID_DPTO = d.ID_DPTO
                    INNER JOIN CL_CARGOS c ON e.ID_CARGOS = c.ID_CARGOS";

                using (var comando = new SqlCommand(query, conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            var emp = new Empleado();

                            // MAPEO: Clase C# a la izquierda = Nombres de SQL a la derecha (en MAYÚSCULAS)
                            emp.IdEmpleado = Convert.ToInt32(lector["ID_EMPLEADO"]);
                            emp.Nombres = lector["NOMBRES"].ToString();
                            emp.Apellidos = lector["APELLIDOS"].ToString();
                            emp.Email = lector["EMAIL"].ToString();

                            // Manejo de nulos para campos opcionales (como Teléfono)
                            emp.Telefono = lector["TELEFONO"] != DBNull.Value ? lector["TELEFONO"].ToString() : "";

                            emp.FechaDeIngreso = Convert.ToDateTime(lector["FECHA_INGRESO"]);
                            emp.Sueldo = Convert.ToDecimal(lector["SUELDO"]);

                            if (lector["PCT_COMISION"] != DBNull.Value)
                                emp.PctComision = Convert.ToDecimal(lector["PCT_COMISION"]);

                            emp.IdDpto = Convert.ToInt32(lector["ID_DPTO"]);
                            emp.IdCargos = Convert.ToInt32(lector["ID_CARGOS"]);

                            if (lector["ID_GERENTE"] != DBNull.Value)
                                emp.IdGerente = Convert.ToInt32(lector["ID_GERENTE"]);

                            // Datos Extra de los Joins 
                            // (Asegúrate de que en el SELECT de arriba les pusiste NOMBRE_DPTO y NOMBRE_CARGO)
                            emp.NombreDepartamento = lector["NOMBRE_DPTO"].ToString();
                            emp.NombreCargo = lector["NOMBRE_CARGO"].ToString();

                            lista.Add(emp);
                        }
                    }
                }
            }
            return lista;
        }
    }
}

