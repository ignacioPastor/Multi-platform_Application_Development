package udpdictionary_server;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Hashtable;

/**
 * SPP - Unit_4 - Exercise_2
 * @author Ignacio
 */
public class UDPDictionary_Server {
    public static void main(String[] args) {
        Hashtable<String, String> dictionary = 
                new Hashtable<String, String>();
        dictionary.put("cat", "gato");
        dictionary.put("dog", "perro");
        dictionary.put("table", "mesa");
        String answer;
        try(DatagramSocket mySocket = 
            new DatagramSocket(6000, InetAddress.getLocalHost()))
        {
            do{
                byte[] buffer = new byte[1024];
                DatagramPacket packetR = new DatagramPacket(buffer, buffer.length);
                mySocket.receive(packetR);
                String wordReceived = new String(packetR.getData()).trim();
                System.out.println("Received: " + wordReceived);

                int destPort = packetR.getPort();
                InetAddress destAddr = packetR.getAddress();
                answer = dictionary.get(wordReceived);

                if(answer != null){
                    byte[] message = answer.getBytes();
                    DatagramPacket packetS = new DatagramPacket(message,
                            message.length, destAddr, destPort);
                    mySocket.send(packetS);
                }
            }while(answer != null);
        }catch(IOException e){
            System.err.println("Error: " + e.getMessage());
        }
    }
    
}
