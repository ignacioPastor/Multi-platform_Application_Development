// (4.2.2) Un programa que pida al usuario dos bloques de 6 cadenas de texto.
// Después pedirá al usuario una nueva cadena y comprobará si aparece en
// alguno de los dos bloques de información anteriores.

using System;
public class Ejercicio_4_2_2
{
	public static void Main()
	{
		string[,] textos = new string [2,6];
		string textoBuscar;
		bool encontrado=false;

		for (byte i = 0; i < 2; i++)
		{
			for(byte j=0; j<6; j++)
			{
				Console.WriteLine("Introduce un texto");
				textos[i,j]=Console.ReadLine();
				
			}
		}
		
		Console.WriteLine("Los datos introducidos son:");
		for (byte i = 0; i < 2; i++)
		{
			for (byte j = 0; j < 6; j++)
			{
				Console.WriteLine("{0}.{1} {2}", i, j, textos[i,j]);
			}
		}
		
		do
		{
			encontrado=false;
			Console.WriteLine("Introduce un texto para buscar si está almacenado, escribe \"salir\" para salir del programa");
			textoBuscar=Console.ReadLine();
			for (byte i = 0; i < 2; i++)
			{
				for (byte j = 0; j < 6; j++)
				{
					if(textoBuscar==textos[i,j])
					{
						Console.WriteLine("{0}.{1} {2}", i, j, textos[i,j]);
						encontrado=true;
					}
				}
			}
			if(!encontrado)
				Console.WriteLine("El texto introducido no está almacenado");
		}	
		while(textoBuscar!="salir");
		
		
	}
}
