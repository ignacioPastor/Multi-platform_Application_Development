// (3.2.3.1) Calcula el volumen de una esfera, dado su radio, que será
// un número de doble precisión (volumen = pi * radio al cubo * 4/3)

using System;
public class Ejercicio_3_2_3_1
{
	public static void Main()
	{
		double volumen, radio;
		float pi=3.1416f;
		
		Console.WriteLine("Introduce el radio de la esfera");
		radio=Convert.ToDouble(Console.ReadLine());
		
		volumen=pi*(radio*radio*radio)*(4/3);
		Console.WriteLine("El volumen de la esfera con el radio dado es {0}", volumen);
	}
}
