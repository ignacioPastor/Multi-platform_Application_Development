/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package auction_server;

import exercise5_unit4.Buyer;
import exercise5_unit4.Product;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadPoolExecutor;

/**
 * SPP - Exercise 5 - Unit 4
 * @author Ignacio Pastor Padilla
 */
class DataBuyer{
    InetAddress dataRemoteIp;
    int dataRemotePort;
    public DataBuyer(InetAddress dataRemoteIP, int dataRemotePort){
        this.dataRemoteIp = dataRemoteIP;
        this.dataRemotePort = dataRemotePort;
    }
    public void setDataRemoteIp(InetAddress dataRemoteIp){this.dataRemoteIp = dataRemoteIp;}
    public InetAddress getDataRemoteIp(){return dataRemoteIp;}
    public void setDataRemotePort(int dataRemotePort){this.dataRemotePort = dataRemotePort;}
    public int getDataRemotePort(){return dataRemotePort;}
}

public class Auction_Server {
    
    static Buyer winner = null;
    static HashMap<DataBuyer, Buyer> buyers;
    static Product prod;
    
    public static void main(String[] args) {
        
       int counter = 0;
       prod = new Product("Xbox", 100);
       buyers = new HashMap<>();
       
       try (DatagramSocket mySocket =
        new DatagramSocket(2000, InetAddress.getLocalHost()))
        {
            //Wait for 3 buyers connected
            while (buyers.size() < 3)
            {
                System.out.println("Waiting for " + (3 - buyers.size()) + " buyers.");
                byte[] received = new byte[1024];
                DatagramPacket datagramReceived = new DatagramPacket(received,
                    received.length);
                mySocket.receive(datagramReceived);
                Buyer b = new Buyer();
                InetAddress remoteIP = datagramReceived.getAddress();
                int remotePort = datagramReceived.getPort();
                DataBuyer data = new DataBuyer(remoteIP, remotePort);
                buyers.put(data, b);
                
            }
            //Send the product to the 3 buyers
            Iterator it = buyers.entrySet().iterator();
            while (it.hasNext()) {
                //Prepare for send a object
                ByteArrayOutputStream bs = new ByteArrayOutputStream();
                ObjectOutputStream objOut = new ObjectOutputStream(bs);
                objOut.writeObject(prod);
                // Get the byte array from the written
                byte[] bytes = bs.toByteArray();
                //Take buyer and his data
                Map.Entry<DataBuyer, Buyer> bu = (Map.Entry<DataBuyer, Buyer>) it.next();
                //Send the object
                DatagramPacket datagramSent = new DatagramPacket (bytes,
                    bytes.length, bu.getKey().getDataRemoteIp(), bu.getKey().getDataRemotePort());
                mySocket.send(datagramSent);
            }
            //Receives the name and the offer of the 3 buyers
            Buyer b3;
            while (counter < 3)
            {
                byte[] receivedPropuesta = new byte[1024];
                DatagramPacket datagramReceivedPropuesta = new DatagramPacket(receivedPropuesta,
                    receivedPropuesta.length);
                mySocket.receive(datagramReceivedPropuesta);
                counter++;
                String offer = new String(datagramReceivedPropuesta.getData()).trim();
                String[] offerSplit = offer.split(" ");
                
                InetAddress remoteIP = datagramReceivedPropuesta.getAddress();
                int remotePort = datagramReceivedPropuesta.getPort();
                DataBuyer data = new DataBuyer(remoteIP, remotePort);
                //showMap();
                //showData(data);
                b3 = asignateBuyer(data); //we identify the buyer by his port number
                b3.setName(offerSplit[0]);
                b3.setOffer(Integer.parseInt(offerSplit[1]));
                
                
            }
            //Choose the best offer
            selectBestOffer();
            
            //Send thee product with the final price an the name of winnerBuyer to the 3 buyers
            Iterator it2 = buyers.entrySet().iterator();
            while (it2.hasNext()) {
                //Prepare for send a object
                ByteArrayOutputStream bsProd = new ByteArrayOutputStream();
                ObjectOutputStream objOutProd = new ObjectOutputStream(bsProd);
                objOutProd.writeObject(prod);
                // Get the byte array from the written
                byte[] bytesProductSold = bsProd.toByteArray();
                //Take the buyer and his dades
                Map.Entry<DataBuyer, Buyer> bu = (Map.Entry<DataBuyer, Buyer>) it2.next();
                //Send the object
                DatagramPacket datagramSentProd = new DatagramPacket (bytesProductSold,
                    bytesProductSold.length, bu.getKey().getDataRemoteIp(), bu.getKey().getDataRemotePort());
                mySocket.send(datagramSentProd);
                
                ByteArrayOutputStream bsBuyerWinner = new ByteArrayOutputStream();
                ObjectOutputStream objOutBuyerWinner = new ObjectOutputStream(bsBuyerWinner);
                objOutBuyerWinner.writeObject(winner);
                // Get the byte array from the written
                byte[] buyerWiner = bsBuyerWinner.toByteArray();
                DatagramPacket datagramSent2 = new DatagramPacket (buyerWiner,
                    buyerWiner.length, bu.getKey().getDataRemoteIp(), bu.getKey().getDataRemotePort());
                mySocket.send(datagramSent2);
            }
        } catch (IOException e) {
            System.out.println(e);
        }
    }
    /**
     * Identify the winnerBuyer choosing the buyer with higher offer
     */
    private static void selectBestOffer() {
        Iterator it = buyers.entrySet().iterator();
        while (it.hasNext()) {
            Map.Entry<DataBuyer, Buyer> mapItem = (Map.Entry<DataBuyer, Buyer>) it.next();
            
            if(winner == null){
               winner = mapItem.getValue();
            }else if(winner.getOffer() < mapItem.getValue().getOffer()){
                winner = mapItem.getValue();
            }
            
        }
        prod.setPrice(winner.getOffer());
    }
    /**
     * To identify a buyer by his client-server relation we need look at his remotePort
     * @param d data of new client conection
     * @return the buyer who is communicating now
     */
    private static Buyer asignateBuyer(DataBuyer d){
        Iterator it = buyers.entrySet().iterator();
        boolean ip = false;
        boolean port = false;
        while (it.hasNext()) {
            Map.Entry<DataBuyer, Buyer> mapItem = (Map.Entry<DataBuyer, Buyer>) it.next();
            
            if(mapItem.getKey().getDataRemoteIp() == d.getDataRemoteIp())
                ip = true;
            if(mapItem.getKey().getDataRemotePort() == d.getDataRemotePort())
                port = true;
            System.out.println("Ip: " + ip + ", Port: " + port);
            if(port == true){
                //mapItem.getKey().setDataRemoteIp(d.getDataRemoteIp());
                return mapItem.getValue();
            }
        }
        System.err.println("Buyer not find!");
        return null;
    }
    private static void showMap(){
        Iterator it = buyers.entrySet().iterator();
        while (it.hasNext()) {
            Map.Entry<DataBuyer, Buyer> mapItem = (Map.Entry<DataBuyer, Buyer>) it.next();
            showBuyer(mapItem.getValue());
            showData(mapItem.getKey());
        }
    }
    private static void showData(DataBuyer d){
        System.out.println("    DataRemoteIP: " + d.getDataRemoteIp() + ", DataRemotePort: " + d.getDataRemotePort());
    }
    private static void showBuyer(Buyer b){
        System.out.println("BuyerName: " + b.getName() + ", BuyerOffer: " + b.getOffer());
    }
}
