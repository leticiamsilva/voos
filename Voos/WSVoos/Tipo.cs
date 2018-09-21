using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVoos
{
    public class Tipo : IComparable
    {
        private string nome;
        private double valor;

        public string Nome { get { return nome; } set { nome = value; } }
        public double Valor { get { return valor; } set { valor = value; } }

              

        public int CompareTo(object obj)
        {
            Tipo t = new Tipo();
            try
            {
                 t = (Tipo)Convert.ChangeType(obj, typeof(Tipo));
            }
            catch
            {                
            }
            
            return this.Valor.CompareTo(t.Valor);
        }
    }
}