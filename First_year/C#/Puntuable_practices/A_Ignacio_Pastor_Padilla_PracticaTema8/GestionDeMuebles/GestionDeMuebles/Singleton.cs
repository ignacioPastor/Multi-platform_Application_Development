using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Clase para crear objetos que podamos utilizar en distintas clases sin violar el principio de encapsulación a la ligera
//Aquí creo los objetos array de Usuarios, Almacén y array de Muebles que se utilizarán en el programa
namespace GestionDeMuebles
{
    class Singleton
    {
        private static Usuarios[] u = null;
        private static Almacen a = null;
        private static Muebles[] m = null;

        private Singleton() { }

        public static Usuarios[] GetUsuarios()
        {
            if (u == null)
            {
                u = new Usuarios[1000];
            }
            return u;
        }
        public static Muebles[] GetMuebles()
        {
            if (m == null)
            {
                m = new Muebles[1000];
            }
            return m;
        }
        public static Almacen GetAlmacen()
        {
            if (a == null)
            {
                a = new Almacen();
            }
            return a;
        }
    }
}
