package ejerciciospropuestos_4_4_3;
// Generated 16-ene-2017 11:03:20 by Hibernate Tools 4.3.1.Final

/**
 * Series generated by hbm2java
 */
public class Series implements java.io.Serializable {

	private int codigo;
	private String nombre;
	private String cadena;
	private Integer duracion;

	public Series() {
	}

	public Series(int codigo) {
		this.codigo = codigo;
	}

	public Series(int codigo, String nombre, String cadena, Integer duracion) {
		this.codigo = codigo;
		this.nombre = nombre;
		this.cadena = cadena;
		this.duracion = duracion;
	}

	public int getCodigo() {
		return this.codigo;
	}

	public void setCodigo(int codigo) {
		this.codigo = codigo;
	}

	public String getNombre() {
		return this.nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getCadena() {
		return this.cadena;
	}

	public void setCadena(String cadena) {
		this.cadena = cadena;
	}

	public Integer getDuracion() {
		return this.duracion;
	}

	public void setDuracion(Integer duracion) {
		this.duracion = duracion;
	}

}
