// (2.2.14.1) Crea un programa que escriba los números del 1 al 10,
// separados por un espacio, sin avanzar de línea. No puedes usar "for",
// ni "while", ni "do..while", sólo "if" y "goto".

using System;
public class Ejercicio_2_2_14_1
{
	public static void Main()
	{
		int i=1;
		repetir:
		if(i<=10)
		{
			Console.Write("{0} ", i);
			i++;
			goto repetir;
		}
		Console.WriteLine();
	}
}
