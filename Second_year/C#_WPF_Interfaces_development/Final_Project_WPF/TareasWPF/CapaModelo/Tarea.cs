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
    public class Tarea
    {
        public int IdTarea { get; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int DuracionEstimada { get; set; }
        public string Tipo { get; set; }
        public bool Urgente { get; set; }
        public int UsuarioAsignado { get; set; }
        public int ProyectoPertenece { get; set; }
        public int DuracionReal { get; set; }
        public bool Aviso { get; set; }
        public DateTime? CuandoAvisar { get; set; }
        public bool Terminada { get; set; }
        public string Comentarios { get; set; }
        public Proyecto MyProyecto { get; set; }
        public Usuario MyUsuario { set; get; }

        /// <summary>
        /// Constructor vacío.
        /// Inicializa los valores
        /// </summary>
        public Tarea()
        {
            IdTarea = 0;
            Nombre = "";
            Descripcion = "";
            FechaAlta = DateTime.Now;
            DuracionEstimada = 0;
            Tipo = "";
            Urgente = false;
            UsuarioAsignado = 0;
            ProyectoPertenece = 0;
            DuracionReal = 0;
            Aviso = false;
            CuandoAvisar = DateTime.Now;
            Terminada = false;
            Comentarios = "";
        }
        /// <summary>
        /// Constructor sobrecargado de la clase Tarea
        /// No incluye el identificador principal, que será asignado por defecto en la BD
        /// </summary>
        /// <param name="nombre">nombre de la tarea</param>
        /// <param name="descripcion">descripción de la tarea</param>
        /// <param name="fechaAlta">fecha de alta de la tarea</param>
        /// <param name="duracionEstimada">duración estimada de la tarea</param>
        /// <param name="tipo">tipo de tarea, será publica o privada</param>
        /// <param name="urgente">true si la tarea es urgente</param>
        /// <param name="usuarioAsignado">usuario a quien se le ha asignado la tarea</param>
        /// <param name="proyectoPertenece">proyecto al cual pertenece la tarea</param>
        /// <param name="duracionReal">duración real de la tarea</param>
        /// <param name="aviso">true si se quiere recibir aviso</param>
        /// <param name="cuandoAvisar">fecha del aviso</param>
        /// <param name="terminada">true si la tarea ya se ha terminado</param>
        /// <param name="comentarios">comentarios sobre la tarea</param>
        public Tarea(string nombre, string descripcion, DateTime? fechaAlta, int duracionEstimada, string tipo,
            bool urgente, int usuarioAsignado, int proyectoPertenece, int duracionReal, bool aviso, DateTime? cuandoAvisar,
            bool terminada, string comentarios)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaAlta = fechaAlta;
            DuracionEstimada = duracionEstimada;
            Tipo = tipo;
            Urgente = urgente;
            UsuarioAsignado = usuarioAsignado;
            ProyectoPertenece = proyectoPertenece;
            DuracionReal = duracionReal;
            Aviso = aviso;
            CuandoAvisar = cuandoAvisar;
            Terminada = terminada;
            Comentarios = comentarios;
        }
        /// <summary>
        /// Constructor sobrecargado de la clase Tarea
        /// Incluye el identificador principal.
        /// </summary>
        /// <param name="idTarea">identificador unívoco de la tarea, generado de forma automática por la BD</param>
        /// <param name="nombre">nombre de la tarea</param>
        /// <param name="descripcion">descripción de la tarea</param>
        /// <param name="fechaAlta">fecha de alta de la tarea</param>
        /// <param name="duracionEstimada">duración estimada de la tarea</param>
        /// <param name="tipo">tipo de tarea, será publica o privada</param>
        /// <param name="urgente">true si la tarea es urgente</param>
        /// <param name="usuarioAsignado">usuario a quien se le ha asignado la tarea</param>
        /// <param name="proyectoPertenece">proyecto al cual pertenece la tarea</param>
        /// <param name="duracionReal">duración real de la tarea</param>
        /// <param name="aviso">true si se quiere recibir aviso</param>
        /// <param name="cuandoAvisar">fecha del aviso</param>
        /// <param name="terminada">true si la tarea ya se ha terminado</param>
        /// <param name="comentarios">comentarios sobre la tarea</param>
        public Tarea(int idTarea, string nombre, string descripcion, DateTime? fechaAlta, int duracionEstimada, string tipo,
            bool urgente, int usuarioAsignado, int proyectoPertenece, int duracionReal, bool aviso, DateTime? cuandoAvisar,
            bool terminada, string comentarios)
        {
            IdTarea = idTarea;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaAlta = fechaAlta;
            DuracionEstimada = duracionEstimada;
            Tipo = tipo;
            Urgente = urgente;
            UsuarioAsignado = usuarioAsignado;
            ProyectoPertenece = proyectoPertenece;
            DuracionReal = duracionReal;
            Aviso = aviso;
            CuandoAvisar = cuandoAvisar;
            Terminada = terminada;
            Comentarios = comentarios;
        }
        /// <summary>
        /// Constructor sobrecargado.
        /// Instancia un objeto tarea dada una fila de datos que contiene los campos e información de la Tarea
        /// </summary>
        /// <param name="row">DataRow con los campos e información de la Tarea</param>
        public Tarea(DataRow row)
        {
            IdTarea = Convert.ToInt32(row["id_tarea"]);
            Nombre = Convert.ToString(row["nombre"]);
            Descripcion = Convert.ToString(row["descripcion"]);
            FechaAlta = Convert.ToDateTime(row["fecha_alta"]);
            DuracionEstimada = Convert.ToInt32(row["duracion"]);
            Tipo = Convert.ToString(row["cod_tarea"]);
            Urgente = Convert.ToBoolean(row["urgente"]);
            UsuarioAsignado = Convert.ToInt32(row["id_usuario"]);
            ProyectoPertenece = Convert.ToInt32(row["id_proyecto"]);
            DuracionReal = Convert.ToInt32(row["duracion_real"]);
            Aviso = Convert.ToBoolean(row["aviso"]);
            if (row["cuando_avisar"] == DBNull.Value)
                CuandoAvisar = null;
            else
                CuandoAvisar = Convert.ToDateTime(row["cuando_avisar"]);
            Terminada = Convert.ToBoolean(row["terminada"]);
            Comentarios = Convert.ToString(row["comentarios"]);
        }
    }
}
