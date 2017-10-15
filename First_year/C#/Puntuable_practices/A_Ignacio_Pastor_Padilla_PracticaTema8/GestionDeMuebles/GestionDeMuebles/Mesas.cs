using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Subtipo de Muebles, hereda de Muebles y gestiona los elementos comunes de todas las Mesas
namespace GestionDeMuebles
{
    class Mesas : Muebles
    {
        protected float alto;
        protected float ancho;
        protected float largo;

        public Mesas()
        {

        }
        public Mesas(string material, string color, string fechaFabricacion, float precioVenta, float alto, float ancho, float largo)
            : base (material, color, fechaFabricacion, precioVenta)
        {
            this.alto = alto;
            this.ancho = ancho;
            this.largo = largo;
        }
       
        public void SetAlto(float alto)
        {
            this.alto = alto;
        }
        public float GetAlto()
        {
            return alto;
        }
        public void SetAncho(float ancho)
        {
            this.ancho = ancho;
        }
        public float GetAncho()
        {
            return ancho;
        }
        public void SetLargo(float largo)
        {
            this.largo = largo;
        }
        public float GetLargo()
        {
            return largo;
        }
       
        public override string Mostrar() //Método para enviar los datos como string a imprimir en el fichero
        {
            return base.Mostrar() + ";" + alto + ";" + ancho + ";" + largo;
        }
        
    }
}
