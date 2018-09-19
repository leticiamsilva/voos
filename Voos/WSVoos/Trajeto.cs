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

        public string Nome { get => nome; set => nome = value; }
        public string Data { get => data; set => data = value; }
        public List<Voo> Voos { get => voos; set => voos = value; }
    }
}