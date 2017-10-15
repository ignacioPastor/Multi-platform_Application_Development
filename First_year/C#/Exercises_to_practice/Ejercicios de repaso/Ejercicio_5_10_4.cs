// (5.10.4) Crea un programa que emplee recursividad para calcular la suma de los elementos de un vector de números enteros,
// desde su posición inicial a la final, usando una función recursiva que tendrá la apariencia: SumaVector(v, desde, hasta).
// Nuevamente, piensa cuál será el caso base (cuántos elementos podrías sumar para que dicha suma sea trivial) y cómo pasar
// del caso "n-1" al caso "n" (por ejemplo, si conoces la suma de los 6 primeros elementos y el valor del séptimo elemento,
// cómo podrías emplear esta información para conocer la suma de los 7 primeros).

using System;
public class Ejercicio_5_10_4
{
	public static int SumaVector(int[] vector, int desde, int hasta)
	{
		
		if(desde==hasta)
			return vector[desde];
		else
			return SumaVector(vector, desde+1, hasta) + vector[desde];
	
	}
	
	public static void Main()
	{
		try
		{
			int suma;
			int[] numeros = {2, 7, 4, 9, 1, 4, 10}; //37
			
			suma=SumaVector(numeros, 0, numeros.Length-1);
			Console.WriteLine("El resultado de la suma del vector es {0}", suma);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
		
	}
	
}
