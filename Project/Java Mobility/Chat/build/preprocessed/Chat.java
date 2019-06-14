/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

import javax.microedition.midlet.*;
import javax.microedition.lcdui.*;
import javax.microedition.io.Connection.*;
import java.io.*;
import javax.microedition.io.*;

/**
 * @author Omid
 */
public class Chat extends MIDlet implements CommandListener {

    private boolean midletPaused = false;

    //<editor-fold defaultstate="collapsed" desc=" Generated Fields ">//GEN-BEGIN:|fields|0|
    private Form form;
    private StringItem stringItem;
    private Command okCommand;
    private Command exitCommand;
    //</editor-fold>//GEN-END:|fields|0|

    /**
     * The Chat constructor.
     */
    public Chat() {
    }

    //<editor-fold defaultstate="collapsed" desc=" Generated Methods ">//GEN-BEGIN:|methods|0|
    //</editor-fold>//GEN-END:|methods|0|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: initialize ">//GEN-BEGIN:|0-initialize|0|0-preInitialize
    /**
     * Initilizes the application.
     * It is called only once when the MIDlet is started. The method is called before the <code>startMIDlet</code> method.
     */
    private void initialize() {//GEN-END:|0-initialize|0|0-preInitialize
        // write pre-initialize user code here
//GEN-LINE:|0-initialize|1|0-postInitialize
        // write post-initialize user code here
    }//GEN-BEGIN:|0-initialize|2|
    //</editor-fold>//GEN-END:|0-initialize|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: startMIDlet ">//GEN-BEGIN:|3-startMIDlet|0|3-preAction
    /**
     * Performs an action assigned to the Mobile Device - MIDlet Started point.
     */
    public void startMIDlet() {//GEN-END:|3-startMIDlet|0|3-preAction
        // write pre-action user code here
        switchDisplayable(null, getForm());//GEN-LINE:|3-startMIDlet|1|3-postAction
        // write post-action user code here
    }//GEN-BEGIN:|3-startMIDlet|2|
    //</editor-fold>//GEN-END:|3-startMIDlet|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: resumeMIDlet ">//GEN-BEGIN:|4-resumeMIDlet|0|4-preAction
    /**
     * Performs an action assigned to the Mobile Device - MIDlet Resumed point.
     */
    public void resumeMIDlet() {//GEN-END:|4-resumeMIDlet|0|4-preAction
        // write pre-action user code here
//GEN-LINE:|4-resumeMIDlet|1|4-postAction
        // write post-action user code here
    }//GEN-BEGIN:|4-resumeMIDlet|2|
    //</editor-fold>//GEN-END:|4-resumeMIDlet|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: switchDisplayable ">//GEN-BEGIN:|5-switchDisplayable|0|5-preSwitch
    /**
     * Switches a current displayable in a display. The <code>display</code> instance is taken from <code>getDisplay</code> method. This method is used by all actions in the design for switching displayable.
     * @param alert the Alert which is temporarily set to the display; if <code>null</code>, then <code>nextDisplayable</code> is set immediately
     * @param nextDisplayable the Displayable to be set
     */
    public void switchDisplayable(Alert alert, Displayable nextDisplayable) {//GEN-END:|5-switchDisplayable|0|5-preSwitch
        // write pre-switch user code here
        Display display = getDisplay();//GEN-BEGIN:|5-switchDisplayable|1|5-postSwitch
        if (alert == null) {
            display.setCurrent(nextDisplayable);
        } else {
            display.setCurrent(alert, nextDisplayable);
        }//GEN-END:|5-switchDisplayable|1|5-postSwitch
        // write post-switch user code here
    }//GEN-BEGIN:|5-switchDisplayable|2|
    //</editor-fold>//GEN-END:|5-switchDisplayable|2|

    //<editor-fold defaultstate="collapsed" desc=" Generated Method: commandAction for Displayables ">//GEN-BEGIN:|7-commandAction|0|7-preCommandAction
    /**
     * Called by a system to indicated that a command has been invoked on a particular displayable.
     * @param command the Command that was invoked
     * @param displayable the Displayable where the command was invoked
     */
    public void commandAction(Command command, Displayable displayable) {//GEN-END:|7-commandAction|0|7-preCommandAction
        // write pre-action user code here
        if (displayable == form) {//GEN-BEGIN:|7-commandAction|1|17-preAction
            if (command == exitCommand) {//GEN-END:|7-commandAction|1|17-preAction
                // write pre-action user code here
                exitMIDlet();//GEN-LINE:|7-commandAction|2|17-postAction
                // write post-action user code here
            } else if (command == okCommand) {//GEN-LINE:|7-commandAction|3|15-preAction
                // write pre-action user code here
//GEN-LINE:|7-commandAction|4|15-postAction
                // write post-action user code here
                try 
{
//testGET("http://google.com" );
testGET("http://94.183.159.245:81/bsco");
} catch (IOException e)
{
System.out.println("IOException " + e);
e.printStackTrace();
}
            }//GEN-BEGIN:|7-commandAction|5|7-postCommandAction
        }//GEN-END:|7-commandAction|5|7-postCommandAction
        // write post-action user code here
    }//GEN-BEGIN:|7-commandAction|6|
    //</editor-fold>//GEN-END:|7-commandAction|6|
void testGET(String url) throws IOException
    {

HttpConnection connection = null;
InputStream is = null;
OutputStream os = null;
StringBuffer stringBuffer = new StringBuffer();

try {

connection = (HttpConnection)Connector.open(url,Connector.READ_WRITE);

os = connection.openOutputStream();
is = connection.openDataInputStream();

int ch;
while ((ch = is.read()) != -1) {
stringBuffer.append((char)ch);
}

stringItem.setText(stringBuffer.toString());
} catch (Exception e) {

stringItem.setText(e.toString());


} finally {

if(is!= null) {
is.close();
}

if(os != null) {
os.close();
}

if(connection != null) {
connection.close();
}
}
}
//<editor-fold defaultstate="collapsed" desc=" Generated Getter: form ">//GEN-BEGIN:|13-getter|0|13-preInit
/**
 * Returns an initiliazed instance of form component.
 * @return the initialized component instance
 */
public Form getForm() {
    if (form == null) {//GEN-END:|13-getter|0|13-preInit
            // write pre-init user code here
        form = new Form("\u0686\u062A \u0622\u0646\u0644\u0627\u06CC\u0646", new Item[] { getStringItem() });//GEN-BEGIN:|13-getter|1|13-postInit
        form.addCommand(getOkCommand());
        form.addCommand(getExitCommand());
        form.setCommandListener(this);//GEN-END:|13-getter|1|13-postInit
            // write post-init user code here
    }//GEN-BEGIN:|13-getter|2|
    return form;
}
//</editor-fold>//GEN-END:|13-getter|2|

//<editor-fold defaultstate="collapsed" desc=" Generated Getter: okCommand ">//GEN-BEGIN:|14-getter|0|14-preInit
/**
 * Returns an initiliazed instance of okCommand component.
 * @return the initialized component instance
 */
public Command getOkCommand() {
    if (okCommand == null) {//GEN-END:|14-getter|0|14-preInit
            // write pre-init user code here
        okCommand = new Command("\u0627\u062A\u0635\u0627\u0644 \u0628\u0647 \u06AF\u0648\u06AF\u0644", Command.OK, 0);//GEN-LINE:|14-getter|1|14-postInit
            // write post-init user code here
    }//GEN-BEGIN:|14-getter|2|
    return okCommand;
}
//</editor-fold>//GEN-END:|14-getter|2|

//<editor-fold defaultstate="collapsed" desc=" Generated Getter: exitCommand ">//GEN-BEGIN:|16-getter|0|16-preInit
/**
 * Returns an initiliazed instance of exitCommand component.
 * @return the initialized component instance
 */
public Command getExitCommand() {
    if (exitCommand == null) {//GEN-END:|16-getter|0|16-preInit
            // write pre-init user code here
        exitCommand = new Command("\u062E\u0631\u0648\u062C", Command.EXIT, 0);//GEN-LINE:|16-getter|1|16-postInit
            // write post-init user code here
    }//GEN-BEGIN:|16-getter|2|
    return exitCommand;
}
//</editor-fold>//GEN-END:|16-getter|2|

//<editor-fold defaultstate="collapsed" desc=" Generated Getter: stringItem ">//GEN-BEGIN:|21-getter|0|21-preInit
/**
 * Returns an initiliazed instance of stringItem component.
 * @return the initialized component instance
 */
public StringItem getStringItem() {
    if (stringItem == null) {//GEN-END:|21-getter|0|21-preInit
        // write pre-init user code here
        stringItem = new StringItem("\u0627\u0637\u0644\u0627\u0639\u0627\u062A \u062F\u0631\u06CC\u0627\u0641\u062A\u06CC", null);//GEN-LINE:|21-getter|1|21-postInit
        // write post-init user code here
    }//GEN-BEGIN:|21-getter|2|
    return stringItem;
}
//</editor-fold>//GEN-END:|21-getter|2|

    /**
     * Returns a display instance.
     * @return the display instance.
     */
    public Display getDisplay () {
        return Display.getDisplay(this);
    }

    /**
     * Exits MIDlet.
     */
    public void exitMIDlet() {
        switchDisplayable (null, null);
        destroyApp(true);
        notifyDestroyed();
    }

    /**
     * Called when MIDlet is started.
     * Checks whether the MIDlet have been already started and initialize/starts or resumes the MIDlet.
     */
    public void startApp() {
        if (midletPaused) {
            resumeMIDlet ();
        } else {
            initialize ();
            startMIDlet ();
        }
        midletPaused = false;
    }

    /**
     * Called when MIDlet is paused.
     */
    public void pauseApp() {
        midletPaused = true;
    }

    /**
     * Called to signal the MIDlet to terminate.
     * @param unconditional if true, then the MIDlet has to be unconditionally terminated and all resources has to be released.
     */
    public void destroyApp(boolean unconditional) {
    }

}
