/**
 * Final Exercise - Unit 2 - Service and Process Programming
 * Ignacio Pastor Padilla - 2º DAM Semi-presincial
 */
package examreminder;

import javafx.application.Application;
import static javafx.application.Application.launch;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 * @author Ignacio Pastor Padilla
 * This class has the main of the program, throws the Login Window
 */
public class ExamReminder extends Application{
    /**
     * Create and run the login window
     * If teacher wants charge directly the main window, please uncomment code, and comment
     * @param stage
     * @throws Exception 
     */
    @Override
    public void start(Stage stage) throws Exception {
        System.out.println("Before root");
        Parent root = FXMLLoader.load(getClass().getResource("/fxml/FXMLLoginView.fxml"));
//        Parent root = FXMLLoader.load(getClass().getResource("/fxml/FXMLMainView.fxml"));
        System.out.println("After root");

        Scene scene = new Scene(root);
        
        scene.getStylesheets().add("/styles/loginView.css");
//        scene.getStylesheets().add("/styles/mainView.css");

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
