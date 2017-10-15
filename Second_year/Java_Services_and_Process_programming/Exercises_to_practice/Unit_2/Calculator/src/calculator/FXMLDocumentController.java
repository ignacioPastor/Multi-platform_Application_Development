/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculator;


import javafx.scene.layout.AnchorPane;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.collections.FXCollections;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;

/**
 *
 * @author Ignacio
 */
public class FXMLDocumentController implements Initializable {

    @FXML
    private Label labelN1;
    @FXML
    private TextField textN1;
    @FXML
    private Label labelChoose;
   
    @FXML
    private Label labelN2;
    @FXML
    private TextField textN2;
    @FXML
    private Button botonCalcular;
    @FXML
    private Label labelResultado;
    @FXML
    private Label labelMostrarResultado;
    @FXML
    private AnchorPane elegirOperacion;
    @FXML
    private ChoiceBox<String> elegirOpcion;
    
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        elegirOpcion.setItems(FXCollections.observableArrayList("+", "-", "*", "/"));
        elegirOpcion.getSelectionModel().selectFirst();
    }    

    @FXML
    private void onActionBoton_Calcular(ActionEvent event) {
        System.out.println("Entra en el action buton");
        float n1, n2;
        try{n1 = Float.parseFloat(textN1.getText());}catch(Exception e){n1 = 0;}
        try{n2 = Float.parseFloat(textN2.getText());}catch(Exception e){n2 = 0;}
        System.out.println("Antes del switch");
        String r = elegirOpcion.getValue();
        switch(r){
            case "+":
                System.out.println("Entra en el +");
                labelMostrarResultado.setText(Float.toString(n1 + n2));
                break;
            case "-":
                labelMostrarResultado.setText(Float.toString(n1 - n2));
                break;
            case "*":
                labelMostrarResultado.setText(Float.toString(n1 * n2));
                break;
            case "/":
                labelMostrarResultado.setText(Float.toString(n1 / n2));
                break;
            default:
                System.err.println("Operación no reconocida: " + r);
                break;
                
        }
    }
    
}
