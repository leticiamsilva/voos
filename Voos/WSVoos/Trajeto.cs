using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WSVoos
{
    public class Trajeto
    {
        private string nome;
        private string data;

        private List<Voo> voos;

        public Trajeto()
        {
            this.voos = new List<Voo>();
        }
        
        public string Nome { get { return nome; } set { nome = value; } }
        public string Data { get { return data; } set { data = value; } }
        public List<Voo> Voos { get { return voos; } set { voos = value; } }


    }
}