/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package currencyconverter2;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.MenuBar;
import javafx.scene.control.RadioMenuItem;
import javafx.scene.control.TextField;
import javafx.scene.control.Toggle;
import javafx.scene.control.ToggleGroup;
import javafx.scene.input.KeyEvent;

/**
 *
 * @author Ignacio
 */
public class FXMLDocumentController implements Initializable {

    @FXML
    private MenuBar mCurrency;
    @FXML
    private RadioMenuItem eu;
    @FXML
    private RadioMenuItem eg;
    @FXML
    private RadioMenuItem ue;
    @FXML
    private RadioMenuItem ug;
    @FXML
    private RadioMenuItem ge;
    @FXML
    private RadioMenuItem gu;
    @FXML
    private Label labelResultado;
    @FXML
    private ToggleGroup tg;
    @FXML
    private TextField textUsuario;
    
   
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
    }    

    @FXML
    private void onKeyReleased_User(KeyEvent event) {
        if(eu.isSelected()){
            try{
            Float n = Float.parseFloat(textUsuario.getText());
            Float r = n * 1.1f;
            labelResultado.setText(textUsuario.getText() + " € = " + r.toString() + " $");
            }catch(Exception e){}
        }else if(eg.isSelected()){
            try{
            Float n = Float.parseFloat(textUsuario.getText());
            Float r = n * 0.8f;
            labelResultado.setText(textUsuario.getText() + " € = " + r.toString() + " P");
            }catch(Exception e){}
        }else if(ue.isSelected()){
            try{
            Float n = Float.parseFloat(textUsuario.getText());
            Float r = n * 0.9f;
            labelResultado.setText(textUsuario.getText() + " $ = " + r.toString() + " €");
            }catch(Exception e){}
        }else if(ug.isSelected()){
            try{
            Float n = Float.parseFloat(textUsuario.getText());
            Float r = n * 0.7f;
            labelResultado.setText(textUsuario.getText() + " $ = " + r.toString() + " P");
            }catch(Exception e){}
        }else if(ge.isSelected()){
            try{
            Float n = Float.parseFloat(textUsuario.getText());
            Float r = n * 1.2f;
            labelResultado.setText(textUsuario.getText() + " P = " + r.toString() + " €");
            }catch(Exception e){}
        }else if(gu.isSelected()){
            try{
            Float n = Float.parseFloat(textUsuario.getText());
            Float r = n * 1.3f;
            labelResultado.setText(textUsuario.getText() + " P = " + r.toString() + " $");
            }catch(Exception e){}
        }
    }
    
}
