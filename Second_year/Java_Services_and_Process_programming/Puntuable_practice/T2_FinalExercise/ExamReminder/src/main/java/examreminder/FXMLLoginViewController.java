package examreminder;

/**
 * Final Exercise - Unit 2 - Service and Process Programming
 * Ignacio Pastor Padilla - 2º DAM Semi-presincial
 */


import examreminder.model.Exam;
import examreminder.utils.FileUtils;
import examreminder.utils.MessageUtils;
import examreminder.utils.ScreenLoader;
import java.net.URL;
import java.util.List;
import java.util.ResourceBundle;
import javafx.application.Platform;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

/**
 * FXML Controller class
 * This class manage the login window
 * @author Ignacio Pastor Padilla
 */
public class FXMLLoginViewController implements Initializable {

    @FXML
    private TextField textLogin;
    @FXML
    private PasswordField textPassword;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
    }    
    /**
     * Manage de event of login button
     * @param event login button action
     */
    @FXML
    private void actionButtonLogin(ActionEvent event) {
        ScreenLoader s = new ScreenLoader();
        // Boolean static function for validate data
        if(FileUtils.checkLogin(textLogin.getText(), textPassword.getText())){
            //Throwing main windows
            MessageUtils.showMessage("Validation correct.");
            try{
            s.loadScreen("/fxml/FXMLMainView.fxml",
                (Stage) ((Node) event.getSource()).getScene().getWindow());
            }catch(Exception e){
                MessageUtils.showError("Fatal Error has ocurred trying to run the main window.");
                Platform.exit();
            }
        }else{  //User o Password incorrect
            MessageUtils.showAlert("User or Password incorrect.");
            textLogin.setText("");
            textPassword.setText("");
        }
    }
}
