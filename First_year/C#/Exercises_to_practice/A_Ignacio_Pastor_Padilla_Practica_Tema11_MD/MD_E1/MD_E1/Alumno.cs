using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

// Ignacio Pastor Padilla Grupo A- Ejercicio 1 - Practica Tema 11 - Programación - DAM Semipresencial

    //En esta clase organizaremos la estructura de los alumnos, sus notas, nombres, dni.
    //Recibimos también un string de notas, que separamos con Split y convertimos a float. Sacaremos la media y la almacenaremos también

namespace MD_E1
{
    class Alumno
    {
        bool tutoBenne;
        string[] notasPartidas;
        string dni;
        string nombre;
        ArrayList miLista = new ArrayList();
        float notaMedia;

        public void SetDni(string dni)
        {
            this.dni = dni;
        }
        public string GetDni()
        {
            return dni;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string GetNombre()
        {
            return nombre;
        }
        public void SetMiLista(string notas)//Recibimos el string de notas separadas por un espacio
        {
            tutoBenne = true;
            notasPartidas = notas.Split(' ');//Separamos ese string en partes y lo guardamos en un array de string
            try
            {
                for (int i = 0; i < notasPartidas.Length; i++)
                {
                    miLista.Add(Convert.ToSingle(notasPartidas[i]));//Cada elemento del array de string lo convertimos a  y lo metemos en la lista de notas
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("Ha habido un error al intentar almacenar las notas: {0}", e.Message);
                Console.WriteLine("Por favor, vuelve a intentarlo.");
                tutoBenne = false;//Si se genera una excepción, mediante un booleano tomamos nota de que no se han guardado los datos
            }
            catch(Exception o)
            {
                Console.WriteLine("Ha habido un error al intentar almacenar las notas: {0}", o.Message);
                Console.WriteLine("Por favor, vuelve a intentarlo.");
                tutoBenne = false;
            }
            if(tutoBenne == true)//Si los datos se han podido procesar adecuadamente, calculamos la media
                SetNotaMedia(miLista);//A la vez, llamamos a un método para calcular y guardar la nota media
        }
        public void SetNotaMedia(ArrayList lista)//Recibimos la lista de notas y calculamos la nota media
        {
            for(int i = 0; i < lista.Count; i++)//Bucle para recorrer la lista
                notaMedia +=  (float) lista[i];//Sumamos todas las notas
            notaMedia /= (float)lista.Count;//Dividimos la suma de todas las notras entre el número de notas que tenemos
        }
        public float GetNotaMedia()
        {
            return notaMedia;
        }
        public bool GetTutoBenne()
        {
            return tutoBenne;
        }
    }

}
