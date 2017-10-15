// (5.9.2.3) Haz un programa que resuelva ecuaciones de segundo grado, del tipo ax2 + bx + c = 0.
// El usuario deberá introducir los valores de a, b y c. Se deberá crear una función "CalcularRaicesSegundoGrado",
// que recibirá como parámetros los coeficientes a, b y c (por valor), así como las soluciones x1 y x2 (por referencia).
// Deberá devolver los valores de las dos soluciones x1 y x2. Si alguna solución no existe, se devolverá como valor
// el "número mágico" 100.000 para esa solución. Pista: la solución se calcula con x = -b +- raíz (b2 – 4·a·c) / (2·a)

//NO CONSIGO QUE ME DE BIEN LA SOLUCIÓN, EL PROBLEMA DEBE ESTAR EN LA FÓRMULA MATEMÁTICA

using System;
public class Ejercicio_5_9_2_3
{
	public static void CalcularRaicesSegundoGrado(double a, double b, double c, out double x1, out double x2)
	{
		x1 = (-b + Math.Sqrt((Math.Pow(b,2) - 4*a*c))) / (2*a);
		
		x2 = (-b - Math.Sqrt((Math.Pow(b,2) - 4*a*c))) / (2*a);
	}
	public static void Main()
	{
		double x1, x2;
		double a, b, c;
		
		Console.WriteLine("Introduce el valor de \"a\"");
		a=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Introduce el valor de \"b\"");
		b=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Introduce el valor de \"c\"");
		c=Convert.ToDouble(Console.ReadLine());
		
		CalcularRaicesSegundoGrado(a, b, c, out x1, out x2);
		
		Console.WriteLine("El resultado es x1={0} y x2={1}", x1, x2);
	}
}
