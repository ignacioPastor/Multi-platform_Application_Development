using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Esta clase tiene la información básica de todos los elementos que se dibujarán en pantalla., como coordenadas x e y, moverse, dibujarse, etc.
namespace Consolenoid
{
    class Sprite //Esta clase será la clase de la que heredarán los elementos que se dibujan en pantalla, de aquí
                 //tomarán diversas estructuras, variables y usarán métodos comunes
    {
        protected int x, y;
        protected int unidadX, unidadY; // De esta forma manejaré el incremento de "x" e "y". En el caso de querer modificar la velocidad del
                                        // desplazamiento (en el caso de la nave) es más fácil cambiar una variable que ir a todas las partes del programa para cambiar
                                        //unos números determinados.
        protected string imagen;


        public Sprite()
        {
            x = 0;
            y = 0;
            unidadX = 4;//La nave se desplazará 4 espacios cada vez. De esa forma la velocidad de desplazamiento es ágil
            unidadY = 1;
        }
        public Sprite(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetImagen(string imagen)
        {
            this.imagen = imagen;
        }
        public string GetImagen()
        {
            return imagen;
        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public int GetX()
        {
            return x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public int GetY()
        {
            return y;
        }
        public int GetUnidadX()
        {
            return unidadX;
        }
        public int GetUnidadY()
        {
            return unidadY;
        }

        public virtual void Dibujar()//Para dibujar, ponemos el cursor en el lugar deseado y escribimos
        {
            Console.SetCursorPosition(x, y);
            Console.Write(imagen);
            Console.SetCursorPosition(1, 0); // Después de dibujar pongo el cursor en otra posición, pues como el juego está ajustado a mi pantalla
                                                // cuando llegaba al extremo derecho la nave bajaba de línea, la nave hacía un salto (en realidad
                                                // se bajaba el scroll de la ventana, pero daba sensación de salto y había que evitarlo 
        }
        public void MoverA(int x, int y)
        {
            if (x >= 0 && x <= 79 && y >= 0 && y <= 29)//Comprobamos que vamos a asignar valores dentro de los márgenes establecidos
            {
                // Asignamos a x e y sus nuevos valores
                SetX(x);
                SetY(y);
            }
        }
    }
}
