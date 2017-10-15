// Practica Evaluable Tema2
// Ejercicio 5

using System;
public class PracT2_E5
{
	public static void Main()
	{
		int peso=0, anyoNacimiento=0;
		string nombre;
		bool pesoBool=false, anyoBool=false;
		
		try
		{
			Console.WriteLine("Dime tu año de nacimiento");
			anyoNacimiento=Convert.ToInt32(Console.ReadLine());
			anyoBool=true;
			Console.WriteLine("Dime tu peso");
			peso=Convert.ToInt32(Console.ReadLine());
			pesoBool=true;
		}
		catch(FormatException)
		{
			Console.WriteLine("Debes introducir un valor numérico válido");
		}
		
		Console.WriteLine("Dime tu nombre");
		nombre=Console.ReadLine();
		
		if(!anyoBool)
			Console.WriteLine("Nacisste en ??, pesas ??kg y te llamas {0}", nombre);
		else if(!pesoBool)
			Console.WriteLine("Naciste en {0}, pesas ??kg y te llamas {1}", anyoNacimiento, nombre);
		else Console.WriteLine("Naciste en {0}, pesas {1}kg y te llamas {2}", anyoNacimiento, peso, nombre);
	}
}
