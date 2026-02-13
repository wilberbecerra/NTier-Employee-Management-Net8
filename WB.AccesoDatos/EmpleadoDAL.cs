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
                           
                            emp.IdEmpleado = Convert.ToInt32(lector["ID_EMPLEADO"]);
                            emp.Nombres = lector["NOMBRES"].ToString();
                            emp.Apellidos = lector["APELLIDOS"].ToString();
                            emp.Email = lector["EMAIL"].ToString();
                            
                            emp.Telefono = lector["TELEFONO"] != DBNull.Value ? lector["TELEFONO"].ToString() : "";

                            emp.FechaDeIngreso = Convert.ToDateTime(lector["FECHA_INGRESO"]);
                            emp.Sueldo = Convert.ToDecimal(lector["SUELDO"]);

                            if (lector["PCT_COMISION"] != DBNull.Value)
                                emp.PctComision = Convert.ToDecimal(lector["PCT_COMISION"]);

                            emp.IdDpto = Convert.ToInt32(lector["ID_DPTO"]);
                            emp.IdCargos = Convert.ToInt32(lector["ID_CARGOS"]);

                            if (lector["ID_GERENTE"] != DBNull.Value)
                                emp.IdGerente = Convert.ToInt32(lector["ID_GERENTE"]);
                            
                            emp.NombreDepartamento = lector["NOMBRE_DPTO"].ToString();
                            emp.NombreCargo = lector["NOMBRE_CARGO"].ToString();

                            lista.Add(emp);
                        }
                    }
                }
            }
            return lista;
        }
        
        public void Insertar(Empleado emp)
        {
            using (var conexion = _db.ObtenerConexion())
            {
                conexion.Open();

                
                string query = @"
                    INSERT INTO CL_EMPLEADOS 
                    (NOMBRES, APELLIDOS, EMAIL, TELEFONO, FECHA_INGRESO, SUELDO, PCT_COMISION, ID_DPTO, ID_CARGOS, ID_GERENTE, ESTADO) 
                    VALUES 
                    (@Nombres, @Apellidos, @Email, @Telefono, @FechaIngreso, @Sueldo, @PctComision, @IdDpto, @IdCargos, @IdGerente, 1)";

                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombres", emp.Nombres);
                    comando.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                    comando.Parameters.AddWithValue("@Email", emp.Email);
                    comando.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(emp.Telefono) ? DBNull.Value : emp.Telefono);
                    comando.Parameters.AddWithValue("@FechaIngreso", emp.FechaDeIngreso);
                    comando.Parameters.AddWithValue("@Sueldo", emp.Sueldo);
                    comando.Parameters.AddWithValue("@PctComision", emp.PctComision ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@IdDpto", emp.IdDpto);
                    comando.Parameters.AddWithValue("@IdCargos", emp.IdCargos);
                    comando.Parameters.AddWithValue("@IdGerente", emp.IdGerente ?? (object)DBNull.Value);

                    // ExecuteNonQuery se usa para INSERT, UPDATE o DELETE (no devuelve tablas, solo hace la acción)
                    comando.ExecuteNonQuery();
                }
            }
        }



        //


    }
}

