// (2.5.6) Crea un programa que calcule un número elevado a otro,
// usando multiplicaciones sucesivas.

using System;
public class Ejercicio_2_5_6
{
	public static void Main()
	{
		int numeroExponente, numeroBase, calculando=1;
		
		Console.WriteLine("Introduce la base del numero que quieres calcular");
		numeroBase=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce el exponente del número que quieres calcular");
		numeroExponente=Convert.ToInt32(Console.ReadLine());
		
		for(int i=0; i<numeroExponente;i++)
		{
			calculando=numeroBase*calculando;
		}
		Console.WriteLine(calculando);
	}
}
