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
     private GUIb gui;

        public void startApp() throws MIDletStateChangeException {
           display = Display.getDisplay(this);
           if (display == null)
           {
               destroyApp(false); 
           }
          
        gui = new GUIb(this);
        display.setCurrent(gui);
        gui.start();
        }

    protected void destroyApp(boolean unconditional) throws MIDletStateChangeException {
        display.setCurrent(null);
    notifyDestroyed();
    }

    protected void pauseApp() {
        throw new UnsupportedOperationException("Not supported yet.");
    }
    }

