
import javax.microedition.lcdui.*;
import javax.microedition.midlet.*;


public class Program extends MIDlet{

    public String username = "",
            password = "";
    public boolean trustUser = false;

    private boolean isPaused;

    public Client client = new Client();
    private LoginPage loginP = new LoginPage(this);
    private MainPage mainP = new MainPage(this);

    public Program()
    {
        if(client.Start())
        {
//            run();
            //
            ShowLogin();
        }
    }

    public void run()
    {
        try
        {
            // Loop forever, receiving data
            while (true)
            {
                String response = "";
                //
                int c = 0;
                //
                while (((c = client.is.read()) != '\n') && (c > -1))
                {
                    if(c != 0)
                        response += String.valueOf((char)c);
                    //
                    else if(c == 0 && response.length() > 0)
                    {
                        if(loginP != null)
                        {
                            loginP.OnNewCommandRecieved(response);
                        }
                        if(mainP != null)
                        {
                            mainP.OnNewCommandRecieved(response);
                        }
                    }
                }

                if (c == -1) {
                    break;
                }
            }
        }
        catch (Exception e)
        {

        }
    }

    public void ShowLogin()
    {
        loginP.Start();
    }

    public void ShowMain()
    {
        if(trustUser)
        {
            mainP.Start();
        }
    }

    public boolean isPaused()
    {
        return isPaused;
    }

    public void startApp()
    {
        isPaused = false;
    }

    public void pauseApp()
    {
        isPaused = true;
        //
        notifyPaused();
    }

    public void destroyApp(boolean unconditional)
    {
        if (loginP != null) {
            loginP.Stop();
        }

        if (mainP != null) {
            mainP.Stop();
        }
        //
        notifyDestroyed();
    }

    public void SetCurrent(Displayable current)
    {
        if(current != null)
        {
            Display.getDisplay(this).setCurrent(current);
        }
    }

    public void SetCurrentItem(Item current)
    {
        if(current != null)
        {
            Display.getDisplay(this).setCurrentItem(current);
        }
    }
}
