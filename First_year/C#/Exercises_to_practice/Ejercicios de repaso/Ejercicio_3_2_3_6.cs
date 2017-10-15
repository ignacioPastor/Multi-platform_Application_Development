// (3.2.3.6) Crea un programa que "dibuje" la gráfica de y = (x-5)2 para
// valores de x entre 1 y 10. Deberá hacerlo dibujando varios espacios
// en pantalla y luego un asterisco. La cantidad de espacios dependerá
// del valor obtenido para "y". Te será fácil si dibujas la gráfica
// "girada", de forma que los valores de "y" crezcan hacia la derecha.

using System;
public class Ejercicio_3_2_3_6
{
	public static void Main()
	{
		int y;
		

		
		
		
		for(byte x=1; x<=10; x++)
		{
			y=(x-5)*(x-5);
			for(byte j=0; j<y; j++)
			{
				if(j<y-1)
					Console.Write(" ");
				else Console.Write("*");
			}
			Console.WriteLine();
		}
	}
}
