using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WB.Entidades
{
    public class Cargo
    {
        public int IdCargos { get; set;}

        public string NombreCargo { get; set; } = "";
         
        public decimal SalarioMinimo { get; set; }

        public decimal SalarioMaximo { get; set; }

    }
}
