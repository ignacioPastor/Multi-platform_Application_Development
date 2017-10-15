package e2e1;

import java.util.Scanner;

public class E2e1 {
	
	static void printMatrix(Matrix matrix) {
		for (int r = -1; r <= matrix.getRowCount(); r++) {
			for (int c = -1; c <= matrix.getColumnCount(); c++) {
				System.out.print("" + matrix.getValue(c, r) + ", ");
			}
			System.out.println();
		}
	}
	
	static void fillMatrix(Matrix matrix, int value) {
		for (int r = 0; r < matrix.getRowCount(); r++)
			for (int c = 0; c < matrix.getColumnCount(); c++)
				matrix.setValue(c, r, value);		
	}

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int index = sc.nextInt();
		
		if (index == 0) {
			Matrix matrix = new MatrixImplementation(3, 2);
			System.out.print("Matrix<" + matrix.getColumnCount() + ", " + matrix.getRowCount() + ">");
		}
		if (index == 1) {
			Matrix matrix = new MatrixImplementation(0, 2);
			System.out.print("Matrix<" + matrix.getColumnCount() + ", " + matrix.getRowCount() + ">");
		}
		if (index == 2) {
			Matrix matrix = new MatrixImplementation(2, -1);
			System.out.print("Matrix<" + matrix.getColumnCount() + ", " + matrix.getRowCount() + ">");
		}
		if (index == 3) {
			Matrix matrix = new MatrixImplementation(3, 2);
			fillMatrix(matrix, 3);
			printMatrix(matrix);
		}
		if (index == 4) {
			Matrix matrix = new MatrixImplementation(3, 2);
			matrix.setValue(0, 0, 0);
			matrix.setValue(0, 1, 1);
			matrix.setValue(1, 0, -2);
			matrix.setValue(1, 1, 3);
			matrix.setValue(2, 0, -4);
			matrix.setValue(2, 1, 5);
			printMatrix(matrix);
		}
		if (index == 5) {
			Matrix matrix = new MatrixImplementation(3, 2);
			fillMatrix(matrix, 10);
			matrix.setValue(-1, 0, 0);
			matrix.setValue(100, 0, 0);
			matrix.setValue(0, -1, 0);
			matrix.setValue(0, 100, 0);
			printMatrix(matrix);
		}
	}
	
}
