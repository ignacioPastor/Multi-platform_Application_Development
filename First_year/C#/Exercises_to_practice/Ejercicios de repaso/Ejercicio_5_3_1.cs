// (5.3.1) Crea una función "DibujarCuadrado" que dibuje en pantalla un cuadrado del ancho (y alto)
// que se indique como parámetro. Completa el programa con un Main que permita probarla.

using System;
public class Ejercicio_5_3_1
{
	public static void DibujarCuadrado(byte lado)
	{
		for (byte i = 0; i < lado; i++)
		{
			for(byte j=0; j<lado; j++)
			{
				Console.Write("*");
			}
			Console.WriteLine();
		}
	}
	public static void Main()
	{
		byte ladoUsuario;
		
		Console.WriteLine("Introduce el tamaño del lado del cuadrado");
		ladoUsuario=Convert.ToByte(Console.ReadLine());
		DibujarCuadrado(ladoUsuario);
	}
}
