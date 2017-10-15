// (3.2.3.3) Halla las soluciones de una ecuación de segundo grado del
// tipo y = Ax2 + Bx + C. Pista: la raíz cuadrada de un número x se calcula
// con Math.Sqrt(x)

using System;
public class Ejercicio_3_2_3_3
{
	public static void Main()
	{
		double x1, x2;
		double a, b, c;
		
		Console.WriteLine("Solucionador de ecuaciones de segundo grado del tipo ax2 + bx +c");
		Console.WriteLine("Introduce el valor de \"a\"");
		a=Convert.ToSByte(Console.ReadLine());
		Console.WriteLine("Introduce el valor de \"b\"");
		b=Convert.ToSByte(Console.ReadLine());
		Console.WriteLine("Introduce el valor de \"c\"");
		c=Convert.ToSByte(Console.ReadLine());
		
		x1=(-b+Math.Sqrt((b*b)-(4*a*c)))/2*a;
		x2=(-b-Math.Sqrt((b*b)-(4*a*c)))/2*a;
		
		Console.WriteLine("\"x\" vale {0} y \"x\" vale {1}", x1, x2);
	}
}
// No resuelve, pero paso de calentarme la cabeza con ecuaciones de segundo grado.
