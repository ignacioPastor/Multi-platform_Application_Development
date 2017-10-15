// (5.4.2) Crea una función "Menor" que calcule el menor de dos números
// enteros que recibirá como parámetros. El resultado será otro número entero.

using System;
public class Ejercicio_5_4_2
{
	public static int Menor(int n1, int n2)
	{
		if(n1<n2)
			return n1;
		else
			return n2;

	}
	public static void Main()
	{
		int numero1, numero2;
		
		Console.WriteLine("Introduce un número");
		numero1=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce otro número");
		numero2=Convert.ToInt32(Console.ReadLine());
		
		Console.WriteLine("El menor de los números introducidos es {0}", Menor(numero1, numero2));
	}
}
