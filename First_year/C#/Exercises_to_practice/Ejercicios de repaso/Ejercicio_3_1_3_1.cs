// (3.1.3.1) Crea un programa que use tres variables x,y,z. Sus valores
// iniciales serán 15, -10, 2.147.483.647. Se deberá incrementar el valor
// de estas variables. ¿Qué valores esperas que se obtengan? Contrástalo
// con el resultado obtenido por el programa.

using System;
public class Ejercicio_3_1_3_1
{
	public static void Main()
	{
		sbyte x=15, y=-10;
		int z=2147483647;
		
		x++;
		y++;
		z++;
		Console.WriteLine("x valía 15 y ahora vale {0}", x);
		Console.WriteLine("y valía -10 y ahora vale {0}", y);
		Console.WriteLine("z valía 2.147.483.647 y ahora vale {0}", z);
	}
}
