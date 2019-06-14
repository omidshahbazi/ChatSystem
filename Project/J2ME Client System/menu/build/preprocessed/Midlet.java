/*
 * Midlet.java
 *
 * Created on December 21, 2009, 4:20 PM
 */

import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;

/**
 *
 * @author  TMOC 1
 * @version
 */
public class Midlet extends MIDlet {
     private Display display;
     private GUI gui;
    public void startApp() {
        
        public void startApp() {
           display = Display.getDisplay(this);
           if (display == null)
           {
               destroyApp(false); 
           }
          }
        gui = new GUI(this);
        display.setCurrent(gui);
        gui.start();     }
    
    public void pauseApp() {
    }
    
    public void destroyApp(boolean unconditional) {
    display.setCurrent(null);
    notifyDestroyed();
    } 
    }
}
