package udpdictionary_client;

import java.io.IOException;
import java.io.InterruptedIOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Scanner;

/**
 * SPP - Unit_4 - Exercise_2
 * @author Ignacio Pastor Padilla
 */
public class UDPDictionary_Client {

    public static void main(String[] args) {
        
        try(
            DatagramSocket mySocket = new DatagramSocket();
            Scanner scanner = new Scanner(System.in);
        )
        {
            String word = "";
            mySocket.setSoTimeout(5000);
            do{
                System.out.println("Type a word for translate");
                word = scanner.nextLine();
                byte[] message = word.getBytes();
                DatagramPacket packetS = new DatagramPacket(
                    message, message.length, InetAddress.getLocalHost(), 6000);
                mySocket.send(packetS);
                
                byte[] buffer = new byte[1024];
                DatagramPacket packetR = new DatagramPacket(buffer, buffer.length);
                mySocket.receive(packetR);
                System.out.println("Received: " +
                    new String(packetR.getData()).trim());
                System.out.println("");
            }while(!word.equals("exit"));
            System.out.println("Finishing program...");
        }catch(InterruptedIOException ie){
            try(DatagramSocket mySocket = new DatagramSocket())
            {
            byte[] message = "exit".getBytes();
                DatagramPacket packetS = new DatagramPacket(
                    message, message.length, InetAddress.getLocalHost(), 6000);
                mySocket.send(packetS);
            }catch(IOException ioInt){
                System.err.println("Error inten: " + ioInt.getMessage());
            }
            System.out.println("Not answer. END.");
        }catch(IOException io){
            System.err.println("Error: " + io.getMessage());
        }
        
    }
    
}
