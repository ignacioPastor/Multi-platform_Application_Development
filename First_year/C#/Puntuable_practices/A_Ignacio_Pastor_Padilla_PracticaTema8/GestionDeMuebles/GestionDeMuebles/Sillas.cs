using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Subclase de Muebles, aquí gestionaremos las particularidades comunes de los muebles que sean sillas
namespace GestionDeMuebles
{
    class Sillas : Muebles
    {
        protected bool antebrazos;

        public Sillas()
        {

        }
        public Sillas(string material, string color, string fechaFabricacion, float precioVenta, bool antebrazos)
            : base (material, color, fechaFabricacion, precioVenta)
        {
            this.antebrazos = antebrazos;
        }

        public void SetAntebrazos(bool antebrazos)
        {
            this.antebrazos = antebrazos;
        }
        public bool GetAntebrazos()
        {
            return antebrazos;
        }
       
        public override string Mostrar()
        {
            return base.Mostrar() +  ";" + antebrazos;
        }

    }
}
