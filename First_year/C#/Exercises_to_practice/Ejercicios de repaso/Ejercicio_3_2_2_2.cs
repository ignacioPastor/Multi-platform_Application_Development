// (3.2.2.2) Calcula el área de un círculo, dado su radio,
// que será un número entero (área = pi * radio al cuadrado)

using System;
public class Ejercicio_3_2_2_2
{
	public static void Main()
	{
		float area, pi=3.1416f;
		int radio;
		
		Console.WriteLine("Introduce el radio del círculo (número entero)");
		radio=Convert.ToInt32(Console.ReadLine());
		
		area=pi*(radio*radio);
		Console.WriteLine("El área es {0}", area);
	}
}
