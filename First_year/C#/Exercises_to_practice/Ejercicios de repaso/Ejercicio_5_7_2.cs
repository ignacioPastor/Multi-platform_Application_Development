// (5.7.2) Crea una función "Iniciales", que reciba una cadena como "Nacho Cabanes"
// y devuelva las letras N y C (primera letra, y letra situada tras el primer espacio),
// usando parámetros por referencia. Crea un "Main" que te permita comprobar que funciona correctamente.

using System;
public class Ejercicio_5_7_2
{
	public static void Iniciales(string cadena, ref char letra1, ref char letra2)
	{
		string[] nombrePartido = cadena.Split(' ');
		letra1=nombrePartido[0][0];
		letra2=nombrePartido[1][0];
	}
	public static void Main()
	{
		string nombreCompleto;
		char l1='a', l2='b';
		
		Console.WriteLine("Introduce tu nombre simple y primer apellido");
		nombreCompleto=Console.ReadLine();
		
		Iniciales(nombreCompleto, ref l1, ref l2); //técnicamente debería dar error, pues no están definidas. Se necesitaría out
		Console.WriteLine("Tus iniciales son {0}{1}", Convert.ToString(l1).ToUpper(), Convert.ToString(l2).ToUpper());
	}
}
