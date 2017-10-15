// (3.2.3.2) Crea un programa que pida al usuario a una distancia (en metros)
// y el tiempo necesario para recorrerla (como tres números: horas, minutos,
// segundos), y muestre la velocidad, en metros por segundo, en kilómetros
// por hora y en millas por hora (pista: 1 milla = 1.609 metros).

using System;
public class Ejercicio_3_2_3_2
{
	public static void Main()
	{
		int distancia;
		float horas, minutos, segundos, tiempo;
		float velocidadMS, velocidadKH, velocidadMPH;
		
		Console.WriteLine("Introduce la distancia(en metros)");
		distancia=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Introduce las horas");
		horas=Convert.ToSByte(Console.ReadLine());
		Console.WriteLine("Introduce los minutos");
		minutos=Convert.ToSByte(Console.ReadLine());
		Console.WriteLine("Introduce los segundos");
		segundos=Convert.ToSByte(Console.ReadLine());
		
		tiempo=((horas*60)+minutos)*60+segundos;
		velocidadMS=distancia/tiempo;
		velocidadKH=(distancia/1000)/(horas+(((segundos/60)+minutos)/60));
		velocidadMPH=(distancia/1609)/(horas+(((segundos/60)+minutos)/60));
		
		Console.WriteLine("La velocidad es: {0}m/s, {1}k/m, {2}mph", velocidadMS, velocidadKH, velocidadMPH);
	}
}
