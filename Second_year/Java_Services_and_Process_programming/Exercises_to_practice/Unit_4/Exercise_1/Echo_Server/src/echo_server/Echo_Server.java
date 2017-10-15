/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package echo_server;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

/**
 * SSP_Unit_4_Exercise_1
 * @author Ignacio Pastor Padilla
 */
public class Echo_Server {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String message = "";
        try(
            ServerSocket server = new ServerSocket(6000);
            Socket service = server.accept();
            DataInputStream socketIn = 
                new DataInputStream(service.getInputStream());
            DataOutputStream socketOut =
                new DataOutputStream(service.getOutputStream());
        )
        {
            do{
                System.out.println();
                message = socketIn.readUTF();
                if(!message.equals("bye")){
                    socketOut.writeUTF(message.toUpperCase());
                }
            }while(!message.equals("bye"));
        }catch(IOException io){
            System.err.println("Error: " + io.getMessage());
        }
        
    }
    
}
