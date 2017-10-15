package ejerciciospropuestos_4_3_3;

import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

public class Main_EjerciciosPropuestos_4_3_3 {
	static Scanner scanner = new Scanner(System.in);
	public static void main(String[] args) {
		@SuppressWarnings("unused")
		org.jboss.logging.Logger logger = 
			org.jboss.logging.Logger.getLogger("org.hibernate");
		java.util.logging.Logger.getLogger("org.hibernate")
			.setLevel(java.util.logging.Level.SEVERE);
		
		
		String opcion = "";
		do{
			System.out.println("Menu:");
			System.out.println("1. Mostrar datos.");
			System.out.println("2. Añadir nueva serie.");
			System.out.println("0. Salir.");
			opcion = scanner.nextLine();
			switch(opcion){
				case "1": mostrarDatos(); break;
				case "2": anyadirDatos(); break;
				case "0": System.out.println("Saliendo del programa..."); break;
				default: System.out.println("No es una opción válida!"); break;
			}
		}while(!opcion.equals("0"));
		
		
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	public static void mostrarDatos(){
		System.out.println("Mostrando datos:");
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Series");
		List resultados = consulta.list();
		
		Series serie;
		for(Object resultado : resultados){
			serie = (Series) resultado;
			System.out.println("Codigo: " + serie.getCodigo()
					+ "; Nombre: " + serie.getNombre()
					+ "; Cadena: " + serie.getCadena()
					+ "; Duración: " + serie.getDuracion());
		}
		sesion.close();
	}
	public static void anyadirDatos(){
		System.out.println("Indica el codigo:");
		int codigo = Integer.parseInt(scanner.nextLine());
		System.out.println("Indica el nombre:");
		String nombre = scanner.nextLine();
		System.out.println("Indica la cadena en la que se emite:");
		String cadena = scanner.nextLine();
		System.out.println("Indica la duración media de los capítulos:");
		int duracion = Integer.parseInt(scanner.nextLine());
		
		Series serie = new Series(codigo, nombre, cadena, duracion);
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		sesion.save(serie);
		trans.commit();
		
		sesion.close();
		System.out.println("Serie guardada!");
	}

}
