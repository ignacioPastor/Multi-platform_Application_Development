// Practica Tema 4. Ejercicio 1 "Cuadro Medico"
// Se deben controlar los posibles errores del Usuario, por ejemplo si introduce una especialidad que no
// está en la lista, mostrar error y volvérsela a pedir. Igua que si introduce una antigüedad negativa o no numérica

using System;
public class CuadroMedico
{
	struct datosDoctor
	{
		public string nombre;
		public string especialidad;
		public byte anyosAntiguedad;
	}
	
	public static void Main()
	{
		try
		{	
			byte opcion, cantidad=0, posicionBorrar, i;
			const byte MAXIMO=100;
			datosDoctor[] doctores = new datosDoctor[MAXIMO];
			bool correcto;
			string especialidadBuscar;
			
			do
			{
				Console.WriteLine("Menu.");
				Console.WriteLine("1. Añadir un doctor al final de los que haya");
				Console.WriteLine("2. Borrar un doctor indicando su posición en la lista");// Al elegir esta opción se mostrará el listado de doctores
				Console.WriteLine("3. Listar los doctores de una especialidad");// Ignorar mayúsculas y minúsculas; y contemplar búsquedas parciales
				Console.WriteLine("4. Ordenar alfabéticamente por nombre");
				Console.WriteLine("0. Salir del programa");
				opcion=Convert.ToByte(Console.ReadLine());
				
				switch(opcion)
				{
					case 1: // Añadir un doctor al final
						if(cantidad<MAXIMO)
						{
							Console.WriteLine("Introduce el nombre del doctor");
							doctores[cantidad].nombre=Console.ReadLine();
							do
							{
								correcto=false;
								Console.WriteLine("Introduce la especialidad del doctor, las opciones posibles son:");
								Console.WriteLine("\"Traumatología\", \"Medicina General\", \"Medicina Interna\", \"Otorrinolaringología\" y \"Cirugía\"");
								doctores[cantidad].especialidad=Console.ReadLine();
								if(doctores[cantidad].especialidad.ToLower()=="traumatología"||doctores[cantidad].especialidad.ToLower()=="traumatologia"||
										doctores[cantidad].especialidad.ToLower()=="medicina general"||doctores[cantidad].especialidad.ToLower()=="medicina interna"||
										doctores[cantidad].especialidad.ToLower()=="otorrinolaringología"||doctores[cantidad].especialidad.ToLower()=="otorrinolaringologia"||
										doctores[cantidad].especialidad.ToLower()=="cirugía"||doctores[cantidad].especialidad.ToLower()=="cirugia")
									correcto=true;
								else
									Console.WriteLine("Esa no es una especialidad válida, inténtalo otra vez");
							}
							while(!correcto);
							
							do
							{
								try
								{
									correcto=false;
									Console.WriteLine("Introduce los años de antigüedad del doctor");
									doctores[cantidad].anyosAntiguedad=Convert.ToByte(Console.ReadLine());
									correcto=true;
								}
								catch(FormatException)
								{
									Console.WriteLine("Error, debes introducir un valor numérico");
								}
								catch(OverflowException)
								{
									Console.WriteLine("Error, debes introducir un valor positivo, y menor que 256");
								}
							}
							while(!correcto);
						}
						else
							Console.WriteLine("No queda espacio disponible, debes borrar algún dato de doctor para almacenar otro");
						cantidad++;
						break;
					
					case 2: // Borrar doctor posición determinada, mostrar antes listado doctores
						for (i = 0; i < cantidad; i++)
							Console.WriteLine("{0}. Nombre: {1}; Especialidad: {2}; Años antigüedad: {3}", i+1, doctores[i].nombre, doctores[i].especialidad, doctores[i].anyosAntiguedad);
						Console.WriteLine("Indica la posición del doctor que quieres borrar");
						posicionBorrar=Convert.ToByte(Console.ReadLine());
						for (i = --posicionBorrar; i < cantidad; i++)
						{
							doctores[i]=doctores[i+1];
						}
						cantidad--;
						break;
					
					case 3: // Listar los doctores de una especialidad, ignorar mayus/minus, busquedas parciales
						correcto=false;
						Console.WriteLine("Introduce la especialidad que quieres buscar ");
						especialidadBuscar=Console.ReadLine();
						for (i = 0; i < cantidad; i++)
						{
							if(doctores[i].especialidad.ToUpper().Contains(especialidadBuscar.ToUpper()))
							{	
								Console.WriteLine("{0}. Nombre: {1}; Especialidad: {2}; Años antigüedad: {3}", i+1, doctores[i].nombre, doctores[i].especialidad, doctores[i].anyosAntiguedad);
								correcto=true;
							}
							if(!correcto)
								Console.WriteLine("No hay resultados para los parámetros introducidos");
						}
						break;
						
					case 4: // Ordenar alfabéticamente por nombre
						for (i = 0; i < cantidad-1; i++)
						{
							for(int j=i+1; j<cantidad; j++)	
								if(doctores[i].nombre.ToUpper().CompareTo(doctores[j].nombre.ToUpper())>0)
								{
									doctores[cantidad]=doctores[i];
									doctores[i]=doctores[j];
									doctores[j]=doctores[cantidad];
								}
						}
						Console.WriteLine("Ahora están ordenados alfabéticamente:");
						for(i=0; i<cantidad; i++)
							Console.WriteLine("{0}. Nombre: {1}; Especialidad: {2}; Años antigüedad: {3}.", i+1, doctores[i].nombre, doctores[i].especialidad, doctores[i].anyosAntiguedad);
						break;
					
					case 0: //Fin del programa
						Console.WriteLine("Fin del programa");
						break;
						
					default:
						Console.WriteLine("Esa no es una opción válida");
						break;
				}
			}
			while(opcion!=0);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
