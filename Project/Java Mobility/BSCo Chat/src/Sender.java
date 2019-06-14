

import javax.microedition.lcdui.*;

public class Sender implements CommandListener
{
    private int toMemberID;
    public Form f;
    private StringItem siRecieved;
    private TextField tfSend;
    private Command sendCommand;
    private Command exitCommand;
    private BSCoChat base;

    public Sender(BSCoChat Base, int ToMemberID, String ToMemberName)
    {
        base = Base;
        //
        toMemberID = ToMemberID;
        //
        f = new Form(BSCoChat.ApplicationName + " - " + ToMemberName);
        //
        base.switchDisplayable(null, f);
        //
        siRecieved = new StringItem("", "");
        //
        tfSend = new TextField("", "", 1000, TextField.ANY);
        //
        sendCommand = new Command("ارسال", Command.SCREEN, 1);
        exitCommand = new Command("خروج", Command.EXIT, 1);
        //
        f.append(siRecieved);
        f.append(tfSend);
        //
        f.addCommand(exitCommand);
        f.addCommand(sendCommand);
        f.setCommandListener(this);
    }

    public void OnNewMessageRecieved(String Content)
    {
        siRecieved.setText(siRecieved.getText() + Content + "\n");
    }
    
    public void commandAction(Command c, Displayable s) 
    {
        if (c == sendCommand) 
        {
            if(tfSend.getString().length() > 0)
            {
                String st = String.valueOf(CommandType.MESSEGE) + CommandType.SPLITER + String.valueOf(toMemberID) + CommandType.SPLITER  + tfSend.getString();
                //
                BSCoChat.client.Send(st);
                //
                tfSend.setString("");
            }
        }

        if ((c == Alert.DISMISS_COMMAND) || (c == exitCommand)) 
        {
            Main.sender = null;
            //
            BSCoChat.mainPgae = new Main(base);
            BSCoChat.mainPgae.Show();
        }
    }
}

