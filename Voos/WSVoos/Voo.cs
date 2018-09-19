using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVoos
{
    public class Voo
    {
        private string id;
        private string hora;
        private List<Tipo>tipos;

        private Trajeto trajeto;

        public string Id { get { return id; } set { id = value; } }
        public string Hora { get { return hora; } set { hora = value; }  }
        public Trajeto Trajeto { get { return trajeto; } set { trajeto = value; }  }
        public List<Tipo> Tipos { get { return tipos; } set { tipos = value; } }
    }
}