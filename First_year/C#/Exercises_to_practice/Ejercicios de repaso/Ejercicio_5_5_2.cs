// (5.5.2) Crea una función "EscribirTablaMultiplicar", que reciba como parámetro un número entero,
// y escriba la tabla de multiplicar de ese número (por ejemplo, para el 3 deberá llegar desde "3x0=0" hasta "3x10=30").

using System;
public class Ejercicio_5_5_2
{
	public static void  EscribirTablaMultiplicar(int numero)
	{
		for (byte i = 0; i <= 10; i++)
		{
			Console.WriteLine("{0}x{1}={2}",numero, i, numero*i);
		}
		
	}
	public static void Main()
	{
		int nUsuario;
		
		Console.WriteLine("Introduce el número entero cuya tabla de multiplicar quieres ver");
		nUsuario=Convert.ToInt32(Console.ReadLine());
		
		Console.WriteLine();
		EscribirTablaMultiplicar(nUsuario);
		Console.WriteLine();
		
	}
}
