// (4.4.5.1) Un programa que pida al usuario 10 frases, las guarde en un array,
// y luego le pregunte textos de forma repetitiva, e indique si cada uno de esos textos
// aparece como parte de alguno de los elementos del array. Terminará cuando el texto introducido sea "fin".

using System;
public class Ejercicio_4_4_5_1
{
	public static void Main()
	{
		string[] frases = new string[10];
		string textoBuscar;
		bool aparece;
		
		for (byte i = 0; i < 3; i++)
		{
			Console.WriteLine("Introduce una frase");
			frases[i]=Console.ReadLine();
		}
		
		do
		{
			Console.WriteLine("Introduce un texto para buscar si aparece entre los almacenados en el array");
			Console.WriteLine("Escribre \"Fin\" para salir del programa");
			textoBuscar=Console.ReadLine();
			
			aparece=false;
			for (byte i = 0; i < 3; i++)
			{
				if(frases[i].Contains(textoBuscar))
				{
					Console.WriteLine("Sí que está almacenado");
					aparece=true;
					Console.WriteLine("Está en la frase número {0} en la posición {1}", i+1, frases[i].IndexOf(textoBuscar));
				}
			}
			if(!aparece)
				Console.WriteLine("No está almacenado");
			
		}
		while (textoBuscar!="Fin");
	}
}
