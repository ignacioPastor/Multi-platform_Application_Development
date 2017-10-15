// (3.1.2.3) Pide al usuario dos números enteros largos ("long")
// y muestra su suma, su resta y su producto.

using System;
public class Ejercicio_3_1_2_3
{
	public static void Main()
	{
		long n1, n2, suma, resta, producto;
		
		Console.WriteLine("Introduce un número entero largo");
		n1=Convert.ToInt64(Console.ReadLine());
		Console.WriteLine("Introduce otro número entero largo");
		n2=Convert.ToInt64(Console.ReadLine());
		
		suma=n1+n2;
		resta=n1-n2;
		producto=n1*n2;
		Console.WriteLine("La suma de {0} y {1} es {2}, la resta {3} y el producto {4}", n1, n2, suma, resta, producto);5
	}
}
