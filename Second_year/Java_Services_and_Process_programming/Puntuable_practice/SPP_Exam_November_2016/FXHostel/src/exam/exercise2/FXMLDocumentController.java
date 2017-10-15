/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exam.exercise2;

import exam.exercise2.model.Client;
import exam.exercise2.model.Room;
import java.net.URL;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.TreeMap;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.DatePicker;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.control.ToggleGroup;
import javafx.scene.control.cell.PropertyValueFactory;


/**
 * PSP Exam
 * @author Ignacio Pastor Padilla
 */
public class FXMLDocumentController implements Initializable {

    @FXML
    private DatePicker dpDate;
    @FXML
    private TableView<Room> tableRooms;
    @FXML
    private TableColumn<Room, Integer> columnRoom;
    @FXML
    private TableColumn<Room, Integer> columnAvailable;
    @FXML
    private TextArea taDetalle;
    @FXML
    private TextField tfName;
    @FXML
    private ToggleGroup discountTogle;
    @FXML
    private Button bAdd;
    @FXML
    private Button bRemove;
    
    private Map<LocalDate, List<Room>> mapRooms;
    private ObservableList<Room> currentRooms;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        dpDate.setValue(LocalDate.now());
        mapRooms = new TreeMap<LocalDate, List<Room>>();
        mapRooms.put(LocalDate.now(), defaultRooms());
        //currentRooms = FXCollections.observableArrayList(mapRooms.);
        currentRooms = FXCollections.observableArrayList(mapRooms.get(LocalDate.now()));
        tableRooms.setItems(currentRooms);
        initializeTable();
    }
    private void initializeTable(){
        tableRooms.setPlaceholder(new Label("No rooms to show!"));
        
        columnRoom.setCellValueFactory(new PropertyValueFactory<>("room"));
        columnAvailable.setCellValueFactory(new PropertyValueFactory<>("available"));
        tableRooms.refresh();
    }
    private void loadTable(){
        //current
    }
    private List<Room> defaultRooms(){
        List<Room> l = new ArrayList<>();
        List<Client> lClient1 = new ArrayList<>();
        List<Client> lClient2 = new ArrayList<>();
        List<Client> lClient3 = new ArrayList<>();
        
        lClient1.add(new Client("Marcus", false));
        lClient1.add(new Client("Martha", true));
        lClient1.add(new Client("Caroline", false));
        lClient2.add(new Client("Ignacio", true));
        lClient2.add(new Client("Ruben", false));
        lClient3.add(new Client("Fernando", true));
        lClient3.add(new Client("Francisco", false));
        lClient3.add(new Client("Jose", true));
        
        l.add(new Room("Room1", 8, lClient1 ));
        l.add(new Room("Room2", 8, null));
        l.add(new Room("Room3", 8, lClient2));
        l.add(new Room("Room4", 8, null));
        l.add(new Room("Room5", 8, lClient3));
        return l;
    }

    @FXML
    private void onAction_dpDate(ActionEvent event) {
        LocalDate date = dpDate.getValue();
        if(!mapRooms.containsKey(date)){
            mapRooms.put(LocalDate.now(), defaultRooms());
            
        }
        currentRooms = FXCollections.observableArrayList(mapRooms.get(date));
            tableRooms.setItems(currentRooms);
            tableRooms.refresh();
            
    }

    @FXML
    private void onAction_bAdd(ActionEvent event) {
    }

    @FXML
    private void onAction_bRemove(ActionEvent event) {
    }
    
}
