// (2.1.5.9) Crea un programa que pida al usuario tres números
// y muestre cuál es el mayor de los tres.

using System;
public class Ejercicio_2_1_5_9
{
	public static void Main()
	{
		int n1, n2, n3;
		
		Console.WriteLine("Introduce un número");
		n1=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce otro número");
		n2=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce el último número");
		n3=Convert.ToInt32(Console.ReadLine());
		
		if (n1>=n2&&n1>=n3)
			Console.WriteLine("{0} es el número mayor", n1);
		else if (n2>n1&&n2>=n3)
			Console.WriteLine("{0} es el número mayor", n2);
		else if (n3>n2&&n3>n2)
			Console.WriteLine("{0} es el número mayor", n3);
	}
}
