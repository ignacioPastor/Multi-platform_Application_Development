using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Tareas WPF
/// <author>Ignacio Pastor Padilla</author>
/// Proyecto final - Segundo Trimestre - Desarrollo de Interfaces
/// Fecha 19/02/2017
/// </summary>
namespace CapaModelo
{
    public class Proyecto
    {
        public int IdProyecto { set; get; }
        public string Nombre { set; get; }
        public string Descripcion { set; get; }
        /// <summary>
        /// Constructor vacío, inicializa los valores.
        /// </summary>
        public Proyecto()
        {
            IdProyecto = 0;
            Nombre = "";
            Descripcion = "";
        }
        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="idProyecto">Código identificador de nuestro proyecto</param>
        /// <param name="nombre">Nombre del proyecto</param>
        /// <param name="descripcion">Descripción del proyecto</param>
        public Proyecto(int idProyecto, string nombre, string descripcion)
        {
            IdProyecto = idProyecto;
            Nombre = nombre;
            Descripcion = descripcion;
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Recibiendo un DataRow, crea un objeto Proyecto
        /// </summary>
        /// <param name="row">DataRow con los campos e información del proyectoparam>
        public Proyecto(DataRow row)
        {
            IdProyecto = Convert.ToInt32(row["id_proyecto"]);
            Nombre = Convert.ToString(row["nombre"]);
            Descripcion = Convert.ToString(row["descripcion"]);
        }
    }
}
