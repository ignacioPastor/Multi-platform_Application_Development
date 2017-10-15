/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package exam.exercise1;

import exam.exercise1.io.MovieIO;
import exam.exercise1.model.Movie;
import java.net.URL;
import java.util.List;
import java.util.ResourceBundle;
import java.util.stream.Collectors;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;

/**
 * 
 * @author Ignacio Pastor Padilla
 */
public class FXMLDocumentController implements Initializable {
    
    private Label label;
    @FXML
    private ChoiceBox<String> cbFilter;
    @FXML
    private Button bApplyFilter;
    @FXML
    private TextField tfTitle;
    @FXML
    private TextField tfYear;
    @FXML
    private ChoiceBox<String> cbCategory;
    @FXML
    private ChoiceBox<Integer> cbRating;
    @FXML
    private Button bAddNew;
    @FXML
    private Button bUpdate;
    @FXML
    private Button bDelete;
    
    private List<Movie> listMovies;
    private ObservableList<Movie> currentMovies;
    @FXML
    private TableView<Movie> tableMovies;
    @FXML
    private TableColumn<Movie, String> columnTitle;
    @FXML
    private TableColumn<Movie, Integer> columnYear;
    @FXML
    private TableColumn<Movie, String> columnCategory;
    @FXML
    private TableColumn<Movie, Integer> columnRating;

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        cbCategory.setItems(FXCollections.observableArrayList(
            "Action", "Adventure", "Comedy","Science Fiction"));
        cbRating.setItems(FXCollections.observableArrayList(1, 2, 3, 4, 5));
        cbFilter.setItems(FXCollections.observableArrayList(
            "Show all movies", "Action", "Adventure", "Comedy","Science Fiction"));
        cbFilter.getSelectionModel().selectFirst();
        listMovies = MovieIO.loadMovies();
        currentMovies = FXCollections.observableArrayList(listMovies);
        tableMovies.setItems(currentMovies);
        initializeTable();
    }    
    public void initializeTable(){
        tableMovies.setPlaceholder(new Label("No movies to show!"));
        
        columnTitle.setCellValueFactory(new PropertyValueFactory<>("title"));
        columnYear.setCellValueFactory(new PropertyValueFactory<>("year"));
        columnCategory.setCellValueFactory(new PropertyValueFactory<>("category"));
        columnRating.setCellValueFactory(new PropertyValueFactory<>("rating"));
        loadMoviesTable();
    }
    @FXML
    private void onAction_bApply(ActionEvent event) {
        loadMoviesTable();
    }
    private void loadMoviesTable(){
        String option = cbFilter.getSelectionModel().getSelectedItem();
        currentMovies.clear();
        switch(option){
            case "Show all movies":
                currentMovies = FXCollections.observableArrayList(listMovies);
                break;
            case "Action":
                currentMovies = FXCollections.observableArrayList(filterAction());
                break;
            case "Adventure":
                currentMovies = FXCollections.observableArrayList(filterAdventure());
                break;
            case "Comedy":
                currentMovies = FXCollections.observableArrayList(filterComedy());
                break;
            case "Science Fiction":
                currentMovies = FXCollections.observableArrayList(filterScience());
                break;
            default:
                currentMovies = FXCollections.observableArrayList(listMovies);
                break;
        }
        tableMovies.setItems(currentMovies);
        tableMovies.refresh();
    }
    private List<Movie> filterAction(){
        List<Movie> l;
        l = listMovies.stream()
                .filter(p -> p.getCategory().equals("Action"))
                .collect(Collectors.toList());
        System.out.println("Count de list return = " + l.size());
        return l;
    }
    private List<Movie> filterAdventure(){
        List<Movie> l;
        l = listMovies.stream()
                .filter(p -> p.getCategory().equals("Adventure"))
                .collect(Collectors.toList());
        System.out.println("Count de list return = " + l.size());
        return l;
    }
    private List<Movie> filterComedy(){
        List<Movie> l;
        l = listMovies.stream()
                .filter(p -> p.getCategory().equals("Comedy"))
                .collect(Collectors.toList());
        System.out.println("Count de list return = " + l.size());
        return l;
    }
    private List<Movie> filterScience(){
        List<Movie> l;
        l = listMovies.stream()
                .filter(p -> p.getCategory().equals("Science Fiction"))
                .collect(Collectors.toList());
        System.out.println("Count de list return = " + l.size());
        return l;
    }
    @FXML
    private void onAction_bAddNew(ActionEvent event) {
        Movie m = new Movie(tfTitle.getText(), Integer.parseInt(tfYear.getText()),
            cbCategory.getSelectionModel().getSelectedItem(),
            cbRating.getSelectionModel().getSelectedItem());
        listMovies.add(m);
        currentMovies.add(m);
        tableMovies.refresh();
        MovieIO.saveMovies(listMovies);
    }
    @FXML
    private void onAction_bUpdate(ActionEvent event) {
        if(tableMovies.getSelectionModel().getSelectedItem() == null)
            return;
        Movie m = tableMovies.getSelectionModel().getSelectedItem();
        m.setTitle(tfTitle.getText());
        m.setYear(Integer.parseInt(tfYear.getText()));
        m.setCategory(cbCategory.getSelectionModel().getSelectedItem());
        m.setRating(cbRating.getSelectionModel().getSelectedItem());
        tableMovies.refresh();
        MovieIO.saveMovies(listMovies);
        
    }
    @FXML
    private void onAction_bDelete(ActionEvent event) {
        if(tableMovies.getSelectionModel().getSelectedItem() == null)
            return;
        Movie m = tableMovies.getSelectionModel().getSelectedItem();
        listMovies.remove(m);
        currentMovies.remove(m);
        tableMovies.refresh();
        MovieIO.saveMovies(listMovies);
    }
}