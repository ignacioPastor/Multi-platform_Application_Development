using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A

// Clase que gestionará el guardado y cargado de los distintos objetos de nuestro juego.
// Utilizaremos SoapFormatter para todo salvo para las estructuras dinámicas, donde utilizaremos un fichero binario
// fruto a los problemas que descubrimos en una de las prácticas del tercer trimestre, donde me daba error al guardar una lista
// con Soap.

namespace Tetris2
{
    [Serializable]
    class Serializador
    {
        // Saca la pieza del Tablero antes de guardar el tablero.
        // Esto se hace porque la pieza está metida dentro del tablero, pero es manejada desde el objeto pieza.
        // Cuando cargamos el tablero esta conexión se ha perdido, lo cual nos obliga a guardar la pieza por separado
        // y si no sacamos antes la pieza del tablero duplicaremos la pieza. Además, la pieza cargada desde el tablero
        // se quedará en su posición quieta flotando allí donde estaba cuando se guardó.
        
        // Conseguimos también otro objetivo, que cuando se cargue una partida, la pieza que estaba moviéndose no se conserve,
        // sino que sea una nueva. Así, lo que conseguimos al guardar es guardar lo ya jugado, el bloque de piezas y la puntuación
        public void SacarPiezaDelTablero(ref List<Tetraedro> objeto, Pieza pieza)
        {
            for (int i = 0; i < objeto.Count; i++)
            {
                for (int j = 0; j < pieza.Posicion.Length; j++)
                {
                    if (objeto[i] == pieza.Posicion[j])
                    {
                        objeto.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
        // Guarda el tablero
        public void GuardarPartida(List<Tetraedro> objeto, string nombre, Pieza pieza)
        {
            SacarPiezaDelTablero(ref objeto, pieza); // Antes de guardar el tablero sacamos la pieza en movimiento del tablero.
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, objeto);
            stream.Close();
        }
        // Carga el tablero
        public List<Tetraedro> CargarPartida(string nombre)
        {
            List <Tetraedro> objeto;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            objeto = (List<Tetraedro>)formatter.Deserialize(stream);
            stream.Close();
            return objeto;
        }

        public void GuardarRanking(Ranking[] objeto, string nombre)
        {
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, objeto);
            stream.Close();
        }

        public Ranking[] CargarRanking(string nombre)
        {
            Ranking[] objeto;
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                objeto = (Ranking[])formatter.Deserialize(stream);
            }
            catch
            {
                objeto = null;
                stream.Close();
            }
            stream.Close();
            return objeto;
        }
        // Guarda un entero, se utilizará tanto para guardar la puntuación como para guardar el nivel
        public void GuardarEntero(int objeto, string nombre)
        {
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(nombre, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, objeto);
            stream.Close();
        }
        // Carga un entero, se utilizará tanto para cargar la puntuación como para cargar el el nivel
        public int CargarEntero(string nombre)
        {
            int objeto;
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(nombre, FileMode.Open, FileAccess.Read, FileShare.Read);
            objeto = (int)formatter.Deserialize(stream);
            stream.Close();
            return objeto;
        }
    }
}
