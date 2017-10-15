/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package serversocket_finalex_ignaciopastor;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import libraryex4.MessageUtils;

/**
 * ServerSocket class
 * @author Ignacio Pastor Padilla
 */
public class ServerSocket_FinalEx_IgnacioPastor {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try(ServerSocket server = new ServerSocket(6000);)
        {
            System.out.println("Server: Listening...");
            while(true){
               Socket service = server.accept();
               ServerThread st = new ServerThread(service);
               st.start();
            }
        }catch(IOException io){
            MessageUtils.showError("Error: " + io.getMessage());
        }
    }
    
}
