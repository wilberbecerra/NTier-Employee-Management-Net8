using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WB.AccesoDatos
{
    public class DB_Acceso
    {
        
        private readonly string _cadenaConexion;
        
        public DB_Acceso(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }

    }
}
