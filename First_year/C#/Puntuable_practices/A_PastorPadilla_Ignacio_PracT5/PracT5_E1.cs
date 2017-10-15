
// Ignacio Pastor Padilla - Practica Tema 5 - Programación - DAM Semipresencial

using System;

public class PracT5_E1
{
	public static int Menu() // Funcion para Menú
	{
		int opcion=0;
		
		do // Con este do/while hacemos que se repita el menú mientras el usuario no introduzca un número que se corresponda con una opción
		{
			try // Usamos un try/catch por si el usuario nos ingresa un valor no numérico
			{
				Console.WriteLine("Menú.");
				Console.WriteLine("1. Calcular una potencia");
				Console.WriteLine("2. Calcular un factorial");
				Console.WriteLine("3. Calcular una raíz cuadrada");
				Console.WriteLine("4. Calcular la serie de Fibobacci");
				Console.WriteLine("5. Salir");
				opcion=Convert.ToInt32(Console.ReadLine());
			}
			catch (Exception errorEncontrado)
			{
				Console.WriteLine("Ha habido un error: {0}", errorEncontrado.Message);
			}
		}
		while (opcion>5||opcion<1);	
			
			return opcion; // Devolvemos el valor de la opción elegida por el usuario
	}
	public static void CalcularPotencia() //Función para calcular la potencia
	{
		int nBase=0, nExponente=0;
		bool formatoCorrecto=false;
		
		do // Con un do/while repetimos la petición de valores si el usuario introduce un valor no válido
		{
			try // Controlamos que el usuario introduzca un valor no válido
			{
				Console.WriteLine("Introduce la base de la potencia");
				nBase=Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Introduce el exponente de la potencia");
				nExponente=Convert.ToInt32(Console.ReadLine());
				formatoCorrecto=true;
			}
			catch (Exception errorEncontrado)
			{
				Console.WriteLine("Ha habido un error: {0}", errorEncontrado.Message);
			}
		}
		while (!formatoCorrecto);
		
		Console.WriteLine("La potencia de {0} elevado a {1} es {2}", nBase, nExponente, Math.Pow(nBase, nExponente));
		
	}
	public static int Factorial(int n) // Función para calcular el Factorial. Función recursiva
	{
		if (n==1) // Que corte el bucle recursivo cuando llegue a 1
			return 1;
		
		return n * Factorial(n-1);		
	}
	public static void CalcularRaiz() // Función para calcular raíz cuadrada
	{
		double nRaiz;
		bool formatoCorrecto=false;
		
		do // Con un do/while repetimos la petición de valores si el usuario introduce un valor no válido
		{
			try // Controlamos que el usuario introduzca un valor no válido
			{
				Console.WriteLine("Introduce el número del que quieras calcular la raíz cuadrada");
				nRaiz=Convert.ToInt32(Console.ReadLine());
				if (nRaiz<0)
					Console.WriteLine("Tienes que introducir un número positivo");
				else
				{
					Console.WriteLine("La raíz cuadrada de {0} es {1}", nRaiz, Math.Sqrt(nRaiz));
					formatoCorrecto=true;
				}
			}
			catch (Exception errorEncontrado)
			{
				Console.WriteLine("Ha habido un error: {0}", errorEncontrado.Message);
			}
		}
		while (!formatoCorrecto);
	}
	public static int Fibonacci(int n) // Función recursiva para calcular un número en la serie Fibonacci
	{
		if (n==1||n==2)
			return 1;
			
		return Fibonacci(n-1)+Fibonacci(n-2);	
	}
	
	public static void Main() // Main del Programa
	{
		int opcion, nFactorial, nFibonacci;
		bool formatoCorrecto=false;
		
		do // Con este do/while no saldremos del programa hasta no introducir esa petición expresa
		{
			opcion=Menu(); // Primero llamamos al menú para preguntar al usuario qué quiere hacer y lo guardamos en "opcion"
			switch (opcion)
			{
				case 1: // Potencial
					CalcularPotencia();
					break;
				
				case 2: //Factorial
					do // Con un do/while repetimos la petición de valores si el usuario introduce un valor no válido
					{
						try // Controlamos que el usuario introduzca un valor no válido
						{
							Console.WriteLine("Introduce el numero del que quieres calcular el factorial");
							nFactorial=Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("El factorial de {0} es {1}", nFactorial, Factorial(nFactorial));
							formatoCorrecto=true;
						}
						catch (Exception errorEncontrado)
						{
							Console.WriteLine("Ha habido un error: {0}", errorEncontrado.Message);
						}
					}
					while (!formatoCorrecto);
					formatoCorrecto=false; // Devolvemos el booleano a su valor original antes de salir por si el usuario vuelve a esta opción, que no se mantenga activo
					break;
					
				case 3: // Raíz Cuadrada
					CalcularRaiz();
					break;
				
				case 4:// Posición número serie Fibonacci
					do // Con un do/while repetimos la petición de valores si el usuario introduce un valor no válido
					{
						try // Controlamos que el usuario introduzca un valor no válido
						{
							Console.WriteLine("Introduce la posición del número que quieres saber de la serie de Fibonacci");
							nFibonacci=Convert.ToInt32(Console.ReadLine());
							if (nFibonacci<=0)
								Console.WriteLine("Tienes que introducir un número entero mayor que 0");
							else
							{
								Console.WriteLine("El número que ocupa la posición {0} en la serie de Fibonacci es {1}", nFibonacci, Fibonacci(nFibonacci));	
								formatoCorrecto=true;
							}
						}
						catch (Exception errorEncontrado)
						{
							Console.WriteLine("Ha habido un error: {0}", errorEncontrado.Message);
						}
					}
					while (!formatoCorrecto);
					formatoCorrecto=false;	//Devolvemos el booleano a su valor original antes de salir por si el usuario vuelve a esta opción, que no se mantenga activo	
					break;
					
				case 5:
					break;	
			}
		}
		while (opcion != 5);
	}
}
