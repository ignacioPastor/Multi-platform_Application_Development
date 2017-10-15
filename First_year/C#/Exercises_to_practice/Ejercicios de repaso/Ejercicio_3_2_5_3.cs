
// (3.2.5.3) Calcula el perímetro, área y diagonal de un rectángulo,
// a partir de su ancho y alto (perímetro = suma de los cuatro lados
// área = base x altura; diagonal, usando el teorema de Pitágoras)
// Muestra todos ellos con una cifra decimal.

using System;
public class Ejercicio_3_2_5_3
{
	public static void Main()
	{
		float ancho, alto, perimetro, area, diagonal;
		
		Console.WriteLine("Introduce el alto del rectángulo");
		alto=Convert.ToSingle(Console.ReadLine());
		Console.WriteLine("Introduce el ancho del rectángulo");
		ancho=Convert.ToSingle(Console.ReadLine());
		
		perimetro=ancho*2+alto*2;
		area=ancho*alto;
		diagonal= (float) Math.Sqrt(ancho*ancho+alto*alto);
		
		Console.WriteLine("El perímetro del rectángulo es {0}", perimetro.ToString("N1"));
		Console.WriteLine("El área del rectángulo es {0}", area.ToString("0.0"));
		Console.WriteLine("La diagonal del rectángulo es {0}", diagonal.ToString("#.#"));
	}
}
