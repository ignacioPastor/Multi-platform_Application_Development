// (4.4.1.4) Crea un programa que pida al usuario dos números enteros y después una operación que realizar con ellos.
// La operación podrá ser "suma", "resta", multiplicación" y "división", que también se podrán escribir de forma abreviado
// con los operadores matemáticos "+", "-", "*" y "/". Para multiplicar también se podrá usar una "x", minúscula o mayúscula.
// A continuación se mostrará el resultado de esa operación (por ejemplo, si los números son 3 y 6 y la operación es "suma", el resultado sería 9).
// La operación debes tomarla como una cadena de texto y analizarla con un "switch".

using System;
public class Ejercicio_4_4_1_4
{
	public static void Main()
	{
		float n1, n2;
		string operacion;
		float resultado;
		
		Console.WriteLine("Introduce el primer número entero");
		n1=Convert.ToInt16(Console.ReadLine());
		Console.WriteLine("Introduce el segundo número entero");
		n2=Convert.ToInt16(Console.ReadLine());
		Console.WriteLine("Indica ahora qué tipo de operación quieres realizar con ellos");
		operacion=Console.ReadLine();
		
		switch(operacion)
		{
			case "suma":
				resultado=n1+n2;
				Console.WriteLine("El resultado de sumar {0} y {1} es {2}", n1, n2, resultado);
				break;
				
			case "resta":
				resultado=n1-n2;
				Console.WriteLine("El resultado de restar a {0}, {1} es {2}", n1, n2, resultado);
				break;
			
			case "multiplicacion":
				resultado=n1*n2;
				Console.WriteLine("El resultado de multiplicar {0} por {1} es {2}", n1, n2, resultado);
				break;
				
			case "division":
				resultado=n1/n2;
				Console.WriteLine("El resultado de duvidir {0} entre {1} es {2}", n1, n2, resultado);
				break;
			
			case "+":
				goto case "suma";
			
			case "-":
				goto case "resta";
					
			case "*":
				goto case "multiplicacion";
			
			case "/":
				goto case "division";
			
			case "x":
				goto case "multiplicacion";
				
			case "X":
				goto case "multiplicacion";
			
			default:
				Console.WriteLine("No reconozco esa referencia, prueba otra expresión para referirte a la suma, resta, multiplicación o división");
				break;
		}
	}
}
