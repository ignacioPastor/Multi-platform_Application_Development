// (3.1.3.2) ¿Cuál sería el resultado de las siguientes operaciones?
// a=5; b=++a; c=a++; b=b*5; a=a*2; Calcúlalo a mano y luego crea un
// programa que lo resuelva, para ver si habías hallado la solución correcta.

using System;
public class Ejercicio_3_1_3_2
{
	public static void Main()
	{
		int a, b, c;
		
		a=5;
			Console.WriteLine("a=5");
		b=++a;
			Console.WriteLine("b=++a, b=6, a=6; resultados: b={0}, a={1}", b, a);
		c=a++;
			Console.WriteLine("c=a++; c=6, a=7; resultados: c={0}, a={1}", c, a);
		b=b*5;
			Console.WriteLine("b=b*5; b=30; resultado: b={0}", b);
		a=a*2;
			Console.WriteLine("a=a*2; a=14; resultado: a={0}", a);
	}
}
