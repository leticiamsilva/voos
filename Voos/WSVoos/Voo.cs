using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVoos
{
    public class Voo
    {
        private int id;
        private string hora;
        private List<Tipo>tarifas;

        private Trajeto trajeto;

        public int Id { get => id; set => id = value; }
        public string Hora { get => hora; set => hora = value; }
        public Trajeto Trajeto { get => trajeto; set => trajeto = value; }       
        public string Tipo { get => tipo; set => tipo = value; }
        public List<Tipo> Tarifas { get => tarifas; set => tarifas = value; }
    }
}