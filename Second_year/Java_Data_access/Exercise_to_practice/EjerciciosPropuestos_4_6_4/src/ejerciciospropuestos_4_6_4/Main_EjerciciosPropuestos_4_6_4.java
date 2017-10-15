package ejerciciospropuestos_4_6_4;

import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

public class Main_EjerciciosPropuestos_4_6_4 {
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
			System.out.println("1. Mostrar Series.");
			System.out.println("2. Mostrar Cadenas.");
			System.out.println("3. Añadir nueva serie.");
			System.out.println("4. Añadir nueva cadena.");
			System.out.println("0. Salir.");
			opcion = scanner.nextLine();
			
			switch(opcion){
				case "1": mostrarSeries(); break;
				case "2": mostrarCadenas(); break;
				case "3": anyadirSerie(); break;
				case "4": anyadirCadena(); break;
				case "0": System.out.println("Saliendo del programa..."); break;
				default: System.out.printf("No es una opción válida!%n%n"); break;
			}
			
		}while(!opcion.equals("0"));
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	public static void mostrarSeries(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Series");
		List resultados = consulta.list();
		
		if(resultados.size() > 0){
			System.out.println("Mostrando Series:");
			Series serie;
			for(Object resultado : resultados ){
				serie = (Series) resultado;
				System.out.println("Código: " + serie.getCodigo()
					+ ", Nombre: " + serie.getNombre()
					+ ", códigoCadena: " + serie.getCadenas().getCodigo()
					+ ", nombreCadena: " + serie.getCadenas().getNombre()
					+ ", Duración media: " + serie.getDuracion());
			}
			
		}else{
			System.out.println("No se han encontrado resultados.");
		}
		sesion.close();
		System.out.println("");
	}
	public static void mostrarCadenas(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Cadenas");
		List resultados = consulta.list();
		
		if(resultados.size() > 0){
			Cadenas cadena;
			Series serie;
			System.out.println("Mostrando Cadenas:");
			for(Object resultado : resultados){
				cadena = (Cadenas) resultado;
				System.out.println("CodigoCadena: " + cadena.getCodigo()
				+ ", NombreCadena: " + cadena.getNombre());
				
				for(Object resultSerie : cadena.getSerieses()){
					serie = (Series) resultSerie;
					System.out.println("        CodigoSerie: " + serie.getCodigo()
						+ ", NombreSerie: " + serie.getNombre()
						+ ", Duración: " + serie.getDuracion());
				}
			}
		}else{
			System.out.println("No se han encontrado resultados.");
		}
		sesion.close();
		System.out.println("");
	}
	public static void anyadirCadena(){
		System.out.println("Nueva Cadena.");
		System.out.println("Indica el codigo de la cadena:");
		String codigo = scanner.nextLine();
		System.out.println("Indica el nombre de la cadena:");
		String nombre = scanner.nextLine();
		
		Cadenas cadena = new Cadenas(codigo, nombre);
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		sesion.save(cadena);
		trans.commit();
		sesion.close();
		System.out.println("Cadena guardada!");
		System.out.println("");
	}
	public static void anyadirSerie(){
		System.out.println("Nueva Serie.");
		System.out.println("Indica el codigo de la serie:");
		int codigo = Integer.parseInt(scanner.nextLine());
		System.out.println("Indica el nombre de la serie:");
		String nombre = scanner.nextLine();
		System.out.println("Indica el código de la cadena:");
		String codigoCadena = scanner.nextLine();
		System.out.println("Indica la duración media de los capítulos:");
		int duracion = Integer.parseInt(scanner.nextLine());
		
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		Query consulta = sesion.createQuery("from Cadenas "
				+ "where codigo = '" + codigoCadena + "'");
		
		Cadenas cadena = (Cadenas) consulta.list().get(0);
		Series serie = new Series(codigo, cadena, nombre, duracion);
		
		sesion.save(serie);
		trans.commit();
		sesion.close();
		System.out.println("Serie guardada!");
		System.out.println("");
	}
}
