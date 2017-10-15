package ejerciciospropuestos_4_7_1;
// Generated 16-ene-2017 15:27:07 by Hibernate Tools 4.3.1.Final

/**
 * Series generated by hbm2java
 */
public class Series implements java.io.Serializable {

	private int codigo;
	private Cadenas cadenas;
	private String nombre;
	private Integer duracion;

	public Series() {
	}

	public Series(int codigo) {
		this.codigo = codigo;
	}

	public Series(int codigo, Cadenas cadenas, String nombre, Integer duracion) {
		this.codigo = codigo;
		this.cadenas = cadenas;
		this.nombre = nombre;
		this.duracion = duracion;
	}

	public int getCodigo() {
		return this.codigo;
	}

	public void setCodigo(int codigo) {
		this.codigo = codigo;
	}

	public Cadenas getCadenas() {
		return this.cadenas;
	}

	public void setCadenas(Cadenas cadenas) {
		this.cadenas = cadenas;
	}

	public String getNombre() {
		return this.nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public Integer getDuracion() {
		return this.duracion;
	}

	public void setDuracion(Integer duracion) {
		this.duracion = duracion;
	}

}