/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package readerswriterslock;

/**
 *
 * @author Ignacio
 */
public class Ex10_Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        MyData mds = new MyData(10);
        ReadingThread[] threadsR = new ReadingThread[10];
        WritingThread[] threadsW = new WritingThread[2];
        
        for (int i = 0; i < threadsW.length; i++) {
            threadsW[i] = new WritingThread(mds);
//            threadsW[i].setDaemon(true);
        }
        for (int i = 0; i < threadsR.length; i++) {
            threadsR[i] = new ReadingThread(mds);
        }
        
        
        for (int i = 0; i < threadsR.length; i++) {
            threadsR[i].start();
        }
        for (int i = 0; i < threadsW.length; i++) {
            threadsW[i].start();
        }
        
//        
//        for (WritingThread threadsW1 : threadsW) {
//            threadsW1.start();
//        }
//        for(ReadingThread r : threadsR){
//            r.start();
//        }
        
    }
    
}
