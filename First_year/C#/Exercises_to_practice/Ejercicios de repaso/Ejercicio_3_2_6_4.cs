// (3.2.6.4) Crea un programa que pida números binarios al usuario
// y muestre su equivalente en sistema hexadecimal y en decimal.
// Debe repetirse hasta que el usuario introduzca la palabra "fin".

// NO HE CONSEGUIDO HACER ESTE EJERCICIO

using System;
public class Ejercicio_3_2_6_4
{
	public static void Main()
	{
		int nBinario;
		int nDecimal;
		
		Console.WriteLine("Introduce un número binario");
		nBinario=Convert.ToInt32(Console.ReadLine())	;
		
		nDecimal=Convert.ToInt32("nBinario",2);
		
		Console.WriteLine("El número binario {0} equivale a {1} en base decimal", nBinario, nDecimal);
	}
}
