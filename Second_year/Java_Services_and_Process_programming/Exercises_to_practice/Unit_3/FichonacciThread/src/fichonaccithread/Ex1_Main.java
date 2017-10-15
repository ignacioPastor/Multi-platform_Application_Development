/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fichonaccithread;

import java.util.Scanner;

/**
 *
 * @author Ignacio
 */
public class Ex1_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int n;
        Scanner scanner = new Scanner(System.in);
        System.out.println("Type until which number do you wants see of Fibonacci's sequence");
        try{
            n = Integer.parseInt(scanner.nextLine());
            Thread t = new MyThread(n);
            t.start();
        }catch(Exception e){
            System.err.println("Error: " + e.getMessage());
        }
        
    }
    
}
