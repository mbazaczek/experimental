/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication1;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author mbaza_000
 */
public class JavaApplication1
{

    public static void main(String [] args)
    {
        // TODO code application logic here
        System.out.println("Hello World");
        try {
            System.in.read();
        } catch (IOException ex) {
            Logger.getLogger(JavaApplication1.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
