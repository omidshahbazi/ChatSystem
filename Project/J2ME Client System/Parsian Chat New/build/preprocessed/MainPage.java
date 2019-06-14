
import java.io.IOException;
import javax.microedition.lcdui.ChoiceGroup;
import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.CommandListener;
import javax.microedition.lcdui.Displayable;
import javax.microedition.lcdui.Form;
import javax.microedition.lcdui.Image;
import javax.microedition.lcdui.List;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Administrator
 */
public class MainPage extends Thread implements CommandListener
{
    public static String Name = "پارسیان چت جدید";
    //
    ChoiceGroup cgFriends = new ChoiceGroup("دوستان", ChoiceGroup.EXCLUSIVE);
    //
    Form page = new Form(Name);
    Command cmdChat = new Command("چت", Command.OK, 0),
            cmdNewMember = new Command("جستجوی اعضا", Command.OK, 1),
            cmdChangePass = new Command("تغییر رمز", Command.OK, 2),
            cmdBackground = new Command("اجرا در پسزمینه", Command.OK, 3),
            cmdOfflines = new Command("پیغامهای دریافت شده", Command.OK, 4),
            cmdExit = new Command("خروج", Command.EXIT, 5);

    Program base;

    List lIDs = new List(null, List.EXCLUSIVE),
         lStatus = new List(null, List.EXCLUSIVE);

    public MainPage(Program Base)
    {
        page.setCommandListener(this);
        //
        page.addCommand(cmdChat);
        page.addCommand(cmdNewMember);
        page.addCommand(cmdChangePass);
        page.addCommand(cmdBackground);
        page.addCommand(cmdOfflines);
        page.addCommand(cmdExit);
        //
        page.append(cgFriends);
        //
        base = Base;
    }

    public void Start()
    {
        Thread td = new Thread(this);
        td.start();
        //
        RequestFriendsData();
        //
        base.SetCurrent(page);
    }

    public void OnNewCommandRecieved(String Content)
    {
        String[] str = SplitString(Content, '^');
        //
        if(str[0].equals(CommandType.GetRelatedMembersResponse))
        {
            try {
                Image status = Image.createImage("/Offline.png");
                //
                if (str[1].equals("1")) {
                    status = Image.createImage("/Online.png");
                }
                //
                lStatus.append(str[1], null);
                lIDs.append(str[2], null);
                cgFriends.append(str[3], status);
            } catch (IOException ex) {
                ex.printStackTrace();
            }
        }
    }

    private void RequestFriendsData()
    {
        cgFriends.deleteAll();
        base.client.Send(CommandType.GetRelatedMembers);
    }

    public void run()
    {
        // Loop forever, receiving data
        while (true)
        {
            String[] str=new String[0];
            String response = "";
            //
            try
            {
                byte[] bytes = new byte[10000];
                base.client.is.read(bytes);
                //
                response = new String(bytes, "UTF-8").trim();
                //
//                cgFriends.append(response, null);
                if(response.length() > 0)
                {
                    str = SplitString(response, '^');
                    //
                    if(str[0].trim().equals(CommandType.GetRelatedMembersResponse))
                    {
                        Image status = Image.createImage("/Offline.png");
                        //
                        if(str[1].equals("1")) status = Image.createImage("/Online.png");
                        //
                        lStatus.append(str[1], null);
                        lIDs.append(str[2], null);
                        cgFriends.append(str[3], status);
                    }
                    else if(str[0].trim().equals(CommandType.SignInFailed))
                    {

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
                cgFriends.append(response+" - " +str.length+" - "+ e.toString(), null);
            }
        }
    }

    public void Stop()
    {
        base.SetCurrent(null);
    }

    public void commandAction(Command c, Displayable s)
    {
        if(c == cmdChat)
        {
            RequestFriendsData();
        }

        else if(c == cmdNewMember)
        {

        }

        else if(c == cmdChangePass)
        {

        }

        else if(c == cmdBackground)
        {
            base.pauseApp();
        }

        else if(c == cmdOfflines)
        {

        }

        else if(c == cmdExit)
        {
            base.destroyApp(true);
        }
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
}
