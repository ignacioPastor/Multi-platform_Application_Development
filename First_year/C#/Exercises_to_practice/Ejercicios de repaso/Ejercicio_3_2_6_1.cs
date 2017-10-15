
//(3.2.6.1) Crea un programa que pida números (en base 10) al usuario
// y muestre su equivalente en sistema binario y en hexadecimal.
// Debe repetirse hasta que el usuario introduzca el número 0.

using System;
public class Ejercicio_3_2_6_1
{
	public static void Main()
	{
		short nDecimal;
		
		do
		{
			Console.WriteLine("Introduce un número en base decimal");
			Console.WriteLine("Pulsa 0 para salir del programa");
			nDecimal=Convert.ToInt16(Console.ReadLine());
			
			if(nDecimal==0)
				continue;
			
			Console.WriteLine("El número en base decimal {0} equivale a {1} en binario y a {2} en hexadecimal", nDecimal, Convert.ToString(nDecimal,2), Convert.ToString(nDecimal,16));
		}
		while(nDecimal!=0);
	}
}
