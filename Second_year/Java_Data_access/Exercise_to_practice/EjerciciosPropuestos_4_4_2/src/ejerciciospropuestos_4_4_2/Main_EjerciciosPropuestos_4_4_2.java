package ejerciciospropuestos_4_4_2;

import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

public class Main_EjerciciosPropuestos_4_4_2 {
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
			System.out.println("1. Mostrar todo.");
			System.out.println("2. Añadir serie.");
			System.out.println("3. Buscar por título.");
			System.out.println("4. Buscar por duración.");
			System.out.println("0. Salir.");
			opcion = scanner.nextLine();
			
			switch(opcion){
				case "1": mostrarTodo(); break;
				case "2": anyadirSerie(); break;
				case "3": busquedaParcialTitulo(); break;
				case "4": busquedaPorDuracion(); break;
				case "0": System.out.println("Saliendo del programa..."); break;
				default: System.out.println("No es una opción válida!"); System.out.println(); break;
			}
		}while(!opcion.equals("0"));
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	public static void anyadirSerie(){
		System.out.println("Indica el código:");
		int codigo = Integer.parseInt(scanner.nextLine());
		System.out.println("Indica el nombre:");
		String nombre = scanner.nextLine();
		System.out.println("Indica la cadena de emisión:");
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
		System.out.println();
	}
	public static void mostrarTodo(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Series");
		List resultados = consulta.list();
		
		if(resultados.size() > 0){
			Series serie;
			System.out.println("Mostrando datos:");
			for(Object resultado : resultados){
				serie = (Series) resultado;
				System.out.println("Código: " + serie.getCodigo()
						+ "; Nombre: " + serie.getNombre()
						+ "; Cadena emisión: " + serie.getCadena()
						+ "; Duración media de capítulos: " + serie.getDuracion() + ".");
			}
		}else{
			System.out.println("No hay datos que mostrar.");
		}
		System.out.println();
		sesion.close();
	}
	public static void busquedaParcialTitulo(){
		System.out.println("Indica el título o parte de él, que quieres buscar:");
		String cadena = scanner.nextLine();
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("select nombre from Series "
				+ "where upper(nombre) like '%" + cadena.toUpperCase()
				+ "%' order by nombre");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			String titulo;
			System.out.println("Mostrando títulos:");
			for(Object resultado : resultados){
				titulo = (String) resultado;
				System.out.println("Título: " + titulo);
			}
		}else{
			System.out.println("No se han encontrado coincidencias.");
		}
		System.out.println();
		sesion.close();
	}
	public static void busquedaPorDuracion(){
		System.out.println("Indica el mínimo de duración");
		int duracionMinima = Integer.parseInt(scanner.nextLine());
		System.out.println("Indica el máximo de duración");
		int duracionMaxima = Integer.parseInt(scanner.nextLine());
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery(
				"from Series "
				+ "where duracion >= " + duracionMinima
				+ " and duracion <= " + duracionMaxima
			);
		
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Series serie;
			System.out.println("Mostrando coincidencias:");
			for(Object resultado : resultados){
				serie = (Series) resultado;
				System.out.println("Código: " + serie.getCodigo()
						+ "; Título: " + serie.getNombre()
						+ "; Cadena de emisión: " + serie.getCadena()
						+ "; Duración media de los capítulos: " + serie.getDuracion() + ".");
			}
		}else{
			System.out.println("No se han encontrado coincidencias.");
		}
		sesion.close();
		System.out.println();
	}

}
