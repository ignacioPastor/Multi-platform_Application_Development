// (3.2.1.1) Crea un programa que muestre el resultado de dividir 3 entre 4,
// primero usando números enteros y luego usando números de coma flotante.

using System;
public class Ejercicio_3_2_1_1
{
	public static void Main()
	{
		int a=3, b=4;
		float resultI;
		float c=3, d=4, resultF;
		
		resultI=a/b;
		resultF=c/d;
		Console.WriteLine("3/4 con entreros da {0} y con reales {1}", resultI, resultF);
	}
}
