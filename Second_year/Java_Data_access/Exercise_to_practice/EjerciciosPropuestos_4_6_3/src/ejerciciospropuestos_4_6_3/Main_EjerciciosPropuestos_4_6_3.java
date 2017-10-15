package ejerciciospropuestos_4_6_3;

import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

public class Main_EjerciciosPropuestos_4_6_3 {
	static Scanner scanner = new Scanner(System.in);
	public static void main(String[] args) {
		@SuppressWarnings("unused")
		org.jboss.logging.Logger logger = 
			org.jboss.logging.Logger.getLogger("org.hibernate");
		java.util.logging.Logger.getLogger("org.hibernate")
			.setLevel(java.util.logging.Level.SEVERE);
		
		String opcion;
		do{
			System.out.println("1. Mostrar datos.");
			System.out.println("2. Añadir Cadena.");
			System.out.println("3. Ver datos cadenas.");
			System.out.println("0. Salir.");
			opcion = scanner.nextLine();
			
			switch(opcion){
				case "1": mostrarDatos(); break;
				case "2": anyadirCadena(); break;
				case "3": verCadenas(); break;
				case "0": System.out.println("Saliendo del programa..."); break;
				default: System.out.printf("Opción no válida!%n%n"); break;
			}
		}while(!opcion.equals("0"));
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	public static void mostrarDatos(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Series");
		List resultados = consulta.list();
		
		if(resultados.size() > 0){
			Series serie;
			for(Object resultado : resultados){
				serie = (Series) resultado;
				System.out.println("Código: " + serie.getCodigo()
					+ ", Nombre: " + serie.getNombre()
					+ ", NombreCadena: " + serie.getCadenas().getNombre()
					+ ", CódigoCadena: " + serie.getCadenas().getCodigo()
					+ ", Duración capítulos: " + serie.getDuracion());
			}
		}else{
			System.out.println("No hay resultados a mostrar.");
		}
				
		sesion.close();
		System.out.println("");
	}
	public static void anyadirCadena(){
		System.out.println("Indica el nombre de la cadena:");
		String nombre = scanner.nextLine();
		System.out.println("Indica el código de la cadena:");
		String codigo = scanner.nextLine();
		
		Cadenas cadena = new Cadenas(codigo, nombre);
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		sesion.save(cadena);
		trans.commit();
		sesion.close();
		System.out.println("Cadena guardada!");
		System.out.println("");
	}
	public static void verCadenas(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Cadenas");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Cadenas cadena;
			for(Object resultado : resultados){
				cadena = (Cadenas) resultado;
				System.out.println("CódigoCadena: " + cadena.getCodigo()
				+ ", NombreCadena: " + cadena.getNombre() + ".");
			}
		}else{
			System.out.println("No se han encontrado resultados.");
		}
		
		sesion.close();
		System.out.println("");
	}
}























