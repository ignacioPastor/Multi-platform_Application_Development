package biblioteca;
/**
 * Clase que caracteriza el objeto Revista
 * @author Ignacio Pastor Padilla
 * Practica Acceso a Datos, Proyecto Biblioteca
 *
 */
public class Revista {
	
	private int issn;
	private String titulo;
	private String editorial;
	private int anyoPublicacion;
	private int mesPublicacion;
	
	/**
	 * Constructor vacío
	 */
	public Revista(){
		
	}
	/**
	 * Constructor sobrecargado
	 * @param issn
	 * @param titulo
	 * @param editorial
	 * @param anyoPublicacion
	 * @param mesPublicacion
	 */
	public Revista(int issn, String titulo, String editorial, 
			int anyoPublicacion, int mesPublicacion){
		this.issn = issn;
		this.titulo = titulo;
		this.editorial = editorial;
		this.anyoPublicacion = anyoPublicacion;
		this.mesPublicacion = mesPublicacion;
	}
	
	public void setIssn(int issn){
		this.issn = issn;
	}
	public int getIssn(){
		return issn;
	}
	public void setTitulo(String titulo){
		this.titulo = titulo;
	}
	public String getTitulo(){
		return titulo;
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
	public void setMesPublicacion(int mesPublicacion){
		this.mesPublicacion = mesPublicacion;
	}
	public int getMesPublicacion(){
		return mesPublicacion;
	}
}
