package ejerciciospropuestos_4_9_1;

import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;

public class Main_EjerciciosPropuestos_4_9_1 {
	static Scanner scanner = new Scanner(System.in);
	public static void main(String[] args) {
		@SuppressWarnings("unused")
		org.jboss.logging.Logger logger = 
			org.jboss.logging.Logger.getLogger("org.hibernate");
		java.util.logging.Logger.getLogger("org.hibernate")
			.setLevel(java.util.logging.Level.SEVERE);
		
		
		String opcion;
		do{
			System.out.println("Menu:");
			System.out.println("1. Mostrar tareas.");
			System.out.println("0. Salir");
			opcion = scanner.nextLine();
			
			switch(opcion){
				case "1": verTareas(); break;
				case "0": System.out.println("Saliendo del programa..."); break;
				default: System.out.printf("No es una opción válida!%n%n"); break;
			}
			
		}while(!opcion.equals("0"));
		
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	private static void verTareas(){
		System.out.println("Mostrando tareas:");
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Tareas");
		List resultados = consulta.list();
		
		if(resultados.size() > 0){
			Tareas tarea;
			for(Object resultado : resultados){
				tarea = (Tareas) resultado;
				mostrarTarea(tarea);
			}
		}else
			System.out.println("No hay resultados que mostrar.");
		System.out.println("");
		
		sesion.close();
	}
	private static void mostrarTarea(Tareas tarea){
		System.out.println("Código: " + tarea.getCodigo()
			+ ", Fecha: " + tarea.getFecha().toString()
			+ ", Completada: " + tarea.getCompletada());
		System.out.println("    Descripción: " + tarea.getDescripcion());
	}
}
