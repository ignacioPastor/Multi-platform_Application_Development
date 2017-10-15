using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//En esta clase tenemos a la pelota y todo lo relativo a sus características y movimiento. En particular, será muy importante el control de los
//rebotes en las distintas partes de cada elemento. Controlaremos desde aquí la puntuación (cada vez que se toque un ladrillo +1 punto)
namespace Consolenoid
{
    class Pelota : Sprite
    {
        Nave n = Singleton.GetNave(); //El objeto nave lo invocamos mediante Singleton, para que sea el mismo en distintas clases sin violar encapsulación (o hacerlo de forma controlada)
        Ladrillo[,] ladrillos1 = Singleton.GetLadrillos1();

        // Serán instrucciones para el switch
        int rebote, unidadXPelota, unidadYPelota; //Utilizaré estas variables para controlar los rebotes y cambios de dirección de la pelota
        int reboteNave = 0; //Variable para controlar el tipo de rebote en la nave. La asignaremos posteriormente a "rebote".
        int reboteLadrillo = 0; //Variable para controlar el tipo de rebote en el ladrillo. La asignaremos posteriormente a "rebote".

        int puntuacion = 0;   // Contador para llevar la puntuación. Cada ladrillo débil vale 50 y el amarillo 100 puntos
                                             
        //Constructor
        public Pelota()
        {
            imagen = "*";
            y = n.GetY() - 1; //La pelota se iniciará encima de la nave
            x = n.GetX() + n.GetImagen().Length / 2; //La pelota se iniciará en medio de la nave
            rebote = 0; //Será la variable que use como "índice" para el switch
            unidadXPelota = unidadYPelota = 1; //Valen uno, y multiplicando por -1 haré que se invierta la dirección (x + 1 pase a ser x - 1)
        }
        //Getters y Setters varios
        public int GetUnidadXPelota()
        {
            return unidadXPelota;
        }
        public int GetUnidadYPelota()
        {
            return unidadYPelota;
        }
        public int GetPuntuacion()
        {
            return puntuacion;
        }
        public void SetPuntuacion(int puntuacion)
        {
            this.puntuacion = puntuacion;
        }
        public void SetReboteNave(int reboteNave)
        {
            this.reboteNave = reboteNave;
        }
        public int GetReboteNave()
        {
            return reboteNave;
        }
        public void SetReboteLadrillo(int reboteLadrillo)
        {
            this.reboteLadrillo = reboteLadrillo;
        }
        public int GetReboteLadrillo()
        {
            return reboteLadrillo;
        }

        public override void Dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Green; //La pelota será de color verde
            base.Dibujar();
            Console.ResetColor();
        }
        /*
        Para mover la pelota:
        - Comprobamos si hay rebote, y en funcion de la respuesta se asigna un valor a la variable "rebote"
            -Veremos como el rebote en la nave lo controlo en otro método, donde manejo la variable "reboteNave", el procedimiento es el mismo, es 
            un índice. En Rebote() consultaré si es en la Nave llamando a ReboteNave(), si es así, vendrá de allí el valor de "reboteNave",
            que asignaré a "rebote".
        - En función del valor de "rebote" en el switch de DireccionPelota configuramos la dirección que va a seguir en su movimiento siguiente
        -Finalmente movememos donde proceda
        */
        public void MoverPelota()//Para mover la pelota
        {
            Rebote();//Vemos si hay rebote
            DireccionPelota();//Asignamos la dirección a seguir por la pelota
            MoverA(GetX() + unidadXPelota, GetY() + unidadYPelota); //Movemos. Recordemos, unidadesPelota serán 1 o -1 según la dirección en que se mueva
        }

        public void Rebote() //Identificamos el tipo de rebote que se produce, y asignamos a "rebote" el valor correspondiente para el switch
        {
            rebote = 0; // Cada vez que venga a ver si hay rebote, la variable se inicializa a 0
            reboteNave = 0; //Esta variable será el equivalente para controlar el rebote particularmente en la nave

            if (EsquinaFilaLadrillos() == true) // Controlamos que rebote bien en las esquinas de las filas de ladrillos
                rebote = GetReboteLadrillo();
            else if (ReboteEnNave() == true)//Caso que rebote en la nave, el tipo de rebote lo precisamos en ReboteNave(), y traemos de allí
                rebote = GetReboteNave();   // el valor de índice para el switch
            else if (GolpeLadrillo() == true)//Caso de que golpee un ladrillo, debe también rebotar. Aprovechamos en GolpeLadrillo() y relativos
                rebote = GetReboteLadrillo();// para borrarlos y llevar el control de la puntuación
            else if ((x == 0 && y == 0) || (x == 0 && y == 29) || (x == 79 && y == 0) || (x == 79 && y == 29)) //Controlamos el rebote en las esquinas consola
                rebote = 3;
            else if (x == 0 || x == 79) //Para el rebote en los laterales de la consola
                rebote = 1;
            else if (y == 0 || y >= 29) // Para el rebote en los lados superior e inferior de la consola
                rebote = 2;
            else //Caso de que no haya rebote
                rebote = 0;
        }

        public void DireccionPelota()//Aquí definimos la dirección que va a seguir la pelota. Es decir, si x e y incrementan o decrementan
        {//Recordemos, lo que hacemos es sumar unidadPelota, y esta es la que vale 1 o -1 según vaya arriba, abajo (caso unidadYPelota), o derecha/izq
            switch(rebote)
            {
                case 1: //Invierte el desplazamiento en el eje horizontal
                    unidadXPelota *= -1;
                    break;
                case 2: // Invierte el desplazamiento en el eje vertical
                    unidadYPelota *= -1;
                    break;
                case 3: //Rebote contra esquinas (para que no se quede bloqueada, hay que considerar este caso como un particular, si no, lo detecta
                        //como un rebote lateral o vertical, invierte ese movimiento de eje pero no el otro. Indica moverse fuera de los márgenes
                        //establecidos y MoverA no lo hace. Por lo que la pelota se queda congelada en la esquina
                    unidadXPelota *= -1;
                    unidadYPelota *= -1;
                    break;
                //Esta parte del switch es para controlar los distintos rebotes según la parte de la nave donde golpee la pelota
                case 4: // Toca la nave en la parte izquierda (sale dirigida hacia la izquierda)
                    if (unidadXPelota == 0) // Si la pelota viene de un movimiento vertical, unidadXPelota vale 0 como incremental. Así que en lugar de
                        unidadXPelota -= 1; // invertir unidadPelota multiplicando por -1, le restamos 1 y obtenemos el -1 de incremental 
                    else if (unidadXPelota > 0)// Caso de que venga de un movimiento diagonal, invertimos el incremental solo si queremos que cambie de
                        unidadXPelota *= -1;   // dirección. Es decir, si viene de izq, invertimos, pues debe salir hacia izq. Si viene de derecha, que siga
                    unidadYPelota *= -1; //La dirección en el eje vertical siempre se invertirá
                    break;
                case 5: // Toca la nave en la parte derecha (sale dirigida hacia la derecha) Misma explicación que en el case 4
                    if (unidadXPelota == 0)
                        unidadXPelota += 1;
                    else if (unidadXPelota < 0)
                        unidadXPelota *= -1;
                    unidadYPelota *= -1;
                    break;
                case 6: //Toca la nave en la parte central (sale dirigida verticalmente hacia arriba, sin desplazamiento horizontal)
                    unidadXPelota = 0; //En este caso el incremental de desplazamiento de x valdrá 0
                    unidadYPelota *= -1;
                    break;
                case 7: //Vertical y esquina derecha
                    unidadXPelota += 1;
                    unidadYPelota *= -1;
                    break;
                case 8://Vertical y esquina izquierda
                    unidadXPelota -= 1;
                    unidadYPelota *= -1;
                    break;
                case 0: //No hay rebote, no hacemos nada
                    break;
                default:
                    break;
            }
        }
        /*
        -La nave ocupa 10 espacios, rebota hacia la izq en la parte izq, hacia la drch en la parte drch y recto vertical en caso de que toque centro
        Consideramos izquierda los 4 primeros espacios, centro los siguientes 2, y derecha los últimos 4 (izq-centro-drcha)(4-2-4)

        Aquí en ReboteNave() identificamos el tipo de rebote en la nave, según qué parte toque, tendrá un movimiento distinto.
        -El método devuelve un valor booleano, true si detecta rebote contra la nave.
        -Si detecta rebote, antes de devolver el valor bool, asigna un valor a la variable "reboteNave", que se lo daremos posteriormente
        a "rebote" para usarlo en el switch como índice y asignar el tipo de dirección a seguir
        
        Lo tratamos a parte porque el rebote en la nave es un caso particular, pues podría darse el caso de que viniese recta en el eje vertical
        sin desplazamiento horizontal. Así, unidadXPelota (nuestro incremental) vale 0, y si no consideramos este caso como particular, la respuesta
        sería intentar multiplicar por 1 o -1 según el lateral de la nave que toque, y el resultado sería 0. Rebotaría recta hacia arriba
        */
        public bool ReboteEnNave()
        {   //Una vez más, tenemos que controlar que rebote en "esquina", en este caso, formada por la nave pegada a la pared
            if((x == 0 && n.GetX() == 0 && y == n.GetY() + 1) || (x == 79 && n.GetX() == 70 && y == n.GetY() + 1))//Rebote en esquinas pared/nave
            {
                SetReboteNave(3);//Asignamos el tipo de rebote que procede
                return true;
            }
            else if ((x == n.GetX() || x == n.GetX() + 1 || x == n.GetX() + 2 || x == n.GetX() + 3) && y == n.GetY() - 1)// Rebote en parte izq de la nave
            {
                SetReboteNave(4); //Rebota en la parte izq, debe irse a la izq. 
                return true;              
            }                       
            else if ((x == n.GetX() + 4 || x == n.GetX() + 5) && y == n.GetY() - 1)//Rebote parte central de la nave, rebota recta hacia arriba
            {
                SetReboteNave(6);
                return true;
            }

            else if ((x == n.GetX() + 6 || x == n.GetX() + 7 || x == n.GetX() + 8 || x == n.GetX() + 9) && y == n.GetY() - 1)//Rebote parte drch nave
            {
                SetReboteNave(5);
                return true;
            }
            else if(x == n.GetX() - 1 && y == n.GetY() - 1) //He decidido considerar el caso en el que la pelota de en la equina
            {                                               //de la nave. En parte porque no me gustaba que atravesara la nave (visualmente se veía)
                if(unidadXPelota == 0)                                           // y porque el juego gana en coherencia y en jugabilidad
                {                                           //Esquina lateral izquierda de la nave
                    SetReboteNave(8);
                    return true;
                }
                SetReboteNave(3);                         
                return true;
            }
            else if (x == n.GetX() + 10 && y == n.GetY() - 1) //Esquina lateral derecha de la nave
            {                                               
                if (unidadXPelota == 0)                                           
                {
                    SetReboteNave(7);
                    return true;
                }
                SetReboteNave(3);
                return true;
            }
            else if((x == n.GetX() - 1 || x == n.GetX() + 10) && y == n.GetY()) //Caso de que choque con el lateral de la nave. La pelota está condenada
            {                                                               // pero queda mejor que rebote a que atraviese la nave. Hacemos la nave sólida
                SetReboteNave(1);
                return true;
            }
            else
                return false;
           
        }
        /*
        Golpes con ladrillo:
        -En GolpeLadrillo detectamos si hay golpe y sumamos un punto
        -En GolpeLadrillo llamamos por un lado a un método para ver si hay golpe por arriba o por abajo; y por otro lado vemos si golpea por los lados; 
        -Si lo hay, se devuelve true y se suma puntuación
        -En los métodos concretos de arriba/abajo y laterales vemos si la pelota toca el ladrillo, identificamos qué ladrillo toca, y le asignamos a ese
        ladrillo la variable bool "roto" como "true", así, no se dibujará, ni la pelota chocará contra él.

        */


        public bool GolpeLadrillo() //Aquí controlamos si golpea un ladrillo, mandamos bool y sumamos un punto
        {


            if (GolpeLadrilloLateral() == true)//Si lo golpea por el lado
            {
                SetReboteLadrillo(1);//
                puntuacion += 50;
                return true;
            }
            else if (GolpeLadrilloInferiorSuperior() == true) //Si lo golpea por arriba o por abajo, suma un punto y manda true
            {
                SetReboteLadrillo(2);//
                puntuacion += 50;
                return true;
            }
            else if (GolpeLadrilloEsquina() == true) //Si lo golpea por la esquina (estamos en una cuadrícula, y la pelota se mueve en diagonal, por lo
            {                        //que hay que controlar todos los espacios del entorno. En un cuadrado, serían 8.
                puntuacion += 50;       //He considerado lo mejor hacer que si da en una esquina del ladrillo (esto solo es posible si el inmediato está
                return true;         // roto) la pelota cambie su dirección 180º (vuelve por donde ha venido)
            }
            else
                return false;
        }
        //Para detectar si toca un ladrillo consideraremos su posición x, y su posición y+1 (para que lo toque, y no se meta dentro)
        public bool GolpeLadrilloInferiorSuperior() //Detectamos si se ha tocado un ladrillo
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (((x == ladrillos1[i, j].GetX() && ladrillos1[i, j].GetRoto() == false) || //si el bool fuera true, no rebotaría contra él
                        (x == ladrillos1[i, j].GetX() + 1 && ladrillos1[i, j].GetRoto() == false) ||
                        (x == ladrillos1[i, j].GetX() + 2 && ladrillos1[i, j].GetRoto() == false) ||
                        (x == ladrillos1[i, j].GetX() + 3 && ladrillos1[i, j].GetRoto() == false) ||
                        (x == ladrillos1[i, j].GetX() + 4 && ladrillos1[i, j].GetRoto() == false) ||
                        (x == ladrillos1[i, j].GetX() + 5 && ladrillos1[i, j].GetRoto() == false) ||
                        (x == ladrillos1[i, j].GetX() + 6 && ladrillos1[i, j].GetRoto() == false) ||
                        (x == ladrillos1[i, j].GetX() + 7 && ladrillos1[i, j].GetRoto() == false))
                        && (y == ladrillos1[i, j].GetY() + 1 || y == ladrillos1[i, j].GetY() - 1))//No consideramos la "y" del ladrillo, sino
                    {                                                                             //la superior o inferior
                        ladrillos1[i, j].SetNGolpes(); //Si ha tocado un ladrillo, le restamos un golpe a la cantidad de golpes que soporta
                        if (ladrillos1[i, j].GetNGolpes() == 0) //Si el ladrillo tiene el contador de golpes a 0, lo indicamos como roto ("roto == true")
                            ladrillos1[i, j].SetRoto(true);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool GolpeLadrilloLateral()//Controlamos el gope por el lateral. El truco está en controlar con valores de x inmediatos de los bloques
        {                                   // y tener en cuenta que el movimiento de la pelota no sea recto vertical, para asegurarnos de que los rompe
            for (int i = 0; i < 4; i++)     //porque los golpea, no solo porque pasa por al lado
            {
                for (int j = 0; j < 10; j++)
                {
                    if (((x == ladrillos1[i, j].GetX() - 1 && ladrillos1[i, j].GetRoto() == false) ||
                        (x == ladrillos1[i, j].GetX() + 8 && ladrillos1[i, j].GetRoto() == false))
                        && (y == ladrillos1[i, j].GetY() && unidadXPelota != 0))
                    {
                        ladrillos1[i, j].SetNGolpes();
                        if (ladrillos1[i, j].GetNGolpes() == 0)
                            ladrillos1[i, j].SetRoto(true);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool GolpeLadrilloEsquina()//Controlar el rebote adecuado en caso que la pelota golpee la esquina, ya sea viniendo de un movimiento con
        {                                   //desplazamiento de x e y, o solo de y (recto vertical)
            for (int i = 0; i < 4; i++)     
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((x == ladrillos1[i, j].GetX() - 1 && ladrillos1[i, j].GetRoto() == false)//Parte izquierda del ladrillo
                        && (y == ladrillos1[i, j].GetY() + 1 || y == ladrillos1[i,j].GetY() -1 ))
                    {
                        ladrillos1[i, j].SetNGolpes();//Restamos un golpe
                        if (unidadXPelota == 0 && y == ladrillos1[i, j].GetY() + 1)//Si la pelota golpea la esquina inferior izquierda viniendo recta vertical
                            SetReboteLadrillo(8);//Esquina inferior izquierda
                        else if (unidadXPelota == 0 && y == ladrillos1[i, j].GetY() - 1)//Si la pelota golpea la esquina superior izquierda viniendo recta vertical
                            SetReboteLadrillo(8);//Esquina superior izquierda
                        else if (unidadXPelota > 0 && unidadYPelota > 0)//Caso golpee esquina lateral izquierda viniendo diagonal desde arriba
                            SetReboteLadrillo(1);
                        else
                            SetReboteLadrillo(3);//Si la pelota golpea una esquina lateral izquierda viniendo de forma diagonal, y desde abajo
                        if (ladrillos1[i, j].GetNGolpes() == 0)//Si el contador de golpes está a cero, ladrillo roto
                            ladrillos1[i, j].SetRoto(true);
                        return true;
                    }
                    else if ((x == ladrillos1[i, j].GetX() + 8 && ladrillos1[i, j].GetRoto() == false)//Parte derecha del ladrillo
                        && (y == ladrillos1[i, j].GetY() + 1 || y == ladrillos1[i, j].GetY() - 1))
                    {
                        ladrillos1[i, j].SetNGolpes();
                        if (unidadXPelota == 0 && y == ladrillos1[i, j].GetY() + 1)//Si la pelota golpea la esquina inferior derecha viniendo recta vertical
                            SetReboteLadrillo(7);//Esquina inferior derecha
                        else if (unidadXPelota == 0 && y == ladrillos1[i, j].GetY() - 1)//Si la pelota golpea la esquina superior derecha viniendo recta vertical
                            SetReboteLadrillo(7);//Esquina superior derecha
                        else if (unidadXPelota < 0 && unidadYPelota > 0)//Si golpea esquina lateral derecha viniendo diagonal desde arriba
                            SetReboteLadrillo(1);
                        else
                            SetReboteLadrillo(3);//Si la pelota golpea una esquina lateral derecha viniendo de forma diagonal desde abajo
                        if (ladrillos1[i, j].GetNGolpes() == 0)
                            ladrillos1[i, j].SetRoto(true);
                        return true;
                    }
                }
            }
            return false;
        }


        //Aquí controlamos que si la pelota choca con una esquina formada por ladrillo y pared consola, rebota bien y destruye ladrillo
        //Recordemos que las esquinas merecían un trato especial en la forma de rebote
        public bool EsquinaFilaLadrillos()
        {
            if (x == 0 && y == 1 + 1 && ladrillos1[0, 0].GetRoto() == false)
            {
                ladrillos1[0, 0].SetRoto(true);
                return true;
            }
            else if (x == 0 && y == 2 + 1 && ladrillos1[1, 0].GetRoto() == false)
            {
                ladrillos1[1, 0].SetRoto(true);
                return true;
            }
            else if (x == 0 && y == 3 + 1 && ladrillos1[2, 0].GetRoto() == false)
            {
                ladrillos1[2, 0].SetRoto(true);
                return true;
            }
            else if (x == 0 && y == 4 + 1 && ladrillos1[3, 0].GetRoto() == false)
            {
                ladrillos1[3, 0].SetRoto(true);
                return true;
            }
            else if (x == 79 && y == 1 + 1 && ladrillos1[0, 9].GetRoto() == false)
            {
                ladrillos1[0, 9].SetRoto(true);
                return true;
            }
            else if (x == 79 && y == 2 + 1 && ladrillos1[1, 9].GetRoto() == false)
            {
                ladrillos1[1, 9].SetRoto(true);
                return true;
            }
            else if (x == 79 && y == 3 + 1 && ladrillos1[2, 9].GetRoto() == false)
            {
                ladrillos1[2, 9].SetRoto(true);
                return true;
            }
            else if (x == 79 && y == 4 + 1 && ladrillos1[3, 9].GetRoto() == false)
            {
                ladrillos1[3, 9].SetRoto(true);
                return true;
            }
            else
                return false;
        }
        
    }
}
