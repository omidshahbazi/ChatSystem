
import java.io.*;

import javax.microedition.io.*;
import javax.microedition.lcdui.*;



public class Client
{
    public boolean Connected;
    public InputStream Input;
    private OutputStream Output;
    private SocketConnection sc;

    public Client() 
    {
        Connect();
    }

    public void Connect()
    {
        try 
        {
            sc = (SocketConnection)Connector.open("socket://omid.ddns.shatel.ir:2324");
            //
            Connected = true;
            //
            Input = sc.openInputStream();
            Output = sc.openOutputStream();
        } 
        catch (ConnectionNotFoundException cnfe) 
        {
            Alert a = new Alert("Client", "Please run Server MIDlet first", null, AlertType.ERROR);
            a.setTimeout(Alert.FOREVER);
        }
        catch (IOException ioe) 
        {
            if (!Connected)
            {
                ioe.printStackTrace();
            }
        }
        catch (Exception e) 
        {
            e.printStackTrace();
            Disconnect();
        }
    }
    
    private void Send(byte[] bytes)
    {
        try
        {
            Output.write(bytes);
            Output.flush();
        } 
        catch (IOException ex) 
        {
            Disconnect();
            Connect();
        }
    }

    public void Send(String Content)
    {
        try
        {
            Send(Content.getBytes("UTF-8"));
        }
        catch (UnsupportedEncodingException ex)
        {
            ex.printStackTrace();
        }
    }

    public void Disconnect()
    {
        try 
        {
            Connected = false;
            //
            if (Input != null)
            {
                Input.close();
            }
            //
            if (Output != null)
            {
                Output.close();
            }
            //
            if (sc != null)
            {
                sc.close();
            }
        } 
        catch (IOException ioe)
        {
        }
    }
}
