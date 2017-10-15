
package echo_client;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

/**
 * SSP_Unit_4_Exercise_1
 * @author Ignacio Pastor Padilla
 */
public class Echo_Client {

    public static void main(String[] args) {
        String response;
        String saidClient;
        try(
            Scanner scanner = new Scanner(System.in);
            Socket mySocket = new Socket("localhost", 6000);
            DataInputStream socketIn =
                new DataInputStream(mySocket.getInputStream());
            DataOutputStream socketOut =
                new DataOutputStream(mySocket.getOutputStream());
        )
        {
            do{
                System.out.println();
                System.out.println("Say something!");
                saidClient = scanner.nextLine();
                socketOut.writeUTF(saidClient);
                if(!saidClient.equals("bye")){
                    response = socketIn.readUTF();
                    System.out.println(response);
                }
            }while(!saidClient.equals("bye"));
            System.out.println("Finishing program...");
        }catch(IOException e){
            System.err.println("Error: " + e.getMessage());
        }
        
    }
    
}
