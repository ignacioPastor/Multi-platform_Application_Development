using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Subclase de Mesas, gestionamos las características particulares de las Mesas de Comedor
namespace GestionDeMuebles
{
    class MesasComedor : Mesas
    {
        protected ushort numeroPatas;
        protected string formaPatas;

        public MesasComedor()
        {

        }
        public MesasComedor(string material, string color, string fechaFabricacion, float precioVenta, float alto,
            float ancho, float largo, ushort numeroPatas, string formaPatas)
            : base (material,  color,  fechaFabricacion, precioVenta, alto,  ancho,  largo)
        {
            this.numeroPatas = numeroPatas;
            this.formaPatas = formaPatas;
        }
        public void SetNumeroPatas(ushort numeroPatas)
        {
            this.numeroPatas = numeroPatas;
        }
        public ushort GetNumeroPatas()
        {
            return numeroPatas;
        }
        public void SetFormaPatas(string formaPatas)
        {
            this.formaPatas = formaPatas;
        }
        public string GetFormaPatas()
        {
            return formaPatas;
        }
        public override string Mostrar()
        {
            return base.Mostrar() + ";" + numeroPatas + ";" + formaPatas;
        }
    }
}
