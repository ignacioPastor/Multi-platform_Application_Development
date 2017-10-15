// (2.5.9) Crea un programa que devuelva el cambio de una compra,
// utilizando monedas (o billetes) del mayor valor posible. Supondremos
// que tenemos una cantidad ilimitada de monedas (o billetes)
// de 100, 50, 20, 10, 5, 2 y 1, y que no hay decimales.

using System;
public class Ejercicio_2_5_9
{
	public static void Main()
	{
		int precio, pagado, cambio;
		
		Console.WriteLine("Introduzca el precio del producto");
		precio=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduzca la cantidad pagada");
		pagado=Convert.ToInt32(Console.ReadLine());
		
		cambio=pagado-precio;
		Console.Write("Su cambio es de {0}: ", cambio);
		if(cambio>0)
		{
			while(cambio!=0)
			{
				if(cambio-100>=0){
					Console.Write("100 ");
					cambio=cambio-100;}
				else if(cambio-50>=0){
					Console.Write("50 ");
					cambio=cambio-50;}
				else if(cambio-20>=0){
					Console.Write("20 ");
					cambio=cambio-20;}
				else if(cambio-10>=0){
					Console.Write("10 ");
					cambio=cambio-10;}
				else if(cambio-5>=0){
					Console.Write("5 ");
					cambio=cambio-5;}
				else if(cambio-2>=0){
					Console.Write("2 ");
					cambio=cambio-2;}
				else if(cambio-1>=0){
					Console.Write("1 ");
					cambio=cambio-1;}
			}
			Console.WriteLine();
		}
		else Console.WriteLine("El importe pagado es igual al precio, no procede devolver ningún cambio");
	}
}
