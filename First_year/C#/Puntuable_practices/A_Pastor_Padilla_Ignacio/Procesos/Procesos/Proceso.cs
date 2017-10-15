using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    class Proceso
    {
        protected string nombre;
        protected int tiempo;
        
        public Proceso()
        {

        }
        public Proceso(string nombre, int tiempo)
        {
            this.nombre = nombre;
            this.tiempo = tiempo;
        }
        
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string GetNombre()
        {
            return nombre;
        }
        public void SetTiempo(int tiempo)
        {
            this.tiempo = tiempo;
        }
        public int GetTiempo()
        {
            return tiempo;
        }
        public string Mostrar()
        {
            return nombre + " (" + tiempo + ")";
        }
    }
}
