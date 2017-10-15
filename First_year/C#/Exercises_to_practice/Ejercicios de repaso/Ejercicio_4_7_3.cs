// (4.7.3) Un programa que pida al usuario varios números, los vaya añadiendo a un array,
// mantenga el array ordenado continuamente y muestre el resultado tras añadir cada nuevo dato
// (todos los datos se mostrarán en la misma línea, separados por espacios en blanco).
// Terminará cuando el usuario teclee "fin".

using System;
public class Ejercicio_4_7_3
{
	public static void Main()
	{
		int[] numeros = new int[100];
		int cantidad=0, datoTemporal;
		string lectura;
		
		do
		{
			Console.WriteLine("Introduce un número. Teclee \"fin\" para salir del programa.");
			lectura=Console.ReadLine();
			
			if(lectura!="fin")
			{
				numeros[cantidad]=Convert.ToInt32(lectura);
				cantidad++;
				for (byte i = 0; i < cantidad-1; i++)
				{
					for (int j = i+1; j < cantidad; j++)
					{
						if(numeros[i]>numeros[j])
						{
							datoTemporal=numeros[j];
							numeros[j]=numeros[i];
							numeros[i]=datoTemporal;
						}
					}
				}
				
				for(byte i=0; i<cantidad; i++)
				{
					Console.Write("{0} ", numeros[i]);
				}
				Console.WriteLine();
			}
		}
		while(lectura!="fin");
	}
}
