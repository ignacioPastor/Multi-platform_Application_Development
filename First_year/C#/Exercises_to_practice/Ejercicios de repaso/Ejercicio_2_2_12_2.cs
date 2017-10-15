// (2.2.12.2) Crea un programa que escriba los números pares del 20 al 10,
// descendiendo, excepto el 14, primero con "for" y luego con "while".

using System;
public class Ejercicio_2_2_12_2
{
	public static void Main()
	{
		for(int i=20; i>=10; i=i-2)
		{
			if(i!=14)
				Console.Write("{0} ", i);
		}
		Console.WriteLine();
		
		int j=20;
		while(j>=10)
		{
			if(j!=14)
				Console.Write("{0} ", j);
			j=j-2;
		}
		Console.WriteLine();
	}
}
