package ejerciciospropuestos_4_4_3;

import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

public class Main_EjerciciosPropuestos_4_4_3 {
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
			System.out.println("5. Mostrar de cuántas series de cada canal tenemos constancia.");
			System.out.println("0. Salir.");
			opcion = scanner.nextLine();
			try{
				switch(opcion){
					case "1": mostrarTodo(); break;
					case "2": anyadirSerie(); break;
					case "3": buscarTitulo(); break;
					case "4": buscarDuracion(); break;
					case "5": seriesPorCanal(); break;
					case "0": System.out.println("Saliendo del programa..."); break;
					default: System.out.printf("No es una opción válida!%n%n"); break;
				}
			}catch(Exception e){
				System.err.println("Error: " + e.getMessage());
			}
		}while(!opcion.equals("0"));
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	public static void seriesPorCanal(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery(
				"select cadena, count(*) from Series "
				+ "group by cadena"
			);
		List<Object[]> resultados = consulta.list();
		if(resultados.size() > 0){
			String cadena;
			long numero;
			for(Object[] resultado : resultados){
				cadena = (String) resultado[0];
				numero = (long) resultado[1];
				System.out.println(cadena + ": " + numero);
			}
		}else{
			System.out.println("No hay resultados que mostrar.");
		}
		sesion.close();
		System.out.println("");
	}
	public static void mostrarTodo(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Series");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Series serie;
			for(Object resultado : resultados){
				serie = (Series) resultado;
				System.out.println("Código: " + serie.getCodigo()
				+ "; Nombre: " + serie.getNombre()
				+ "; Cadena emisión: " + serie.getCadena()
				+ "; Duración media de capítulos: " + serie.getDuracion() + ".");
			}
		}else{
			System.out.println("No se han encontrado coincidencias.");
		}
		sesion.close();
		System.out.println("");
	}
	public static void anyadirSerie(){
		System.out.println("Indica el código:");
		int codigo = Integer.parseInt(scanner.nextLine());
		System.out.println("Indica el título:");
		String titulo = scanner.nextLine();
		System.out.println("Indica la cadena en la que se emite:");
		String cadena = scanner.nextLine();
		System.out.println("Indica la duración media del capítulo:");
		int duracion = Integer.parseInt(scanner.nextLine());
		
		Series serie = new Series(codigo, titulo, cadena, duracion);
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		sesion.save(serie);
		trans.commit();
		sesion.close();
		System.out.println("Serie guardada");
		System.out.println("");
	}
	public static void buscarTitulo(){
		System.out.println("Indica el título que quieres buscar:");
		String cadena = scanner.nextLine();
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery(
				"select nombre from Series "
				+ "where upper(nombre) like '%"
				+ cadena.toUpperCase() + "%' "
				+ "order by nombre"
			);
		List resultados = consulta.list();
		if(resultados.size() > 0){
			System.out.println("Mostrando coincidencias:");
			String titulo;
			for(Object resultado : resultados){
				titulo = (String) resultado;
				System.out.println("Título: " + titulo);
			}
		}else{
			System.out.println("No se han encontrado coincidencias.");
		}
		
		sesion.close();
		System.out.println();
	}
	public static void buscarDuracion(){
		System.out.println("Indica la duración mínima:");
		int duracionMinima = Integer.parseInt(scanner.nextLine());
		System.out.println("Indica la duración máxima:");
		int duracionMaxima = Integer.parseInt(scanner.nextLine());
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery(
				"from Series where duracion >= " + duracionMinima
				+ " and duracion <= " + duracionMaxima
			);
		List resultados = consulta.list();
		if(resultados.size() > 0){
			System.out.println("Mostrando resultados:");
			Series serie;
			for(Object resultado : resultados){
				serie = (Series) resultado;
				System.out.println("Código: " + serie.getCodigo()
				+ "; Nombre: " + serie.getNombre()
				+ "; Cadena emisión: " + serie.getCadena()
				+ "; Duración media de capítulos: " + serie.getDuracion() + ".");
			}
		}else{
			System.out.println("No se han encontrado resultados.");
		}
		sesion.close();
		System.out.println("");
	}
	
}
