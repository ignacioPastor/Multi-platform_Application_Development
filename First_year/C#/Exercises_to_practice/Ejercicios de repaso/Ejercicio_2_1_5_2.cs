// (2.1.5.2) Crea un programa que pida al usuario un número entero
// y responda si es múltiplo de 2 y de 3 simultáneamente.

using System;
public class Ejercicio_2_1_5_2
{
	public static void Main()
	{
		int numero;
		
		Console.WriteLine("Introduce un número");
		numero=Convert.ToInt32(Console.ReadLine());
		
		if (numero%2==0&&numero%3==0)
			Console.WriteLine("{0} es múltiplo de 2 y de 3", numero);
		else if (numero%2==0&&numero%3!=0)
			Console.WriteLine("{0} es múltiplo de 2 pero no de 3", numero);
		else if (numero%2!=0&&numero%3==0)
			Console.WriteLine("{0} es múltiplo de 3 pero no de 2", numero);
		else Console.WriteLine("{0} no es múltiplo de 2 ni de 3", numero);
	}
}
