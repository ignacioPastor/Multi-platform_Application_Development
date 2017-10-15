/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package userdata_client;

import exercise4.User;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class UserData_Client {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Antes del try");
        Socket mySocket = null;
        ObjectInputStream objIn = null;
        ObjectOutputStream objOut = null;
        try{
            mySocket = new Socket("localhost", 6000);
            objOut = new ObjectOutputStream(mySocket.getOutputStream());
            objIn = new ObjectInputStream(mySocket.getInputStream());
            System.out.println("Entra en el try");
                
            User user = (User) objIn.readObject();

            System.out.println("Say your name");
            user.setName(scanner.nextLine());
            System.out.println("Type your password");
            user.setPassword(scanner.nextLine());

            objOut.writeObject(user);
            System.out.println();
            System.out.println("Finishing program...");
            scanner.close();
        }catch(IOException e){
            System.err.println("Error: " + e.getMessage());
        }catch(ClassNotFoundException ce){
            System.err.println("Class not found: " + ce.getMessage());
        }finally{
            
            try{
                if(mySocket != null)
                    mySocket.close();
                if(objIn != null)
                    objIn.close();
                if(objOut != null)
                    objOut.close();
            }catch(Exception e){
                System.err.println("Peta: " + e.getMessage());
            }
        }
    }
    
}
