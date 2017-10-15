// Practica Evaluable Tema2
// Ejercicio 1

using System;
public class PracT2_E1
{
	public static void Main()
	{
		string ciclo, asignatura;
		
		Console.WriteLine("Dime de qué ciclo estás matriculado:");
		ciclo=Console.ReadLine();
		
		if(ciclo=="DAM")
		{
			Console.WriteLine("Dime cuál es tu asignatura favorita");
			asignatura=Console.ReadLine();
			
			if(asignatura=="Programación")
				Console.WriteLine("Tú sí que sabes");
			else Console.WriteLine("Sí, esa tampoco está mal");			
		}
		else Console.WriteLine("Ese ciclo no lo conozco");	
	}
}
