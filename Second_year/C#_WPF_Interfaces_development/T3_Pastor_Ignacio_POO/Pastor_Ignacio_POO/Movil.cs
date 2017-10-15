using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <author>Ignacio Pastor Padilla</author>
/// <summary>
/// </summary>
namespace Pastor_Ignacio_POO
{
    class Movil : Telefono, IComparable<Movil>
    {
        //Constructor
        public Movil()
        {

        }
        //Constructor con todos los parámetros. Se apoya en el constructor del padre
        public Movil(ulong id, string numero, string propietario, Tipo tipoTelf, string tarifa, ulong segundosConsumidos)
            : base(id, numero, propietario, tipoTelf, tarifa)
        {

            SegundosConsumidos = segundosConsumidos;
        }
        //Constructor copia. Se apoya en el constructor del padre
        public Movil(Movil prevMovil) 
            : base(prevMovil.ID, prevMovil.Numero, prevMovil.Propietario, prevMovil.TipoTelf, prevMovil.Tarifa)
        {

            SegundosConsumidos = prevMovil.SegundosConsumidos;
        }
        private ulong SegundosConsumidos { set; get; }

        //Destructor
        ~Movil()
        {
            SegundosConsumidos = 0;
        }
        /// <summary>
        /// Sobrecarga del método ToString que devuelve los datos del movil separados por #
        /// Se apoya en la sobrecarga del padre
        /// </summary>
        /// <returns>cadena con los datos de un teléfono separados por # </returns>
        public override string ToString()
        {
            return base.ToString() + "#" + SegundosConsumidos.ToString();
        }
        /// <summary>
        /// Implementación del método CompareTo de la Intefaz IComparable<T>
        /// Se utilizará para ordenar listas de móviles, el método Sort acudirá aquí para encontrar la forma de ordenar estos objetos
        /// </summary>
        /// <param name="otroMovil"> instancia a comparar con la instancia actual</param>
        /// <returns> O, 1, -1 según si esta instancia debe preceder o anteceder a la instancia recibida</returns>
        public int CompareTo(Movil otroMovil)
        {
            return this.Propietario.CompareTo(otroMovil.Propietario);
        }
    }
}
