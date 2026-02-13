using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WB.Entidades
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string Nombres { get; set; } = "";

        public string Apellidos { get; set; } = "";

        public string Email { get; set; } = "";

        public string Telefono { get; set; } = "";

        public DateTime FechaDeIngreso { get; set; }

        public decimal Sueldo { get; set; }

        public decimal? PctComision { get; set; }

        public int IdDpto { get; set; } 

        public int IdCargos { get; set; }

        public int? IdGerente { get; set; }

        public string NombreDepartamento { get; set; } = "";

        public string NombreCargo { get; set; } = "";

        public bool Estado { get; set; } = true;

    }
}
