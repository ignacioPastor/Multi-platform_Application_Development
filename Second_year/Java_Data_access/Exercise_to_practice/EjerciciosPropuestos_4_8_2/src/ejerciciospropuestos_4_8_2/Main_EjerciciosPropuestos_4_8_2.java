package ejerciciospropuestos_4_8_2;

import java.util.List;
import java.util.Scanner;
import java.util.Set;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;


public class Main_EjerciciosPropuestos_4_8_2 {
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
			System.out.println("8. Borrar espacios iniciales y finales"
					+ " de los nombres de las series");
			System.out.println("9. Añadir actores.");
			System.out.println("10. Ver actores.");
			System.out.println("11. Indicar actuación de un actor en una serie");
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
				case "8": borrarEspaciosNombresSeries(); break;
				case "9": anyadirActores(); break;
				case "10": verActores(); break;
				case "11": indicarActuacion(); break;
				case "0": System.out.println("Saliendo del programa..."); break;
				default: System.out.printf("No es una opción válida!%n%n"); break;
			}
		}while(!opcion.equals("0"));
		
		
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	private static void indicarActuacion(){
		verActores();
		System.out.println("Indica el código del actor");
		String idActor = scanner.nextLine();
		verSeries();
		System.out.println("Indica el código de la serie");
		int codigoSerie = Integer.parseInt(scanner.nextLine());
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consultaSerie = sesion.createQuery("from Series"
				+ " where codigo = :codigoParam")
				.setParameter("codigoParam", codigoSerie);
		Query consultaActor = sesion.createQuery("from Actores "
				+ " where id = :idParam").setParameter("idParam", idActor);
		List resultadosSerie = consultaSerie.list();
		List resultadosActor = consultaActor.list();
		if(resultadosActor.size() == 0){
			System.out.println("Ese actor no está en la base de datos!");
			System.out.println("Volviendo al programa principal...");
		}else if(resultadosSerie.size() == 0){
			System.out.println("Esa serie no está en la base de datos!");
			System.out.println("Volviendo al programa principal...");
		}else{
			Actores actor = (Actores) resultadosActor.get(0);
			Series serie = (Series) resultadosSerie.get(0);
			actor.getSerieses().add(serie);
			//mostrarSerie(serie);
			
			Transaction trans = sesion.beginTransaction();
			//Query insertarActuar = sesion.createQuery("insert into actuar "
			//		+ "(id, codigo) values (:idParam, :codigoParam)")
			//		.setParameter("idParam", actor.getId())
			//		.setParameter("codigoParam", serie.getCodigo());
			//insertarActuar.executeUpdate();
			//trans.commit();
			
			//actor.addSerie(serie);
			//serie.getActoreses().add(actor);
			sesion.save(actor);
			trans.commit();
			System.out.println("Actuación añadida con éxito!");
		}
		
		System.out.println("");
		sesion.close();
	}
	private static void verActores(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Actores");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			Actores actor;
			for(Object resultado : resultados){
				actor = (Actores) resultado;
				mostrarActor(actor);
			}
		}else{
			System.out.println("No hay resultados que mostrar");
		}
		
		System.out.println("");
		sesion.close();
	}
	private static void anyadirActores(){
		
	}
	private static void borrarEspaciosNombresSeries(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		Query consulta = sesion.createQuery("update Series set "
				+ " nombre = trim(nombre) "
				+ "where nombre <> trim(nombre)");
		
		int nFilasAfectadas = consulta.executeUpdate();
		trans.commit();
		
		System.out.println("Operación realizada con éxito!");
		System.out.println("Se han modificado " + nFilasAfectadas + " filas");
		System.out.println("");
		sesion.close();
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
		Series serie = new Series(codigo, cadena, nombre, duracion, null);
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
	private static void mostrarActor(Actores actor){
		System.out.println("Id: " + actor.getId()
				+ ", Nombre: " + actor.getNombre()
				+ ", Apellidos: " + actor.getApellidos());
		
		Set actuarSeries = actor.getSerieses();
		if(actuarSeries != null && actuarSeries.size() > 0){
			Series serie;
			
			for(Object actuadas : actuarSeries){
				serie = (Series) actuadas;
				System.out.print("        ");
				mostrarSerie(serie);
			}
		}
	}
}
