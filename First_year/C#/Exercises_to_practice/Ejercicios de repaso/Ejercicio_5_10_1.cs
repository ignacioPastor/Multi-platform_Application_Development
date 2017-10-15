// (5.10.1) Crea una función que calcule el valor de elevar un número entero a otro número entero
// (por ejemplo, 5 elevado a 3 = 53 = 5 ·5 ·5 = 125). Esta función se debe crear de forma recursiva.
// Piensa cuál será el caso base (qué potencia se puede calcular de forma trivial) y cómo pasar del
//  caso "n-1" al caso "n" (por ejemplo, si sabes el valor de 54, cómo hallarías el de 55 a partir de él).

using System;
public class Ejercicio_5_10_1
{
	public static int CalcularPotencia(int nBas, int nExp)
	{
		if(nExp==1)
			return nBas;
		return nBas*CalcularPotencia(nBas, nExp-1);
	}
	public static void Main()
	{
		int nBase, nExponente;
		
		Console.WriteLine("Introduce la base");
		nBase=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce el exponente");
		nExponente=Convert.ToInt32(Console.ReadLine());
		
		Console.WriteLine("{0} elevado a {1} da {2}", nBase, nExponente, CalcularPotencia(nBase, nExponente));
		
	}
}
