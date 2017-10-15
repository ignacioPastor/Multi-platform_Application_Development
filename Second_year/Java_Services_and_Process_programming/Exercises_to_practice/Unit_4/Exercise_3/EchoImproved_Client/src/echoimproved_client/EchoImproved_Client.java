package echoimproved_client;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

/**
 * SPP - Unit 4 - Exercise 3
 * @author Ignacio Pastor Padilla
 * Client part of Client-Server connection.
 * The client choose the connection addres and send word, which is returned in capital letters
 */
public class EchoImproved_Client {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String response;
        String saidClient;
        String serverAddress = "";
        System.out.println("Which address would you connect?");
        serverAddress = scanner.nextLine();
        try(
            Socket mySocket = new Socket(serverAddress, 6000);
            DataInputStream socketIn = 
                new DataInputStream(mySocket.getInputStream());
            DataOutputStream socketOut = 
                new DataOutputStream(mySocket.getOutputStream());        )
        {
            do{
                System.out.println("Say something!");
                saidClient = scanner.nextLine();
                socketOut.writeUTF(saidClient);
                if(!saidClient.equals("bye")){
                    response = socketIn.readUTF();
                    System.out.println(response);
                }
                System.out.println();
            }while(!saidClient.equals("bye"));
            System.out.println("Finishing program...");
            scanner.close();
        }catch(IOException e){
            System.err.println("Error: " + e.getMessage());
        }
    }
}
