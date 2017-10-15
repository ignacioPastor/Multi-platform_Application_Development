// (4.4.6.1) Una variante del ejercicio 4.4.5.1 (buscar textos en un array de frases),
// que no distinga entre mayúsculas y minúsculas a la hora de buscar.

using System;
public class Ejercicio_4_4_6_1
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
				if(frases[i].ToUpper().Contains(textoBuscar.ToUpper()))
				{
					Console.WriteLine("Sí que está almacenado");
					aparece=true;
					Console.WriteLine("Está en la frase número {0} en la posición {1}", i+1, frases[i].ToUpper().IndexOf(textoBuscar.ToUpper()));
				}
			}
			if(!aparece)
				Console.WriteLine("No está almacenado");
			
		}
		while (textoBuscar!="Fin");
	}
}
