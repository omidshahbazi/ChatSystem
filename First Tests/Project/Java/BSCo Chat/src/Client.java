



import java.io.*;

import javax.microedition.io.*;
import javax.microedition.lcdui.*;
import javax.microedition.midlet.*;


public class Client implements Runnable, CommandListener {
    private BSCoChat display;
    private Form f;
    private StringItem si;
    private TextField tf;
    private boolean stop;
    private Command sendCommand = new Command("ارسال", Command.ITEM, 1);
    private Command exitCommand = new Command("خروج", Command.EXIT, 1);
    InputStream is;
    OutputStream os;
    SocketConnection sc;

    public Client(BSCoChat m) {
        display = m;
        f = new Form("چت بایناری سافت");
        si = new StringItem("وضعیت:", " ");
        tf = new TextField("ارسال:", "", 10000, TextField.ANY);
        f.append(si);
        f.append(tf);
        f.addCommand(exitCommand);
        f.addCommand(sendCommand);
        f.setCommandListener(this);
        display.getDisplay().setCurrent(f);
    }

    /**
     * Start the client thread
     */
    public void start() {
        Thread t = new Thread(this);
        t.start();
    }

    public void run() {
        try {
            sc = (SocketConnection)Connector.open("socket://94.183.159.245:2324");
            si.setText("متصل به سرور");
            is = sc.openInputStream();
            os = sc.openOutputStream();

            // Loop forever, receiving data
            while (true) 
            {
                StringBuffer sb = new StringBuffer();
                int c = 0;

                while (((c = is.read()) != '\n') && (c != -1)) {
                    sb.append((char)c);
                }

                if (c == -1) {
                    break;
                }

                // Display message to user
                si.setText(sb.toString());
            }

            stop();
            si.setText("اتصال قطع شد");
            f.removeCommand(sendCommand);
        } catch (ConnectionNotFoundException cnfe) {
            Alert a = new Alert("Client", "Please run Server MIDlet first", null, AlertType.ERROR);
            a.setTimeout(Alert.FOREVER);
            a.setCommandListener(this);
            display.getDisplay().setCurrent(a);
        } catch (IOException ioe) {
            if (!stop) {
                ioe.printStackTrace();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    
    public void Send(byte[] bytes)
    {
        try
        {
            os.write(bytes);
            os.flush();
        } 
        catch (IOException ex) 
        {
            ex.printStackTrace();
        }
    }
    
//    public enum CommandType
//    {
//        Message
//    }
    
    public byte[] intTobytes(int value)
    {
        return new byte[] {
                (byte)(value >>> 24),
                (byte)(value >>> 16),
                (byte)(value >>> 8),
                (byte)value};
    }

    public void SendToServer() throws UnsupportedEncodingException
    {
        String s = "Message\u00b61\u00b6" + tf.getString();
//        String s="Message!192.168.238.2!" + tf.getString();
//        Send(intTobytes(s.length()));
        Send(s.getBytes("UTF8"));
        
//        Send(intTobytes("192.168.238.2".length()));
//        Send("192.168.238.2".getBytes());
//        
//        Send(intTobytes(4));
//        
//        
//        int i = tf.getString().length();
//        Send(intTobytes(i));
//        Send(tf.getString().getBytes());
        //
        
    }
    
    public void commandAction(Command c, Displayable s) 
    {
        if ((c == sendCommand)) 
        {
            tf.setString("سلام");
            try {
                SendToServer();
            } catch (UnsupportedEncodingException ex) {
                ex.printStackTrace();
            }
        }

        if ((c == Alert.DISMISS_COMMAND) || (c == exitCommand)) 
        {
            display.exitMIDlet();
        }
    }

    /**
     * Close all open streams
     */
    public void stop() {
        try {
            stop = true;

//            if (sender != null) {
//                sender.stop();
//            }

            if (is != null) {
                is.close();
            }

            if (os != null) {
                os.close();
            }

            if (sc != null) {
                sc.close();
            }
        } catch (IOException ioe) {
        }
    }
}
