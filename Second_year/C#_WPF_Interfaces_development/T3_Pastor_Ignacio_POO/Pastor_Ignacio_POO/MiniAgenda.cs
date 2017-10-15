using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///<author>Ignacio Pastor Padilla</author>
/// <summary>
/// Clase MiniAgenda
/// Gestiona una agenda de móviles
/// </summary>
namespace Pastor_Ignacio_POO
{
    class MiniAgenda
    {
        //Constructor vacío
        public MiniAgenda()
        {

        }
        //Constructor con argumentos
        public MiniAgenda(List<Movil> agendaMoviles)
        {
            this.agendaMoviles = agendaMoviles;
        }
        //Constructor copia
        public MiniAgenda(MiniAgenda objetoPrevio)
        {
            this.agendaMoviles = objetoPrevio.agendaMoviles;
        }
        // Lista de contactos
        List<Movil> agendaMoviles = new List<Movil>();

        /// <summary>
        /// Busca contactos por propietario
        /// </summary>
        /// <param name="propietarioBuscar">string de propietario a buscar</param>
        /// <returns> Lista con los contactos cuyo propietario coincide total o parcialmente con la cadena buscada</returns>
        public List<Movil> BuscarPropietario(string propietarioBuscar)
        {
            List<Movil> encontrados = new List<Movil>();
            for(int i = 0; i < agendaMoviles.Count; i++)
                if (agendaMoviles[i].Propietario.ToUpper().Contains(propietarioBuscar.ToUpper()))
                    encontrados.Add(agendaMoviles[i]);
            return encontrados;
        }
        
        /// <summary>
        /// Busca contactos por numero
        /// </summary>
        /// <param name="numeroBuscar">numero a buscar, es de tipo string</param>
        /// <returns>List con los contactos que contienen el número buscado</returns>
        public List<Movil> BuscarNumero(string numeroBuscar)
        {
            List<Movil> encontrados = new List<Movil>();
            for (int i = 0; i < agendaMoviles.Count; i++)
                if(agendaMoviles[i].Numero.Contains(numeroBuscar))
                    encontrados.Add(agendaMoviles[i]);
            return encontrados;
        }
        //Devuelve la lista de contactos
        public List<Movil> MostrarContactos()
        {
            agendaMoviles.Sort();
            return agendaMoviles;
        }

        // Recibe los atributos de un móvil, e instancia un nuevo móvil que almacena en la agenda
        public void NuevoMovil(ulong id, string numero, string propietario, Telefono.Tipo tipoTelf, string tarifa, ulong segundos)
        {
            agendaMoviles.Add(new Movil(id, numero, propietario, tipoTelf, tarifa, segundos));
        }
        //Recibe una instancia de Movil y lo agrega a la agenda
        public void NuevoMovil(Movil m)
        {
            agendaMoviles.Add(m);
        }
    }
}
