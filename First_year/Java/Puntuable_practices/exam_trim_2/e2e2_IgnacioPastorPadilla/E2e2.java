package e2e2;

import java.util.Scanner;

public class E2e2 {
	
	static void testPointInShape(Shape aShape, float x, float y) {
		System.out.print("Testeando el punto (" + x + ", " + y + "): ");
		System.out.println(aShape.containsPoint(x, y));		
	}
	
	static void testRecangle(Shape aShape) {
		testPointInShape(aShape, 0, 2);
		testPointInShape(aShape, 4, 2);
		testPointInShape(aShape, 2, 0);
		testPointInShape(aShape, 2, 4);
		testPointInShape(aShape, 0, 4);
		testPointInShape(aShape, 4, 4);
		testPointInShape(aShape, 4, 0);
		testPointInShape(aShape, 0, 0);
		testPointInShape(aShape, 1, 1);
		testPointInShape(aShape, 3, 3);
		testPointInShape(aShape, 1, 3);
		testPointInShape(aShape, 3, 1);
		testPointInShape(aShape, 2, 2);		
	}

	static void testCircle(Shape aShape) {
		testPointInShape(aShape, 0, 0);
		testPointInShape(aShape, -1, -1);
		testPointInShape(aShape, 3, 2);
		testPointInShape(aShape, 4, 3);
		testPointInShape(aShape, 2, 2);
		testPointInShape(aShape, 3, 0);
		testPointInShape(aShape, 2, 1);
	}
	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int index = sc.nextInt();

		if (index == 0) {
			Shape shape = new Rectangle(1, 1, 3, 3);
			System.out.println("Testeando el rect 1, 1, 3, 3");
			testRecangle(shape);
		}
		if (index == 1) {
			Shape shape = new Rectangle(1, 1, 1, 3);
			System.out.println("Testeando el rect 1, 1, 1, 3");
			testRecangle(shape);
		}
		if (index == 2) {
			Shape shape = new Rectangle(1, 1, -3, -3);
			System.out.println("Testeando el rect 1, 1, -3, -3");
			testRecangle(shape);
		}
		if (index == 3) {
			Shape shape = new Circle(2, 1, 2);
			System.out.println("Testeando el circ 2, 1, 2");
			testCircle(shape);
		}
		if (index == 4) {
			Shape shape = new Circle(2, 1, -2);
			System.out.println("Testeando el circ 2, 1, -2");
			testCircle(shape);
		}
		if (index == 5) {
			Shape shape = new Circle(2, 0, 2);
			shape.setColor(10);
			System.out.print(shape.getColor());
		}
	}
	
}
