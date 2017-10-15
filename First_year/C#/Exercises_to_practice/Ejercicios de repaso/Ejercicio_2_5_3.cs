// (2.5.3) Haz un programa que dé al usuario la oportunidad de adivinar
// un número del 1 al 100 (prefijado en el programa) en un máximo de 6
// intentos. En cada pasada deberá avisar de si se ha pasado o se ha
// quedado corto.

using System;
public class Ejercicio_2_5_3
{
	public static void Main()
	{
		int numeroUsuario, intentos=6;
		do
		{
			Console.WriteLine("Intenta adivinar un número entre 1 y 100");
			numeroUsuario=Convert.ToInt32(Console.ReadLine());
			if(numeroUsuario!=68)
			{
				if(numeroUsuario>68)
					Console.WriteLine("Fallaste, eres lo peor. Has puesto un número demasiado alto. Te  quedan {0} intentos", intentos-1);
				else Console.WriteLine("Fallaste, eres lo peor. Has puesto un número demasiado bajo. Te  quedan {0} intentos", intentos-1);
			}
			else Console.WriteLine("Acertaste, eres un crack!");
			intentos--;
			if(intentos==0&&numeroUsuario!=68)
				Console.WriteLine("Lamentable, eres un perdedor");
		} while (numeroUsuario!=68&&intentos>0);
		
	}
}
