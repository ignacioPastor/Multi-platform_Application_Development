// (4.3.1.1) Crea un "struct" que almacene datos de una canción en formato
// MP3: Artista, Título, Duración (en segundos), Tamaño del fichero (en KB).
//Un programa debe pedir los datos de una canción al usuario, almacenarlos
// en dicho "struct" y después mostrarlos en pantalla.

using System;
public class Ejercicio_4_3_1_1
{
	struct datosCancion
	{
		public string artista;
		public string titulo;
		public ushort duracion;
		public ushort tamanyo;  
	}
	public static void Main()
	{
		try
		{
			datosCancion cancion;
			
			Console.WriteLine("Introduce el nombre del artista");
			cancion.artista=Console.ReadLine();
			Console.WriteLine("Introduce el título de la canción");
			cancion.titulo=Console.ReadLine();
			Console.WriteLine("Introduce la duración de la canción en segundos");
			cancion.duracion=Convert.ToUInt16(Console.ReadLine());
			Console.WriteLine("Introduce el tamaño del fichero en KB");
			cancion.tamanyo=Convert.ToUInt16(Console.ReadLine());
			
			Console.WriteLine("Artista: {0}; titulo: {1}; duracion {2}s; tamaño: {3}Kb", cancion.artista, cancion.titulo, cancion.duracion, cancion.tamanyo);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
