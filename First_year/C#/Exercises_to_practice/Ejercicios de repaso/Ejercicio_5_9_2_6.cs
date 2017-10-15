// (5.9.2.6) Crea una función "Distancia", que calcule la distancia entre dos puntos
// (x1,y1) y (x2,y2), usando la expresión d = raíz [ (x1-x2)2 + (y1-y2)2 ].

using System;
public class Ejercicio_5_9_2_6
{
	public static double Distancia(int x1, int y1, int x2, int y2)
	{
		double d;
		
		d= Math.Sqrt((Math.Pow((x1-x2),2) + Math.Pow((y1-y2),2)));
		
		return d;
	}
	public static void Main()
	{
		Console.WriteLine(Distancia(3,5,7,8));
	}
}
