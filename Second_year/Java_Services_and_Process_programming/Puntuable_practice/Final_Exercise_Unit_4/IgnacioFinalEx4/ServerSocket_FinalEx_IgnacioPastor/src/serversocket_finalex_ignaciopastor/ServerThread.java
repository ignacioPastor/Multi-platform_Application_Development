
package serversocket_finalex_ignaciopastor;

import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.net.URL;
import java.net.URLConnection;
import java.net.URLEncoder;
import libraryex4.Actor;

/**
 * Class for manage connections to the server
 * @author Ignacio Pastor Padilla
 */
public class ServerThread extends Thread{
    Socket service;
    String search = "";
    
    public ServerThread(Socket s){
        service = s;
    }
    @Override
    public void run(){
        DataInputStream socketIn = null;
        ObjectOutputStream objOut = null;
        BufferedReader bufInputFindActor = null;
        BufferedReader bufInputDataActor = null;
        Actor myActor = new Actor();
        try{
            socketIn = new DataInputStream(service.getInputStream());
            objOut = new ObjectOutputStream(service.getOutputStream());

            search = socketIn.readUTF();
            search = URLEncoder.encode(search, "UTF-8");
            
            URL imdb = new URL("http://www.imdb.com/find?q=" + search);
            URLConnection connFindActor = (URLConnection)imdb.openConnection();
            String charsetFindActor = getCharset(connFindActor.getHeaderField("Content-Type"));
            bufInputFindActor = new BufferedReader(new InputStreamReader(connFindActor.getInputStream(), charsetFindActor));
            String htmlFindActor = "";
            String lineFindActor;
            while((lineFindActor = bufInputFindActor.readLine()) != null)
                htmlFindActor += lineFindActor;
            String linkPartialActor = getLinkActor(htmlFindActor);
            //Actor not found
            if(linkPartialActor.equals("-1")){
                objOut.writeObject(myActor);
                System.out.println("No results have been found.");
            }else{
                URL dataActor = new URL("http://www.imdb.com" + linkPartialActor);
                URLConnection connDataActor = (URLConnection)dataActor.openConnection();
                String charsetDataActor = getCharset(connDataActor.getHeaderField("Content-Type"));
                bufInputDataActor = new BufferedReader(new InputStreamReader(connDataActor.getInputStream(), charsetDataActor));
                String respDataActor = "";
                String line;
                while((line = bufInputDataActor.readLine()) != null)
                    respDataActor += line;

                myActor.setName(getNameActor(respDataActor));
                myActor.setImgFile(getImageLink(respDataActor));
                myActor.setDescription(getDescription(respDataActor));
                myActor.setBirthDate(getBirthDate(respDataActor));
                objOut.writeObject(myActor);

                System.out.println(myActor.toString());
            }
            
                
        }catch(IOException e){
            System.err.println("Error: " + e.getMessage());
        }finally{
            try{
                if(objOut != null)
                    objOut.close();
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
    private String getCharset(String contentType){
        for(String param : contentType.replace(" ", "").split(";")){
            if(param.startsWith("charset=")){
                return param.split("=", 2)[1];
            }
        }
        return null;
    }
    /**
     * Get the part of the link specific of the actor
     * @param htmlCode htmlCode of web page
     * @return part of the link specific of the actor
     */
    private String getLinkActor(String htmlCode){
        int index = htmlCode.indexOf("class=\"findResult");
        if(index == -1)
            return "-1";
        index = htmlCode.indexOf("href=", index);
        int index2 = htmlCode.indexOf("\"", index+7);
        String link = htmlCode.substring(index + 6, index2);
        return link;
    }
    /**
     * Get the name of the actor in the actor biography web page
     * @param htmlCode biography actor web page
     * @return name of actor
     */
    private String getNameActor(String htmlCode){
        int index = htmlCode.indexOf("h1 class=\"header");
        index = htmlCode.indexOf("name", index);
        int index2 = htmlCode.indexOf("<",index);
        String name = htmlCode.substring(index + 6, index2);
        return name;
    }
    /**
     * Get the link of the actor's image
     * @param htmlCode biography actor web page
     * @return link of the actor's image
     */
    private String getImageLink(String htmlCode){
        int index = htmlCode.indexOf("name-poster");
        index = htmlCode.indexOf("src", index);
        int index2 = htmlCode.indexOf("\"",index + 8); //Not really necesary el +8
        String link = htmlCode.substring(index + 5, index2);
        return link;
    }
    /**
     * Get the description of the actor from biography actor web page
     * @param htmlCode biography actor web page
     * @return description of the actor
     */
    private String getDescription(String htmlCode){
        int index = htmlCode.indexOf("id=\"name-bio-text");
        index = htmlCode.indexOf("description", index);
        int index2 = htmlCode.indexOf("<",index);
        String description = htmlCode.substring(index + 13, index2);
        return description;
    }
    /**
     * Get the birth date of the actor from biography actor web page
     * @param htmlCode biography actor web page
     * @return birth date of the actor
     */
    private String getBirthDate(String htmlCode){
        int index = htmlCode.indexOf("Born");
        index = htmlCode.indexOf("datetime", index);
        int index2 = htmlCode.indexOf("\"",index + 13);
        String date = htmlCode.substring(index + 10, index2);
        return date;
    }
}
