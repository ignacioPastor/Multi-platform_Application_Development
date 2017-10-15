package ejerciciospropuestos_4_7_2;

import java.util.List;
import java.util.Scanner;
import java.util.Set;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;


//import ejerciciospropuestos_4_7_1.HibernateUtil;

public class Main_EjerciciosPropuestos_4_7_2 {
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
			System.out.println("1. Ver series.");
			System.out.println("2. Ver cadenas.");
			System.out.println("3. Añadir serie.");
			System.out.println("4. Añadir cadena.");
			System.out.println("5. Modificar serie.");
			System.out.println("6. Modificar cadena.");
			System.out.println("7. Borrar serie.");
			System.out.println("0. Salir.");
			opcion = scanner.nextLine();
			
			switch(opcion){
				case "1": verSeries(); break;
				case "2": verCadenas(); break;
				case "3": anyadirSerie(); break;
				case "4": anyadirCadena(); break;
				case "5": modificarSerie(); break;
				case "6": modificarCadena(); break;
				case "7": borrarSerie(); break;
				case "0": System.out.println("Saliendo del programa..."); break;
				default: System.out.printf("No es una opción válida!%n%n"); break;
			}
		}while(!opcion.equals("0"));
		
		
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	private static void borrarSerie(){
		verSeries();
		System.out.println("Indica el código de la serie que quieres borrar");
		int codigo = Integer.parseInt(scanner.nextLine());
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Series"
				+ " where codigo = :codigoParam")
				.setParameter("codigoParam", codigo);
		List resultados = consulta.list();
		Series serie = (Series) resultados.get(0);
		System.out.println("Es esta la serie que quieres borrar? (S/N)");
		mostrarSerie(serie);
		String respuesta = scanner.nextLine();
		if(respuesta.toUpperCase().equals("S")){
			Transaction trans = sesion.beginTransaction();
			sesion.delete(serie);
			trans.commit();
			System.out.println("Serie borrada!");
		}else
			System.out.println("No se ha borrado la serie.");
		System.out.println("");
		sesion.close();
		
	}
	private static void verSeries(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Series");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Series serie;
			for(Object resultado : resultados){
				serie = (Series) resultado;
				mostrarSerie(serie);
			}
		}else{
			System.out.println("No hay resultados que mostrar.");
		}
		sesion.close();
		System.out.println("");
	}
	private static void verCadenas(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Cadenas");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Cadenas cadena;
			for(Object resultado : resultados){
				cadena = (Cadenas) resultado;
				mostrarCadena(cadena);
			}
		}else{
			System.out.println("No hay resultados que mostrar.");
		}
		sesion.close();
		System.out.println("");
		
	}
	private static void anyadirSerie(){
		System.out.println("Nueva Serie:");
		System.out.println("Indica el codigo de la serie:");
		int codigo = Integer.parseInt(scanner.nextLine());
		System.out.println("Indica el nombre de la serie:");
		String nombre = scanner.nextLine();
		System.out.println("Indica el código de la cadena en la que se emite:");
		String codCadena = scanner.nextLine();
		System.out.println("Inidca la duración media de los capítulos");
		int duracion = Integer.parseInt(scanner.nextLine());
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		//Query consulta = sesion.createQuery("from Cadenas "
		//		+ "where codigo = '" + codCadena + "'");
		Query consulta = sesion.createQuery("from Cadenas "
				+ "where codigo = :codCadenaPara")
					.setParameter("codCadenaPara",  codCadena);
		Cadenas cadena = (Cadenas) consulta.list().get(0);
		Series serie = new Series(codigo, cadena, nombre, duracion);
		sesion.save(serie);
		trans.commit();
		
		sesion.close();
		System.out.println("Serie guardada!");
		System.out.println("");
	}
	private static void anyadirCadena(){
		System.out.println("Nueva Cadena.");
		System.out.println("Indica el código de la cadena:");
		String codigo = scanner.nextLine();
		System.out.println("Indica el nombre de la cadena:");
		String nombre = scanner.nextLine();
		Cadenas cadena = new Cadenas(codigo, nombre, null);
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		sesion.save(cadena);
		trans.commit();
		
		sesion.close();
		System.out.println("Cadena guardada!");
		System.out.println("");
	}
	private static void modificarSerie(){
		verSeries();
		System.out.println("Indica el código de la serie que quieres modificar");
		int codigo = Integer.parseInt(scanner.nextLine());
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		Query consulta = sesion.createQuery("from Series where codigo "
				+ "= :codigoParam").setParameter("codigoParam", codigo);
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Series serie = (Series) resultados.get(0);
			System.out.println("Es esta la serie que quieres modificar? (S/N)");
			mostrarSerie(serie);
			String respuesta = scanner.nextLine();
			if(respuesta.toUpperCase().equals("S")){
				System.out.println("Indica el nuevo nombre de la serie:");
				String nombre = scanner.nextLine();
				System.out.println("Indica la nueva duración de la serie:");
				int duracion = Integer.parseInt(scanner.nextLine());
				serie.setNombre(nombre);
				serie.setDuracion(duracion);
				sesion.update(serie);
				trans.commit();
				System.out.println("Serie modificada!");
			}else{
				System.out.println("Saliendo de modificar Serie...");
			}
		}else{
			System.out.println("No se ha encontrado la serie indicada.");
		}
		sesion.close();
		System.out.println("");
	}
	private static void modificarCadena(){
		verCadenas();
		System.out.println("Indica el código de la cadena que quieres modificar");
		String codigo = scanner.nextLine();
	
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		Query consulta = sesion.createQuery("from Cadenas "
				+ "where codigo = :codigoParam")
				.setParameter("codigoParam", codigo);
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Cadenas cadena = (Cadenas) resultados.get(0);
			System.out.println("Es esta la cadena que quieres modificar? (S/N)");
			mostrarCadena(cadena);
			String respuesta = scanner.nextLine();
			if(respuesta.toUpperCase().equals("S")){
				System.out.println("Indica el nuevo nombre de la cadena:");
				String nuevoNombre = scanner.nextLine();
				cadena.setNombre(nuevoNombre);
				sesion.update(cadena);
				trans.commit();
				System.out.println("Cadena guardada!");
			}else{
				System.out.println("Saliendo de modificar cadena...");
			}
		}else{
			System.out.println("No se han encontrado resultados.");
		}
		sesion.close();
		System.out.println("");
	}
	private static void mostrarSerie(Series serie){
		System.out.println("CodigoSerie: " + serie.getCodigo()
			+ ", NombreSerie: " + serie.getNombre()
			+ ", códigoCadena: " + serie.getCadenas().getCodigo()
			+ ", nombreCadena: " + serie.getCadenas().getNombre()
			+ ", Duración: " + serie.getDuracion() + ".");
	}
	private static void mostrarCadena(Cadenas cadena){
		System.out.println("CodigoCadena: " + cadena.getCodigo()
			+ ", NombreCadena: " + cadena.getNombre());
		Set resultSeries = cadena.getSerieses();
		Series serie;
		for(Object resultSerie : resultSeries){
			serie = (Series) resultSerie;
			System.out.print("        ");
			mostrarSerie(serie);
		}
	}
}
