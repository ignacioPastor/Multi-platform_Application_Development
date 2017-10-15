package crewmanagement;

import java.util.Arrays;
import java.util.Scanner;

public class CrewManagement {

	static	void	printTurn(Turn turn) {
		System.out.print("<B>" + turn.getDay() + "</B>");
		System.out.print("<BR/>" + turn.getInitHour()+ "<BR/>");
		System.out.print("" + turn.getFinishHour()+ "<BR/>");
	}

	static	void	printTurns(Employee employee) {
		Turn[] turns = employee.getTurns();
		int count = turns == null ? 0 : turns.length; 
		if (count != employee.getTurnCount())	
			throw new NullPointerException();
		if (count == 0)
			System.out.print("null");
		else {
			for (Turn turn : turns) {
				if (turn == null)
					throw new NullPointerException();
				if (turn.getDay() == null)
					throw new NullPointerException();
			}
			
			System.out.print("turn count = " + count + "<BR/>");
			Arrays.sort(turns, 0, turns.length - 1, (Turn a, Turn b) -> {
				int comp = a.getDay().compareTo(b.getDay());
				if (comp != 0)
					return comp;
				if (a.getInitHour() < b.getInitHour())
					return -1;
				if (a.getInitHour() > b.getInitHour())
					return 1;
				if (a.getFinishHour() < b.getFinishHour())
					return -1;
				if (a.getFinishHour() > b.getFinishHour())
					return 1;
				return 0;
			});
			
			for (Turn turn : turns)
				printTurn(turn);
			for (int i = 0; i < count; i++) {
				printTurn(employee.getTurnAt(i));
			}
		}
	}
	
	static	String	getDayName(int i) {
		return "Day" + Integer.toString(i);
	}
	
	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int index = sc.nextInt();

		try {
					
			if (index == 0) 
			{
				Turn t = new Turn();
				t.setDay("monday");
				System.out.print(t.getDay());
			}
			if (index == 1) 
			{
				Turn t = new Turn();
				t.setDay("monday");
				t.setDay(null);
				System.out.print(t.getDay());
			}
			if (index == 2) 
			{
				Turn t = new Turn();
				t.setFinishHour(10);
				System.out.print(t.getFinishHour());
			}
			if (index == 3) 
			{
				Turn t = new Turn();
				t.setFinishHour(10);
				t.setFinishHour(-1);
				System.out.print(t.getFinishHour());
			}
			if (index == 4) 
			{
				Turn t = new Turn();
				t.setFinishHour(10);
				t.setFinishHour(24);
				System.out.print(t.getFinishHour());
			}
			if (index == 5) 
			{
				Turn t = new Turn();
				t.setInitHour(10);
				System.out.print(t.getInitHour());
			}
			if (index == 6) 
			{
				Turn t = new Turn();
				t.setInitHour(10);
				t.setInitHour(-1);
				System.out.print(t.getInitHour());
			}
			if (index == 7) 
			{
				Turn t = new Turn();
				t.setInitHour(10);
				t.setInitHour(24);
				System.out.print(t.getInitHour());
			}
			if (index == 7) 
			{
				Turn t = new Turn("lunes", 1, 2);
				System.out.print(t.getDay());
				System.out.print(t.getInitHour());
				System.out.print(t.getFinishHour());
			}
			if (index == 8) 
			{
				Employee e = new Employee("Juan", "Perez", "11111111h");
				System.out.print(e.getName());
				System.out.print(e.getSurname());
				System.out.print(e.getDNI().toLowerCase());
			}
			if (index == 9) 
			{
				Employee e = new Employee("Juan", "Perez", "11111111H");
				System.out.print(e.getName());
				System.out.print(e.getSurname());
				System.out.print(e.getDNI().toLowerCase());
			}
			if (index == 10) 
			{
				Employee e = new Employee();
				e.setName("Juan");
				e.setName(null);
				System.out.print(e.getName());
			}
			if (index == 11) 
			{
				Employee e = new Employee();
				e.setDNI("11111111h");
				System.out.print(e.getDNI().toLowerCase());
			}
			if (index == 12) 
			{
				Employee e = new Employee();
				e.setDNI("11111111H");
				System.out.print(e.getDNI().toLowerCase());
			}
			if (index == 13) 
			{
				Employee e = new Employee();
				e.setDNI("11111111H");
				e.setDNI("1111111H");
				System.out.print(e.getDNI().toLowerCase());
			}
			if (index == 14) 
			{
				Employee e = new Employee();
				e.setDNI("11111111H");
				e.setDNI("12345678H");
				System.out.print(e.getDNI().toLowerCase());
			}
			if (index == 15) 
			{
				Employee e = new Employee();
				e.setDNI("11111111H");
				e.setDNI("12345678h");
				System.out.print(e.getDNI().toLowerCase());
			}
			if (index == 16) 
			{
				Employee e = new Employee();
				e.setDNI("11111111H");
				e.setDNI(null);
				System.out.print(e.getDNI() == null ? null : e.getDNI().toLowerCase());
			}
			if (index == 17) 
			{
				Employee e = new Employee();
				for (int i = 0; i < 10; i++)
					e.addTurn(new Turn(getDayName(i), 1, 3));
				printTurns(e);
			}
			if (index == 18) 
			{
				Employee e = new Employee();
				for (int i = 0; i < 10; i++)
					e.addTurn(null);
				printTurns(e);
			}
			if (index == 19) 
			{
				Employee e = new Employee();
				for (int i = 0; i < 10; i++)
					e.addTurn(new Turn(getDayName(i), 1, 3));
				for (int i = 0; i < 10; i++)
					e.removeTurn(getDayName(i));
				printTurns(e);
			}
			if (index == 20) 
			{
				Employee e = new Employee();
				for (int j = 0; j < 100; j++) {
					for (int i = 0; i < 10; i++)
						e.addTurn(new Turn(getDayName(i), 1, 3));
					for (int i = 0; i < 10; i++)
						e.removeTurn(getDayName(i));
				}
				for (int i = 0; i < 10; i++)
					e.addTurn(new Turn(getDayName(i), 1, 3));
				printTurns(e);
			}
			if (index == 21) 
			{
				Employee e = new Employee();
				for (int i = 0; i < 10; i++)
					e.addTurn(new Turn(getDayName(i), 1, 3));
				for (int i = 0; i < 10; i++)
					e.removeTurn(getDayName(i));
				for (int i = 0; i < 100; i++) {
					e.addTurn(new Turn(getDayName(i), 1, 3));
					e.removeTurn(getDayName(i));
				}
				printTurns(e);
			}
			if (index == 22) 
			{
				Employee e = new Employee();

				for (int j = 0; j < 100; j++) {
					for (int i = 0; i < 10; i++)
						e.addTurn(new Turn(getDayName(i), 1, 3));
					for (int i = 0; i < 10; i++)
						e.removeTurn(getDayName(i));
				}
				printTurns(e);
			}
			if (index == 23) 
			{
				Employee e = new Employee();
				e.setName("Juan");
				e.setSurname("Antonio");
				System.out.print(e.getFullName(true, true) + "<BR/>");
				System.out.print(e.getFullName(false, true) + "<BR/>");
				System.out.print(e.getFullName(true, false) + "<BR/>");
				System.out.print(e.getFullName(false, false) + "<BR/>");
			}
			if (index == 24) 
			{
				Employee e = new Employee();
				e.setName(null);
				e.setSurname("Antonio");
				System.out.print(e.getFullName(true, true) + "<BR/>");
				System.out.print(e.getFullName(false, true) + "<BR/>");
				System.out.print(e.getFullName(true, false) + "<BR/>");
				System.out.print(e.getFullName(false, false) + "<BR/>");
			}
			if (index == 25) 
			{
				Employee e = new Employee();
				e.setName(null);
				e.setSurname(null);
				System.out.print(e.getFullName(true, true) + "<BR/>");
				System.out.print(e.getFullName(false, true) + "<BR/>");
				System.out.print(e.getFullName(true, false) + "<BR/>");
				System.out.print(e.getFullName(false, false) + "<BR/>");
			}
			if (index == 26) 
			{
				Employee e = new Employee();
				e.setName("Juan");
				e.setSurname(null);
				System.out.print(e.getFullName(true, true) + "<BR/>");
				System.out.print(e.getFullName(false, true) + "<BR/>");
				System.out.print(e.getFullName(true, false) + "<BR/>");
				System.out.print(e.getFullName(false, false) + "<BR/>");
			}
		} catch (Exception e) {
			throw e;
		}
	}
}
