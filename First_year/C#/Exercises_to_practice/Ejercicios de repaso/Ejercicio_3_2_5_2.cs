
// (3.2.5.2) Crea un programa que use tres variables x,y,z. Las tres
// serán números reales, y nos bastará con datos de simple precisión.
// Se deberá pedir al usuario los valores para las tres variables y
// mostrar en pantalla el valor de x2 + y - z (con exactamente dos
// cifras decimales).

using System;
public class Ejercicio_3_2_5_2
{
	public static void Main()
	{
		float x, y, z, resultado;
		
		Console.WriteLine("Introduce el valor de la variable \"x\"");
		x=Convert.ToSingle(Console.ReadLine());
		Console.WriteLine("Introduce el valor de la variable \"y\"");
		y=Convert.ToSingle(Console.ReadLine());
		Console.WriteLine("Introduce el valor de la variable \"y\"");
		z=Convert.ToSingle(Console.ReadLine());
		
		resultado=x*x+y-z;
		Console.WriteLine("El resultado de x2+y-z con los valores dados es {0}", resultado.ToString("N2"));
	}
}
