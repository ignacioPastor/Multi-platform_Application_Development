/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package client_finalex4_ignaciopastor;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.Socket;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.stage.Stage;
import libraryex4.Actor;
import libraryex4.ServiceUtils;
import libraryex4.WSOkResponse;

/**
 * FXML Controller class of AddActor window
 * @author Ignacio Pastor Padilla
 */
public class FXMLAddActorController implements Initializable {

    @FXML
    private TextField tfSearch;
    @FXML
    private Button bSearch;
    @FXML
    private Button bChooseImage;
    @FXML
    private TextField tfName;
    @FXML
    private TextField tfBirthDate;
    @FXML
    private TextArea taDescription;
    @FXML
    private Button bAccept;
    @FXML
    private Button bCancel;
    @FXML
    private Label lAlertInfo;
    private Actor actor;
    private String token;
    @FXML
    private ImageView imgActor;

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        token = FXMLLoginWindowController.token;
        Image imgSilueta = new Image("file:img/silueta.jpg");
        imgActor.setImage(imgSilueta);
        if(FXMLMainWindowController.actorModify != null)
            fillDataActor(FXMLMainWindowController.actorModify);
        
        bCancel.setOnAction(e -> {
           ((Stage)((Node)e.getSource()).getScene().getWindow()).close();
        });
        bAccept.setOnAction(e -> {
            if(checkFields()){
                if(FXMLMainWindowController.actorModify == null)
                    saveActor();
                else
                    updateActor();
            }
        });
        bSearch.setOnAction(e ->{
            getActorFromIMDB();
        });
    }

    /**
     * Check that all values for actor are filled
     * @return true if values are filled
     */
    private boolean checkFields(){
        if(tfName.getText().equals("")){
            lAlertInfo.setText("Name can't be empty.");
            return false;
        }
        if(tfBirthDate.getText().equals("")){
            lAlertInfo.setText("BirthDate can't be empty.");
            return false;
        }
        if(taDescription.getText().equals("")){
            lAlertInfo.setText("Description can't be empty.");
            return false;
        }
        return true;
    }
    /**
     * Manage the updating actor.
     */
    private void updateActor(){
        Actor actorTmp = new Actor();
        copyActor(FXMLMainWindowController.actorModify, actorTmp); //Copy, in case updates fails return to original values
        asignateDataActor(FXMLMainWindowController.actorModify);
        ServiceUtils.setToken(token);
        Gson gsonInsertActor = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
        String dataActor = gsonInsertActor.toJson(FXMLMainWindowController.actorModify);
        String jsonResponse = ServiceUtils.getResponse("http://finalex4.iessanvi.es/finalex4/actor/"
                + FXMLMainWindowController.actorModify.getId(), dataActor, "PUT");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                lAlertInfo.setText("Actor updated correctly");
            }else{
                lAlertInfo.setText("Error: " + wsResponse.getError());
                copyActor(actorTmp, FXMLMainWindowController.actorModify);
            }
        }else{
            lAlertInfo.setText("Error updating actor.");
            copyActor(actorTmp, FXMLMainWindowController.actorModify);
        }
        FXMLMainWindowController.actorModify = null;
    }
    /**
     * Make a copy of Actor
     * @param original
     * @param copy 
     */
    private void copyActor(Actor original, Actor copy){
        copy.setId(original.getId());
        copy.setName(original.getName());
        copy.setBirthDate(original.getBirthDate());
        copy.setDescription(original.getDescription());
        copy.setImgFile(original.getImgFile());
    }
    /**
     * Save actor in server
     */
    private void saveActor(){
        Actor myActor = new Actor(0, tfName.getText(),
                tfBirthDate.getText(), "", taDescription.getText());
        ServiceUtils.setToken(token);
        Gson gsonInsertActor = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
        String dataActor = gsonInsertActor.toJson(myActor);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/actor", dataActor, "POST");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                lAlertInfo.setText("Actor inserted correctly");
            }else{
                lAlertInfo.setText("Error: " + wsResponse.getError());
            }
        }else{
            lAlertInfo.setText("Error inserting actor.");
        }
    }
    /**
     * Search in IMDB webpage for the actor indicated by User.
     * Get the result and show the data
     */
    private void getActorFromIMDB(){
        if(tfSearch.getText().equals("")){
            lAlertInfo.setText("You must indicate some data!");
            return;
        }else
            lAlertInfo.setText("Searching...");
        try(
            Socket mySocket = new Socket("localhost", 6000);
            ObjectInputStream objIn =
                new ObjectInputStream(mySocket.getInputStream());
            DataOutputStream socketOut =
                new DataOutputStream(mySocket.getOutputStream());
        )
        {
            socketOut.writeUTF(tfSearch.getText());
            
            actor = (Actor)objIn.readObject();
            if(actor.getBirthDate() == null){
                lAlertInfo.setText("No results have been found");
                cleanDataActor();
                return;
            }else{
                fillDataActor(actor);
                lAlertInfo.setText("");
            }
        }catch(IOException io){
            lAlertInfo.setText("Error: " + io.getMessage());
        }catch(ClassNotFoundException cnf){
            lAlertInfo.setText("Error: " + cnf.getMessage());
        }
    }
    private void asignateDataActor(Actor a){
        a.setName(tfName.getText());
        a.setBirthDate(tfBirthDate.getText());
        a.setDescription(taDescription.getText());
    }
    private void fillDataActor(Actor a){
        tfName.setText(a.getName());
        tfBirthDate.setText(a.getBirthDate());
        taDescription.setText(a.getDescription());
    }
    private void cleanDataActor(){
        tfName.setText("");
        tfBirthDate.setText("");
        taDescription.setText("");
    }

}
