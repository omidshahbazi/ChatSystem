

import javax.microedition.lcdui.*;

public class Main implements CommandListener
{
    private List lContacts;
    private List lIDs;
    private Command chatCommand;
    private Command exitCommand;
    private BSCoChat base;
    private boolean ListenerRunnig = true;
    public static Sender sender;

    public Main(BSCoChat Base)
    {
        base = Base;
        //
        lIDs = new List("", List.IMPLICIT);
        lContacts = new List("Friends", List.IMPLICIT);
        //
        chatCommand = new Command("Chat", Command.SCREEN, 1);
        exitCommand = new Command("Exit", Command.EXIT, 1);
        //
        lContacts.addCommand(exitCommand);
        lContacts.addCommand(chatCommand);
        lContacts.setCommandListener(this);
        //
        LoadMembers();
        //
        Show();
        //
        Listener();
    }

    public void LoadMembers()
    {
        BSCoChat.client.Send(String.valueOf(CommandType.GET_RELATED_MEMBERS));
    }

    public void Show()
    {
        base.switchDisplayable(null, lContacts);
    }

    public void Listener()
    {
        try
        {
            //Loop forever, receiving data
            while (true)
            {
                String response = "";

                int c = 0;

                while (((c = BSCoChat.client.Input.read()) != '\n') && (c > -1) && ListenerRunnig)
                {
                    // Display message to user
                    if(c != 0)
                        response += String.valueOf((char)c);
                    //
                    if(c == 0 && response.length() > 0)
                    {
                        String[] str = SplitString(response, '^');
                        //
                        if(Integer.parseInt(str[0]) == CommandType.GET_RELATED_MEMBERS)
                        {
                            lIDs.append(str[1], null);
                            lContacts.append(str[2], null);
                        }
                        else if(Integer.parseInt(str[0]) == CommandType.MESSEGE)
                        {
                            if(sender == null)
                            {
                                int ID = Integer.parseInt(str[1]);
                                String name = "";
                                //
                                if(ID > -1)
                                {
                                    for(int i = 0; i < lIDs.size(); i++)
                                        if(ID == Integer.parseInt(lIDs.getString(i)))
                                            name = lContacts.getString(i);
                                }
                                else
                                {
                                    name = "Server";
                                }
                                //
                                sender = new Sender(base, ID, name);
                            }
                            //
                            sender.OnNewMessageRecieved(str[2]);
                        }
                        //
                        response = "";
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

    private String[] SplitString(String temp, char Spliter)
    {
        int count = 0;
        String st = temp;
        //
        while(st.length() > 0)
        {
            count++;
            int i = st.indexOf(Spliter);
            if (i == -1) break;
            st = st.substring(i + 1);
        }
        //
        String[] ret = new String[count];
        //
        int index = -1;
        while(temp.length() > 0)
        {
            int i = temp.indexOf(Spliter);
            if (i == -1)
            {
                ret[++index] = temp.substring(0);
                //
                break;
            }
            ret[++index] = temp.substring(0, i);
            temp = temp.substring(i);
            temp = temp.substring(1);
        }
        //
        return ret;
    }

    public void commandAction(Command c, Displayable s)
    {
        if (c == List.SELECT_COMMAND || c == chatCommand)
        {
            int ID = Integer.parseInt(lIDs.getString(lContacts.getSelectedIndex()));
            sender = new Sender(base, ID, lContacts.getString(lContacts.getSelectedIndex()));
        }

        if (c == Alert.DISMISS_COMMAND || c == exitCommand)
        {
            new BSCoChat().exitMIDlet();
        }
    }
}
