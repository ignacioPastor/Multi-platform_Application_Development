// (2.2.10.1) Crea un programa que pida al usuario dos números y escriba
// su máximo común divisor (pista: una solución lenta pero sencilla es
// probar con un "for" todos los números descendiendo a partir del menor
// de ambos, hasta llegar a 1; cuando encuentres un número que sea divisor
// de ambos, interrumpes la búsqueda con "break").

using System;
public class Ejercicio_2_2_10_1
{
	public static void Main()
	{
		int n1, n2, menor;
		
		Console.WriteLine("Introduce un número");
		n1=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce el segundo número");
		n2=Convert.ToInt32(Console.ReadLine());
		
		if(n1>n2)
			menor=n2;
		else menor=n1;
		
		for(int i=menor; i>0; i--)
		{
			if(n1%i==0&&n2%i==0)
				Console.WriteLine("El máximo común divisor de {0} y {1} es {2}", n1, n2, i);
			break;
		}
	}
}
