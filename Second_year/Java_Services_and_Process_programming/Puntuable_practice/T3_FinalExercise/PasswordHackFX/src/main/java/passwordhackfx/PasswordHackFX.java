package passwordhackfx;

import java.io.IOException;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.stage.Stage;

/**
 * Final Exercise PSP Unit 3
 * @author Ignacio Pastor Padilla
 * Main class, show the stage and make a controller for close event
 */
public class PasswordHackFX extends Application {
    
    @Override
    public void start(Stage stage) throws IOException{
        FXMLLoader loader = new FXMLLoader(getClass().getResource("FXMLPasswordHackFX.fxml"));
        Parent root = (Parent)loader.load();

        FXMLPasswordHackFXController controller = (FXMLPasswordHackFXController)loader.getController();
        controller.setOnCloseListener(stage);
        
        Scene scene = new Scene(root);  
        
        stage.setScene(scene);
        stage.setTitle("PasswordHackFX");
        stage.getIcons().add(new Image("icon.jpg"));
        stage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
