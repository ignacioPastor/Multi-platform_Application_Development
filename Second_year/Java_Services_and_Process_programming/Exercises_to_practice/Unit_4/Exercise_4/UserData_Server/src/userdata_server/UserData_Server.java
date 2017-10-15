/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package userdata_server;

import exercise4.User;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.ServerSocket;
import java.net.Socket;

/**
 *
 * @author Ignacio
 */
public class UserData_Server {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ServerSocket server = null;
        ObjectInputStream objIn = null;
        ObjectOutputStream objOut = null;
        try{
            server = new ServerSocket(6000);
            
            System.out.println("Listening...");
               Socket service = server.accept();
               objIn = new ObjectInputStream(service.getInputStream());
            objOut = new ObjectOutputStream(service.getOutputStream());
            
               System.out.println("Connection established");
//               ServerThread st = new ServerThread(service);
//               st.start();
            User user = new User();
            objOut.writeObject(user);
            
            User user2 = (User) objIn.readObject();
            
            user.setName(user2.getName());
            user.setPassword(user2.getPassword());
            
            System.out.println("User information:");
            System.out.println("    Name: " + user.getName()
                + ", Password: " + user.getPassword()
                + ", Date register: " + user.getDateRegister().toString());
        }catch(IOException io){
            System.err.println("Error: " + io.getMessage());
        }catch(ClassNotFoundException ce){
            System.err.println("Class not found: " + ce.getMessage());
        }finally{
            try{server.close();}catch(Exception e){
                System.err.println("Peta en el main server: " + e.getMessage());}
        }
    }
    
}
