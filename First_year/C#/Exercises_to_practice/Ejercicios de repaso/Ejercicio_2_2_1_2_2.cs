// (2.2.1.2.2) Crea un programa que escriba en pantalla los números
// pares del 26 al 10 (descendiendo), usando "while".

using System;
public class Ejercicio_2_2_1_2_2
{
	public static void Main()
	{
		int n=26;
		while (n>=10)
		{
			Console.Write(n+ " ");
			n=n-2;
		}
		Console.WriteLine();
	}
}
