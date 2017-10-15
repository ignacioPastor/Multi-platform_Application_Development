
package passwordhackfx;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.net.URL;
import java.text.DecimalFormat;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.concurrent.ConcurrentMap;
import java.util.concurrent.ConcurrentSkipListMap;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;
import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;
import org.apache.commons.codec.digest.DigestUtils;

/**
 * FXML Controller class, manage the behaviour of the program
 * Final Exercise PSP Unit 3
 * @author Ignacio Pastor Padilla
 */
public class FXMLPasswordHackFXController implements Initializable {

    @FXML
    private ListView<String> lvKey;
    @FXML
    private Button bStart;
    @FXML
    private Label lInformation;
    @FXML
    private ListView<String> lvValue;
    BufferedReader reader;
    ConcurrentMap<String, String> resultMap;
    ThreadPoolExecutor poolExecutor;
    ScheduledExecutorService executorPending; 
    Map.Entry<String,String> mapItemTemp;//Main collection, here we save the encrypted password as key
                                        // and decrypted as value.
    Lock lock;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        lock = new ReentrantLock();
        resultMap = new ConcurrentSkipListMap<>();
        poolExecutor = (ThreadPoolExecutor) Executors.newFixedThreadPool(
                Runtime.getRuntime().availableProcessors());
        readPasswordFile();//Charge passwords in resultMap
        lvKey.getItems().setAll(resultMap.keySet());
        //Make a void Value listView with the same length of Key listView
        //  because we'll need put values in different parts of the list,
        //  without starting in the first position
        for (int i = 0; i < resultMap.size(); i++)
            lvValue.getItems().add("");
        
        executorPending = Executors.newScheduledThreadPool(1);
        /**
         * onAction event Start Button
         */
        bStart.setOnAction( e -> {
            executorPending.scheduleAtFixedRate(task, 1, 100, TimeUnit.MILLISECONDS);
            bStart.setDisable(true);
            throwThreads();
        });
    } //initialize
    /**
     * Task that manage the actualiced information showing in ScheduledService
     */
    Runnable task = () -> {
        int nTotal;
        int pending;
        nTotal = resultMap.size();
        pending = nTotal - (int)poolExecutor.getCompletedTaskCount();
        Platform.runLater(() -> lInformation.setText(pending + " threads pending"));
//        if(pending == 0)
//            executorPending.shutdownNow();
        if(pending == 0){
            executorPending.shutdownNow();
            int indx = someStillVoid();//Test phase has detected that a minimum percent of cases (around 5%)
                                    //one (only one) of decrypt password of resultMap is not copied 
                                    // in value listView and then appears one void in the listView 
                                    // of decrypted passwords. This line check voids, and in case of void
                                    // copy again the value of resultMap in value listView
            while(indx != -1){//This loop is not necesary, I don't delete this lines by redundant safety
                indx = someStillVoid();
            }
        }
    };
    /**
     * Implements the process of find the password of each encrypted password
     */
    private void throwThreads(){
        //Iterates over the resultMap
        for(Map.Entry<String,String> m : resultMap.entrySet()){
            poolExecutor.submit(()->{
                boolean find = false;
                for (int i = 0; i <= 999999 && !find; i++) {
                    if(DigestUtils.sha256Hex(new DecimalFormat("000000").format(i)).equals(m.getKey())){
                        String s = String.valueOf(new DecimalFormat("000000").format(i));
                        resultMap.replace(m.getKey(), s);
                        find = true;
                    }//if
                }//for intern
                if(!find)//if we haven't find the solution...
                    resultMap.replace(m.getKey(), "NOT FOUND");
                try{
                    lock.lock();
                    putValueInList(m);//Finally, we put the value in the value listView
                }finally{
                    lock.unlock();
                }
            });//executor
            
        }//iterating above map
        //Throws the executor
        poolExecutor.shutdown();
    }
    /**
     * Put the decrypted value in the value listView
     * @param m, Map item with encrypted and decrypted password
     */
    private void putValueInList(Map.Entry<String,String> m){
        mapItemTemp = m;
        //We use Platform.runLater for modify main thread from other threads
        Platform.runLater(taskAddValue);
    }
    /**
     * Task that add values to value listView
     */
    Runnable taskAddValue = () -> {
        int index;
        try{
            lock.lock();
            index = lvKey.getItems().indexOf(mapItemTemp.getKey());
            lvValue.getItems().set(index, resultMap.get(mapItemTemp.getKey()));
        }finally{
            lock.unlock();
        }
        //printMap();
    };
    /**
     * Read encrypted passwords from a file and save them in a map
     */
    private void readPasswordFile(){
        try{
            reader = new BufferedReader(new FileReader(new File("password.txt")));
            String line = "";
            while((line = reader.readLine()) != null){
                resultMap.put(line, "");
            }
            reader.close();
        }catch(FileNotFoundException fnf){
            System.err.println("File of password not found");
            System.exit(1);
        }catch(IOException io){
            System.err.println("Error reading password file: " + io.getMessage());
        }
    }
    /**
     * listener for close event
     * In case of sudden close of the form, finnish the threads.
     * @param stage 
     */
    public void setOnCloseListener(Stage stage) {
        stage.setOnCloseRequest(e -> {
            executorPending.shutdownNow();
            poolExecutor.shutdownNow();
        });
    }
    /**
     * Manage the syncronic selection of key and value
     * @param event selection of listView of keys
     */
    @FXML
    private void lvKey_onMouseClicked(MouseEvent event) {
        int index;
        String key;
        key = lvKey.getSelectionModel().getSelectedItem();
        index = lvKey.getItems().indexOf(key);
        lvValue.getSelectionModel().select(index);
    }
    /**
     * Prints map and value listView, usefull in test phase
     */
    private void printMap(){
        System.out.println();
        for (Map.Entry<String,String> m : resultMap.entrySet()) {
            System.out.println("ResultMap: Key: " + m.getKey() + "; Value: " + m.getValue());
        }
        for (String s : lvValue.getItems()) {
            System.out.println("lvValue: " + s);
        }
    }
    /**
     * Check voids in value listView
     * @return index of void, -1 if there are no void
     */
    private int someStillVoid(){
        for (String s : lvValue.getItems()) {
            if(s.equals("")){
                for (Map.Entry<String,String> m : resultMap.entrySet()) {
                    if(notInLvValue(m.getValue())){
                        int n= lvKey.getItems().indexOf(m);
                        putValueInList(m);
                        return n;
                    }
                }
            }
        }
        return -1;
    }
    /**
     * Check if a item value from resultMap doesn't appear in value listView
     * @param s value of item from resultMap
     * @return true if the value item does'n appears, which means that that values hasn't been copied
     */
    public boolean notInLvValue(String s){
        for (String s2 : lvValue.getItems()) {
            if(s2.equals(s))
                return false;
        }
        return true;
    }
}