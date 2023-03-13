using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Adesco
{
    //-------------------------Auxiliar------------------------------
    internal class DatosBD
    {
       
            private int id;
            private string nombres;
            private string apellidos;
            private string senda;
            private string poligono;
            private string n_casa;
            private string codigo;

            public int Id { get => id; set => id = value; }
            public string Nombres { get => nombres; set => nombres = value; }
            public string Apellidos { get => apellidos; set => apellidos = value; }
            public string Senda { get => senda; set => senda = value; }
            public string Poligono { get => poligono; set => poligono = value; }    
            public string N_casa { get => n_casa; set => n_casa = value; }
            public string Codigo { get => codigo; set => codigo = value; }
            

    }
}
