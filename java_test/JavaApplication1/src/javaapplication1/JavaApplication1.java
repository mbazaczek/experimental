/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication1;
<<<<<<< HEAD
import java.io.IOException;
import java.lang.String;
=======

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;
>>>>>>> 9ba7fa8be8d045fe28ec28c149c18a78cb5f66b8

/**
 *
 * @author mbaza_000
 */
public class JavaApplication1
{

<<<<<<< HEAD
    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) throws IOException {
        // TODO code application logic here
        System.out.println("Hello World");
        String chujnia;
        System.in.read();
=======
    public static void main(String [] args)
    {
        // TODO code application logic here
        System.out.println("Hello World");
        try {
            System.in.read();
        } catch (IOException ex) {
            Logger.getLogger(JavaApplication1.class.getName()).log(Level.SEVERE, null, ex);
        }
>>>>>>> 9ba7fa8be8d045fe28ec28c149c18a78cb5f66b8
    }
}
