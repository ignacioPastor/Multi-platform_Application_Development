// (5.7.1) Crea una función "Intercambiar", que intercambie el valor de los dos números
// enteros que se le indiquen como parámetro. Crea también un programa que la pruebe.

using System;
public class Ejercicio_5_7_1
{
	public static void Intercambiar(ref int n1, ref int n2)
	{
		int datoTemporal;
		
		datoTemporal=n1;
		n1=n2;
		n2=datoTemporal;
	}
	public static void Main()
	{
		int numero1, numero2;
		
		Console.WriteLine("Introduce un valor entero para a");
		numero1=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce un valor entero para b");
		numero2=Convert.ToInt32(Console.ReadLine());
		
		Intercambiar(ref numero1, ref numero2);
		
		Console.WriteLine("Ahora a vale {0} y b {1}", numero1, numero2);
	}
}
