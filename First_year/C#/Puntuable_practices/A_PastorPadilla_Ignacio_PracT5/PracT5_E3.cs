
// Ignacio Pastor Padilla - Practica Tema 5 - Programación - DAM Semipresencial

using System;

public class PracT5_E3
{
	public static char[] GenerarCombinacion() // Función para generar una combinación
	{
		
		char[] simbolos = {'*','+','$','@','%','&','#'}; //Creamos un array definido con los valores que ya conocemos de antemano
		Random generador = new Random(); // Creamos un generador Random
		int aleatorio, contador=0;
		
		char[] combinacion = new char [4]; // Creamos un array de char definido, pues sabemos que solo va a necesitar 4 espacios
		do
		{
			aleatorio=generador.Next(0,7); //Generamos un número aleatorio entre 0 y 6
			for (int i=0; i<=contador; i++) // Con un for asignamos al array que almacenará la combinación a adivinar, unos datos aleatorios
			{
				if (simbolos[aleatorio]==combinacion[i]) //Comprobamos si el símbolo está ya en nuestra combinación para que no se repita
					break;
				else if (i==contador)
				{
					combinacion[i]=simbolos[aleatorio]; // Rellenamos nuestro array de forma aleatoria con los símbolos establecidos
					contador++;
					break;
				}
			}
		}
		while (contador<4);
		return combinacion;
	}
	public static bool ComparaCombinacion(char[]combinacion, char[]combinacionUsuario, out char[]respuesta) // Función para comprobar si hemos acertado
	{
		respuesta= new char[4];
		bool acierto=false;
		bool encontrado=false;
		int contadorAciertos=0;
		for (int i=0; i<combinacionUsuario.Length; i++)
			{
				for (int j=0; j<combinacion.Length && !encontrado; j++)
				{
					if (combinacion[j]==combinacionUsuario[i])
					{
						encontrado=true;
						if (i==j)
						{
							respuesta[i]='o';
							contadorAciertos++;
						}
						else
							respuesta[i]='x';
					}
					else if (j==combinacion.Length-1)
						respuesta[i]='-';
					
					
				}
				encontrado=false;
				Console.Write(respuesta[i]+ " ");
			}
			Console.WriteLine();
			if (contadorAciertos==4)
			{
				Console.WriteLine("Enhorabuena, lo has acertado!");
				acierto=true;
			}
			return acierto;
			
	}
	
	public static void Main() // Cuerpo del programa
	{
		char[] combinacion;
		bool acierto=false;
		
		int intentos=10;
		string lecturaUsuario;
		string continuar;
		string[] lecturaArray = new string [4];
		char[] combinacionUsuario = new char [4];
		char[] respuesta = new char [4];
		bool salir=false;
		
		do //Para que se repita en caso de que el usuario quiera seguir jugando al terminar una partida
		{	
			intentos=10;
			combinacion = GenerarCombinacion();
			
			do // para que se repita mientras queden intentos o mientras no se acierte la respuesta
			{
				Console.WriteLine("Introduce tu combinación"); // Pedimos al usuario su combinación y la leemos
				lecturaUsuario=Console.ReadLine();
				lecturaArray=lecturaUsuario.Split(' '); //Con Split creamos un array con los datos. Es un Array de String
				
				for (int i=0; i<lecturaArray.Length; i++)
				{
					combinacionUsuario[i]=Convert.ToChar(lecturaArray[i]); //Pasamos los datos a un array de Char
				}
				
				Console.WriteLine();
				acierto=ComparaCombinacion(combinacion, combinacionUsuario, out respuesta); // Llamamos a la función de comparar combinación
				
				intentos--;
				Console.WriteLine("Intentos restantes: {0}", intentos);
			}
			while (!acierto&&intentos>0);
			
			Console.WriteLine("Quieres jugar de nuevo? (S/N)");// Finalmente preguntamos al usuario si quiere jugar otra partida
			continuar=Console.ReadLine();
			if(continuar.ToUpper()=="S")
				salir=false;
			else
				salir=true;
		}
		while (!salir);
	}
	
	
}
