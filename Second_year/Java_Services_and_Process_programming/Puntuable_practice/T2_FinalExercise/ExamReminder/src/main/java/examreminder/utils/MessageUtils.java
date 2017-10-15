/**
 * Final Exercise - Unit 2 - Service and Process Programming
 * Ignacio Pastor Padilla - 2º DAM Semi-presincial
 */
package examreminder.utils;

import java.util.Optional;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.ButtonType;

/**
 * This class manage the dialog messages shown in the application
 * @author Ignacio Pastor Padilla
 */
public class MessageUtils {

    /**
     * Show error messages
     * @param message for showing in the window
     */
    public static void showError(String message){
        Alert alert = new Alert(AlertType.ERROR);
        alert.setTitle("Error Window");
        alert.setHeaderText("An error has ocurred!");
        alert.setContentText(message);

        alert.showAndWait(); 
    }
    /**
     * Show information messages
     * @param message  for showing in the window
     */
    public static void showMessage(String message){
        Alert alert = new Alert(AlertType.INFORMATION);
        alert.setTitle("Information Window");
        alert.setHeaderText("Information message");
        alert.setContentText(message);

        alert.showAndWait();
    }
    /**
     * Show alert messages
     * @param message for showing in the window
     */
    public static void showAlert(String message){
        Alert alert = new Alert(AlertType.WARNING);
        alert.setTitle("Warning Window");
        alert.setHeaderText("Warning message!");
        alert.setContentText(message);

        alert.showAndWait();
    }
    /**
     * Show confirmation window, and manage the choosen option
     * @param message 
     * @return true if ok button has been choosen
     */
    public static boolean showConfirmation(String message){
        Alert alert = new Alert(AlertType.CONFIRMATION);
        alert.setTitle("Confirmation Window");
        alert.setHeaderText("Confirmation message");
        alert.setContentText(message);

        Optional<ButtonType> result = alert.showAndWait();
        if (result.get() == ButtonType.OK)
            return true;
        else
            return false;
    }
}