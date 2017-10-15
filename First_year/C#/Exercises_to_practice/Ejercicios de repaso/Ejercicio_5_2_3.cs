// (5.2.3) Descompón en funciones la base de datos de ficheros (ejemplo 04_06a),
// de modo que el "Main" sea breve y más legible (Pista: las variables que se
// compartan entre varias funciones deberán estar fuera de todas ellas,
// y deberán estar precedidas por la palabra "static").

using System;
public class Ejercicio_5_2_3
{
	static int numeroFichas=0;
	static int i;
	static int opcion;
	static string textoBuscar;
	static long tamanyoBuscar;
	static tipoFicha[] fichas = new tipoFicha[1000];
	
	struct tipoFicha
	{
		public string nombreFich;
		public long tamanyo;
	}
	
	public static void MostrarMenu()
	{
		Console.WriteLine();
		Console.WriteLine("Escoja una opción:");
		Console.WriteLine("1.- Añadir datos de un nuevo fichero");
		Console.WriteLine("2.- Mostrar los nombres de todos los ficheros");
		Console.WriteLine("3.- Mostrar ficheros por encima de un cierto tamaño");
		Console.WriteLine("4.- Ver datos de un fichero");
		Console.WriteLine("5.- Salir");
	}
	public static void AnyadirDatoNuevo()
	{
		if (numeroFichas < 1000) // Si queda hueco
		{
			Console.WriteLine("Introduce el nombre del fichero: "); 
			fichas[numeroFichas].nombreFich = Console.ReadLine();
			Console.WriteLine("Introduce el tamaño en KB: ");
			fichas[numeroFichas].tamanyo = Convert.ToInt32( Console.ReadLine() );
			
			numeroFichas++;
		}
		else
			Console.WriteLine("Maximo de fichas alcanzado (1000)!");
	}
	public static void MostrarTodos()
	{
		for (i=0; i<numeroFichas; i++)
			Console.WriteLine("Nombre: {0}; Tamaño: {1} KB", fichas[i].nombreFich, fichas[i].tamanyo);
	}
	public static void MostrarSegunTamanyo()
	{
		Console.WriteLine("¿A partir de que tamaño quieres ver?");
		tamanyoBuscar = Convert.ToInt64( Console.ReadLine() );
		for (i=0; i<numeroFichas; i++)
			if (fichas[i].tamanyo >= tamanyoBuscar)
				Console.WriteLine("Nombre: {0}; Tamaño: {1} KB", fichas[i].nombreFich, fichas[i].tamanyo);
	}
	public static void VerTodosDatosUnFichero()
	{
		Console.WriteLine("¿De qué fichero quieres ver todos los datos?");
		textoBuscar = Console.ReadLine();
		for (i=0; i<numeroFichas; i++)
			if ( fichas[i].nombreFich == textoBuscar )
				Console.WriteLine("Nombre: {0}; Tamaño: {1} KB", fichas[i].nombreFich, fichas[i].tamanyo);
	}
	
	public static void Main()
	{
		

		
		do
		{
			MostrarMenu();
			opcion = Convert.ToInt32( Console.ReadLine() );
			
			switch(opcion)
			{
				case 1: AnyadirDatoNuevo(); break;
				case 2: MostrarTodos(); break;
				case 3: MostrarSegunTamanyo(); break;
				case 4: VerTodosDatosUnFichero(); break;
				case 5: // Avisamos de que salimos del programa
					Console.WriteLine("Fin del programa");
					break;
				default: //Otra opcion: no válida
					Console.WriteLine("Opción desconocida!");
					break;
			}
		}
		while (opcion != 5);
	}
}
