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
			System.out.println("2. A�adir serie.");
			System.out.println("3. Buscar por t�tulo.");
			System.out.println("4. Buscar por duraci�n.");
			System.out.println("5. Mostrar de cu�ntas series de cada canal tenemos constancia.");
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
					default: System.out.printf("No es una opci�n v�lida!%n%n"); break;
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
				System.out.println("C�digo: " + serie.getCodigo()
				+ "; Nombre: " + serie.getNombre()
				+ "; Cadena emisi�n: " + serie.getCadena()
				+ "; Duraci�n media de cap�tulos: " + serie.getDuracion() + ".");
			}
		}else{
			System.out.println("No se han encontrado coincidencias.");
		}
		sesion.close();
		System.out.println("");
	}
	public static void anyadirSerie(){
		System.out.println("Indica el c�digo:");
		int codigo = Integer.parseInt(scanner.nextLine());
		System.out.println("Indica el t�tulo:");
		String titulo = scanner.nextLine();
		System.out.println("Indica la cadena en la que se emite:");
		String cadena = scanner.nextLine();
		System.out.println("Indica la duraci�n media del cap�tulo:");
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
		System.out.println("Indica el t�tulo que quieres buscar:");
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
				System.out.println("T�tulo: " + titulo);
			}
		}else{
			System.out.println("No se han encontrado coincidencias.");
		}
		
		sesion.close();
		System.out.println();
	}
	public static void buscarDuracion(){
		System.out.println("Indica la duraci�n m�nima:");
		int duracionMinima = Integer.parseInt(scanner.nextLine());
		System.out.println("Indica la duraci�n m�xima:");
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
				System.out.println("C�digo: " + serie.getCodigo()
				+ "; Nombre: " + serie.getNombre()
				+ "; Cadena emisi�n: " + serie.getCadena()
				+ "; Duraci�n media de cap�tulos: " + serie.getDuracion() + ".");
			}
		}else{
			System.out.println("No se han encontrado resultados.");
		}
		sesion.close();
		System.out.println("");
	}
	
}
