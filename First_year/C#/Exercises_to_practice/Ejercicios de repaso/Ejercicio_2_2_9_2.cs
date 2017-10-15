// (2.2.9.2) Crea un programa que pida al usuario dos números y escriba
// sus divisores comunes. Debes usar llaves en todas las estructuras de
// control, aunque sólo incluyan una sentencia.

using System;
public class Ejercicio_2_2_9_2
{
	public static void Main()
	{
		int n1, n2, menor;
		
		Console.WriteLine("Introduce un número");
		n1=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce un segundo número");
		n2=Convert.ToInt32(Console.ReadLine());
		
		if(n1>n2)
		{
			menor=n2;
		}
		else
		{
			menor=n2;
		}
		
		for(int i=1; i<=menor; i++)
		{
			if(n1%i==0&&n2%i==0)
			{
				Console.Write("{0} ", i);
			}
		}
		Console.WriteLine();
	}
}
