// (3.1.2.2) Pide al usuario dos números de dos cifras ("byte"),
// calcula su multiplicación, que se deberá guardar en un "int",
// y muestra el resultado en pantalla.

using System;
public class Ejercicio_3_1_2_2
{
	public static void Main()
	{
		byte n1, n2;
		int resultado;
		
		Console.WriteLine("Introduce un número de dos cifras");
		n1=Convert.ToByte(Console.ReadLine());
		Console.WriteLine("Introduce otro número de dos cifras");
		n2=Convert.ToByte(Console.ReadLine());
		resultado=n1*n2;
		Console.WriteLine("El resultado de multiplicar {0} por {1} es {2}", n1, n2, resultado);
	}
}
