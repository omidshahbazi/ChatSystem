/*
 * GUI.java
 *
 * Created on December 21, 2009, 4:43 PM
 *
 * To change this template, choose Tools | Options and locate the template under
 * the Source Creation and Management node. Right-click the template and choose
 * Open. You can then make changes to the template in the Source Editor.
 */

/**
 *
 * @author TMOC 1
 */
import java.util.*;
import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;
import javax.microedition.media.*;
import javax.microedition.media.control.*;
import java.io.*;
import javax.microedition.io.*;
import javax.microedition.io.file.*; 
class GUI extends GameCanvas {  
    private Midlet midlet;    
    private Display display;   
    private Graphics g;  
    private Font font;    
    private int width = 0;   
    private int height = 0;        
    private Menu menu;   
    private String leftOption;   
    private String rightOption;  
    private String[] menuOptions;    
    
    private int currentlySelectedIndex = 0;   
    private boolean menuIsActive = false;
}

public class GUI {
    
    /** Creates a new instance of GUI */
    public GUI(Midlet midlet) {
     super(false);  
     this.midlet = midlet;   
     font = Font.getFont(Font.FACE_SYSTEM, Font.STYLE_PLAIN, Font.SIZE_SMALL);     
     setFullScreenMode(true);  
     width = getWidth();     
     height = getHeight();     
     g = getGraphics();  
     leftOption = "Options";      
     rightOption = "Exit";        
     menuOptions = new String[] {"Option #1", "Option #2", "Option #3", "Option #4"};    
     menu = new Menu(leftOption, rightOption, menuOptions);
    }
    public void start() 
    {  
        clearScreen();   
        menu.drawInactiveMenu(this, g);
    }
    private int LEFT_SOFTKEY_CODE = -6; 
    private int RIGHT_SOFTKEY_CODE = -7;
     protected void keyPressed(int keyCode) {    
              if (menuIsActive) { 
                  if (keyCode == RIGHT_SOFTKEY_CODE) {              
                      clearScreen();            
                      menu.drawInactiveMenu(this, g);        
                      menuIsActive = false;             }
              }
              keyCode = getGameAction(keyCode); 
              if (keyCode == UP) {       
               currentlySelectedIndex--;
               if (currentlySelectedIndex < 0) {
                   currentlySelectedIndex = 0;              
               }                 
               clearScreen();                
               menu.drawActiveMenu(this, g, currentlySelectedIndex);      }
               }
              }
 else if (keyCode == DOWN) {
     currentlySelectedIndex++;  
     if (currentlySelectedIndex >= menuOptions.length) { 
         currentlySelectedIndex = menuOptions.length - 1; 
     }                 clearScreen();               
     menu.drawActiveMenu(this, g, currentlySelectedIndex);          } 
 else if (keyCode == FIRE) {                           
     clearScreen();              
     g.setColor(0x000000);            
     g.drawString("[" + menuOptions[currentlySelectedIndex] + "] was selected", 10, 15, g.LEFT | g.TOP);
     menu.drawInactiveMenu(this, g);
     menuIsActive = false
  }   
 }
} 
  else {            
      if (keyCode == LEFT_SOFTKEY_CODE) { 
        clearScreen();
        currentlySelectedIndex = 0;
        menu.drawActiveMenu(this, g, currentlySelectedIndex); 
       menuIsActive = true;             } 
      else if (keyCode == RIGHT_SOFTKEY_CODE) {
          exitGUI();             } 
  }
     } 
         public void exitGUI() { 
             midlet.destroyApp(false); 
             midlet.notifyDestroyed();  
         } 
         public void clearScreen() {  
             g.setColor(0xffffff);  
             g.fillRect(0, 0, width, height);
             flushGraphics();     } 
 } 
 
   
    
}
