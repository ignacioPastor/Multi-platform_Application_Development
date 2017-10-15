// (4.2.1) Un programa que pida al usuario dos bloques de 10 números enteros
// (usando un array de dos dimensiones). Después deberá mostrar el mayor
// dato que se ha introducido en cada uno de ellos.

using System;
public class Ejercicio_4_2_1
{
	public static void Main()
	{
		try
		{
			short[,] numeros = new short[2,10];
			short mayor, jota=0;
			
			for (byte i = 0; i < 2; i++)
			{
				for (byte j = 0; j < 10; j++)
				{
					Console.WriteLine("Introduce en dato {0} del bloque {1}", j+1, i+1);
					numeros[i,j]=Convert.ToInt16(Console.ReadLine());
				}
				
			}
			
			Console.WriteLine("Los datos introducidos son: ");
			for (byte i = 0; i < 2; i++)
			{
				for(byte j=0; j<10; j++)
				{
					Console.WriteLine("{0}.{1}. {2}", i, j, numeros[i,j]);
				}
			}
			
			Console.WriteLine("El mayor dato introducido en cada uno de ellos es:");
			for (byte i = 0; i < 2; i++)
			{
				mayor=numeros[i,0];
				for(byte j=1; j<10; j++)
				{
					if(mayor<numeros[i,j])
					{
						mayor=numeros[i,j];
						jota=j;
					}
				}
				Console.WriteLine("{0}.{1}. {2}", i, jota, mayor);
			}
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
