// Programa que pida al usuario una lista de películas separadas por guiones y después las 
// muestre ordenadas alfabéticamente, separadas, en mayúsculas, y con el eventual artículo al final

using System;
public class PracT4_E2
{
	public static void Main()
	{
		string pelicula, datoTemporal;
		Console.WriteLine("Introduce el título de las películas que quieres almacenar separadas por guiones");
		pelicula=Console.ReadLine();
		pelicula=pelicula.ToUpper(); // Pasamos a mayúsculas lo que introduce el usuario
		string[] peliculas = pelicula.Split('-'); // Hacemos un array
		
		try
		{
			for (byte i = 0; i < peliculas.Length; i++) // Ponemos los artículos al final
			{
				if(peliculas[i].Length>4)
				{
					if(peliculas[i].IndexOf("EL ", 0, 3)>=0)
					{
						peliculas[i]=peliculas[i].Remove(0, 3);
						peliculas[i]=peliculas[i].Insert(peliculas[i].Length, ", EL");
					}
					else if(peliculas[i].IndexOf("LA ", 0, 3)>=0)
					{
						peliculas[i]=peliculas[i].Remove(0, 3);
						peliculas[i]=peliculas[i].Insert(peliculas[i].Length, ", LA");
					}
					else if(peliculas[i].IndexOf("LO ", 0, 3)>=0)
					{
						peliculas[i]=peliculas[i].Remove(0, 3);
						peliculas[i]=peliculas[i].Insert(peliculas[i].Length, ", LO");
					}
					else if(peliculas[i].IndexOf("LAS ", 0, 4)>=0)
					{
						peliculas[i]=peliculas[i].Remove(0, 4);
						peliculas[i]=peliculas[i].Insert(peliculas[i].Length, ", LAS");
					}
					else if(peliculas[i].IndexOf("LOS ", 0, 4)>=0)
					{
						peliculas[i]=peliculas[i].Remove(0, 4);
						peliculas[i]=peliculas[i].Insert(peliculas[i].Length, ", LOS");
					}
				}
			}
			
			for (byte i = 0; i < peliculas.Length-1; i++) // Ordenamos el array
			{
				for (int j = i+1; j < peliculas.Length; j++)
				{
					if(peliculas[i].CompareTo(peliculas[j])>0)
					{
						datoTemporal=peliculas[i];
						peliculas[i]=peliculas[j];
						peliculas[j]=datoTemporal;
					}
				}
			}
			
			for (byte i = 0; i < peliculas.Length; i++) // Sacamos el resultado por pantalla
			{
				Console.WriteLine("{0}. {1}", i+1, peliculas[i]);
			}
	
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	
	}
}
