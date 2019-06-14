
import java.io.IOException;
import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.CommandListener;
import javax.microedition.lcdui.Displayable;
import javax.microedition.lcdui.Form;
import javax.microedition.lcdui.Image;
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
//        run();
        //
        base.SetCurrent(page);
    }

    public void Stop()
    {
        base.SetCurrent(null);
    }

    public void OnNewCommandRecieved(String Content)
    {
        if(Content.equals(CommandType.SignInSuccessful))
        {
            Stop();
            //
            base.trustUser = true;
            base.username = tfUsername.getString();
            base.password = tfPassword.getString();
            //
            base.ShowMain();
        }
        else if(Content.equals(CommandType.SignInFailed))
        {
            tfUsername.setString("");
            tfPassword.setString("");
            base.SetCurrentItem(tfUsername);
        }
    }
    
    public void run()
    {
        // Loop forever, receiving data
        while (true)
        {
            String response = "";
            //
            try
            {
                byte[] bytes = new byte[1000];
                base.client.is.read(bytes);
                //
                response = new String(bytes,"UTF-8").trim();
                //
                if(response.length() > 0)
                {
                    if(response.equals(CommandType.SignInSuccessful))
                    {
                        Stop();
                        //
                        base.trustUser = true;
                        base.username = tfUsername.getString();
                        base.password = tfPassword.getString();
                        //
                        base.ShowMain();
                    }
                    else if(response.equals(CommandType.SignInFailed))
                    {
                        tfUsername.setString("");
                        tfPassword.setString("");
                        base.SetCurrentItem(tfUsername);
                    }
                    //
                    response = "";
                }
            }
            catch (IOException e)
            {
                Stop();
            }
            catch (Exception e)
            {
                tfUsername.setString(e.toString());
            }
        }
    }

    public void commandAction(Command c, Displayable s)
    {
        if(c == cmdLogin)
        {
            tfUsername.setString("Omid");
            tfPassword.setString("123");
            //
            base.client.Send(
                    CommandType.SignIn +
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
