// (2.1.1.1) Crea un programa que pida al usuario un número entero y diga si es par
// (pista: habrá que comprobar si el resto que se obtiene al dividir entre dos es cero: if (x % 2 == 0) …).

using System;
public class Ejercicio_2_1_1_1
{
	public static void Main()
	{
		Console.WriteLine("Introduce un número entero");
		int numero=Convert.ToInt32(Console.ReadLine());
		if (numero%2==0)
			Console.WriteLine("El número que has introducido es par");
		else Console.WriteLine("El número no es par");
	}
}
