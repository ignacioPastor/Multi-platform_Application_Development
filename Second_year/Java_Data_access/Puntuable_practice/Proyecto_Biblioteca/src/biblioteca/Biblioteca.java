package biblioteca;

import java.util.List;
import java.util.Scanner;

import com.db4o.Db4o;
import com.db4o.ObjectContainer;
import com.db4o.ObjectSet;
import com.db4o.query.Predicate;

/**
 * Clase que contiene el main, y la lógica del programa
 * @author Ignacio Pastor Padilla
 * Practica Acceso a Datos, Proyecto Biblioteca
 *
 */
public class Biblioteca {
	public static Scanner scanner = new Scanner(System.in);
	public static ObjectContainer db = null;
	
	/**
	 * Main principal
	 * @param args
	 */
	@SuppressWarnings("deprecation")
	public static void main(String[] args) {
		boolean salir = false;
		try{
		db = Db4o.openFile("personas.dat");
		do{
			int opcion = mostrarMenu();
			switch(opcion){
				case 1: anyadirLibro(); break;
				case 2: anyadirRevista(); break;
				case 3: buscarLibros(); break;
				case 4: buscarRevistas(); break;
				case 5: listarLibros(); break;
				case 6: listarRevistas(); break;
				case 0: salir = true; break;
				default: System.err.println("Opción incorrecta!"); break;
			}
		}while (salir == false);
		}catch(Exception e){
			System.err.println("Error: " + e.getMessage());
		}finally{
			if(db != null)
				db.close();
		}
		scanner.close();
		System.out.printf("%nFin del programa%n");
	}
	/**
	 * Busca revistas, preguntando al usuario el título parcial o completo
	 */
	public static void buscarRevistas(){
		System.out.printf("%nBuscar revistas%n");
		System.out.print("Título: ");
		String tituloBuscar = scanner.nextLine();
		@SuppressWarnings("serial")
		List<Revista> revistas = db.query(new Predicate<Revista>(){
			public boolean match(Revista candidato){
				return candidato.getTitulo().indexOf(tituloBuscar) != -1;
			}
		});
		if(revistas.size() == 0)
			System.err.println("No se han encontrado resultados!");
		else{
			for(Revista r : revistas){
				System.out.printf("Revista: issn = %d, título = %s, editorial = %s, año publicación = %d, mes publicación = %d%n",
						r.getIssn(), r.getTitulo(), r.getEditorial(), r.getAnyoPublicacion(), r.getMesPublicacion());
			}
		}
	}
	/**
	 * Busca libro, pidiendo al usuario el título, parcial o completo
	 */
	public static void buscarLibros(){
		System.out.printf("%nBuscar libros%n");
		System.out.print("Título: ");
		String tituloBuscar = scanner.nextLine();
		@SuppressWarnings("serial")
		List<Libro> libros = db.query(new Predicate<Libro>(){
			public boolean match(Libro candidato){
				return candidato.getTitulo().indexOf(tituloBuscar) != -1;
			}
		});
		if(libros.size() == 0)
			System.err.println("No se han encontrado resultados!");
		else{
			for(Libro l : libros){
				System.out.printf("Libro: isbn = %d, título = %s, autor = %s, editorial = %s, año publicación = %d, lujo = %b%n",
						l.getIsbn(), l.getTitulo(), l.getAutor(),l.getEditorial(), l.getAnyoPublicacion(), l.getEdicionLujo());
			}
		}
		
	}
	/**
	 * Lista todas las revistas almacenadas en la base de datos
	 */
	@SuppressWarnings("deprecation")
	public static void listarRevistas(){
		System.out.println();
		System.out.println("Listado de revistas");
		System.out.println("-------------------");
		@SuppressWarnings("rawtypes")
		ObjectSet listaRevistas = db.get(new Revista());
		while(listaRevistas.hasNext()){
			Revista r = (Revista) listaRevistas.next();
			System.out.printf("Revista: issn = %d, título = %s, editorial = %s, año publicación = %d, mes publicación = %d%n",
					r.getIssn(), r.getTitulo(), r.getEditorial(), r.getAnyoPublicacion(), r.getMesPublicacion());
		}
		System.out.printf("Total revistas: %d%n", listaRevistas.size());
	}
	/**
	 * Lista todos los libros de la base de datos
	 */
	@SuppressWarnings("deprecation")
	public static void listarLibros(){
		System.out.println();
		System.out.println("Listado de libros");
		System.out.println("-----------------");
		@SuppressWarnings("rawtypes")
		ObjectSet listaLibros = db.get(new Libro());
		while(listaLibros.hasNext()){
			Libro l = (Libro) listaLibros.next();
			System.out.printf("Libro: isbn = %d, título = %s, autor = %s, editorial = %s, año publicación = %d, lujo = %b%n",
					l.getIsbn(), l.getTitulo(), l.getAutor(),l.getEditorial(), l.getAnyoPublicacion(), l.getEdicionLujo());
		}
		System.out.printf("Total libros: %d%n", listaLibros.size());
	}
	/**
	 * Gestiona el pedido de datos de una nueva revista al usuario y el cargado de una nueva revista en la base de datos
	 */
	@SuppressWarnings("deprecation")
	public static void anyadirRevista(){
		Revista r = new Revista();
		System.out.printf("%nAñadir revista%n");
		System.out.print("ISSN: ");
		r.setIssn(Integer.parseInt(scanner.nextLine()));
		System.out.printf("Título: ");
		r.setTitulo(scanner.nextLine());
		System.out.printf("Editorial: ");
		r.setEditorial(scanner.nextLine());
		System.out.printf("Mes publicación: ");
		r.setMesPublicacion(Integer.parseInt(scanner.nextLine()));
		System.out.printf("Año publicación: ");
		r.setAnyoPublicacion(Integer.parseInt(scanner.nextLine()));
		
		if(!existeIssn(r)){
			db.set(r);
			db.commit();
			System.out.println("Revista guardada!");
		}else
			System.err.println("Error, el ISSN ya existe en la base de datos!");
	}
	/**
	 * Comprueba si el ISSN de una revista existe ya en la base de datos
	 * @param r Revista cuyo ISSN queremos comprobar
	 * @return true si el ISSN ya existe en la base de datos
	 */
	public static boolean existeIssn(Revista r){
		@SuppressWarnings("serial")
		List<Revista> revistas = db.query(new Predicate<Revista>(){
			public boolean match(Revista candidato){
				return candidato.getIssn() == r.getIssn();
			}
		});
		return revistas.size() != 0 ? true : false;
	}
	/**
	 * Gestiona el pedido de datos de un nuevo libro al usuario y su posterior cargado en la base de datos
	 */
	@SuppressWarnings("deprecation")
	public static void anyadirLibro(){
		Libro l = new Libro();
		System.out.printf("%nAñadir libro%n");
		System.out.print("ISBN: ");
		l.setIsbn(Integer.parseInt(scanner.nextLine()));
		System.out.printf("Título: ");
		l.setTitulo(scanner.nextLine());
		System.out.printf("Autor: ");
		l.setAutor(scanner.nextLine());
		System.out.printf("Editorial: ");
		l.setEditorial(scanner.nextLine());
		System.out.printf("Año: ");
		l.setAnyoPublicacion(Integer.parseInt(scanner.nextLine()));
		System.out.printf("Lujo (s/n): ");
		l.setEdicionLujo(scanner.nextLine().equals("s")?true:false);
		
		if(!existeIsbn(l)){
			db.set(l);
			db.commit();
			System.out.println("Libro guardado!");
		}
		else
			System.err.println("Error, el ISBN ya existe en la base de datos!");
	}
	/**
	 * Comprueba si el ISBN de un libro exite ya en la base de datos
	 * @param l Libro cuyo ISBN queremos saber si ya existe en la base de datos
	 * @return true si el ISBN ya existe en la base de datos
	 */
	@SuppressWarnings("serial")
	public static boolean existeIsbn(Libro l){
			List<Libro> libros = db.query(new Predicate<Libro>(){
				public boolean match(Libro candidato){
					return candidato.getIsbn() == l.getIsbn();
				}
			});
			return libros.size() != 0 ? true : false;
	}
	/**
	 * Muestra el menú de opciones disponibles para el usuario
	 * @return la opción elegida por el usuario. En caso de error, devuelve -1
	 */
	public static int mostrarMenu(){
		int opcion;
		
		System.out.println();
		System.out.println("Biblioteca");
		System.out.println("----------");
		System.out.println();
		System.out.println("1- Añadir libros");
		System.out.println("2- Añadir revistas");
		System.out.println("3- Buscar libros");
		System.out.println("4- Buscar revistas");
		System.out.println("5- Listar libros");
		System.out.println("6- Listar revistas");
		System.out.println("0- Salir");
		System.out.println();
		System.out.print("Elige una opción: ");
		try{
			opcion = Integer.parseInt(scanner.nextLine());
		}catch(NumberFormatException e){
			opcion = -1;
		}
		return opcion;
	}
}
