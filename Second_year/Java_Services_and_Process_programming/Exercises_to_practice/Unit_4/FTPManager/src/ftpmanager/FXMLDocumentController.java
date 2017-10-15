/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ftpmanager;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.input.MouseEvent;
import javafx.stage.DirectoryChooser;
import javafx.stage.FileChooser;
import javafx.stage.FileChooserBuilder;
import javafx.stage.Window;
import javax.swing.JFileChooser;
import javax.swing.JTextArea;
import org.apache.commons.net.ftp.FTP;
import org.apache.commons.net.ftp.FTPClient;
import org.apache.commons.net.ftp.FTPFile;
import org.apache.commons.net.ftp.FTPReply;

/**
 *
 * @author Ignacio
 */
public class FXMLDocumentController implements Initializable {
    
    @FXML
    private TextField tfServer;
    @FXML
    private TextField tfUser;
    @FXML
    private TextField tfPass;
    @FXML
    private Button bConnect;
    @FXML
    private ListView<FTPFile> lwContent;
    @FXML
    private Button bUpload;
    @FXML
    private Button bDownloadEnter;
    @FXML
    private Button bGoUp;
    @FXML
    private Button bDelete;
    @FXML
    private Label lInfo;
    @FXML
    private Button bDisconnect;
    
    FTPClient ftp;
    String server;
    String user;
    String password;
    int contador = 0;
    
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        System.out.println("Entra en initialize");
        ftp = new FTPClient();
        bDelete.setDisable(true);
        bDownloadEnter.setDisable(true);
        inicializacionModoPruebas();
    }    
    
    
    private void connect(){
        try {
            //lwContent.getItems().clear();
            server = tfServer.getText();
            user = tfUser.getText();
            password = tfPass.getText();
            ftp.setControlEncoding("UTF-8"); // Important (before connect)
            ftp.connect(server);
            //System.out.print(ftp.getReplyString());
            ftp.enterLocalPassiveMode(); // If the server is in another network
            if(!FTPReply.isPositiveCompletion(ftp.getReplyCode())) {
                ftp.disconnect();
                lInfo.setText("Error connecting to Server.");
            }
            
            if(ftp.login(user, password)) {
                lInfo.setText("Connection established succesfully.");
                //lInfo.setText("Loggin succesfull.");
                readFiles();
            }else{
                lInfo.setText("Loggin failed. User or password invalid.");
            }
        } catch (IOException e) {
            lInfo.setText("Error conecting: " + e.getMessage());
            System.out.println("Exception: " + e.getMessage());
        }
    }
    private void readFiles(){
        try{
            lwContent.getItems().clear();
            FTPFile[] files = ftp.listFiles();
            for(FTPFile file: files) {
                String type = file.isDirectory()?
                    "Directory: ":file.isSymbolicLink()?
                    "Link: ":"File: ";
                lwContent.getItems().add(file);
                System.out.println(type + " -> " + file.getName());
            }
        }catch(IOException io){
            lInfo.setText("Error reading files: " + io.getMessage());
        }
    }
    private void disconnect(){
        if (ftp.isConnected()) {
            try {
                ftp.disconnect();
                lInfo.setText("Disconection finished succesfully.");
            } catch (IOException ioe) {
                lInfo.setText("Error disconecting to server: " + ioe.getMessage());
            }
        }else{
            lInfo.setText("There are no connection established.");
        }
    }

    @FXML
    private void onClick_Connect(ActionEvent event) {
        connect();
    }

    @FXML
    private void onClick_Upload(ActionEvent event) {
        JTextArea textArea = new JTextArea();
        
        JFileChooser fileChooser = new JFileChooser();
        int result = fileChooser.showOpenDialog(textArea);
        File selectedFile = null;
        if (result == JFileChooser.APPROVE_OPTION) {
            selectedFile = fileChooser.getSelectedFile();
        }else
            return;
        String filePath = selectedFile.getAbsolutePath();
        String nameFile = selectedFile.getName();
        try(FileInputStream in = new FileInputStream(filePath)) {
            ftp.setFileTransferMode(FTP.BINARY_FILE_TYPE);
            if(!ftp.storeFile(nameFile, in)) {
                lInfo.setText("Error uploading file " + filePath +
                    " (" + ftp.getReplyString() + ")");
            } else {
                lInfo.setText("File " + filePath +
                    " uploaded with name " + nameFile);
                readFiles();
            }
        } catch (IOException e) {
            lInfo.setText("Error uploading file " + filePath
                + ": " + e.getMessage());
        }
    }

    @FXML
    private void onClick_DownloadEnter(ActionEvent event) {
        try{
            FTPFile selectedFile = lwContent.getSelectionModel().getSelectedItem();
            if(selectedFile == null)
                return;
            String path = selectedFile.getName();
            if(selectedFile.isFile()){ //File, download
                DirectoryChooser directoryChooser = new DirectoryChooser(); 

                  FTPFile fileDownload = lwContent.getSelectionModel().getSelectedItem();

                  File remoteFile = directoryChooser.showDialog(null);

                 if(remoteFile==null)
                      return;
                
                try(FileOutputStream out = new FileOutputStream(fileDownload.getName())) {
//                try(FileOutputStream out = new FileOutputStream(remoteFile.getAbsolutePath())) {
                    ftp.setFileTransferMode(FTP.BINARY_FILE_TYPE);
                    if(!ftp.retrieveFile(remoteFile.getAbsolutePath(), out)) {
//                    if(!ftp.retrieveFile(fileDownload.getName(), out)) {
                        lInfo.setText("Error downloading file " + fileDownload.getName() +
                            " (" + ftp.getReplyString() + ")");
                    } else {
                        lInfo.setText("File " + fileDownload.getName() +
                            " downloaded in name " + remoteFile.getName());
                    }
                } catch (IOException e) {
                    lInfo.setText("Error downloading file " + fileDownload.getName() +
                    e.getMessage());
                }
                
                
                
                
            }
            else if(selectedFile.isDirectory()){ // Directory, enter
                ftp.removeDirectory(path);
            }
            //lInfo.setText("Delete made succesfully");
            readFiles();
        }catch(IOException io){
            lInfo.setText("Error while deleting: " + io.getMessage());
        }
        
    }

    @FXML
    private void onClick_goUp(ActionEvent event) {
        
    }

    @FXML
    private void onClick_Delete(ActionEvent event) {
        try{
            FTPFile selectedFile = lwContent.getSelectionModel().getSelectedItem();
            if(selectedFile == null)
                return;
            String path = selectedFile.getName();
            if(selectedFile.isFile())
                ftp.deleteFile(path);
            else if(selectedFile.isDirectory())
                ftp.removeDirectory(path);
            lInfo.setText("Delete made succesfully");
            readFiles();
        }catch(IOException io){
            lInfo.setText("Error while deleting: " + io.getMessage());
        }
    }
    private void inicializacionModoPruebas(){
        tfServer.setText("localhost");
        tfUser.setText("Ignacio");
        tfPass.setText("1234");
    }

    @FXML
    private void onClick_bDisconnect(ActionEvent event) {
        disconnect();
    }

    @FXML
    private void onMouseClick(MouseEvent event) {
        bDelete.setDisable(false);
        bDownloadEnter.setDisable(false);
    }
}
