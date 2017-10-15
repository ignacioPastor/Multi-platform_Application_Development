/**
 * Final Exercise - Unit 2 - Service and Process Programming
 * Ignacio Pastor Padilla - 2º DAM Semi-presincial
 */
package examreminder.utils;

import examreminder.FXMLMainViewController;
import java.io.IOException;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 * Manages the change from Login window to main window
 * @author Ignacio Pastor Padilla
 */
public class ScreenLoader {
    /**
     * Prepare the new window, takin care of make a listener for catching close event
     * @param viewPath path of new view
     * @param stage
     * @throws IOException 
     */
    public void loadScreen(String viewPath, Stage stage) throws IOException{
        FXMLLoader loader = new FXMLLoader(getClass().getResource(viewPath));
        Parent root = (Parent)loader.load();
        FXMLMainViewController controller = (FXMLMainViewController)loader.getController();
        controller.setOnCloseListener(stage);
        Scene scene = new Scene(root);
        scene.getStylesheets().add("/styles/mainView.css");
        stage.setScene(scene);
        stage.show();
    }
}