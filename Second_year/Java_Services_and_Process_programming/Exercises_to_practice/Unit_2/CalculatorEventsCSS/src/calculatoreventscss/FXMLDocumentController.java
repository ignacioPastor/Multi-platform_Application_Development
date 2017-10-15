/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculatoreventscss;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.collections.FXCollections;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.Label;
import javafx.scene.control.MenuButton;
import javafx.scene.control.MenuItem;
import javafx.scene.control.TextField;

/**
 *
 * @author Ignacio
 */
public class FXMLDocumentController implements Initializable {
    
    private Label label;
    @FXML
    private Label labelFirstNumber;
    @FXML
    private TextField textFirstNumber;
    @FXML
    private Label labelOperation;
    @FXML
    private Label labelSecondNumber;
    @FXML
    private TextField textSecondNumber;
    @FXML
    private Button buttonCalculate;
    @FXML
    private Label labelResult;
    @FXML
    private TextField textResult;
    @FXML
    private ChoiceBox<String> chooseOperation;
    
    
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        chooseOperation.setItems(FXCollections.observableArrayList("+","-","*","/"));
        chooseOperation.getSelectionModel().selectFirst();
    }    

    @FXML
    private void onAction_Calculate(ActionEvent event) {
        float n1 = 0;
        float n2 = 0;
        float r;
        try{
        n1 = Float.parseFloat(textFirstNumber.getText());
        n2 = Float.parseFloat(textSecondNumber.getText());
        }catch(Exception e){return;}
        if(chooseOperation.getSelectionModel().getSelectedItem().charAt(0) == '+')
            textResult.setText(String.valueOf(n1 + n2));
        else if(chooseOperation.getSelectionModel().getSelectedItem().charAt(0) == '-')
            textResult.setText(String.valueOf(n1 - n2));
        else if(chooseOperation.getSelectionModel().getSelectedItem().charAt(0) == '*')
            textResult.setText(String.valueOf(n1 * n2));
        else if(chooseOperation.getSelectionModel().getSelectedItem().charAt(0) == '/')
            textResult.setText(String.valueOf(n1 / n2));
    }
    
}
