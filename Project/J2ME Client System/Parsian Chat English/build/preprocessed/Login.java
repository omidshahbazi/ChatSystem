


import javax.microedition.lcdui.*;

public class Login implements CommandListener
{
    private Form f;
    private TextField tfUsername, tfPassword;
    private Command loginCommand;
    private Command exitCommand;
    private BSCoChat base;
    private boolean ListenerRunnig = true;

    public Login(BSCoChat Base)
    {
        base = Base;
        //
        f = new Form(BSCoChat.ApplicationName);
        //
        tfUsername = new TextField("Username", "", 50, TextField.ANY);
        tfPassword = new TextField("Password", "", 50, TextField.PASSWORD);
        //
        loginCommand = new Command("Login", Command.SCREEN, 1);
        exitCommand = new Command("Exit", Command.EXIT, 1);
        //
        f.append(tfUsername);
        f.append(tfPassword);
        base.getDisplay().setCurrentItem(tfUsername);
        //
        f.addCommand(exitCommand);
        f.addCommand(loginCommand);
        f.setCommandListener(this);
        //
        base.switchDisplayable(null, f);
        //
        Listener();
    }

    public void Listener()
    {
        try
        {
            //Loop forever, receiving data
            while (true)
            {
                StringBuffer sb = new StringBuffer();

                int c = 0;

                while (((c = BSCoChat.client.Input.read()) != '\n') && (c > -1) && ListenerRunnig)
                {
                    // Display message to user
                    if(c != 0)
                        sb.append((char)c);
                    //are
                    if(c == 0 && sb.toString().length() > 0)
                    {
                        String resp = sb.toString();
                        //
                        sb = new StringBuffer();
                        //
                        if(Integer.parseInt(resp) == CommandType.LOGIN_SUCCESSFUL)
                        {
                            Stop();
                            //
                            BSCoChat.mainPgae = new Main(base);
                        }
                        else if(Integer.parseInt(resp) == CommandType.LIGIN_FAILED)
                        {
                            tfUsername.setString("");
                            tfPassword.setString("");
                            base.getDisplay().setCurrentItem(tfUsername);
                        }
                    }
                }

                if (c == -1)
                {
                    break;
                }
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public void Stop()
    {
        ListenerRunnig = false;
    }
    
    public void commandAction(Command c, Displayable s) 
    {
        if ((c == loginCommand)) 
        {
            if(tfUsername.getString().length() > 0 &&
               tfPassword.getString().length() > 0)
            {
//                tfUsername.setString(String.valueOf(CommandType.LOGIN_REQUEST) +
//                            String.valueOf(CommandType.SPLITER) +
//                            tfUsername.getString() +
//                            String.valueOf(CommandType.SPLITER) +
//                            tfPassword.getString());
                
                    BSCoChat.client.Send(String.valueOf(CommandType.LOGIN_REQUEST) +
                            String.valueOf(CommandType.SPLITER) +
                            tfUsername.getString() +
                            String.valueOf(CommandType.SPLITER) +
                            tfPassword.getString());
            }
        }

        if ((c == Alert.DISMISS_COMMAND) || (c == exitCommand)) 
        {
            new BSCoChat().exitMIDlet();
        }
    }
}
