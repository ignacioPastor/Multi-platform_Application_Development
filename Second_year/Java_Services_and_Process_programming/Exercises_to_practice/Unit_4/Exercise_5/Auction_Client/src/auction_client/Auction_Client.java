/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package auction_client;

import exercise5_unit4.Buyer;
import exercise5_unit4.Product;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Scanner;

/**
 * SPP - Exercise 5 - Unit 4
 * @author Ignacio Pastor Padilla
 */
public class Auction_Client {

    public static void main(String[] args) throws ClassNotFoundException {
        Scanner scanner = new Scanner(System.in);
        Product prod = null;
        ByteArrayInputStream bis = null;
        ObjectInputStream in = null;
        
        byte[] bytesProduct;
        
        try (DatagramSocket mySocket = new DatagramSocket())
        {
            // Send handsake
            String text = "";
            byte[] message = text.getBytes();
            DatagramPacket packetS = new DatagramPacket(message, message.length,
                InetAddress.getLocalHost(), 2000);
            mySocket.send(packetS);
            
            while(prod == null){
                // Receives product
                 byte[] received = new byte[1024];
                DatagramPacket datagramReceived = new DatagramPacket(received,
                    received.length);
                mySocket.receive(datagramReceived);
                
                bis = new ByteArrayInputStream(received);
                in = new ObjectInputStream(bis); //peta aquí
                prod = (Product) in.readObject();
            }
            
            //Print data product
            System.out.println("Product name: " + prod.getName());
            System.out.println("Product initial price: " + prod.getPrice());
            System.out.println("");
            //take the offer
            String offer = scanner.nextLine();
            
            //send the offer
            byte[] byteOffer = offer.getBytes();
            DatagramPacket packetSOffer = new DatagramPacket(byteOffer, byteOffer.length,
                InetAddress.getLocalHost(), 2000);
            mySocket.send(packetSOffer);
            
            
            //receives product
            byte[] received2 = new byte[1024];
            DatagramPacket datagramReceived2 = new DatagramPacket(received2,
                    received2.length);
            mySocket.receive(datagramReceived2);
            bis = new ByteArrayInputStream(received2);
            in = new ObjectInputStream(bis);
            prod = (Product) in.readObject();

            //Receive BuyerWinner
            byte[] received3 = new byte[1024];
            DatagramPacket datagramReceived3 = new DatagramPacket(received3,
                    received3.length);
            mySocket.receive(datagramReceived3);
            bis = new ByteArrayInputStream(received3);
            in = new ObjectInputStream(bis);
            Buyer buyerWinner = (Buyer) in.readObject();
            
            //Print final result
            System.out.println();
            System.out.println("Final price: " + prod.getPrice());
            System.out.println("Buyer's name: " + buyerWinner.getName());
            
        } catch (IOException e) {
            System.err.println("Error: " + e.getMessage());
        }
    }
}
