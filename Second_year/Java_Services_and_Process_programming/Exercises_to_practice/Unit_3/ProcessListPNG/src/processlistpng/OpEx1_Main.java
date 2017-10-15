/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package processlistpng;

import java.io.BufferedReader;
import java.io.InputStreamReader;

/**
 *
 * @author Ignacio
 */
public class OpEx1_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String path = "C:\\Users\\Ignacio\\Pictures";
        String line = "";
        ProcessBuilder pb = new ProcessBuilder("find *" );
//        Runtime rt = Runtime.getRuntime();
        try{
            Process p = pb.start();
//            Process p = rt.exec("dir " + path );
            BufferedReader br = new BufferedReader(new InputStreamReader(p.getInputStream()));
            System.out.println("Process output:");
            while((line = br.readLine()) != null){
                System.out.println(line);
            }
        }catch(Exception e){
            System.err.println("Error: " + e.getMessage());
        }
    }
    
}
