// (2.2.11.2) Crea un programa que escriba los números pares del 2 al 106,
// excepto los que sean múltiplos de 10, usando "continue".

using System;
public class Ejercicio_2_2_11_2
{
	public static void Main()
	{
		for(int i=2; i<=106; i=i+2)
		{
			if(i%10!=0)
				Console.Write("{0} ", i);
		}
		Console.WriteLine();
	}
}
