/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package clientesimple;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import java.io.DataOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.lang.reflect.Type;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import javafx.collections.FXCollections;
import libraryex4.Actor;
import libraryex4.Login;
import libraryex4.ServiceUtils;
import libraryex4.WSLoginResponse;
import libraryex4.WSOkResponse;
import org.apache.commons.net.ftp.FTP;
import org.apache.commons.net.ftp.FTPClient;
import org.apache.commons.net.ftp.FTPFile;
import org.apache.commons.net.ftp.FTPReply;


/**
 *
 * @author Ignacio
 */
public class ClienteSimple {

    /**
     * @param args the command line arguments
     */
    private static String token;
    private static FTPClient ftp;
    private static Actor myStaticActor;
    public static void main(String[] args) {
        //probarSocket();
        login();
        //getActors();
        getMatchActors();
        //insertActor();
        //deleteActor();
        //getFavourite();
        //insertFavourite();
        //deleteFavourite();
        //connectFTPServer();
        //downloadImage(myStaticActor.getImgFile());
        //listFiles();
        //updateActor();
    }
    private static void updateActor(){
        Actor myActor = new Actor(222, "Actor1Mod", "January 2, 1111", "imgActor1DoubleMod", "DescriptionActor1Mod");
        ServiceUtils.setToken(token);
        Gson gsonInsertActor = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
        String dataActor = gsonInsertActor.toJson(myActor);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/actor/" + myActor.getId(), dataActor, "PUT");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                System.out.println("Actor updated correctly");
            }else{
                System.out.println("Error: " + wsResponse.getError());
            }
        }else{
            System.out.println("Error updating actor.");
        }
    }
    private static boolean connectFTPServer(){
        String server = "finalex4.iessanvi.es";
        String user = "finalex4";
        String pass = "1234";

        if (server.isEmpty() || user.isEmpty() || pass.isEmpty()) {
            System.out.println("There are empty fields!");
            return false;
        }
        try {
            ftp = new FTPClient();
            ftp.connect(server);
            ftp.setControlEncoding("UTF-8");

            if (!FTPReply.isPositiveCompletion(ftp.getReplyCode())) {
                System.out.println("Error connecting to server!");
                return false;
            }
//            if (!ftp.login(user, pass)) {
//                System.out.println("User and/or password incorrect!");
//                return false;
//            }
            System.out.println("Connected!");
            return true;
        } catch (IOException ex) {
            System.out.println("Error connecting to server!");
            return false;
        }
    }
    private static void uploadImage(){
        
    }
    private static void listFiles(){
        String user = "finalex4";
        String pass = "1234";
        if(!connectFTPServer()){
            System.out.println("Error connecting");
            return;
        }
        try{
            ftp.changeWorkingDirectory("finalex4.iessanvi.es/img");
            FTPFile[] files = ftp.listFiles();
            for(FTPFile file: files) {
                String type = file.isDirectory()?
                "Directory":file.isSymbolicLink()?
                "Link":"File";
                System.out.println(type + " -> " + file.getName());
            }
        }catch(IOException io){
            System.err.println("Error trying listing: " + io.getMessage());
        }
    }
    private static void downloadImage(String nameImage){
        if(!connectFTPServer()){
            System.out.println("Cannot download image, error connecting");
            return;
        }
        try(FileOutputStream out = new FileOutputStream(nameImage)){
            ftp.setFileTransferMode(FTP.BINARY_FILE_TYPE);
            if(!ftp.retrieveFile(nameImage, out)){
                System.err.println("Error downloading the image: " + ftp.getReplyString());
            }else{
                System.out.println("File downloaded!");
            }
        }catch(IOException io){
            System.err.println("Error downloading image: " + io.getMessage());
        }
    }
    private static void deleteFavourite(){
        ServiceUtils.setToken(token);
        int idActor = 222;
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/favourite/" + idActor, null, "DELETE");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                System.out.println("Actor deleted correctly from favourite");
            }else{
                System.out.println("Error: " + wsResponse.getError());
            }
        }else{
            System.out.println("Error deleting actor from favourite.");
        }
    }
    private static void insertFavourite(){
        int id = 222;
        ServiceUtils.setToken(token);
        Gson gsonInsertFavourite = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/favourite/"+id, null, "POST");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                System.out.println("Actor inserted correctly in favourites");
            }else{
                System.out.println("Error: " + wsResponse.getError());
            }
        }else{
            System.out.println("Error inserting actor in favourites.");
        }
    }
    private static void getFavourite(){
        ServiceUtils.setToken(token);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/favourite", null, "GET");
        if(jsonResponse != null){
            Gson gsonGetFavourites = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            Type type = new TypeToken<List<Actor>>(){}.getType();
            List<Actor> actors = gsonGetFavourites.fromJson(jsonResponse, type);
            for(Actor a : actors){
                System.out.println(a.toString());
                System.out.println();
            }
        }else{
            System.out.println("Error getting the favourite actors.");
        }
    }
    private static void deleteActor(){
        ServiceUtils.setToken(token);
        String idActor = "220";
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/actor/" + idActor, null, "DELETE");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                System.out.println("Actor deleted correctly");
            }else{
                System.out.println("Error: " + wsResponse.getError());
            }
        }else{
            System.out.println("Error deleting actor.");
        }
    }
    private static void insertActor(){
        Actor myActor = new Actor(0, "Actor1", "January 1, 1111", "imgActor1", "DescriptionActor1");
        ServiceUtils.setToken(token);
        Gson gsonInsertActor = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
        String dataActor = gsonInsertActor.toJson(myActor);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/actor", dataActor, "POST");
        if(jsonResponse != null){
            Gson gsonAnswer = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSOkResponse wsResponse = gsonAnswer.fromJson(jsonResponse, WSOkResponse.class);
            if(wsResponse.isOk()){
                System.out.println("Actor inserted correctly");
            }else{
                System.out.println("Error: " + wsResponse.getError());
            }
        }else{
            System.out.println("Error inserting actor.");
        }
    }
    private static void getMatchActors(){
        
        ServiceUtils.setToken(token);
        String nameLookFor = "Actor";
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/actor/" + nameLookFor, null, "GET");
        if(jsonResponse != null){
            Gson gsonGetMatchActors = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            Type type = new TypeToken<List<Actor>>(){}.getType();
            List<Actor> actors = gsonGetMatchActors.fromJson(jsonResponse, type);
            for(Actor a : actors){
                if(myStaticActor == null)
                    myStaticActor = a;
                System.out.println(a.toString());
                System.out.println();
            }
        }else{
            System.out.println("Error getting match actor.");
        }
        
    }
    private static void getActors(){
        
        ServiceUtils.setToken(token);
        //String dataGetActors = gsonGetActors.toJson(myLogin);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/actor", null, "GET");
        if(jsonResponse != null){
            Gson gsonGetActors = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            Type type = new TypeToken<List<Actor>>(){}.getType();
            List<Actor> actors = gsonGetActors.fromJson(jsonResponse, type);
            for(Actor a : actors){
                System.out.println(a.toString());
                System.out.println();
            }
        }else{
            System.out.println("Error getting the actors.");
        }
    }
    private static void login(){
        Login myLogin = new Login("bob", "1234");
        
        Gson gsonLogin = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
        String dataLogin = gsonLogin.toJson(myLogin);
        String jsonResponse = ServiceUtils.getResponse(
                "http://finalex4.iessanvi.es/finalex4/login", dataLogin, "POST");
        
        if(jsonResponse != null){
            Gson gson = new GsonBuilder().setPrettyPrinting().serializeNulls().create();
            WSLoginResponse loginResponse = gson.fromJson(jsonResponse, WSLoginResponse.class);
            if(loginResponse == null){
                System.out.println("Respuesta nula");
            }else
            if(loginResponse.getError() == null || loginResponse.getError().equals("")){
                System.out.println(loginResponse.toString());
                System.out.println();
                token = loginResponse.getToken();
            }
        }else{
            System.out.println("Error in the login process");
        }
    }
    private static void probarSocket(){
        String response;
        String saidClient;
        try(
            Scanner scanner = new Scanner(System.in);
            Socket mySocket = new Socket("localhost", 6000);
            ObjectInputStream objIn =
                new ObjectInputStream(mySocket.getInputStream());
            DataOutputStream socketOut =
                new DataOutputStream(mySocket.getOutputStream());
        )
        {

            System.out.println();
            saidClient = "Rob";
            socketOut.writeUTF(saidClient);
            
            Actor myActor = (Actor)objIn.readObject();
            if(myActor.getName() == null){
                System.out.println("No results have been found");
            }else{
                System.out.println(myActor.toString());
            }

            System.out.println("Finishing program...");
        }catch(IOException io){
            System.err.println("Error: " + io.getMessage());
        }catch(ClassNotFoundException cnf){
            System.err.println("Error: " + cnf.getMessage());
        }
    }
}
