
import java.io.*;

import javax.microedition.io.*;


public class Client implements Runnable
{
    public InputStream is;
    private OutputStream os;
    private SocketConnection sc;
    public Sender sender;
    public boolean Connected;

    public Client()
    {
        
    }

    /**
     * Start the client thread
     */
    public boolean Start()
    {
        run();
//        Thread t = new Thread(this);
//        t.start();
        //
        return true;
    }

    private void OpenConnection()
    {
        try {
            sc = (SocketConnection) Connector.open("socket://omid.ddns.shatel.ir:2324");
            //
            Connected = true;
            //
            is = sc.openInputStream();
            os = sc.openOutputStream();
        } catch (IOException ex) {
            Connected = false;
        }
    }

    public void run()
    {
            OpenConnection();

            // Loop forever, receiving data
//            while (true)
//            {
//                int c = 0;
//            try {
//
//                while (((c = is.) != '\0') && (c != -1)) {
//                }
//            } catch (IOException ex) {
//                Connected=false;
//            }
//
//                OpenConnection();
//            }
//
//            Stop();
            //
    }

    public void Send(String Content)
    {
        try {
            os.write(Content.getBytes("UTF-8"));
            os.flush();
        } catch (IOException ex) {
            OpenConnection();
            Send(Content);
        }
    }

    /**
     * Close all open streams
     */
    public void Stop() {
        try {
            Connected = true;

            if (sender != null) {
                sender.Stop();
            }

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
