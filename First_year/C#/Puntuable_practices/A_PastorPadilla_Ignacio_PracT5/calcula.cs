
// Ignacio Pastor Padilla - Practica Tema 5 - Programación - DAM Semipresencial

using System;

public class calcula
{
	public static void OrdenaArray(ref int[] n) // Función para Ordenar el Array
	{
		int datoTemporal;
		
		for (int i=0; i<n.Length-1; i++) // Ordenamos con el método de burbuja
		{
			for (int j=i+1; j<n.Length; j++)
			{
				if (n[i]>n[j])
				{
					datoTemporal=n[i];
					n[i]=n[j];
					n[j]=datoTemporal;
				}
			}
		}
	}
	public static void Mediana(int[] n) //Función para clacular la mediana
	{
		double mediana;
		
		int mitad=n.Length/2;
		if (n.Length%2==0) // Si el array es impar, la mediana es la media de los dos números que ocupan la posición central
			mediana=(n[mitad-1]+n[mitad])/2;
		else
			mediana=n[mitad]; // En caso de que el array sea impar, la mediana es el valor que ocupa la posición central
		
		Console.WriteLine(mediana);// Escribimos el valor
		
	}
	public static float Media(int[] n) // Función para calcular la media
	{
		float media;
		int suma=0;
		
		for (int i=0; i<n.Length; i++)// Sumamos cada elemento del array y lo dividimos entre el número total de elementos
		{ 
			suma += n[i];
		}
		media=suma/n.Length;
		return media;
		
	}
	
	
	public static void Main(string[] args) // Cuerpo del programa
	{
		if(args.Length==0) // Primero comprobamos que junto a la instrucción, el usuario haya introducido algún parámetro
		{
			Console.WriteLine("No ha indicado ningún parámetro!");
			Environment.Exit(1);
		}
		string operacion=args[0]; // Lo que introduce el usuario primero es la operación que quiere hacer, esta la registramos en una variable operación
		
		int[] num=new int[args.Length-1];
		
		for (int i=1; i<args.Length; i++) // Convertimos los parámetros de string a int y los metemos en el array.El primer valor lo ignoramos, pues es la operación que queremos hacer
		{
			num[i-1]=Convert.ToInt32(args[i]);
		}
		
		switch (operacion) // Gestionamos con un switch las operaciones que podemos querer hacer
		{
			case "mediana": //Calcular mediana
				OrdenaArray(ref num);
				Mediana(num);
				break;
			
			case "media": // Calcular media
				Console.WriteLine(Media(num).ToString("#.##")); // Nos pide en el enunciado que se muestre con dos decimales
				break;
			
			case "max": // Mostrar el parámetro de mayor valor
				OrdenaArray(ref num);
				Console.WriteLine(num[num.Length-1]);
				break;
			
			case "min": // Mostrar el parámetro de menor valor
				OrdenaArray(ref num);
				Console.WriteLine(num[0]);
				break;	
		}	
	}
}
