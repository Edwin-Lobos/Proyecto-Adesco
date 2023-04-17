using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Adesco.Clases
{
    internal class AuxRecibo
    {
        private int num_recibo;
        private string mes_es;
        private string codigo;
        private string nota;
        private double total, cantidad, otro;
        private string nombres, apellidos, senda, poligono, n_casa;

        public int Num_recibo { get => num_recibo; set => num_recibo = value; }
        public string Mes_es { get => mes_es; set => mes_es = value; }
        public double Total { get => total; set => total = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public double Otro { get => otro; set => otro = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Senda { get => senda; set => senda = value; }
        public string Poligono { get => poligono; set => poligono = value; }
        public string N_casa { get => n_casa; set => n_casa = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nota { get => nota; set => nota = value; }
    }
}
