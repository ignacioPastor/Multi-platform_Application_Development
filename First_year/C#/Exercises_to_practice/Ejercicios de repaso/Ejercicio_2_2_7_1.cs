// (2.2.7.1) Crea un programa que muestre las letras de la Z (mayúscula)
// a la A (mayúscula, descendiendo).

using System;
public class Ejercicio_2_2_7_1
{
	public static void Main()
	{
		for(char i='Z'; i>='A'; i--)
			Console.Write("{0} ", i);
		Console.WriteLine();
	}
}
