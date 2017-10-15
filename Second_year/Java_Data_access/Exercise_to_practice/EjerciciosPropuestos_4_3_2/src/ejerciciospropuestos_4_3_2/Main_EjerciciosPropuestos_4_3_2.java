package ejerciciospropuestos_4_3_2;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

public class Main_EjerciciosPropuestos_4_3_2 {

	public static void main(String[] args) {
		@SuppressWarnings("unused")
		org.jboss.logging.Logger logger = 
			org.jboss.logging.Logger.getLogger("org.hibernate");
		java.util.logging.Logger.getLogger("org.hibernate")
			.setLevel(java.util.logging.Level.SEVERE);
			
		mostrarDatos();
		
		HibernateUtil.getSessionFactory().close();
	}
	
	public static void mostrarDatos(){
		Session sesion = HibernateUtil.getSessionFactory().openSession();
		Query consulta = sesion.createQuery("from Series");
		List resultados = consulta.list();
		
		Series serie;
		System.out.println("Mostrando todos los datos:");
		for(Object resultado : resultados){
			serie = (Series) resultado;
			System.out.println("Codigo: " + serie.getCodigo() 
				+ "; Nombre: " + serie.getNombre() + "; Cadena: "
				+ serie.getCadena() + "; Duración: " + serie.getDuracion());
		}
	}

}
