package e2e3;

import java.util.Scanner;

public class E2e3 {
	
	static	String	getEmployeeNameForIndex(int index) {
		return "Employee" + index;
	}

	private static void printEmployees1(Company company) {
            int contador = 0;
		System.out.println("Turnos 1");
		for (int i = 0; i < company.getEmployeeCount(); i++){
                    
                    //System.out.println("contador vale " + contador);
                    contador++;
			System.out.println(company.getEmployeeAt(i).getName(false));
                }
	}

	private static void printEmployees2(Company company) {
            int contador = 0;
		Employee[] employees = company.getEmployees();
		System.out.println("Turnos 2");
		for (Employee employee : employees){
                    
                   // System.out.println("contador vale " + contador);
                    contador++;
			System.out.println(employee.getName(false));
                }
	}

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int index = sc.nextInt();
		
		if (index == 0) {
			Employee employee = new Employee("juan");
			System.out.print(employee.getName(false));
			System.out.print(employee.getName(true));
		}
		if (index == 1) {
			Employee employee = new Employee("juan");
			employee.setName(null);
			System.out.print(employee.getName(false));
			System.out.print(employee.getName(true));
		}
		if (index == 2) {
			Company company = new Company();
			for (int i = 0; i < 20; i++)
				company.addEmployee(new Employee(getEmployeeNameForIndex(i)));
			printEmployees1(company);
		}
		if (index == 3) {
			Company company = new Company();
			for (int i = 0; i < 20; i++)
				company.addEmployee(((i % 2) == 0) ? null : new Employee(getEmployeeNameForIndex(i)));
			for (int i = 0; i < 5; i++)
				company.removeEmployee(getEmployeeNameForIndex(i));
			printEmployees2(company);
		}
		if (index == 4) {
			Company company = new Company();
			for (int j = 0; j < 100; j++) {
				for (int i = 0; i < 20; i++)
					company.addEmployee(new Employee(getEmployeeNameForIndex(i)));
				for (int i = 0; i < 20; i++)
					if (i % 2 == 0)
						company.removeEmployee(getEmployeeNameForIndex(i));
				for (int i = 0; i < 20; i++)
					company.removeEmployee(getEmployeeNameForIndex(i));
			}
			printEmployees2(company);
		}
		if (index == 5) {
			Company company = new Company();
			for (int j = 0; j < 100; j++) {
				for (int i = j * 4; i < (j + 1) * 4; i++)
					company.addEmployee(new Employee(getEmployeeNameForIndex(i)));
				for (int i = j * 4; i < (j + 1) * 4 - 1; i++)
					company.removeEmployee(getEmployeeNameForIndex(i));
			}
			printEmployees1(company);
		}
	}	
}
