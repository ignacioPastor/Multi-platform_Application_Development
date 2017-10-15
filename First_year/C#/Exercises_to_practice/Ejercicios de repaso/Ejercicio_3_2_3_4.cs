// (3.2.3.4) Si se ingresan E euros en el banco a un cierto interés
// I durante N años, el dinero obtenido viene dado por la fórmula del
// interés compuesto: Resultado = e (1+ i)n Aplícalo para calcular en cuanto
// se convierten 1.000 euros al cabo de 10 años al 3% de interés anual.

using System;
public class Ejercicio_3_2_3_4
{
	public static void Main()
	{
		double i=3/100, resultado, potencia=1;
		short e=1000, n=10;
		
		for(byte j=0; j<n; j++)
		{
			potencia=potencia*(1+i);
		}
		resultado=e*potencia;
		Console.WriteLine("El interés generado es {0}euros", resultado);
	}
}
// No tengo ni idea de si da bien
