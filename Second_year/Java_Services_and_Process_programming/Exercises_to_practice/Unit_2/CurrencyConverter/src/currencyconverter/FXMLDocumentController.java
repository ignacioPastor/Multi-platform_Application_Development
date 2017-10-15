/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package currencyconverter;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.RadioButton;
import javafx.scene.control.TextField;
import javafx.scene.control.ToggleGroup;

/**
 *
 * @author Ignacio
 */
public class FXMLDocumentController implements Initializable {
    
    
    
    private ToggleGroup modoConvertir;
    @FXML
    private RadioButton ed;
    @FXML
    private RadioButton el;
    @FXML
    private RadioButton de;
    @FXML
    private RadioButton dl;
    @FXML
    private RadioButton le;
    @FXML
    private RadioButton ld;
    @FXML
    private Label labelCurrency;
    @FXML
    private TextField textoDatos;
    @FXML
    private Label labelResultado;
    
   
   
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        ed.setToggleGroup(modoConvertir);
        el.setToggleGroup(modoConvertir);
        de.setToggleGroup(modoConvertir);
        dl.setToggleGroup(modoConvertir);
        le.setToggleGroup(modoConvertir);
        ld.setToggleGroup(modoConvertir);
    }    
    
}
