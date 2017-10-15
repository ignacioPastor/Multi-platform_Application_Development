// (2.6.2) Crea un programa que pregunte al usuario su edad y su año de
// nacimiento. Si la edad que introduce no es un número válido, mostrará
// un mensaje de aviso, pero aun así le preguntará su año de nacimiento.

using System;
public class Ejercicio_2_6_2
{
	public static void Main()
	{
		int anyoNacimiento=0;
		bool anyo = false;
		int edad=0;
		bool edadBool=false;
		
		try
		{
			Console.WriteLine("Introduzca su edad");
			edad=Convert.ToInt32(Console.ReadLine());
		}
		catch(Exception e)
		{
			Console.WriteLine("Valor no válido: {0}", e.Message);
			edadBool=true;
		}
		
		try
		{
			Console.WriteLine("Introduzca su año de nacimiento");
			anyoNacimiento=Convert.ToInt32(Console.ReadLine());
		}
		catch(FormatException)
		{
			Console.WriteLine("Valor no válido");
			anyo = true;
		}
		
		if(!anyo&&!edadBool)
			Console.WriteLine("Su año de nacimiento es {0} y su edad es {1}", anyoNacimiento, edad);
		else if(!anyo&&edadBool)
			Console.WriteLine("Su año de nacimiento es {0} y su edad es ??", anyoNacimiento);
		else if(anyo&&!edadBool)
			Console.WriteLine("Su año de nacimiento es ?? y su edad es {0}", edad);
		else Console.WriteLine("Su año de nacimiento es ?? y su edad es ??");
	}
}
