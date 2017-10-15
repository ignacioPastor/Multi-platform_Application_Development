/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my3counter;

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
    private Label l110;
    @FXML
    private Button b15;
    @FXML
    private Label l15;
    @FXML
    private Button b101;
    @FXML
    private Label l101;
    @FXML
    private Button b110;
    
    
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    

    @FXML
    private void onAction_B15(ActionEvent event) {
        MyThread t = new MyThread(1, 5, l15);
        b15.setDisable(true);
        t.start();
    }

    @FXML
    private void onAction_B101(ActionEvent event) {
        MyThread t = new MyThread(10, 1, l101);
        b101.setDisable(true);
        t.start();
    }

    @FXML
    private void onAction_B110(ActionEvent event) {
        MyThread t = new MyThread(1, 10, l110);
        b110.setDisable(true);
        t.start();
    }
    public void setOnCloseListener(Stage stage) {
        stage.setOnCloseRequest(e -> {
            System.exit(0);
        });
    }
    
}
