// (2.1.5.1) Crea un programa que pida al usuario un número entero
// y responda si es múltiplo de 2 o de 3.

using System;
public class Ejercicio_2_1_5_1
{
	public static void Main()
	{
		int numero;
		
		Console.WriteLine("Introduce un número entero");
		numero=Convert.ToInt32(Console.ReadLine());
		
		if (numero%2==0)
			Console.WriteLine("{0} es múltiplo de 2", numero);
		else if (numero%3==0)
			Console.WriteLine("{0} es múltiplo de 3", numero);
		else Console.WriteLine("{0} no es múltiplo de 2 ni de 3", numero);
	}
}
