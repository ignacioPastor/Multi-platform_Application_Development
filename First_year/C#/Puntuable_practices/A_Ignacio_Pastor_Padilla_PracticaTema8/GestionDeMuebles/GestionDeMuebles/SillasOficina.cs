using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Subclase de Sillas, aquí gestionaremos las características particulares de las Sillas de Oficina
namespace GestionDeMuebles
{
    class SillasOficina : Sillas
    {
        protected string materialPata;
        protected ushort numeroRuedas;

        public SillasOficina()
        {

        }
        public SillasOficina(string material, string color, string fechaFabricacion, float precioVenta, bool antebrazos,
            string materialPata, ushort numeroRuedas)
            : base (material, color, fechaFabricacion, precioVenta, antebrazos)
        {
            this.materialPata = materialPata;
            this.numeroRuedas = numeroRuedas;
        }
        public void SetMaterialPata(string materialPata)
        {
            this.materialPata = materialPata;
        }
        public string GetMaterialPata()
        {
            return materialPata;
        }
        public void SetNumeroRuedas(ushort numeroRuedas)
        {
            this.numeroRuedas = numeroRuedas;
        }
        public ushort GetNumeroRuedas()
        {
            return numeroRuedas;
        }
        public override string Mostrar()
        {
            return base.Mostrar() + ";" + materialPata + ";" + numeroRuedas;
        }
    }
}
