package biblioteca;
/**
 * Clase que caracteriza el objeto Libro
 * @author Ignacio Pastor Padilla
 * Practica Acceso a Datos, Proyecto Biblioteca
 *
 */
public class Libro {
	
	private int isbn;
	private String titulo;
	private String autor;
	private String editorial;
	private int anyoPublicacion;
	private boolean edicionLujo;
	
	/**
	 * Constructor vacío
	 */
	public Libro(){
		
	}
	/**
	 * Constructor sobrecargado
	 * @param isbn
	 * @param titulo
	 * @param autor
	 * @param editorial
	 * @param anyoPublicacion
	 * @param edicionLujo
	 */
	public Libro(int isbn, String titulo, String autor, String editorial, 
			int anyoPublicacion, boolean edicionLujo){
		this.isbn = isbn;
		this.titulo = titulo;
		this.autor = autor;
		this.editorial = editorial;
		this.anyoPublicacion = anyoPublicacion;
		this.edicionLujo = edicionLujo;
	}
	
	public void setIsbn(int isbn){
		this.isbn = isbn;
	}
	public int getIsbn(){
		return isbn;
	}
	public void setTitulo(String titulo){
		this.titulo = titulo;
	}
	public String getTitulo(){
		return titulo;
	}
	public void setAutor(String autor){
		this.autor = autor;
	}
	public String getAutor(){
		return autor;
	}
	public void setEditorial(String editorial){
		this.editorial = editorial;
	}
	public String getEditorial(){
		return editorial;
	}
	public void setAnyoPublicacion(int anyoPublicacion){
		this.anyoPublicacion = anyoPublicacion;
	}
	public int getAnyoPublicacion(){
		return anyoPublicacion;
	}
	public void setEdicionLujo(boolean edicionLujo){
		this.edicionLujo = edicionLujo;
	}
	public boolean getEdicionLujo(){
		return edicionLujo;
	}
	
	
	
	
}
