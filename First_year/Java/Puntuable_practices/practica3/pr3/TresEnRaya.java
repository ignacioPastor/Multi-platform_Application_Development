package tresenraya;

import java.util.Scanner;
import tresenraya.NoughtsAndCrossesBoard.Color;

/**
 * Esta es una version del tres en raya. La diferencia con el juego original es 
 * que el tablero empieza ya con todas las fichas en el tablero y mueven las rojas.
 * Las fichas se representan con una R las rojas, con una B las blancas, y con 
 * una V la casilla vacía
 * El tablero empieza así:
 * R  V  B
 * B  R  V
 * R  V  B
 */

public class TresEnRaya {
	
	final static int FORCE_EXIT_CODE = 1000;
	final static boolean USE_WEB_OUTPUT = true;
	
	final static String SPACE = USE_WEB_OUTPUT ? "" : " ";
	final static String CORNER_SPACE = USE_WEB_OUTPUT ? "-" : " ";
	final static String NEW_LINE = USE_WEB_OUTPUT ? "<BR/>" : "";

	static NoughtsAndCrossesBoard	createBoard() {
		return new NoughtsAndCrossesBoardImplementation();
	}
	
	static void printBoard(NoughtsAndCrossesBoard aBoard) {
		
		System.out.print(SPACE + CORNER_SPACE + SPACE);
		for (int x = 0; x < 3; x++)
			System.out.print(SPACE + (x + 1) + SPACE);
		System.out.println(NEW_LINE);

		for (int y = 2; y >= 0; y--) {

			System.out.print(SPACE + (y + 1) + SPACE);
	
			for (int x = 0; x < 3; x++) {
				Color color = aBoard.getPieceAt(x, y);
				if (color == null)
					System.out.print(SPACE + CORNER_SPACE + SPACE);
				else
					switch(color) {
						case RED: System.out.print(SPACE + "R" + SPACE); break;
						case WHITE: System.out.print(SPACE + "B" + SPACE); break;
						case VOID: System.out.print(SPACE + CORNER_SPACE + SPACE); break;
					}
			}
			System.out.println(NEW_LINE);
		}
		System.out.println("-------------------" + NEW_LINE);
	}

	public static void main(String[] args) {
		NoughtsAndCrossesBoard board = createBoard();
		NoughtsAndCrossesBoard.Color currentColor = NoughtsAndCrossesBoard.Color.RED;
		Scanner keyboard = new Scanner(System.in);
		boolean forceExit = false;
		
		System.out.println("Bienvenido al juego de las res en raya, mueven las rojas" + NEW_LINE);
		while (!board.isGameOver() && !forceExit) {
			printBoard(board);
			
			while (true) {
				if (currentColor == NoughtsAndCrossesBoard.Color.RED)
					System.out.println("Mueven las rojas" + NEW_LINE);
				else
					System.out.println("Mueven las blancas" + NEW_LINE);
				System.out.print("Diga la X de la ficha que quiera mover: ");
				int x = keyboard.nextInt() - 1;
				System.out.println("Has introducido " + (x + 1) + NEW_LINE);
				if (x == FORCE_EXIT_CODE - 1) {
					forceExit = true;
					break;
				}
				System.out.print("Diga la Y de la ficha que quiera mover: ");
				int y = keyboard.nextInt() - 1;
				System.out.println("Has introducido " + (y + 1) + NEW_LINE);
				if (y == FORCE_EXIT_CODE - 1) {
					forceExit = true;
					break;
				}
				
				if (board.getPieceAt(x, y) == currentColor && board.canMovePieceAt(x, y)) {
					while (true) {
						System.out.print("Diga la X de la casilla a la que quiera mover: ");
						int dx = keyboard.nextInt() - 1;
						System.out.println("Has introducido " + (dx + 1) + NEW_LINE);
						if (dx == FORCE_EXIT_CODE - 1) {
							forceExit = true;
							break;
						}
						System.out.print("Diga la Y de la casilla a la que quiera mover: ");
						int dy = keyboard.nextInt() - 1;
						System.out.println("Has introducido " + (dy + 1) + NEW_LINE);
						if (dy == FORCE_EXIT_CODE - 1) {
							forceExit = true;
							break;
						}

						if (board.movePiece(x, y, dx, dy))
							break;
						else 
							System.out.println("No has elegido una calda correcta" + NEW_LINE);
					}
					break;
				}
				else
					System.out.println("No has elegido una calda correcta" + NEW_LINE);
			}
			if (currentColor == NoughtsAndCrossesBoard.Color.RED)
				currentColor = NoughtsAndCrossesBoard.Color.WHITE;
			else
				currentColor = NoughtsAndCrossesBoard.Color.RED;			
		}
		if (forceExit)
			System.out.println("Salida forzada");
		else {
			printBoard(board);
			if (currentColor == NoughtsAndCrossesBoard.Color.RED)
				System.out.println("Ganan las blancas!!");
			else
				System.out.println("Ganan las rojas!!");
		}
	}
	
}
