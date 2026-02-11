using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WB.Entidades
{
    public class Departamento
    {
        public int IdDpto { get; set; }

        public string NombreDpto { get; set; } = "";

        public int? IdGerente { get; set; }

        public int IdLocalidad { get; set; }


    }
}
