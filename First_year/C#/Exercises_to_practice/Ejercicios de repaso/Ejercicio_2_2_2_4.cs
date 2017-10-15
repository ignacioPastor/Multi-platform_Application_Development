// (2.2.2.4) Crea un programa que pida al usuario su identificador
// y su contraseña (ambos numéricos), y no le permita seguir hasta que
// introduzca como identificador "1234" y como contraseña "1111".

using System;
public class Ejercicio_2_2_2_4
{
	public static void Main()
	{
		int identificador=1234, contrasenya=1111, identi, contra;
		
		do
		{
			Console.WriteLine("Introduzca su identificador");
			identi=Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Introduzca su contraseña");
			contra=Convert.ToInt32(Console.ReadLine());
		}
		while(identi!=identificador||contra!=contrasenya);
		
		
	}
}
