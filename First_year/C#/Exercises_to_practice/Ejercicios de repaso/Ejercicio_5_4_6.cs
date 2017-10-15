// (5.4.6) Crea una función "MostrarPerimSuperfCuadrado" que reciba un número entero
// y calcule y muestre en pantalla el valor del perímetro y de la superficie de
// un cuadrado que tenga como lado el número que se ha indicado como parámetro.

using System;
public class Ejercicio_5_4_6
{
	public static string MostrarPerimSuperfCuadrado(int numero)
	{
		string superficie, perimetro;
		superficie=Convert.ToString(numero*numero);
		perimetro=Convert.ToString(numero*4);
		
		return "La supercicie sería "+superficie+"u" + " y el perímetro " + perimetro+"u";
	}
	public static void Main()
	{
		int nUsuario;
		
		Console.WriteLine("Introduce el lado del cuadrado");
		nUsuario=Convert.ToInt32(Console.ReadLine());
		
		Console.WriteLine(MostrarPerimSuperfCuadrado(nUsuario));
	}
}
