using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ignacio Pastor Padilla - Practica Tema 8 - Programación - DAM Semipresencial
//Subclase de Mesas, aquí gestionamos las características particulares de las Mesas de Ordenador
namespace GestionDeMuebles
{
    class MesasOrdenador : MesasOficina
    {
        protected float largoBandejaTeclado;
        protected float anchoBandejaTeclado;

        public MesasOrdenador()
        {
            largoBandejaTeclado = 0.4f;
            anchoBandejaTeclado = 0.1f;
        }
        public MesasOrdenador(string material, string color, string fechaFabricacion, float precioVenta, float alto, float ancho,
            float largo, ushort numeroCajones, bool ruedas, float largoBandejaTeclado, float anchoBandejaTeclado)
            : base (material, color, fechaFabricacion, precioVenta, alto, ancho, largo, numeroCajones, ruedas)
        {
            this.largoBandejaTeclado = largoBandejaTeclado;
            this.anchoBandejaTeclado = anchoBandejaTeclado;
        }
        public void SetLargoBandejaTeclado(float largoBandejaTeclado)
        {
            this.largoBandejaTeclado = largoBandejaTeclado;
        }
        public float GetLargoBandejaTeclado()
        {
            return largoBandejaTeclado;
        }
        public void SetAnchoBandejaTeclado(float anchoBandejaTeclado)
        {
            this.anchoBandejaTeclado = anchoBandejaTeclado;
        }
        public float GetAnchoBandejaTeclado()
        {
            return anchoBandejaTeclado;
        }
        public override string Mostrar()
        {
            return base.Mostrar() + ";" + largoBandejaTeclado + ";" + anchoBandejaTeclado;
        }
    }
}
