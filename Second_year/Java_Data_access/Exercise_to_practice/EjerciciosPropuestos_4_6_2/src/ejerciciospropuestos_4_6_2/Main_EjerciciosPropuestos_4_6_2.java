package ejerciciospropuestos_4_6_2;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

public class Main_EjerciciosPropuestos_4_6_2 {

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
		
		if(resultados.size() > 0){
			System.out.println("Mostrando datos:");
			Series serie;
			for(Object resultado : resultados){
				serie = (Series) resultado;
				System.out.println("Código: " + serie.getCodigo()
					+ "; Título: " + serie.getNombre()
					+ "; Código cadena: " + serie.getCadenas().getCodigo()
					+ "; Nombre cadena: " + serie.getCadenas().getNombre()
					+ "; Duración media: " + serie.getDuracion() + ".");
			}
		}else{
			System.out.println("No hay datos que mostrar.");
		}
		sesion.close();
		System.out.println("");
	}
}
