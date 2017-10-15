// (2.2.7.2) Crea un programa que muestre 5 veces las letras de la L
// (mayúscula) a la N (mayúscula), en la misma línea, empleando dos
// "for" anidados.

using System;
public class Ejercicio_2_2_7_2
{
	public static void Main()
	{
		for(int i=0; i<5; i++)
		{
			for(char j='L'; j<='N'; j++)
				Console.Write(j);
			Console.WriteLine();
		}
	}
}
