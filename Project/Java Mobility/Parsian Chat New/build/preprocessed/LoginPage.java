
import java.io.IOException;
import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.CommandListener;
import javax.microedition.lcdui.Displayable;
import javax.microedition.lcdui.Form;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.ImageItem;
import javax.microedition.lcdui.TextField;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Administrator
 */
public class LoginPage extends Thread implements CommandListener
{
    Form page = new Form("ورود کاربر");

    Command cmdLogin = new Command("ورود", Command.OK, 0),
            cmdExit = new Command("خروج", Command.EXIT, 1);

    TextField tfUsername = new TextField("نام کاربری", null, 20, TextField.ANY),
              tfPassword = new TextField("کلمه عبور", null, 20, TextField.PASSWORD);

    Program base;

    public LoginPage(Program Base)
    {
        page.setCommandListener(this);
        //
        try {
            page.append(Image.createImage("/Background.jpg"));
        } catch (IOException ex) {
            ex.printStackTrace();
        }
        //
        page.append(tfUsername);
        page.append(tfPassword);
        //
        page.addCommand(cmdLogin);
        page.addCommand(cmdExit);
        //
        base = Base;
    }

    public void Start()
    {
        Thread td = new Thread(this);
        td.start();
//        Listener();
        //
        base.SetCurrent(page);
    }

    public void Stop()
    {
        base.SetCurrent(null);
    }

    public void OnNewCommandRecieved(String Content)
    {
        if(Content.equals(CommandType.LOGIN_SUCCESSFUL))
        {
            Stop();
            //
            base.trustUser = true;
            base.username = tfUsername.getString();
            base.password = tfPassword.getString();
            //
            base.ShowMain();
        }
        else if(Content.equals(CommandType.LOGIN_FAILED))
        {
            tfUsername.setString("");
            tfPassword.setString("");
            base.SetCurrentItem(tfUsername);
        }
    }
    
    public void run()
    {
        try
        {
            // Loop forever, receiving data
            while (true)
            {
                StringBuffer sb = new StringBuffer();
                int c = 0;
                //
                while (((c = base.client.is.read()) != '\n') && (c > -1))
                {
                    if(c != 0)
                        sb.append((char)c);
                    
                    else if(c == 0 && sb.toString().length() > 0)
                    {
                        String st = sb.toString();
                        //
                        sb = new StringBuffer();
                        //
                        if(st.equals(CommandType.LOGIN_SUCCESSFUL))
                        {
                            Stop();
                            //
                            base.trustUser = true;
                            base.username = tfUsername.getString();
                            base.password = tfPassword.getString();
                            //
                            base.ShowMain();
                        }
                        else if(st.equals(CommandType.LOGIN_FAILED))
                        {
                            tfUsername.setString("");
                            tfPassword.setString("");
                            base.SetCurrentItem(tfUsername);
                        }
                    }
                }

                if (c == -1) {
                    break;
                }
            }

            Stop();
        }
        catch (Exception e)
        {
tfUsername.setString(e.toString());
        }
    }

    public void commandAction(Command c, Displayable s)
    {
        if(c == cmdLogin)
        {
//            tfUsername.setString("Omid");
//            tfPassword.setString("123");
            //
            base.client.Send(
                    CommandType.LOGIN_REQUEST +
                    CommandType.SPLITER +
                    tfUsername.getString() +
                    CommandType.SPLITER +
                    tfPassword.getString());
        }

        else if(c == cmdExit)
        {
            base.destroyApp(true);
        }
    }
}
