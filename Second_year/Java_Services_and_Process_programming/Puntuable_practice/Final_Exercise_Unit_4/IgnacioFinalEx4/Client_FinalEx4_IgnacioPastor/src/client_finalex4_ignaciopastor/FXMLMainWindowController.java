/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package client_finalex4_ignaciopastor;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import java.io.IOException;
import java.lang.reflect.Type;
import java.net.URL;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.Set;
import javafx.beans.InvalidationListener;
import javafx.collections.FXCollections;
import javafx.collections.ListChangeListener;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.stage.Modality;
import javafx.stage.Stage;
import libraryex4.Actor;
import libraryex4.MessageUtils;
import libraryex4.ServiceUtils;
import libraryex4.WSOkResponse;

/**
 * FXML Controller class for Main window
 * @author Ignacio Pastor Padilla
 */
public class FXMLMainWindowController implements Initializable {

    @FXML
    private TextField tfLookfor;
    @FXML
    private Button bLookfor;
    @FXML
    private Button bFavourite;
    @FXML
    private ListView<String> lvActors;
    @FXML
    private Button bAdd;
    @FXML
    private Label lName;
    @FXML
    private Label lBirthDate;
    @FXML
    private Label lDescription;
    @FXML
    private Button bFavRigth;
    @FXML
    private Button bDelete;
    private String token;
    private HashMap<String, Actor> currentActors;
    private Actor actorShown;
    @FXML
    private Label lInfo;
    private boolean showingFavourites;
    @FXML
    private ImageView imgActor;
    @FXML
    private Button bModify;
    public static Actor actorModify;
    
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        currentActors = new HashMap<>();
        setIconButtons();
        token = FXMLLoginWindowController.token;
        showingFavourites = false;
        bDelete.setDisable(true);
        bFavRigth.setDisable(true);
        
        bModify.setOnAction(e -> {
            if(actorShown != null){
                actorModify = actorShown;
                throwAddActorWindow(e);
            }
        });
        bFavRigth.setOnAction(e -> {
            if(actorShown != null)
                if(showingFavourites == true) deleteFromFavourites();
                else addToFavourites();
            else lInfo.setText("Select an Actor!");
        });
        bFavourite.setOnAction(e ->{
            listFavourites();
        });
        bDelete.setOnAction(e -> {
            if(actorShown != null)
                deleteActor();
        });
        lvActors.setOnMouseClicked(e -> {
            String selectedName = lvActors.getSelectionModel().getSelectedItem();
            cleanDataActor();
            actorShown = currentActors.get(selectedName);
            showDataActor();
        });
        bAdd.setOnAction(e -> {
            throwAddActorWindow(e);
        });
        bLookfor.setOnAction(e -> {
            cleanDataActor();
            if(tfLookfor.getText().equals("")) getActors();
            else getMatchActors();
        });
    }
    
    /**
     * Delete selected actor from the favourite list of loged user
     */
    private void deleteFromFavourites(){
        ServiceUtils.setToken(token);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/favourite/" + actorShown.getId(), null, "DELETE");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                lInfo.setText("Actor deleted correctly from favourite");
                currentActors.remove(actorShown.getName(), actorShown);
                lvActors.getItems().clear();
                lvActors.getItems().setAll(currentActors.keySet());
                cleanDataActor();
            }else{
                lInfo.setText("Error: " + wsResponse.getError());
            }
        }else{
            lInfo.setText("Error deleting actor from favourite.");
        }
    }
    
    /**
     * Add selected actor to favourite list of this user
     */
    private void addToFavourites(){
        ServiceUtils.setToken(token);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/favourite/"+actorShown.getId(), null, "POST");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                lInfo.setText("Actor added as favourite!");
            }else{
                lInfo.setText("Error: " + wsResponse.getError());
            }
        }else{
            lInfo.setText("Error inserting actor in favourites.");
        }
    }
    
    /**
     * Show the list of Favourite actors for this user
     */
    private void listFavourites(){
        lInfo.setText("Searching...");
        ServiceUtils.setToken(token);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/favourite", null, "GET");
        if(jsonResponse != null){
            Gson gsonGetFavourites = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            Type type = new TypeToken<List<Actor>>(){}.getType();
            List<Actor> actors = gsonGetFavourites.fromJson(jsonResponse, type);
            showingFavourites = true;
            fillListView(actors);
            lInfo.setText("");
        }else{
            lInfo.setText("Error getting the favourite actors.");
        }
    }
    
    /**
     * Delete an actor from BD
     */
    private void deleteActor(){
        ServiceUtils.setToken(token);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/actor/" + actorShown.getId(), null, "DELETE");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                lInfo.setText("Actor deleted correctly");
                currentActors.remove(actorShown.getName(), actorShown);
                lvActors.getItems().clear();
                lvActors.getItems().setAll(currentActors.keySet());
                cleanDataActor();
            }else{
                lInfo.setText("Error: " + wsResponse.getError());
            }
        }else{
            lInfo.setText("Error deleting actor.");
        }
    }
    
    /**
     * Show in the main window the data of shown actor
     */
    private void showDataActor(){
        if(actorShown != null){
            lName.setText(actorShown.getName());
            lBirthDate.setText(actorShown.getBirthDate());
            lDescription.setText(actorShown.getDescription());
            bDelete.setDisable(false);
            bFavRigth.setDisable(false);
        }
    }
    
    /**
     * Clean the actor data of main window
     */
    private void cleanDataActor(){
        actorShown = null;
        lName.setText("");
        lBirthDate.setText("");
        lDescription.setText("");
        bDelete.setDisable(true);
        bFavRigth.setDisable(true);
    }
    
    /**
     * Get all the actors of our BD
     */
    private void getActors(){
        lInfo.setText("Searching...");
        ServiceUtils.setToken(token);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/actor", null, "GET");
        if(jsonResponse != null){
            Gson gsonGetActors = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            Type type = new TypeToken<List<Actor>>(){}.getType();
            List<Actor> actors = gsonGetActors.fromJson(jsonResponse, type);
            showingFavourites = false;
            fillListView(actors);
            lInfo.setText("");
        }else{
            lInfo.setText("Error getting the actors.");
        }
    }
    
    /**
     * Get actors which contains text indicated by user
     */
    private void getMatchActors(){
        lInfo.setText("Searching...");
        ServiceUtils.setToken(token);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/actor/" + tfLookfor.getText(), null, "GET");
        if(jsonResponse != null){
            Gson gsonGetMatchActors = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            Type type = new TypeToken<List<Actor>>(){}.getType();
            List<Actor> actors = gsonGetMatchActors.fromJson(jsonResponse, type);
            showingFavourites = false;
            fillListView(actors);
            lInfo.setText("");
        }else{
            lInfo.setText("Error getting match actor.");
        }
    }
    
    /**
     * Fill the listView of the windows with the names of listActos received
     * @param listActors to show in listView
     */
    private void fillListView(List<Actor> listActors){
        currentActors.clear();
        listActors.stream().forEach((a) -> {
            currentActors.put(a.getName(), a);
        });
        lvActors.getItems().clear();
        lvActors.getItems().setAll(currentActors.keySet());
    }
    
    /**
     * Set the icon for each button in main Window
     */
    private void setIconButtons(){
        Image imgDelete = new Image("file:img/delete.png");
        bDelete.setGraphic(new ImageView(imgDelete));
        Image imgSearch = new Image("file:img/search.png");
        bLookfor.setGraphic(new ImageView(imgSearch));
        Image imgFav = new Image("file:img/favourite_on.png");
        bFavourite.setGraphic(new ImageView(imgFav));
        Image imgAdd = new Image("file:img/add.png");
        bAdd.setGraphic(new ImageView(imgAdd));
        Image imgNoFav = new Image("file:img/favourite_off.png");
        bFavRigth.setGraphic(new ImageView(imgNoFav));
        Image imgSilueta = new Image("file:img/silueta.jpg");
        imgActor.setImage(imgSilueta);
        Image imgModify = new Image("file:img/modify.png", 24, 24, false, true);
        bModify.setGraphic( new ImageView(imgModify));
    }
    
    /**
     * Throws the AddActor window
     * @param e click event
     */
    private void throwAddActorWindow(ActionEvent e){
        try{
            FXMLLoader loader = new FXMLLoader(getClass().getResource("FXMLAddActor.fxml"));
            Parent root = (Parent)loader.load();
            FXMLAddActorController controller = (FXMLAddActorController)loader.getController();
            Stage newStage = new Stage();
            Stage stage = (Stage) ((Node) e.getSource()).getScene().getWindow();
            Scene scene = new Scene(root);
            newStage.setScene(scene);
            newStage.setTitle("Add Actor Window");
            newStage.initModality(Modality.WINDOW_MODAL);
            newStage.initOwner(stage);
            newStage.show();
        }catch(IOException io){
            MessageUtils.showError("Error: " + io.getMessage());
        }
    }
    
}
