// (2.2.2.1) Crear un programa que pida números positivos al usuario,
// y vaya calculando y mostrando la suma de todos ellos
// (terminará cuando se teclea un número negativo o cero).

using System;
public class Ejercicio_2_2_2_1
{
	public static void Main()
	{
		int total=0, numero;
		
		do
		{
			Console.WriteLine("Total={0}.", total);
			Console.WriteLine("Introduce un número positivo para sumarselo al total");
			numero=Convert.ToInt32(Console.ReadLine());
			
			total=total+numero;
		
		}
		while(numero>0);
	}
}
