// (5.9.2.1) Crea un programa que halle (y muestre) la raíz cuadrada del
// número que introduzca el usuario. Se repetirá hasta que introduzca 0.

using System;
public class Ejercicio_5_9_2_1
{
	public static double CalcularRaiz(ref double n)
	{
		n=Math.Pow(n,2);
		return n;
	}
	public static void Main()
	{
		double numero=2;
		
		do
		{
			Console.WriteLine("Introduce un número para calcular su raíz cuadrada");
			Console.WriteLine("Pulsa \"0\" para salir del programa");
			try
			{
				numero=Convert.ToDouble(Console.ReadLine());
			
			if(numero==0)
				Console.WriteLine("Fin del programa");
			else
			{
				CalcularRaiz(ref numero);
				Console.WriteLine("La raíz cuadrada del número introducido es {0}", numero);
			}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		while (numero!=0);
	}
}
