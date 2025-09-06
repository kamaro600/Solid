using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSolid
{
    public class MultaEstandar : ICalculadoraMulta
    {
        public decimal Calcular(int diasRetraso)
        {
            return diasRetraso * 10;
        }
    }
}
