package examreminder;

/**
 * Final Exercise - Unit 2 - Service and Process Programming
 * Ignacio Pastor Padilla - 2º DAM Semi-presincial
 */


import examreminder.model.Exam;
import examreminder.utils.FileUtils;
import examreminder.utils.MessageUtils;
import java.net.URL;
import java.text.DecimalFormat;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.OptionalDouble;
import java.util.ResourceBundle;
import java.util.stream.Collectors;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.DatePicker;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.control.TableCell;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;

/**
 * FXML Controller class
 * This class manage the main window
 * @author Ignacio Pastor Padilla
 */
public class FXMLMainViewController implements Initializable {

    @FXML
    private TableView<Exam> tableData;
    @FXML
    private TableColumn<Exam, String> columnSubject;
    @FXML
    private TableColumn<Exam, LocalDate> columnDate;
    @FXML
    private TableColumn<Exam, Float> columnMark;
    @FXML
    private TextField textSubject;
    @FXML
    private DatePicker datePicker;
    @FXML
    private TextField textMark;
    @FXML
    private Button buttonUpdate;
    @FXML
    private Button buttonDelete;
    @FXML
    private ChoiceBox<String> choiceFilter;
    @FXML
    private Button buttonFilter;
    
    private List<Exam> listExam;
    private ObservableList<Exam> currentExams;
    private boolean examSelected = false;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        choiceFilter.setItems(FXCollections.observableArrayList(
            "Show all exams", "Show exams from currently selected subject", "Show exams average",
            "Show future exams", "Show maximum marks"));
        choiceFilter.getSelectionModel().selectFirst();
        listExam = FileUtils.loadExams();
        loadTable();
    }
    /**
     * We will call this method for knowing wich filter use
     * Depends of filter choosen, we will prepare the current list for table in one or other way
     */
    private void loadTable(){
        switch(choiceFilter.getSelectionModel().getSelectedIndex()){
            case 0:
                filterAllExams();
                break;
            case 1:
                if(!examSelected){
                    MessageUtils.showAlert("One Exam has to be selected.");
                    return;
                }
                filterSelectedExams();
                break;
            case 2:
                filterExamsAverage();
                break;
            case 3:
                filterFutureExams();
                break;
            case 4:
                filterMaximumMarks();
                break;
            default:
                MessageUtils.showError("Internal error has ocurred");
                break;
        }
    }
    /**
     * Performs the data of the date 
     * @param date for taking data
     * @return data of date well performed
     */
    private String getPerformedDate(LocalDate date){
        String[] splitDate = date.toString().split("-");
        return splitDate[2] + "/" + splitDate[1] + "/" + splitDate[0];
    }
    /**
     * Charge currentExams (observable list) with all exams, for first filter
     */
    private void filterAllExams(){
        currentExams = FXCollections.observableArrayList(listExam);
        initializeTable();
    }
    /**
     * Charge currentExams with exams of subject selected
     */
    private void filterSelectedExams(){
        // It's not necessary check if something selected (buttons must be disabled) but it's a good protection
        Exam selectedExam = tableData.getSelectionModel().selectedItemProperty().getValue();
        if(selectedExam == null){
            MessageUtils.showMessage("Exam has to be selected");
            return;
        }
        String aSubject = selectedExam.getSubject();
        currentExams.clear();
        for (int i = 0; i < listExam.size(); i++) {
            if(listExam.get(i).getSubject().equals(aSubject)){
                currentExams.add(listExam.get(i));
            }
        }
        initializeTable();
    }
    /**
     * Show the average of visible exams
     */
    private void filterExamsAverage(){
        OptionalDouble avgMark = currentExams.stream()
                .filter(p -> p.getMark() != 0.0f)
                .mapToDouble(p -> p.getMark()).average();
        Double n = avgMark.orElse(0);
        DecimalFormat formatter = new DecimalFormat("#0.0");     
        MessageUtils.showMessage("The average of selected exams is " + formatter.format(n));
        
    }
    /**
     * Charge currentExams with future exams
     */
    private void filterFutureExams(){
        currentExams.clear();
        LocalDate dateNow = LocalDate.now();
        for (int i = 0; i < listExam.size(); i++) {
            if(listExam.get(i).getDate().isAfter(dateNow)){
                currentExams.add(listExam.get(i));
            }
        }
        initializeTable();
    }
    /**
     * Identificate a exam from a list, given the subject and mark from that exam
     * @param l list with exams where look for
     * @param subject of the exam that we're looking for
     * @param mark of the exam that we're looking for
     * @return  exam which we were looking for
     */
    public Exam identificateExam(List<Exam> l, String subject, float mark){
        for (int i = 0; i < l.size(); i++) {
            if(l.get(i).getSubject().equalsIgnoreCase(subject) && l.get(i).getMark() == mark)
                return l.get(i);
        }
        return null;
    }
    /**
     * Removes duplicates from string list
     * @param l list of strings
     * @return list witch out duplicates
     */
    public List<String> removeDuplicates(List<String> l){
        List<String> l2 = new ArrayList<>();
        for (int i = 0; i < l.size(); i++) {
            if(!l2.contains(l.get(i)))
                l2.add(l.get(i));
        }
        return l2;
    }
    /**
     * Charge currentExams with exams with higher marks of each subject
     * Don't show exams with out mark
     */
    private void filterMaximumMarks(){
        currentExams.clear();
        // We do a list with all subjects (there are duplicates)
        List<String> namesSubject = listExam.stream()
                                        .map(p -> p.getSubject())
                                        .collect(Collectors.toList());
        // Remove duplicates, now we have the name of each subject
        namesSubject = removeDuplicates(namesSubject);
        // For each subject, we catch the exam with higher mark
        for (int i = 0; i < namesSubject.size(); i++) {
            String s = namesSubject.get(i); // subject
            Double t = listExam.stream() //Mark
                            .filter(p -> p.getSubject().equals(s))
                            .mapToDouble(Exam::getMark)
                            .max().getAsDouble();
            //With subject, and mark, we look for the exam
            Exam e = identificateExam(listExam, s, Float.parseFloat(String.valueOf(t)));
            //Add exam to currenExams
            currentExams.add(e);
        }
        // Delete the exams with out mark (maybe there are subjects with all exams without mark
        for (int i = 0; i < currentExams.size(); i++) {
            if(currentExams.get(i).getMark() == 0.0f){
                currentExams.remove(currentExams.get(i));
                i--;
            }
        }
        initializeTable();
    }
    /**
     * Charge the observableList (currentExams) in table
     * Initializes the tableview
     */
    public void initializeTable(){ 
        tableData.setPlaceholder(new Label("No exams to show!"));
        
        columnSubject.setCellValueFactory(new PropertyValueFactory<>("subject"));
        columnDate.setCellValueFactory(new PropertyValueFactory<>("date"));
        columnMark.setCellValueFactory(new PropertyValueFactory<>("mark"));
        
        tableData.setItems(currentExams);
        // Not show exams without mark (mark of 0.0)
        columnMark.setCellFactory(col -> {
            return new TableCell<Exam, Float>() {
                @Override
                protected void updateItem(Float mark, boolean empty) {
                    super.updateItem(mark, empty);
                    
                    if(mark == null || empty)
                        setText(null);
                    else if(mark == 0.0f)
                        setText(null);
                    else
                        setText(String.valueOf(mark));
                }
            };
        });
        //Date is shown in asked way (dd/mm/yyyy)
        columnDate.setCellFactory(col -> {
            return new TableCell<Exam, LocalDate>() {
                @Override
                protected void updateItem(LocalDate date, boolean empty) {
                    super.updateItem(date, empty);
                    
                    if(date == null || empty)
                        setText(null);
                    else
                        setText(getPerformedDate(date));
                }
            };
        });
        // Check if exam is selected for enable or disable buttons
        checkEnableButtons();
    }
    /**
     * Manage action button of add button
     * @param event action of add button
     */
    @FXML
    private void onActionAdd(ActionEvent event) {
        String aSubject = textSubject.getText();
        LocalDate aDate = datePicker.getValue();
        if(aSubject.equals("")|| aDate == null){
            MessageUtils.showAlert("Subject and Date can't be empty");
            clearFields();
            return;
        }
        Float aMark = -1f; // Control value, if doesn't change, we will asume that there are no mark
        String sMark = textMark.getText();
        if(!sMark.equals("")){
            try{
                aMark = Float.parseFloat(sMark);
                if(aMark < 0 || aMark > 10){
                    MessageUtils.showAlert("Mark has to be a number between 0 and 10");
                    clearFields();
                    return;
                }
            }catch(Exception e){
                MessageUtils.showAlert("Invalid data, Mark has to be a number");
                clearFields();
                return;
            }
        }
        Exam newExam;
        // We create the new exam depending of mark
        if(aMark != -1f)
            newExam = new Exam(aSubject, aDate, aMark);
        else
            newExam = new Exam(aSubject, aDate);
        listExam.add(newExam);
        
        //FileUtils.saveExams(listExam);
        currentExams.add(newExam);
        MessageUtils.showMessage("New exam added successfully!");
        clearFields();
        tableData.getSelectionModel().select(newExam);
        tableData.scrollTo(newExam);
    }
    /**
     * Clear text fields
     */
    private void clearFields(){
        textSubject.setText("");
        textMark.setText("");
        datePicker.setValue(null);
    }
    /**
     * Manage event of action in update button
     * @param event action of update button
     */
    @FXML
    private void onActionUpdate(ActionEvent event) {
        //Check if there are exam selected. It's not really necessary, only for security
        if(tableData.getSelectionModel().getSelectedItem() == null){
            MessageUtils.showMessage("An Exam has to be selected");
            return;
        }
        String aSubject = textSubject.getText();
        LocalDate aDate = datePicker.getValue();
        if(aSubject.equals("")|| aDate == null){
            MessageUtils.showAlert("Subject and Date can't be empty");
            clearFields();
            return;
        }
        Float aMark = -1f;
        String sMark = textMark.getText();
        if(!sMark.equals("")){
            try{
                aMark = Float.parseFloat(sMark);
                if(aMark < 0 || aMark > 10){
                    MessageUtils.showAlert("Mark has to be a number between 0 and 10");
                    clearFields();
                    return;
                }
            }catch(Exception e){
                MessageUtils.showAlert("Invalid data, Mark has to be a number");
                clearFields();
                return;
            }
        }
        Exam selectedExam = tableData.getSelectionModel().getSelectedItem();
        
        selectedExam.setDate(aDate);
        selectedExam.setSubject(aSubject);
        
        if(aMark != -1f)
            selectedExam.setMark(aMark);
        else
            selectedExam.setMark(0.0f);
        
        //FileUtils.saveExams(listExam);
        MessageUtils.showMessage("Exam updated successfully!");
        clearFields();
        tableData.refresh();
        tableData.scrollTo(selectedExam);
    }
    /**
     * Manage the action event of delete button
     * @param event action of delete button
     */
    @FXML
    private void onActionDelete(ActionEvent event) {
        if(tableData.getSelectionModel().getSelectedItem() == null){
            MessageUtils.showMessage("An Exam has to be selected");
            return;
        }
        Exam selectedExam = tableData.getSelectionModel().getSelectedItem();
        if(!MessageUtils.showConfirmation("Are you sure about delete this exam? \n" + selectedExam.getData()))
           return;
        listExam.remove(selectedExam);
        currentExams.remove(selectedExam);
        //FileUtils.saveExams(listExam);
    }
    /**
     * Manage the action event of apply filter button
     * @param event action of apply button
     */
    @FXML
    private void onActionApllyFilter(ActionEvent event) {
        loadTable();
    }

    /**
     * Manage the event on click in the tableView
     * When click detected, we'll check if there are exam select
     * Because cntrl + click unselect the selected exam
     * @param event on click in the tableview
     */
    @FXML
    private void onTableClick(MouseEvent event) {
        checkEnableButtons();
    }
    /**
     * Activate and desactivate buttons in depends of if there ara a exam selected or not
     * @param event mouse click on table
     */
    private void checkEnableButtons(){
       if(tableData.getSelectionModel().getSelectedItem() == null){ // Nothing selected
            buttonUpdate.setDisable(true);
            buttonDelete.setDisable(true);
            examSelected = false;
        }
        else{                               //Exam selected
            buttonUpdate.setDisable(false);
            buttonDelete.setDisable(false);
            examSelected = true;
        } 
    }
    /**
     * Listener for catch the close event for main window
     * Before close the application, we come here
     * @param stage 
     */
    public void setOnCloseListener(Stage stage) {
        stage.setOnCloseRequest(e -> {
            //System.out.println("The application is being closed");
            if(!MessageUtils.showConfirmation("Are you sure about closing the application?"))
                e.consume();
            else{
                FileUtils.saveExams(listExam);
                MessageUtils.showMessage("All data have been saved successfully!");
            }
        });
    }
}