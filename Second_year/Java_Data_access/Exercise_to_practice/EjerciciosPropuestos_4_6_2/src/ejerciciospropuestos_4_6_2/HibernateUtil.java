package ejerciciospropuestos_4_6_2;

import org.hibernate.*;
import org.hibernate.cfg.*;

public class HibernateUtil {
	
	private static final SessionFactory sessionFactory;
	static {
	try {
	// Create the SessionFactory from standard (hibernate.cfg.xml)
	sessionFactory = new Configuration()
	.configure()
	.buildSessionFactory();
	} catch (Throwable ex) {
	// Log the exception.
	System.err.println("Initial SessionFactory creation failed."+ex);
	throw new ExceptionInInitializerError(ex);
	}
	}
	public static SessionFactory getSessionFactory() {
	return sessionFactory;
	}
	
}
