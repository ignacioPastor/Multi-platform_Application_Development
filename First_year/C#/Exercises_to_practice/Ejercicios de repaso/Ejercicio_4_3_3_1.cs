// (4.3.3.1) Amplia el programa 4.3.2.1, para que el campo "duración" se
// almacene como minutos y segundos, usando un "struct" anidado que
// contenga a su vez estos dos campos.


using System;
public class Ejercicio_4_3_2_1
{
	struct tiempo
	{
		public byte minutos;
		public byte segundos;
	}
	struct datosCancion
	{
		public string artista;
		public string titulo;
		public tiempo duracion;
		public uint tamanyo;
	}
	public static void Main()
	{
		try
		{
			datosCancion[] cancion = new datosCancion[100];
			byte opcion, cantidad=0;
			string textoBuscar;
			bool encontrado;
			
			do
			{
				Console.WriteLine("Menú. Indica que acción quieres realizar");
				Console.WriteLine("1. Añadir una nueva canción");
				Console.WriteLine("2. Mostrar el título de todas las canciones");
				Console.WriteLine("3. Buscar la canción que contenga un cierto texto, en el artista o en el título");
				Console.WriteLine("0. Salir del programa");
				opcion=Convert.ToByte(Console.ReadLine());
				
				switch(opcion)
				{
					case 1: // 1. añadir una nueva canción
						Console.WriteLine("Introduce el nombre del artista");
						cancion[cantidad].artista=Console.ReadLine();
						Console.WriteLine("Introduce el titulo de la canción");
						cancion[cantidad].titulo=Console.ReadLine();
						Console.WriteLine("Introduce la duración de la canción, primero los minutos");
						cancion[cantidad].duracion.minutos=Convert.ToByte(Console.ReadLine());
						Console.WriteLine("Introduce ahora los segundos");
						cancion[cantidad].duracion.segundos=Convert.ToByte(Console.ReadLine());
						Console.WriteLine("Introduce el tamaño del fichero en Kb");
						cancion[cantidad].tamanyo=Convert.ToUInt32(Console.ReadLine());
						cantidad++;
						break;
					
					case 2: // 2. mostrar el título de todas las canciones
						for (byte i = 0; i < cantidad; i++)
						{
							Console.WriteLine("{0}. {1}", i+1, cancion[i].titulo);
						}
						break;
					
					case 3: // 3. buscar la canción que contenga un cierto texto (en el artista o en el título).
						encontrado=false;
						Console.WriteLine("Introduce el texto que quieres buscar");
						textoBuscar=Console.ReadLine();
						for (byte i = 0; i < cantidad; i++)
						{
							if(textoBuscar==cancion[i].artista||textoBuscar==cancion[i].titulo)
							{
								Console.WriteLine("{0}. Artista: {1}; Titulo: {2}.", i+1, cancion[i].artista, cancion[i].titulo);
								encontrado=true;
							}	
						}
						if(!encontrado)
							Console.WriteLine("No se ha encontrado el artista o título que buscas");							
						break;
					
					case 0: // Salir del programa
						break;
					
					default:
						Console.WriteLine("Debes indicar una opción entre 0-3");
						break;
				}
			}
			while(opcion!=0);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
