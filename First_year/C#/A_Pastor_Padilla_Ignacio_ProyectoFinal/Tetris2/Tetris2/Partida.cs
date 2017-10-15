using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Ignacio Pastor Padilla - Proyecto Final Programación - 1º DAM Semipresencial - Grupo A


namespace Tetris2
{
    class Partida
    {
        public Partida()
        {
            TableroInicial(); // Desde el principio hacemos que el tablero tenga los bordes ya guardados.
        }
        
        Random r = new Random();
        List<Tetraedro> tablero; // El tablero será en realidad una lista de tetraedros
        Sprite s = new Sprite();
        Serializador se = new Serializador();
        Pieza p;
        GestionMovimiento gm = new GestionMovimiento();
        GestionGiro gg = new GestionGiro();
        PantallaFinal pf = new PantallaFinal();

        int puntuacion = 0;
        static int anchoTablero = 17; // Tamaño del tablero en el eje X. Variará según el nivel
        const int altoTablero = 22; // Tamaño del tablero en el eje Y. El tamaño vertical no variará.
        int xAparecer = anchoTablero / 2; // La posición en la que la pieza aparece dentro del tablero variará en función del anchoTablero
        const int yAparecer = 2;
        bool salir = false;
        bool modoCorrector = false; // Con F9 está la activar este booleano. Si true, se pasa de nivel a cada línea completada
        int nivel = 1;              // así será más fácil comprobar los pasos de niveles.
        bool acelerar = false;
        int contadorVueltas = 0; // Utilizaremos un contador de vueltas para que se haga un movimiento vertical por cada tres bucles
                                    // con esto conseguimos que la pieza se pueda mover lateralmente más rápido que verticalmente
        const string FICHERO_GUARDAR = "partidaGuardada.dat";
        const string FICHERO_GUARDAR_PIEZA = "piezaGuardada.dat";
        const string FICHERO_GUARDAR_PUNTUACION = "puntuacionGuardada.dat";
        const string FICHERO_GUARDAR_NIVEL = "nivelGuardado.dat";

        ConsoleKeyInfo tecla;

        // Método principal del juego. Aquí estará el bucle que gestiona el movimiento del juego.
        public void Lanzar()
        {
            AsignarPieza(); // Primero asignamos/creamos una pieza
            MeterPiezaEnTablero(); // La metemos en el tablero
            s.ImprimirTablero(tablero); // Imprimimos el tablero
            s.ImprimirPanel(puntuacion, nivel);// Imprimimos el panel

            do
            {
                // Con esto conseguimos que haya tres vueltas de bucle por cada movimiento hacia abajo.
                // Así se mejora la jugabilidad permitiendo mayor velocidad de desplazamiento lateral que vertical
                if (contadorVueltas == 2)
                {
                    contadorVueltas = 0;
                    if (gm.MoverPiezaAbajo(tablero, p) == false) // Cuando toca mover hacia abajo, no solo intentamos mover hacia abajo,
                        Contacto();                              // sino que en caso de no conseguirlo, lo sabemos gracias al metodo
                                                             // booleano que es MoverPiezaAbajo e indicamos que ha habido un contacto

                        // Caso de contacto en movimiento hacia      
                        // abajo habrá que dejar la pieza quita y sacar una nueva..
                    s.ImprimirPieza(p); // Volvemos a imprimir la pieza, ya sea porque se ha movido, o porque es una nueva pieza.
                }
                else
                    contadorVueltas++;
                if (Console.KeyAvailable) //  Si hay tecla disponible...
                {
                    tecla = Console.ReadKey(); // ... la leemos

                    if (tecla.Key == ConsoleKey.RightArrow) // Mover pieza a la derecha
                    {
                        gm.MoverPiezaDerecha(tablero, p);
                        s.ImprimirPieza(p); // Después de realizar un movimiento siempre volveremos a imprimir la pieza
                    }
                    else if (tecla.Key == ConsoleKey.LeftArrow) // Mover pieza a la izquierda
                    {
                        gm.MoverPiezaIzquierda(tablero, p);
                        s.ImprimirPieza(p);
                    }
                    else if (tecla.Key == ConsoleKey.Spacebar) // Rotar la pieza
                    {   // Antes de rotar borraremos la pieza
                        for (int i = 0; i < 4; i++)
                            s.BorrarTetraedro(p.Posicion[i]);

                        gg.GirarPieza(p, tablero);
                        s.ImprimirPieza(p);

                    }
                    else if (tecla.Key == ConsoleKey.DownArrow) // Acelerar el movimiento de la pieza
                    {
                        acelerar = true;
                    }
                    else if (tecla.Key == ConsoleKey.Escape) // Salir del juego
                    {
                        salir = true;
                    }
                    else if (tecla.Key == ConsoleKey.F10) // Pausar la partida
                    { 
                        s.Mensaje("Partida Pausada"); // Mostramos un mensaje por pantalla de partida pausada
                        Console.ReadKey(true); // Esperamos a que pulse una tecla para continuar
                        Console.Clear(); // Después tendremos que borrar la pantalla para eliminar el mensaje...
                        s.ImprimirTablero(tablero);// ... e imprimirlo todo de nuevo
                        s.ImprimirPanel(puntuacion, nivel);
                    }
                    else if (tecla.Key == ConsoleKey.F11) // Guardar la partida
                    {
                        Guardar(); // Por la cantidad de código, se ha preferiddo implementar el guardado en una función a parte
                    }
                    else if (tecla.Key == ConsoleKey.F12) // Cargar la partida
                    {
                        Cargar();
                    }
                    else if (tecla.Key == ConsoleKey.F9) // Modo corrector. Para que se pase de nivel cada línea completada
                    {                                    // y así simplificar la comprobación de pasos de nivel
                        ModoCorrector();
                    }
                }
                TiempoPausa(); // El tiempo de pausa entre vueltas de bucle dependerá del nivel y de si se ha acelerado el movimiento
                                // de esa pieza de forma temporal y voluntaria
            } while (salir == false);
            pf.PedirDatos(puntuacion); // Cuando salimos del bucle de la partida lanzamos la pantalla final pidiendo los datos.
        }
        // Asigna una nueva pieza a la variable (objeto) pieza que manejamos. Estrictamente, crea una nueva pieza.
        public void AsignarPieza()
        {
            int n = r.Next(0, 7); // La asignación será aleatoria. Con un random gestionamos una elección azarosa.
            switch(n)
            { // Creamos la nueva pieza con la implementación que haya tocado
                case 0:
                    p = new Cuadrado(xAparecer, yAparecer); // A la pieza le pasamos los valores x, y donde aparecerá.
                    break;                                  // servirá para montar la pieza entorno a esa posición relativa
                case 1:
                    p = new Palo(xAparecer, yAparecer);
                    break;
                case 2:
                    p = new Ele(xAparecer, yAparecer);
                    break;
                case 3:
                    p = new EleReves(xAparecer, yAparecer);
                    break;
                case 4:
                    p = new Zeta(xAparecer, yAparecer);
                    break;
                case 5:
                    p = new ZetaReves(xAparecer, yAparecer);
                    break;
                case 6:
                    p = new Te(xAparecer, yAparecer);
                    break;
            }
        }
        // Mete la pieza en la lista tablero. Con eso, aunque gestionemos la pieza desde el objeto pieza, ya estará dentro del tablero
        // preparando el momento de "dejarla abandonada" como parte del bloque de piezas. Que no existe propiamente, es el tablero.
        public void MeterPiezaEnTablero()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < tablero.Count; j++)
                { // Aquí detectaremos el Game Over. Es decir, si cuando va a aparecer una pieza ya hay otra en esa posición. Esto sería
                    if (p.Posicion[i].X == tablero[j].X && p.Posicion[i].Y == tablero[j].Y)//indicador de que el bloque de piezas ha 
                        salir = true;                                                   // llegado al máximo y la partida se ha acabado.
                }
                tablero.Add(p.Posicion[i]); // Si no hay otra pieza en la posición de aparición, añadimos la pieza al tablero
            }
        }
        // Da los valores por defecto al tablero. Es decir, los bordes en función del tamaño del tablero.
        // El tamaño del tablero variará en función del nivel
        public void TableroInicial()
        {
            tablero = new List<Tetraedro>();
            for (int i = 0; i < altoTablero; i++)
            {
                for (int j = 0; j < anchoTablero; j++)
                {
                    if (j == 0 || i == 0 || j == anchoTablero - 1 || i == altoTablero - 1)
                        tablero.Add(new Tetraedro(j, i, Tetraedro.Color.amarillo)); // Meteremos en el tablero los tetraedros que
                }                                               // conformarán los bordes. Tantos como el tamaño del tablero requiera
            }
        }
        // Se lanza cuando se detecta contacto en el movimiento hacia abajo.
        public void Contacto()
        {
            VerSiHayFilaCompleta();// Comprueba si hay una fila completa.
            AsignarPieza();// Crea y asigna una nueva pieza
            MeterPiezaEnTablero();//Mete la pieza en el tablero
            acelerar = false; // Desacelera el movimiento en caso de que el usuario haya decidido acelerarlo voluntariamente
        }
        // En función del nivel y de la voluntad del usuario, el tiempo de espera (la velocidad del desplazamiento de la pieza) variará
        public void TiempoPausa()
        {
            if (acelerar == false)
            {   // Cada nivel tiene una velocidad distinta
                switch (nivel)
                {
                    case 1: Thread.Sleep(200); break;
                    case 2: Thread.Sleep(160); break;
                    case 3: Thread.Sleep(120); break;
                    case 4: Thread.Sleep(80); break;
                    case 5: Thread.Sleep(40); break;
                }
            }
            else
                Thread.Sleep(20); // Velocidad máxima, cuando el usuario lo indica
        }
        //Comprueba si se ha completado una fila y gestiona su desaparición.
        // Recorre el tablero fila a fila, y cuenta cuántos tetraedros con esa posición Y (fila) hay.
        // En caso de que haya tantos tetraedros en esa fila como ancho es el tablero, tendremos una fila completa.
        public void VerSiHayFilaCompleta()
        {
            int contadorCuadradosPorFila;
            for (int i = altoTablero - 2 ; i >= 1; i--) // Obviamos la primera y última fila (bordes superior e inferior)
            {
                contadorCuadradosPorFila = 0; // Cada vez que pasemos a examinar una fila nueva ponemos el contador a 0
                for (int j = 0; j < tablero.Count; j++)
                {
                    if (tablero[j].Y == i)
                        contadorCuadradosPorFila++; //Por cada tetraedro que encontremos en esa fila, sumamo uno al contador
                }
                if (contadorCuadradosPorFila == anchoTablero) // Caso de fila completa (contador igual al ancho del tablero)
                {
                    puntuacion++; // Aumentamos la puntuación
                    ParpadeoFilaBorrar(i); //Lanzamos el efecto de parpadeo para la fila en cuestión
                    BorrarFila(i);// Borramos la fila completa
                    BajarFilas(i);// Bajamos el resto de filas
                    Console.Clear();// Borramos la pantalla e imprimimos el tablero y la puntuación
                    s.ImprimirTablero(tablero);
                    s.ImprimirPanel(puntuacion, nivel);
                    Thread.Sleep(500);
                    //Comprobamos si el aumento de puntuación conlleva un paso de nivel.
                    // Distinguimos aquí si estamos en modo corrector o no.
                    if (modoCorrector == false)
                        ComprobarPasoNivel();
                    else
                        ComprobarPasoNivelPruebas();
                    VerSiHayFilaCompleta();
                }
            }
        }
        // Borra una fila. Lo utilizaremos para borrar las líneas que están completas
        // Recorre el tablero y borra todos los tetraedros que tienen un valor Y del valor de la fila.
        // Exceptuamos los tetraedros que tengan color amarillo, éstos serán los bordes.
        public void BorrarFila(int fila)
        {
            bool borrado = false;
            for (int i = 0; i < tablero.Count; i++)
            {
                if (tablero[i].Y == fila && tablero[i].AColor != Tetraedro.Color.amarillo)
                {
                    tablero.RemoveAt(i);
                    borrado = true;
                }
            }
            if (borrado == true)
                BorrarFila(fila);
        }
        // Baja las filas a partir de una fila indicada
        // Lo utilizaremos para bajar las filas superiores a una fila completada y borrada
        // Recorre las filas superiores (con un menor valor de Y en los tetraedros) y reduce en uno el valor de Y de cada uno
        // Exceptuamos el caso de que el tetraedro sea amarillo, pues es un borde
        public void BajarFilas(int fila)
        {
            for (int i = 0; i < tablero.Count; i++)
            {
                if(tablero[i].AColor != Tetraedro.Color.amarillo && tablero[i].Y < fila)
                {
                    tablero[i].Y++;
                }
            }
        }
        // Efecto visual de parpadeo. Lo utilizaremos antes de borrar una fila completada
        // Recibe el valor Y que identifica la fila, y recorremos el tablero.
        // Cuando detecte un tetraedro con ese valor Y, le cambiará el color a rojo o negro, según proceda.
        // Hacemos un bucle de 5 vueltas, las pares la fila aparece como roja y las impares como negra (desaparece)
        public void ParpadeoFilaBorrar(int fila)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(22, 5 + fila);
                if (i % 2 == 0)
                    Console.BackgroundColor = ConsoleColor.Red;
                else
                    Console.BackgroundColor = ConsoleColor.Black;
                for (int j = 0; j < anchoTablero - 2; j++)
                {
                    
                    Console.Write("  ");
                }
                Thread.Sleep(200);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        // Comprueba si ha habido paso de nivel. En función de la puntuación actual, entra en la parte del if que corresponde.
        // Si el nivel no corresponde con el que debería tener con la puntuación actual mandamos mensaje de paso de nivel.
        // En todos los casos asignamos el nivel que corresponde a la puntuación
        public void ComprobarPasoNivel()
        {
            if (puntuacion >= 0 && puntuacion < 6)
                nivel = 1;
            else if (puntuacion >= 6 && puntuacion < 11)
            {
                if (nivel != 2) // Si es la primera vez que entra, en una franja de puntuación de un nuevo nivel.
                {
                    anchoTablero++; // En el nivel 2 el ancho del tablero varía
                    TableroInicial(); // Cuando varíe el ancho del tablero eliminaremos el bloque de piezas y empezaremos de nuevo.
                    PasoDeNivel(); 
                }
                nivel = 2; // Asignamos el nivel correspondiente
                s.ImprimirPanel(puntuacion, nivel); // Volvemos a imprimir el panel para actualizar la puntuación.
            }
            else if (puntuacion >= 11 && puntuacion < 16)
            {
                if (nivel != 3)
                    PasoDeNivel(); //
                nivel = 3;
                s.ImprimirPanel(puntuacion, nivel);
            }
            else if (puntuacion >= 16 && puntuacion < 21)
            {
                if (nivel != 4)
                    PasoDeNivel();
                nivel = 4;
                s.ImprimirPanel(puntuacion, nivel);
            }
            else if (puntuacion >= 21)
            {
                if (nivel != 5)
                {
                    nivel = 5; 
                    anchoTablero++; // En el último nivel también aumentará el tamaño del tablero
                    TableroInicial();
                    PasoDeNivel();
                }
                nivel = 5;
                s.ImprimirPanel(puntuacion, nivel);
            }
        }
        
        // Este método es igual que el anterior, pero pasa de nivel cada vez que se completa una línea. De esta forma, es más fácil comprobar el 
        // correcto funcionamiento de los pasos de nivel. Lo he utilizado al realizar el programa, y he pensado que podría ser útil para el corrector.
        public void ComprobarPasoNivelPruebas()
        {
            if (puntuacion == 0 && puntuacion < 1)
                nivel = 1;
            else if (puntuacion >= 1 && puntuacion < 2)
            {
                if (nivel != 2)
                {
                    anchoTablero++;
                    TableroInicial();
                    PasoDeNivel();
                }
                nivel = 2;
                s.ImprimirPanel(puntuacion, nivel);
            }
            else if (puntuacion >= 2 && puntuacion < 3)
            {
                if (nivel != 3)
                    PasoDeNivel();
                nivel = 3;
                s.ImprimirPanel(puntuacion, nivel);
            }
            else if (puntuacion >= 3 && puntuacion < 4)
            {
                if (nivel != 4)
                    PasoDeNivel();
                nivel = 4;
                s.ImprimirPanel(puntuacion, nivel);
            }
            else if (puntuacion >= 4)
            {
                if (nivel != 5)
                {
                    nivel = 5;
                    anchoTablero++;
                    TableroInicial();
                    PasoDeNivel();
                }
                nivel = 5;
                s.ImprimirPanel(puntuacion, nivel);
            }
        }
        // Caso de paso de nivel, enviamos un mensaje por pantalla
        public void PasoDeNivel()
        {
            if (nivel != 5)
                s.Mensaje("Enhorabuena, pasas de nivel!");
            else
                s.Mensaje("Entras en el último nivel!");
            Thread.Sleep(2000);
            Console.Clear();
            s.ImprimirTablero(tablero);
            s.ImprimirPanel(puntuacion, nivel);
        }
        // Guarda la partida.
        public void Guardar()
        {
            s.Mensaje("Guardando partida...");
            se.GuardarPartida(tablero, FICHERO_GUARDAR, p); // Guardamos el tablero
            MeterPiezaEnTablero(); // A la hora de guardar, sacamos la pieza del tablero. Tendremos que volver a meterla para seguir
                                    // jugando la partida que tenemos a medias. Esto es así porque no guardamos la pieza que está en juego
            se.GuardarEntero(puntuacion, FICHERO_GUARDAR_PUNTUACION); // Guardamos la puntuación
            se.GuardarEntero(nivel, FICHERO_GUARDAR_NIVEL);// Guardamos el nivel
            Thread.Sleep(1000);
            Console.Clear();
            s.ImprimirTablero(tablero);
            s.ImprimirPanel(puntuacion, nivel);
        }
        // Carga una partida anterior
        // Si se intenta cargar una partida sin que no haya una guardada, o que haya algún error
        // capturamos el error y lo ignoramos. No se carga la partida.
        public void Cargar()
        {
            s.Mensaje("Cargando partida...");
            try
            {
                tablero = se.CargarPartida(FICHERO_GUARDAR);
                puntuacion = se.CargarEntero(FICHERO_GUARDAR_PUNTUACION);
                nivel = se.CargarEntero(FICHERO_GUARDAR_NIVEL);
                AsignarPieza(); // Asignamos una nueva pieza (no se guarda la pieza en movimiento)
                MeterPiezaEnTablero();

            }
            catch { }
            Thread.Sleep(1000);
            Console.Clear();
            s.ImprimirTablero(tablero);
            s.ImprimirPanel(puntuacion, nivel);
        }
        // Para facilitar la corrección, se ha implementado un método para pasar de nivel más rápidamente.
        // Pulsando F9 entramos en una ventana donde se nos pregunta si queremos activarlo o desactivarlo
        public void ModoCorrector()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();

            for (int i = 0; i < 7; i++)
                Console.WriteLine();

            s.EscribirCentrado("Herramientas del Corrector");
            s.EscribirCentrado("Quieres que se pase de nivel cada vez que se complete una línea? (S/N)");
            string eleccion = Console.ReadLine();

            if (eleccion.ToUpper() == "S")
                modoCorrector = true;
            else
                modoCorrector = false;

            Console.Clear();
            s.ImprimirTablero(tablero);
            s.ImprimirPanel(puntuacion, nivel);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
