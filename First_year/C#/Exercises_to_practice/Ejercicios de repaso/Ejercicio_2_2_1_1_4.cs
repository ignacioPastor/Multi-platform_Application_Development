// (2.2.1.1.4) Crea una versión mejorada del programa anterior, que,
// tras introducir cada par de números, responderá si el primero es
// múltiplo del segundo, o el segundo es múltiplo del primero,
// o ninguno de ellos es múltiplo del otro.

using System;
public class Ejercicio_2_2_1_1_4
{
	public static void Main()
	{
		int n1, n2;
		
		Console.WriteLine("Introduce un número (0 si quieres salir del programa)");
		n1=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce otro número (0 si quieres salir del programa)");
		n2=Convert.ToInt32(Console.ReadLine());
		
		while(n1!=0&&n2!=0)
		{
			if (n1%n2==0)
				Console.WriteLine("{0} es múltiplo de {1}", n1, n2);
			else if (n2%n1==0)
				Console.WriteLine("{0} es múltiplo de {1}", n2, n1);
			else Console.WriteLine("Ninguno de los dos es múltiplo del otro");

			Console.WriteLine("Introduce un número (0 si quieres salir del programa)");
			n1=Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Introduce otro número (0 si quieres salir del programa)");
			n2=Convert.ToInt32(Console.ReadLine());
		}
	}
}
