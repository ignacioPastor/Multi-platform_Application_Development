// (3.1.4.1) Crea un programa que use tres variables x,y,z.
// Sus valores iniciales serán 15, -10, 214. Deberás incrementar el valor
// de estas variables en 12, usando el formato abreviado.
// ¿Qué valores esperas que se obtengan? Contrástalo con el resultado
// obtenido por el programa.

using System;
public class Ejercicio_3_1_4_1
{
	public static void Main()
	{
		sbyte x=15, y=-10;
		short z=214;
		
		x+=12;
			Console.WriteLine("x valía 15, yo digo que ahora vale 27, resultado {0}", x);
		y+=12;
			Console.WriteLine("y valía -10, yo digo que ahora vale 2, resultado {0}", y);
		z+=12;
			Console.WriteLine("z valía 214, yo digo que ahora vale 226, resultado {0}", z);
	}
}
