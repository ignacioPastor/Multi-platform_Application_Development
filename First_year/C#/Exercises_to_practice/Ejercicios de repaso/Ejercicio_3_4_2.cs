// (3.4.2) Crear un programa que pida al usuario un nombre y una contraseña.
// La contraseña se debe introducir dos veces. Si las dos contraseñas no
// son iguales, se avisará al usuario y se le volverán a pedir las dos contraseñas.

using System;
public class Ejercicio_3_4_2
{
	public static void Main()
	{
		try
		{
			string nombre, contrasenya1, contrasenya2;
			
			Console.WriteLine("Introduce un nombre");
			nombre=Console.ReadLine();
			
			do
			{
				Console.WriteLine("Introduce una contraseña");
				contrasenya1=Console.ReadLine();
				Console.WriteLine("Vuelve a introducir la contraseña");
				contrasenya2=Console.ReadLine();
				if(contrasenya1!=contrasenya2)
					Console.WriteLine("No coinciden");
			}
			while(contrasenya1!=contrasenya2);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
