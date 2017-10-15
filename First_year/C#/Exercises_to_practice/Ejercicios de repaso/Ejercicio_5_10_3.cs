// (5.10.3) Crea un programa que emplee recursividad para calcular un número de la serie Fibonacci
// (en la que los dos primeros elementos valen 1, y para los restantes, cada elemento es la suma de los dos anteriores).

using System;
public class Ejercicio_5_10_3
{
	public static int Fibonnaci(int n)
	{
		if(n==1||n==2)
			return 1;
		else
			return Fibonnaci(n-1)+Fibonnaci(n-2);
	}
	
	public static void Main()
	{
		int numero;
		
		Console.WriteLine("Qué número de la sucesión de Fibonnaci quieres saber?");
		numero=Convert.ToInt32(Console.ReadLine());
		
		Console.WriteLine("El número en cuestión es {0}", Fibonnaci(numero));
		
		
	}
}
