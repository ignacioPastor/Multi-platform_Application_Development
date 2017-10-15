using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//En esta clase tendremos el bloque de ladrillos, lo creamos, dibujamos, etc
namespace Consolenoid
{
    class BloqueLadrillos : Ladrillo
    {
        int k; //Utilizaremos esta variable para sumar 8 a cada posición inicial de cada ladrillo (en cada fila).
        //Ocupan 8 espacios, el primero estará en x = 0, el siguiente en x = 8, etc. Esto lo haremos haciendo x += k, y aumentando k en 8 cada vez
         
        Ladrillo[,] ladrillos1 = Singleton.GetLadrillos1(); //Array para crear y almacenar las tres filas de ladrillos

        public BloqueLadrillos()
        {
            //Inicializamos cada ladrillo y le asignamos una posición
            for (int i = 0; i < 4; i++)
            {
                k = 0;
                for (int j = 0; j < 10; j++)
                {
                    //Aquí controlamos de hacer primero los ladrillos fuertes
                    if (i == 0 && j == 2)
                    {
                        ladrillos1[i, j] = new LadrilloFuerte(16, 0 + i, false);
                    }
                    else if (i == 1 && j == 9)
                    {
                        ladrillos1[i, j] = new LadrilloFuerte(72, 0 + i, false);
                    }
                    else if (i == 3 && j == 5)
                    {
                        ladrillos1[i, j] = new LadrilloFuerte(40, 0 + i, false);
                    }
                    else if (i % 2 == 0) //Ahora pasamos ya a crear e inicializar los ladrillos azules y rojos
                    {                    // Para que se muestren alternados en las filas superiores e inferiores, en filas 0 o pares
                        if (j == 0 || j % 2 == 0) // Posiciones 0 o pares
                        {
                            ladrillos1[i, j] = new LadrilloRojo(0 + k, 0 + i, false);
                        }
                        else if (j == 1 || j % 2 != 0) //Posiciones 1 o impares
                        {
                            ladrillos1[i, j] = new LadrilloAzul(0 + k, 0 + i, false);
                        }
                    }
                    else // Para filas 1 o impares
                    {
                        if (j == 0 || j % 2 == 0) // Posiciones 0 o pares
                        {
                            ladrillos1[i, j] = new LadrilloAzul(0 + k, 0 + i, false);
                        }
                        else if (j == 1 || j % 2 != 0) //Posiciones 1 o impares
                        {
                            ladrillos1[i, j] = new LadrilloRojo(0 + k, 0 + i, false);
                        }   
                    }
                    k += 8; //Cada vez que se crea un ladrillo, k aumenta  8 para indicar la posición del ladrillo siguiente (que estará al lado)
                }
            }
        }
        public override void Dibujar() //Para dibujar el bloque de ladrillos
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(ladrillos1[i,j].GetRoto() == false)
                        ladrillos1[i,j].Dibujar();
                }
                Console.WriteLine();
            }

        }
        public void RestablecerBloqueLadrillos() //Para restablecer el bloque de ladrillos (que no haya ninguno roto). 
        {                                        //Lo usaremos para iniciar una nueva partida después de haber jugado ya alguna previa
            //El funcionamiento es igual que en el constructor. Duplicamos código, pero así podemos trabajar bien desde la clase Partida
            //Inicializamos cada ladrillo y le asignamos una posición
            for (int i = 0; i < 4; i++)
            {
                k = 0;
                for (int j = 0; j < 10; j++)
                {
                    //Aquí controlamos de hacer primero los ladrillos fuertes
                    if (i == 0 && j == 2)
                    {
                        ladrillos1[i, j] = new LadrilloFuerte(16, 0 + i, false);
                    }
                    else if (i == 1 && j == 9)
                    {
                        ladrillos1[i, j] = new LadrilloFuerte(72, 0 + i, false);
                    }
                    else if (i == 3 && j == 5)
                    {
                        ladrillos1[i, j] = new LadrilloFuerte(40, 0 + i, false);
                    }
                    else if (i % 2 == 0)
                    {
                        if (j == 0 || j % 2 == 0)
                        {
                            ladrillos1[i, j] = new LadrilloRojo(0 + k, 0 + i, false);
                        }
                        else if (j == 1 || j % 2 != 0)
                        {
                            ladrillos1[i, j] = new LadrilloAzul(0 + k, 0 + i, false);
                        }
                    }
                    else
                    {
                        if (j == 0 || j % 2 == 0)
                        {
                            ladrillos1[i, j] = new LadrilloAzul(0 + k, 0 + i, false);
                        }
                        else if (j == 1 || j % 2 != 0)
                        {
                            ladrillos1[i, j] = new LadrilloRojo(0 + k, 0 + i, false);
                        }
                    }
                    k += 8;
                }
            }
        }
        //Para comprobar si todos los ladrillos están rotos
        public bool TodosLadrillosRotos()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ladrillos1[i, j].GetRoto() == false)
                        return false;
                }
            }
            return true;
        }
    
    }
}
