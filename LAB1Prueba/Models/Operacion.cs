using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB1Prueba.Models
{
    public class Operacion
    {
        public string tipoOperacion { get; set; }
        public double valor1 { get; set; }
        public double valor2 { get; set; }
        public double resultado { get; set; }

        public Operacion(string tipoOperacion, double valor1, double valor2, double resultado)
        {
            this.tipoOperacion = tipoOperacion;
            this.valor1 = valor1;
            this.valor2 = valor2;
            this.resultado = resultado;
        }
    }
}