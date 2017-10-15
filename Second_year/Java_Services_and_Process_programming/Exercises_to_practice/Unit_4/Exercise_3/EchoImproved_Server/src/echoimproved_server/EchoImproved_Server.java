package echoimproved_server;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

/**
 * SPP - Unit 4 - Exercise 3
 * @author Ignacio Pastor Padilla
 * Client-Server program who deal with multiple client.
 * Establish the conection in this class and create new thread for manage that
 * comunication in separate thread
 */
public class EchoImproved_Server {
    public static void main(String[] args) {
        
        try(ServerSocket server = new ServerSocket(6000);)
        {
            System.out.println("Listening...");
            while(true){
               Socket service = server.accept();
               System.out.println("Connection established");
               ServerThread st = new ServerThread(service);
               st.start();
            }
        }catch(IOException io){
            System.err.println("Error: " + io.getMessage());
        }
        
    }
    
}
