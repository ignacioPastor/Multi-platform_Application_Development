/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package client_finalex4_ignaciopastor;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import libraryex4.Login;
import libraryex4.MessageUtils;
import libraryex4.ServiceUtils;
import libraryex4.WSLoginResponse;

/**
 * FXML Controller class for Login Window
 * @author Ignacio Pastor Padilla
 */
public class FXMLLoginWindowController implements Initializable {

    @FXML
    private TextField tfUser;
    @FXML
    private TextField tfPass;
    @FXML
    private Button bLogin;
    public static  String token;
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        bLogin.setOnAction(e ->{
            if(checkLogin()){
                throwMainWindow(e);
            }else{
                MessageUtils.showAlert("User or password not valid!");
            }
        });
    }
    /**
     * Trhows main window
     * @param e ActionEvent of Login button
     */
    private void throwMainWindow(ActionEvent e){
        try{
            FXMLLoader loader = new FXMLLoader(getClass().getResource("FXMLMainWindow.fxml"));
            Parent root = (Parent)loader.load();
            FXMLMainWindowController controller = (FXMLMainWindowController)loader.getController();
            
            Stage stage = (Stage) ((Node) e.getSource()).getScene().getWindow();
            Scene scene = new Scene(root);
            stage.setScene(scene);
            stage.setTitle("Main Window");
            stage.show();
        }catch(IOException io){
            MessageUtils.showError("Error: " + io.getMessage());
        }
    }

    private boolean checkLogin(){
        Login myLogin = new Login(tfUser.getText(), tfPass.getText());
        Gson gsonLogin = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
        String dataLogin = gsonLogin.toJson(myLogin);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/login", dataLogin, "POST");
        if(jsonResponse != null){
            Gson gson = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSLoginResponse loginResponse = gson.fromJson(jsonResponse, WSLoginResponse.class);
            if(loginResponse == null){
                return false;
            }
            if(loginResponse.getError() == null || loginResponse.getError().equals("")){
                token = loginResponse.getToken();
                return true;
            }
            return false;
        }else{
            return false;
        }
    }
    
}
