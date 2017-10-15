// (2.1.3.1) Crea un programa que multiplique dos números enteros de la
// siguiente forma: pedirá al usuario un primer número entero. Si el número
// que se que teclee es 0, escribirá en pantalla "El producto de 0 por cualquier
// número es 0". Si se ha tecleado un número distinto de cero, se pedirá al
// usuario un segundo número y se mostrará el producto de ambos.

using System;
public class Ejercicio_2_1_3_1
{
	public static void Main()
	{
		Console.WriteLine("Introduce el primer número de la multiplicación");
		int n1=Convert.ToInt32(Console.ReadLine());
		if (n1==0)
			Console.WriteLine("El producto de 0 por cualquier número es 0");
		else
		{
			Console.WriteLine("Introduce el segundo número");
			int n2=Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("El producto de {0} y {1} es {2}", n1, n2, n1*n2);
		}
	}
}
