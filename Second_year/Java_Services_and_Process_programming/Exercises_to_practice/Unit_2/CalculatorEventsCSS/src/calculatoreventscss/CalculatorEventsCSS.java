/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package calculatoreventscss;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 *
 * @author Ignacio
 */
public class CalculatorEventsCSS extends Application {
    
    @Override
    public void start(Stage stage) throws Exception {
        Parent root = FXMLLoader.load(getClass().getResource("FXMLDocument.fxml"));
        
        Scene scene = new Scene(root);
        
//        scene.getStylesheets().add(
//            getClass().getResource("style.css").toExternalForm());
//        scene.getStylesheets().add(
//            getClass().getResource("style.css").getFile());
        
        //scene.getStylesheets().add("style.css");
        scene.getStylesheets().add("resources/css/style.css");
        
        stage.setScene(scene);
        stage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
