/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package productmanagerignacio;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TextField;

/**
 *
 * @author Ignacio
 */
public class FXMLDocumentController implements Initializable {

    @FXML
    private Button buttonNew;
    @FXML
    private Button buttonSave;
    @FXML
    private Button buttonDelete;
    @FXML
    private TextField textPlus;
    @FXML
    private Button buttonPlus;
    @FXML
    private Label labelBottom;
    @FXML
    private TableColumn<?, ?> columnReference;
    @FXML
    private TableColumn<?, ?> columnName;
    @FXML
    private TableColumn<?, ?> columnPrice;
    @FXML
    private Label labelCategory;
    @FXML
    private ChoiceBox<?> choiceCategory;
    @FXML
    private Label labelReference;
    @FXML
    private TextField textReference;
    @FXML
    private Label labelName;
    @FXML
    private TextField textName;
    @FXML
    private Label labelPrice;
    @FXML
    private TextField textPrice;
    
    
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    
    
}
