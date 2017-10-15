/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my3countersservice;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.stage.Stage;

/**
 *
 * @author Ignacio
 */
public class FXMLDocumentController implements Initializable {
    
    @FXML
    private Button b110;
    @FXML
    private Label l110;
    @FXML
    private Button b15;
    @FXML
    private Label l15;
    @FXML
    private Button b101;
    @FXML
    private Label l101;
    
    MyService service;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
        b110.setOnAction(e ->{
           service = new MyService(1, 10, b110);
           l110.textProperty().bind(service.messageProperty());
           b110.setDisable(true);
           service.start();
        });
        b15.setOnAction(e ->{
           service = new MyService(1, 5, b15);
           l15.textProperty().bind(service.messageProperty());
           b15.setDisable(true);
           service.start();
        });
        b101.setOnAction(e ->{
           service = new MyService(10, 1, b101);
           l101.textProperty().bind(service.messageProperty());
           b101.setDisable(true);
           service.start();
        });
    }    
    
    public void setOnCloseListener(Stage stage) {
        stage.setOnCloseRequest(e -> {
            System.out.println("The application is being closed");
            //e.consume(); //Evita que el programa se apague
            //Sistem.exit(0) // Finaliza el programa y todos los hilos
        });
    }
}
