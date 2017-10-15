package ejerciciospropuestos_4_4_1;

import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

public class Main_EjerciciosPropuestos_4_4_1 {
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
			System.out.println("2. Añadir serie.");
			System.out.println("3. Buscar por nombre parcial");
			System.out.println("0. Salir.");
			opcion = scanner.nextLine();
			switch(opcion){
				case "1": mostrarDatos(); break;
				case "2": anyadirSerie(); break;
				case "3": buscarPorTitulo(); break;
				case "0": System.out.println("Saliendo del programa..."); break;
				default: System.out.println("Opción no válida!"); break;
			}
		}while(!opcion.equals("0"));
		
		
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	public static void mostrarDatos(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Series");
		List resultados = consulta.list();
		Series serie;
		for(Object resultado : resultados){
			serie = (Series) resultado;
			System.out.println("Codigo: " + serie.getCodigo()
					+ "; Nombre: " + serie.getNombre()
					+ "; Cadena: " + serie.getCadena()
					+ "; Duración: " + serie.getDuracion() + ".");
		}
		sesion.close();
	}
	public static void anyadirSerie(){
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
		System.out.println("Libro guardado!");
	}
	public static void buscarPorTitulo(){
		System.out.println("Indica el título o parte del título:");
		String cadena = scanner.nextLine();
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("select nombre "
											+ "from Series "
			+ "where upper(nombre) like '%" + cadena.toUpperCase() + "%' "
											+ "order by nombre");
		List resultados = consulta.list();
		String titulo;
		if(resultados.size() == 0){
			System.out.println("No se han encontrado coincidencias!");
		}else{
			System.out.println("Coincidencias encontradas:");
			for(Object resultado : resultados){
				titulo = (String) resultado;
				System.out.println("Título: " + titulo);
			}
		}
		sesion.close();
	}
}
