/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package scheduledchronometer;

import java.net.URL;
import java.util.ResourceBundle;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.application.Platform;
import javafx.concurrent.ScheduledService;
import javafx.concurrent.Task;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.util.Duration;

/**
 *
 * @author Ignacio
 */
public class FXMLDocumentController implements Initializable {
    
    @FXML
    private TextField tfSeconds;
    @FXML
    private Button bStart;
    @FXML
    private Button bPause;
    @FXML
    private Label lCount;
    private int seconds;
    ScheduledService<Boolean> schedServ;
    ThreadPoolExecutor executor;
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        schedServ = new ScheduledService<Boolean>(){
            
            @Override
            protected Task<Boolean> createTask() {
                return new Task<Boolean>(){
                    @Override
                    protected Boolean call() throws Exception {
                        Platform.runLater(() -> {
                            lCount.setText(String.valueOf(seconds--));
                            try {Thread.sleep(1000);} catch (InterruptedException ex) {}
                        });
                        return executor.isTerminated();
                    }
                };
            }
        };
        //schedServ.setPeriod(Duration.millis(10));
        schedServ.setOnSucceeded(e ->{
            if(schedServ.getValue()){
                schedServ.cancel();
                bStart.setDisable(false);
            }
        });
        bStart.setOnAction(e -> {
            try{
                seconds = Integer.parseInt(tfSeconds.getText());
            }catch(NumberFormatException ne){
                e.consume();
            }
            bStart.setDisable(true);
            executor = (ThreadPoolExecutor)Executors.newFixedThreadPool(Runtime.getRuntime().availableProcessors());
            executor.submit(()->{
                while(seconds > 0){
                    try {Thread.sleep(1);} catch (InterruptedException ex) {}
                }
            });
            executor.shutdown();
            schedServ.restart();
        });
        bPause.setOnAction(e -> {
            if(schedServ.isRunning())
                schedServ.cancel();
            else
                schedServ.restart();
        });
        
    }// initialize
}
