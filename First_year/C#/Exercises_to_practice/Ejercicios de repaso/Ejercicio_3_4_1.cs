// (3.4.1) Crear un programa que pida al usuario su nombre, y le diga
// "Hola" si se llama "Juan", o bien le diga "No te conozco"
// si teclea otro nombre.

using System;
public class Ejercicio_3_4_1
{
	public static void Main()
	{
		string nombre;
		
		Console.WriteLine("Dime tu nombre");
		nombre=Console.ReadLine();
		
		if(nombre=="Juan")
			Console.WriteLine("Hola");
		else Console.WriteLine("No te conozco");
	}
}
