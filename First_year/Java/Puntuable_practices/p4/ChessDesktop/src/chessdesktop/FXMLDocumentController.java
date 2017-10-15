//Ignacio Pastor Padilla - Entornos de Desarrollo Práctica 4 - DAM Semi A

package chessdesktop;

import Chess.ChessPiece;
import Chess.ChessRandomAI;
import Chess.ChessUtils;
import java.io.BufferedWriter;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.util.ResourceBundle;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.canvas.Canvas;
import javafx.scene.control.Label;
import javafx.scene.input.MouseEvent;
import javafx.scene.paint.Color;
import javafx.stage.FileChooser;
import javafx.stage.FileChooser.ExtensionFilter;

public class FXMLDocumentController implements Initializable {
	
	ChessBoardRenderer board = new ChessBoardRenderer();
        Chess.ChessPiece.Color currentColor = Chess.ChessPiece.Color.WHITE;
        ChessRandomAI ai = new ChessRandomAI();

	@FXML
	private Label label;
	@FXML
	private Canvas canvas;
	
	@FXML
	private void handleButtonAction(ActionEvent event) {
		board = new ChessBoardRenderer();
		board.draw(canvas);
	}
	
	@FXML
	private void handleSaveButtonAction(ActionEvent event) {
		FileChooser fileChooser = new FileChooser();
		fileChooser.setTitle("Save Game");
		File file = fileChooser.showSaveDialog(null);
		if (file != null) {
                    board.getBoard().saveToFile(file);
		}
	}

	@FXML
	private void handleLoadButtonAction(ActionEvent event) {
		FileChooser fileChooser = new FileChooser();
		fileChooser.setTitle("Open Resource File");
		fileChooser.getExtensionFilters().addAll(new ExtensionFilter("Chess Files", "*.chess.xml"), 
                        new ExtensionFilter("Txt Files", "*.txt"));
		File selectedFile = fileChooser.showOpenDialog(null);
		if (selectedFile != null) {
                    board.getBoard().loadFromFile(selectedFile);
                    board.draw(canvas);
		}
	}

	@Override
	public void initialize(URL url, ResourceBundle rb) {
		
		board.draw(canvas);
		
		canvas.addEventHandler(MouseEvent.MOUSE_CLICKED, (MouseEvent e)->{
			Chess.ChessPiece piece = board.getPieceAt(canvas, e.getX(), e.getY());
			if (board.getMovingPiece() == piece) {
                            board.setMovingPiece(null);
                            board.draw(canvas);
                            return;
			}
			if (board.getMovingPiece() == null) {
                                if (piece != null && piece.getColor() == currentColor) {
                                    board.setMovingPiece(piece);
                                    board.draw(canvas);
                                    board.drawAvailablePositions(canvas, piece);
                                }
				return;
			}
			if (board.movePieceTo(canvas, e.getX(), e.getY())) {
				board.setMovingPiece(null);
				board.draw(canvas);
				if (!board.containsKing(ChessPiece.Color.BLACK) || !board.containsKing(ChessPiece.Color.WHITE)) {
					if (!board.containsKing(ChessPiece.Color.BLACK))
						label.setText("Ganan las blancas");
					else
						label.setText("Ganan las negras");
				}
                                
                                currentColor = ChessPiece.Color.BLACK;     
                                ai.performNextMovement(board.getBoard(), ChessPiece.Color.BLACK);
                                board.draw(canvas);
                                
                                currentColor = ChessPiece.Color.WHITE;

                                
                                
                                
			}
		});
	}	
	
}
