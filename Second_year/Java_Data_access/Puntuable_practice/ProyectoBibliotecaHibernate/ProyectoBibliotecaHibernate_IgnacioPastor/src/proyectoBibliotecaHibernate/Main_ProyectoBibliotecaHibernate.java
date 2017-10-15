package proyectoBibliotecaHibernate;

import java.sql.SQLException;
import java.util.List;
import java.util.Scanner;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;

/**
 * Proyecto Biblioteca Hibernate, práctica Tema 4 - Acceso a Datos
 * @author Ignacio Pastor Padilla - 2º DAM - Semipresencial
 * En este proyecto se implementa una biblioteca con una base de datos en postgre utilizando hibernate
 */
public class Main_ProyectoBibliotecaHibernate {
	
	static Scanner scanner = new Scanner(System.in);
	
	public static void main(String[] args) {
		@SuppressWarnings("unused")
		org.jboss.logging.Logger logger = 
			org.jboss.logging.Logger.getLogger("org.hibernate");
		java.util.logging.Logger.getLogger("org.hibernate")
			.setLevel(java.util.logging.Level.SEVERE);
		
		
		String opcion;
		do{
			System.out.println("Biblioteca");
			System.out.printf("----------%n%n");
			System.out.println("1- Añadir libros");
			System.out.println("2- Añadir revistas");
			System.out.println("3- Buscar libros");
			System.out.println("4- Buscar revistas");
			System.out.println("5- Listar libros");
			System.out.println("6- Listar revistas");
			System.out.printf("0- Salir%n%n");
			System.out.print("Elige una opción: ");
			opcion = scanner.nextLine();
			
			switch(opcion){
				case "1": anyadirLibro(); break;
				case "2": anyadirRevista(); break;
				case "3": buscarLibro(); break;
				case "4": buscarRevista(); break;
				case "5": listarLibros(); break;
				case "6": listarRevistas(); break;
				case "0": System.out.printf("%nFin de programa%n%n"); break;
				default: System.err.printf("Opción incorrecta!%n%n"); break;
			}
		}while(!opcion.equals("0"));
		
		scanner.close();
		HibernateUtil.getSessionFactory().close();
	}
	
	/**
	 * Gestiona los procesos para añadir un nuevo libro
	 */
	private static void anyadirLibro(){
		System.out.printf("%nAñadir libro%n");
		System.out.print("ISBN: ");
		int isbn;
		try{
			isbn = Integer.parseInt(scanner.nextLine());
		}catch(NumberFormatException nfe){
			System.err.printf("Error: \"ISBN\" debe ser un número.%n%n");
			return;
		}
		System.out.print("Título: ");
		String titulo = scanner.nextLine();
		System.out.print("Autor: ");
		String autor = scanner.nextLine();
		System.out.print("Editorial: ");
		String editorial = scanner.nextLine();
		System.out.print("Año: ");
		int anyo;
		try{
			anyo = Integer.parseInt(scanner.nextLine());
		}catch(NumberFormatException nfe){
			System.err.printf("Error: \"Año\" debe ser un número.%n%n");
			return;
		}
		System.out.print("Lujo (s/n): ");
		String lujoString = scanner.nextLine();
		boolean lujo = lujoString.toUpperCase().equals("S") ? true : false;
		/*
		Libro libro = new Libro(isbn, titulo, autor, editorial, anyo, lujo);
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		*/
		Libro libro;
		Session sesion;
		
		/*
		Transaction trans = sesion.beginTransaction();
		Query consulta = sesion.createQuery("from Libro where isbn = :isbnParam").setParameter("isbnParam", isbn);
		*/
		Transaction trans;
		
		/*
		List resultados = consulta.list();
		if(resultados.size() > 0){
			System.err.println("Error, el ISBN ya existe en la base de datos!");
		}else{
			sesion.save(libro);
			trans.commit();
		}
		*/
		try{
			libro = new Libro(isbn, titulo, autor, editorial, anyo, lujo);
			sesion = HibernateUtil.getSessionFactory().openSession();
			trans = sesion.beginTransaction();
			sesion.save(libro);
			trans.commit();
			sesion.close();
		} catch(Exception e){
			System.err.println("Entra en Exception");
		    /*if(e.getErrorCode() == 23000 ){
		        System.err.println("Entra en el if");
		    }*/
		}
		//sesion.close();
				
		System.out.println("");
	}
	
	/**
	 * Gestiona los procesos para añadir una nueva revista
	 */
	private static void anyadirRevista(){
		System.out.printf("%nAñadir revista%n");
		System.out.print("ISSN: ");
		int issn;
		try{
			issn = Integer.parseInt(scanner.nextLine());
		}catch(NumberFormatException nfe){
			System.err.printf("Error: \"ISSN\" debe ser un número.%n%n");
			return;
		}
		System.out.print("Titulo: ");
		String titulo = scanner.nextLine();
		System.out.print("Editorial: ");
		String editorial = scanner.nextLine();
		System.out.print("Año publicación: ");
		int anyo;
		try{
			anyo = Integer.parseInt(scanner.nextLine());
		}catch(NumberFormatException nfe){
			System.err.printf("Error: \"Año publicación\" debe ser un número.%n%n");
			return;
		}
		System.out.print("Mes publicación: ");
		int mes;
		try{
			mes = Integer.parseInt(scanner.nextLine());
		}catch(NumberFormatException nfe){
			System.err.printf("Error: \"Mes publicación\" debe ser un número.%n%n");
			return;
		}
		
		Revista revista = new Revista(issn, titulo, editorial, anyo, mes);
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Transaction trans = sesion.beginTransaction();
		Query consulta = sesion.createQuery("from Revista where issn = :issnParam").setParameter("issnParam", issn);
		List resultados = consulta.list();
		if(resultados.size() > 0){
			System.err.println("Error: el ISSN ya existe en la base de datos!");
		}else{
			sesion.save(revista);
			trans.commit();
		}
		sesion.close();
		System.out.println("");
	}
	
	/**
	 * Gestiona los procesos para buscar un libro por título parcial introducido por el usuario
	 */
	private static void buscarLibro(){
		System.out.printf("%nBuscar libros%n");
		System.out.print("Título: ");
		String textoBuscar = scanner.nextLine();
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Libro where titulo like '%" + textoBuscar + "%'");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			for(Object resultado : resultados)
				mostrarLibro((Libro) resultado);
		}else{
			System.err.println("No se han encontrado resultados!");
		}
		sesion.close();
		System.out.println("");
	}
	/**
	 * Gestiona los procesos para buscar una revista por título parcial introducido por el usuario
	 */
	private static void buscarRevista(){
		System.out.printf("%nBuscar revistas%n");
		System.out.print("Título: ");
		String textoBuscar = scanner.nextLine();
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Revista where titulo like '%" + textoBuscar + "%'");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			for(Object resultado : resultados)
				mostrarRevista((Revista) resultado);
		}else{
			System.err.println("No se han encontrado resultados!");
		}
		sesion.close();
		System.out.println("");
	}
	/**
	 * Lista todos los libros almacenados en la base de datos
	 */
	private static void listarLibros(){
		System.out.printf("%nListado de libros%n");
		System.out.println("-----------------");
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Libro");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			for(Object resultado : resultados)
				mostrarLibro((Libro) resultado);
			System.out.println("Total libros: " + resultados.size());
		}else{
			System.err.println("No hay libros que mostrar.");
		}
		sesion.close();
		System.out.println("");
	}
	/**
	 * Lista todas las revistas almacenadas en la base de datos
	 */
	private static void listarRevistas(){
		System.out.printf("%nListado de revistas%n");
		System.out.println("--------------------");
		
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Revista");
		List resultados = consulta.list();
		if(resultados.size() > 0){
			for(Object resultado : resultados)
				mostrarRevista((Revista) resultado);
			System.out.println("Total revistas: " + resultados.size());
		}else{
			System.err.println("No hay revistas que mostrar.");
		}
		sesion.close();
		System.out.println("");
	}
	/**
	 * Imprime por consola los datos de un libro
	 * @param libro Libro cuyos datos vamos a imprimir por consola
	 */
	private static void mostrarLibro(Libro libro){
		System.out.println("Libro: isbn = " + libro.getIsbn() + ", título = " + libro.getTitulo()
			+ ", autor = " + libro.getAutor() + ", editorial = " + libro.getEditorial() + ", año = "
			+ libro.getAnyopublicacion() + ", lujo = " + libro.getEdicionlujo().toString());
	}
	/**
	 * Iprime por consola los datos de una revista
	 * @param revista Revista cuyos datos vamos a imprimir por consola
	 */
	private static void mostrarRevista(Revista revista){
		System.out.println("Revista: issn = " + revista.getIssn() + ", título = " + revista.getTitulo()
			+ ", editorial = " + revista.getEditorial() + ", mes = " + revista.getMespublicacion() 
			+ ", año = " + revista.getAnyopublicacion());
	}
}
