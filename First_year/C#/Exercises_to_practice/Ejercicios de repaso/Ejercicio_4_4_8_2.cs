// (4.4.8.2) Un programa que pida al usuario cinco frases,
// las guarde en un array y muestre la "mayor" de ellas.

using System;
public class Ejercicio_4_4_8_2
{	
	public static void Main()
	{
		string[] frase = new string[5];
		string mayor;
		
		for (byte i=0; i<5; i++)
		{
			Console.WriteLine("Introduce la frase número {0}", i+1);
			frase[i]=Console.ReadLine();
		}
		
		mayor=frase[0];
		for (byte i = 1; i < 5; i++)
		{
			if(frase[i].ToUpper().CompareTo(mayor.ToUpper())>0)
				mayor=frase[i];
		}
		Console.WriteLine("La frase mayor es \"{0}\"", mayor);
		
	}
}
