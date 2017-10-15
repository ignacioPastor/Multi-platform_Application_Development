using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Subclase de Mesas, aquí gestionamos las características particulares de las Mesas de Oficina
namespace GestionDeMuebles
{
    class MesasOficina : Mesas
    {
        protected ushort numeroCajones;
        protected bool ruedas;

        public MesasOficina()
        {
            numeroCajones = 7;
            ruedas = true;
        }
        public MesasOficina(string material, string color, string fechaFabricacion, float precioVenta, float alto, float ancho, 
            float largo, ushort numeroCajones, bool ruedas)
            : base (material, color, fechaFabricacion, precioVenta, alto, ancho, largo)
        {
            this.numeroCajones = numeroCajones;
            this.ruedas = ruedas;
        }
        public void SetNumeroCajones(ushort numeroCajones)
        {
            this.numeroCajones = numeroCajones;
        }
        public ushort GetNumeroCajones()
        {
            return numeroCajones;
        }
        public void SetRuedas(bool ruedas)
        {
            this.ruedas = ruedas;
        }
        public bool GetRuedas()
        {
            return ruedas;
        }
        public override string Mostrar()
        {
            return base.Mostrar() + ";" + numeroCajones + ";" + ruedas;
        }
    }
}
