using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Superclase de Muebles, aquí almacenamos y gestionamos los muebles y las características comunes en cada subtipo
namespace GestionDeMuebles
{
    class Muebles
    {
        protected string material;
        protected string color;
        protected string fechaFabricacion;
        protected float precioVenta;

        public Muebles()
        {

        }
        public Muebles(string material, string color, string fechaFabricacion, float precioVenta)
        {
            this.material = material;
            this.color = color;
            this.fechaFabricacion = fechaFabricacion;
            this.precioVenta = precioVenta;
        }

        public void SetMaterial(string material)
        {
            this.material = material;
        }
        public string GetMaterial()
        {
            return material;
        }
        public void SetColor(string color)
        {
            this.color = color;
        }
        public string GetColor()
        {
            return color;
        }
        public void SetFechaFabricacion(string fechaFabricacion)
        {
            this.fechaFabricacion = fechaFabricacion;
        }
        public string GetFechaFabricacion()
        {
            return fechaFabricacion;
        }
        public void SetPrecioVenta(float precioVenta)
        {
            this.precioVenta = precioVenta;
        }
        public float GetPrecioVenta()
        {
            return precioVenta;
        }
        public virtual string Mostrar()
        {
            return material + ";" + color + ";" + fechaFabricacion + ";" + precioVenta;
        }
    }
}