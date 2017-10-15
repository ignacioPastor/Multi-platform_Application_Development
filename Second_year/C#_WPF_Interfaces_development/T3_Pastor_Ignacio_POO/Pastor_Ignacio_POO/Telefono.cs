using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
///<author> Ignacio Pastor Padilla</author>
/// <summary>
/// Clase Telefono
/// </summary>
namespace Pastor_Ignacio_POO
{

    class Telefono
    {
        // Constructor vacío
        public Telefono()
        {

        }
        //Constructor con todos los argumentos
        public Telefono(ulong id, string numero, string propietario, Tipo tipoTelf, string tarifa)
        {
            this.id = id;
            Numero = numero;
            Propietario = propietario;
            this.tipoTelf = tipoTelf;
            Tarifa = tarifa;
        }
        //Constructor Copia
        public Telefono(Telefono telfPrevio)
        {
            this.id = telfPrevio.ID;
            Numero = telfPrevio.Numero;
            Propietario = telfPrevio.Propietario;
            this.tipoTelf = telfPrevio.TipoTelf;
            Tarifa = telfPrevio.Tarifa;
        }
        //Enumerador con los tipos de teléfono disponibles
        public enum Tipo { Movil = 6, Especial = 8, Fijo = 9 };

        private readonly ulong id;
        protected string numero;
        string propietario; 
        private Tipo tipoTelf;
        string tarifa;
        
        //Propiedades
        //ID es readonly, no se implementa set
        public ulong ID
        {
            get
            {
                return id;
            }
        }
        public string Numero
        {
            set
            {
                if (ComprobarNumero(value))// Antes de asignar, comprobamos que el número cumple con el formato deseado
                {
                    numero = value;
                }
                else
                {
                    throw new Exception("El formato del número debe ser \"+NN-NNNNNNNNN\"");
                }
            }
            get
            {
                return numero;
            }
        }
        public string Propietario
        {
            set
            {
                if (value.Length <= 255)//Antes de asignar, comprobamos que no supere las posiciones máximas requeridas
                    propietario = value;
                else
                {
                    throw new Exception("El máximo de caracteres es 255");
                }
            }
            get
            {
                return propietario;
            }
        }
        public Tipo TipoTelf
        {
            set
            {
                tipoTelf = value;
            }
            get
            {
                return tipoTelf; ;
            }
        }
        public string Tarifa
        {
            set
            {
                if (value.Length <= 255)//Antes de asignar, comprobamos que no supere las posiciones máximas requeridas
                    tarifa = value;
                else
                {
                    throw new Exception("El máximo de caracteres es 255");
                }
            }
            get
            {
                return tarifa;
            }
        }
        //Destructor
        ~Telefono()
        {
            numero = null;
            Propietario = "";
            Tarifa = "";
            tipoTelf = 0;
        }
        /// <summary>
        /// Comprueba que el número cumple con el formato exigido ("+NN-NNNNNNNNN")
        /// </summary>
        /// <param name="n"> numero a validar, es de tipo string</param>
        /// <returns> true si cumple con el formato exigido</returns>
        private bool ComprobarNumero(string n)
        {
            Regex reg = new Regex(@"\A\+\d{2}\-\d{9}\z");// No es necesario comprobar que tiene 13 posiciones mediante .length porque
                                                        // con esta expresión regular se rechaza toda cadena que no tiene 13 posiciones
                if (reg.IsMatch(n))
                    return true;
                return false;
        }
        /// <summary>
        /// Sobrecarga del método ToString que devuelve los datos del teléfono separados por #
        /// </summary>
        /// <returns>cadena con los datos de un teléfono separados por # </returns>
        public override string ToString()
        {
            return System.String.Format("{0}#{1}#{2}#{3}#{4}", id, numero, propietario, tipoTelf, tarifa);
        }
    }
}
