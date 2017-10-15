// (4.2.3) Un programa que pregunte al usuario el tamaño que tendrán dos
// bloques de números enteros (por ejemplo, uno de 10 elementos y otro de 12).
// Luego pedirá los datos para ambos bloques de datos.
// Finalmente deberá mostrar el mayor dato que se ha introducido en cada uno de ellos.

using System;
public class Ejercicio_4_2_3
{
	public static void Main()
	{
		try
		{
			byte tamanyo1, tamanyo2;
			int mayor;
			
			Console.WriteLine("Introduce el tamaño del primer bloque de números");
			tamanyo1=Convert.ToByte(Console.ReadLine());
			Console.WriteLine("Introduce el tamaño del segundo bloque de números");
			tamanyo2=Convert.ToByte(Console.ReadLine());
			
			int[][] numeros = new int [2][];
			numeros[0] = new int [tamanyo1];
			numeros[1] = new int [tamanyo2];
			
			
			for (byte i = 0; i < numeros.Length; i++)
			{
				for (byte j = 0; j < numeros[i].Length; j++)
				{
					Console.WriteLine("Introduce un número entero para almacenarlo en el bloque {0}, posición {1}", i, j);
					numeros[i][j]=Convert.ToInt32(Console.ReadLine());
				}
			}
			
			Console.WriteLine("Los datos introducidos son:");
			for (byte i = 0; i < numeros.Length; i++)
			{
				for (byte j = 0; j < numeros[i].Length; j++)
				{
					Console.WriteLine("{0}.{1}  {2}", i, j, numeros[i][j]);
				}
			}
			
			Console.WriteLine("El mayor dato introducido en cada uno de ellos es:");
			for (byte i = 0; i < numeros.Length; i++)
			{
				mayor=numeros[i][0];
				for (byte j = 0; j < numeros[i].Length; j++)
				{
					if(mayor<numeros[i][j])
						mayor=numeros[i][j];
				}
				Console.WriteLine("En el bloque {0} el número mayor es {1}", i, mayor);
			}
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
