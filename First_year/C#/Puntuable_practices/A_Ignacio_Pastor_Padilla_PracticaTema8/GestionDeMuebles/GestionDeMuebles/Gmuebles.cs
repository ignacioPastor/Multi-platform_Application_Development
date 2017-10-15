using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Lanzamos el menú de entrada, desde donde llamará a cargar los datos del fichero muebles y del array de usuarios
namespace GestionDeMuebles
{
    class Gmuebles
    {
        public Gmuebles()
        {
            
        }
        public void Empezar()
        {
            EntradaUsuarios eu = new EntradaUsuarios();
            eu.MenuEntrada();
        }
    }
}
