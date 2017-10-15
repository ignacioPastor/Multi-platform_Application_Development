// (2.2.1.2.3) Crea un programa calcule cuantas cifras tiene un número
// entero positivo (pista: se puede hacer dividiendo varias veces entre 10).

using System;
public class Ejercicio_2_2_1_2_3
{
	public static void Main()
	{
		int numero, contador=1;
		
		Console.WriteLine("Introduce un número entero positivo para calcular cuántas cifras tiene");
		numero=Convert.ToInt32(Console.ReadLine());
		
		while(numero>10)
		{
			numero=numero/10;
			contador++;
		}
		Console.WriteLine("El número introducido tiene {1} cifras", contador);
	}
}
