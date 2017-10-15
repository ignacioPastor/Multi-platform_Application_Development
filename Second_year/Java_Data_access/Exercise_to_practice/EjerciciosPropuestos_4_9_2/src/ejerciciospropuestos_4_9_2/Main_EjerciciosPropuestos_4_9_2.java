package ejerciciospropuestos_4_9_2;

import java.text.DateFormat;
import java.util.Date;
import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

/**
 * Ejercicios Propuesto_4_9_2.
 * Programa que gestiona una base de datos de Tareas, permite mostrar y a�adir tareas. 
 * Busca por descripci�n parcial y muestra las tareas pendientes de completar para los pr�ximos tres d�as
 * @author Ignacio Pastor Padilla 2� DAM Semipresencial
 *
 */

public class Main_EjerciciosPropuestos_4_9_2 {
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
			System.out.println("2. A�adir tareas.");
			System.out.println("3. Buscar por descripci�n.");
			System.out.println("4. Pendientes para los pr�ximos tres d�as.");
			System.out.println("0. Salir");
			opcion = scanner.nextLine();
			
			switch(opcion){
				case "1": verTareas(); break;
				case "2": anyadirTareas(); break;
				case "3": buscarDescripcion(); break;
				case "4": pendientesTresDias(); break;
				case "0": System.out.println("Saliendo del programa..."); break;
				default: System.out.printf("No es una opci�n v�lida!%n%n"); break;
			}
			
		}while(!opcion.equals("0"));
		
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	private static void pendientesTresDias(){
		System.out.println("Mostrando tareas pendientes para los pr�ximos "
				+ "tres d�as...");
		Date hoy = new Date();
		Date despues = new Date();
		int dia = despues.getDate();
		dia += 3;
		despues.setDate(dia);
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Tareas "
				+ "where fecha >= :hoyParam "
				+ "and fecha <= :despuesParam "
				+ "and completada = false")
				.setParameter("hoyParam", hoy)
				.setParameter("despuesParam", despues);
		
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Tareas tarea;
			for(Object resultado : resultados){
				tarea = (Tareas) resultado;
				mostrarTarea(tarea);
			}
		}else
			System.out.println("No se han encontrado coincidencias.");
		
		System.out.println("");
		sesion.close();
	}
	private static void buscarDescripcion(){
		System.out.println("Indica parte de la descripci�n que quieres buscar");
		String texto = scanner.nextLine();
		System.out.println("Buscando...");
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Tareas "
				+ "where descripcion like '%"+texto+"%'");
				//.setParameter("textoParam", texto);
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Tareas tarea;
			for(Object resultado : resultados){
				tarea = (Tareas) resultado;
				mostrarTarea(tarea);
			}
		}else{
			System.out.println("La b�squeda no ha arrojado ning�n resultado.");
		}
		sesion.close();
	}
	private static void anyadirTareas(){
		System.out.println("Indica el c�digo de la tarea");
		String codigo = scanner.nextLine();
		
		System.out.println("Indica la fecha de la tarea (dd-mm-yyyy)");
		String fechaString = scanner.nextLine();
		String[] fechaSplit = fechaString.split("-");
		Date fecha = new Date();
		fecha.setDate(Integer.parseInt(fechaSplit[0]));
		fecha.setMonth(Integer.parseInt(fechaSplit[1]) - 1);
		fecha.setYear(Integer.parseInt(fechaSplit[2]) - 1900);
		
		System.out.println("Indica la descripci�n de la tarea");
		String descripcion = scanner.nextLine();
		System.out.println("Indica si la tarea est� terminada (S/N)");
		String respuesta = scanner.nextLine();
		boolean completada;
		if(respuesta.toUpperCase().equals("S"))
			completada = true;
		else
			completada = false;
		Tareas tarea = new Tareas(codigo, fecha, descripcion, completada);
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		sesion.save(tarea);
		trans.commit();
		sesion.close();
		System.out.println("Tarea a�adida!");
		System.out.println("");
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
		System.out.println("C�digo: " + tarea.getCodigo()
			+ ", Fecha: " + tarea.getFecha().toString()
			+ ", Completada: " + tarea.getCompletada());
		System.out.println("    Descripci�n: " + tarea.getDescripcion());
	}
}
