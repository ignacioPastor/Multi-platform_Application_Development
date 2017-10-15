
package echoimproved_server;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

/**
 * SPP - Unit 4 - Exercise 3
 * @author Ignacio Pastor Padilla
 * Thread who manage the relation with client once the conection has been
 * stablished in the main thread
 */
public class ServerThread extends Thread{
    Socket service;
    String message = "";
    
    public ServerThread(Socket s){
        service = s;
    }
    
    @Override
    public void run(){
        DataInputStream socketIn = null;
        DataOutputStream socketOut = null;
        try{
            socketIn = new DataInputStream(service.getInputStream());
            socketOut = new DataOutputStream(service.getOutputStream());
            
            do{
                System.out.println();
                message = socketIn.readUTF();
                if(!message.equals("bye")){
                    socketOut.writeUTF(message.toUpperCase());
                }
            }while(!message.equals("bye"));
            
        }catch(IOException e){
            System.err.println("Error: " + e.getMessage());
        }finally{
            try{
                if(socketOut != null)
                    socketOut.close();
            }catch(IOException ex){}
            try{
                if(socketIn != null)
                    socketIn.close();
            }catch(IOException ex){}
            try{
                if(service != null)
                    service.close();
            }catch(IOException ex){}
        }
    }
}
