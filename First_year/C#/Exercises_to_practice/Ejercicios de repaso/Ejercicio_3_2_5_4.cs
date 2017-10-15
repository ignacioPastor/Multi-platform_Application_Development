
// (3.2.5.4) Calcula la superficie y el volumen de una esfera, a partir
// de su radio (superficie = 4 * pi * radio al cuadrado;
// volumen = 4/3 * pi * radio al cubo). Usa datos "doble"
// y muestra los resultados con 5 cifras decimales.

using System;
public class Ejercicio_3_2_5_4
{
	public static void Main()
	{
		double radio, superficie, pi=Math.PI, volumen;
		
		Console.WriteLine("Introduce el valor del radio de la esfera");
		radio=Convert.ToDouble(Console.ReadLine());
		
		superficie=4*pi*Math.Pow(radio, 2);
		volumen=4/3*pi*Math.Pow(radio, 3);
		
		Console.WriteLine("La superficie de la esfera es {0}u2", superficie.ToString("N5"));
		Console.WriteLine("El volumen de la esfera es {0}u3", volumen.ToString("0.00000"));
	}
}
