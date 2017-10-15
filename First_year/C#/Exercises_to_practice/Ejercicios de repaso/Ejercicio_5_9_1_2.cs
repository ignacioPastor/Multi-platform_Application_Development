// (5.9.1.2) Crea un programa que genere un número al azar entre 1 y 100.
// El usuario tendrá 6 oportunidades para acertarlo.

using System;
public class Ejercicio_5_9_1_2
{
	public static void Main()
	{
		byte oportunidades=6, numero, respuesta;
		Random r = new Random();
		
		numero=Convert.ToByte(r.Next(1,101));
		
		do
		{
			oportunidades--;
			Console.WriteLine("Intenta adivinar un número entre 1 y 101 que tengo en la memoria");
			respuesta=Convert.ToByte(Console.ReadLine());
			if(respuesta==numero)
				Console.WriteLine("Enhorabuena, lo has conseguido");
			else if(respuesta!=numero&&oportunidades>0)
				Console.WriteLine("Nop, prueba otra vez.Te quedan {0} intentos", oportunidades);
			else
				Console.WriteLine("Ya no te quedan intentos, has fracasado. Perdedor");
		} while (oportunidades>0&&respuesta!=numero);
	}
}
