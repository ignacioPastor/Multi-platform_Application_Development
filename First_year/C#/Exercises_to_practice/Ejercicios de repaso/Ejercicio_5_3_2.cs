// (5.3.2) Crea una función "DibujarRectangulo" que dibuje en pantalla un rectángulo
// del ancho y alto que se indiquen como parámetros. Incluye un Main para probarla.

using System;
public class Ejercicio_5_3_2
{
	public static void DibujarRectangulo(byte alto, byte ancho)
	{
		for (byte i = 0; i < alto; i++)
		{
			for(byte j=0; j<ancho; j++)
			{
				Console.Write("*");
			}
			Console.WriteLine();
		}
	}
	public static void Main()
	{
		byte altoUsuario, anchoUsuario;
		
		Console.WriteLine("Introduce el alto del rectángulo");
		altoUsuario=Convert.ToByte(Console.ReadLine());
		Console.WriteLine("Introduce el ancho del rectángulo");
		anchoUsuario=Convert.ToByte(Console.ReadLine());
		
		DibujarRectangulo(altoUsuario, anchoUsuario);
	}
}
