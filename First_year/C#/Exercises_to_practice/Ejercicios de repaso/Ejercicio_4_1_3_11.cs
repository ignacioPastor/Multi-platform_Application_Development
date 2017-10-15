// (4.1.3.11) Un programa que pida al usuario 4 números enteros y calcule
// (y muestre) cuál es el mayor de ellos. Nota: para calcular el mayor
// valor de un array, hay que comparar cada uno de los valores que tiene
// almacenados el array con el que hasta ese momento es el máximo provisional.
// El valor inicial de este máximo provisional no debería ser cero
// (porque el resultado sería incorrecto si todos los números son negativos),
// sino el primer elemento del array. Mira el apartado 4.1.4 para más detalles.

using System;
public class Ejercicio_4_1_3_11
{
	public static void Main()
	{
		try
		{
			short[] numeros = new short[4];
			short mayor;
			
			for (byte i = 0; i < 4; i++)
			{
				Console.WriteLine("Introduce el número de la posición {0}", i+1);
				numeros[i]=Convert.ToInt16(Console.ReadLine());
			}
			mayor=numeros[0];
			for (byte i = 1; i < 4; i++)
			{
				mayor= mayor>numeros[i] ? mayor:numeros[i];
			}
			Console.WriteLine("El número mayor de los introducidos es {0}", mayor);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
