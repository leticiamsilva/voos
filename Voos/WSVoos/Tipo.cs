using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVoos
{
    public class Tipo
    {
        private string nome;
        private double valor;

        private Voo voo;

        public string Nome { get { return nome; } set { nome = value; } }
        public double Valor { get { return valor; } set { valor = value; } }
    }
}