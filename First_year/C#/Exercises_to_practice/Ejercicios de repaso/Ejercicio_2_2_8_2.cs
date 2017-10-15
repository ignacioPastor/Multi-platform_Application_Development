// (2.2.8.2) Crea un programa que pida al usuario el ancho (por ejemplo, 4)
// y el alto (por ejemplo, 3) y escriba un rectángulo formado por esa
// cantidad de asteriscos, como en el ejercicio 2.2.6.2. Deberás usar las
// variables "ancho" y "alto" para los datos que pidas al usuario, y las
// variables "filaActual" y "columnaActual" (declaradas en el "for")
// para el bloque repetitivo.

using System;
public class Ejercicio_2_2_8_2
{
	public static void Main()
	{
		int ancho, alto;
		
		Console.WriteLine("Introduce el alto del rectángulo");
		alto=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce el ancho del rectángulo");
		ancho=Convert.ToInt32(Console.ReadLine());
		
		for(int filaActual=0; filaActual<alto; filaActual++)
		{
			for(int anchoActual=0; anchoActual<ancho; anchoActual++)
				Console.Write("*");
			Console.WriteLine();
		}
	}
}
