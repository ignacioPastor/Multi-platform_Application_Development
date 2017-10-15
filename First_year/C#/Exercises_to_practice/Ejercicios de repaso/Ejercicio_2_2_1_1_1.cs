// (2.2.1.1.1) Crea un programa que pida al usuario su contraseña
// (numérica). Deberá terminar cuando introduzca como contraseña el número
// 1111, pero volvérsela a pedir tantas veces como sea necesario.

using System;
public class Ejercicio_2_2_1_1_1
{
	public static void  Main()
	{
		int contrasenya;
		
		Console.WriteLine("Introduzca su contraseña");
		contrasenya=Convert.ToInt32(Console.ReadLine());
		
		while (contrasenya != 1111)
		{
			Console.WriteLine("Contraseña no válida, vuelva a introducirla");
			contrasenya=Convert.ToInt32(Console.ReadLine());
		}
	}
}
