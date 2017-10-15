using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Subclase de Sillas, aquí gestionaremos las características particulares de las Sillas de Comedor
namespace GestionDeMuebles
{
    class SillasComedor : Sillas
    {
        protected string materialAsiento;
        protected string materialRespaldo;
        protected string formaPatas;

        public SillasComedor()
        {

        }
        public SillasComedor(string material, string color, string fechaFabricacion, float precioVenta, bool antebrazos,
            string materialAsiento, string materialRespaldo, string formaPatas)
            : base (material, color, fechaFabricacion, precioVenta, antebrazos)
        {
            this.materialAsiento = materialAsiento;
            this.materialRespaldo = materialRespaldo;
            this.formaPatas = formaPatas;
        }
        public void SetMaterialAsiento(string materialAsiento)
        {
            this.materialAsiento = materialAsiento;
        }
        public string GetMaterialAsiento()
        {
            return materialAsiento;
        }
        public void SetMaterialRespaldo(string materialRespaldo)
        {
            this.materialRespaldo = materialRespaldo;
        }
        public string GetMaterialRespaldo()
        {
            return materialRespaldo;
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
            return base.Mostrar() + ";" + materialAsiento + ";" + materialRespaldo + ";" + formaPatas;
        }
    }
}
