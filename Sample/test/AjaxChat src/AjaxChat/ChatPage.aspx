<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChatPage.aspx.cs" Inherits="ChatPage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" >
<head id="Head1" runat="server">
    <title>Chat Ajax .NET</title>
    <style type="text/css">
    td {
        font-family: Arial;
        font-size: 8pt;
       }
    </style>
    <!--
    License and Disclaimer: All the intructions, code, html and everything presented with this solution is provided 'as is' with no warranties what so ever.
	The only condition for you to use this software is that you keep the link to http://www.spilafis.com.ar in the chat page as provided. Please support freeware keeping the link and clicking on my sponsors.
	Thank you!
    !-->
</head>
<body>

	<form id="form1" runat="server" onsubmit="return false;">
<br />
    <table align="center" width="732" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
        <textarea id="txtChatFrame" runat="server" rows="15" style="width:527px; border:1px solid #aaaaaa; padding:4px;" readonly="readonly"></textarea><br/>
        </td>
        <td valign="top">
            <div style="overflow: auto; height: 226px; border-top: solid 2px gray; border-bottom: solid 2px gray; border-right: solid 1px gray; border-left: solid 1px gray; ">
                <asp:GridView ID="grvUsers" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="1" ForeColor="Black"
                    GridLines="Vertical" Height="30px">
                    <FooterStyle BackColor="#CCCC99" />
                    <Columns>
                        <asp:BoundField HeaderText="User" ReadOnly="True" DataField="ChatUsers">
                            <ItemStyle Width="110px" />
                            <HeaderStyle Height="10px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Last Activity" DataField="ChatLastActivity">
                            <ItemStyle Width="190px" />
                            <HeaderStyle Height="10px" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <input id="btnRefresh" runat="server" type="submit" onclick="document.forms['form1'].submit();" value="Refresh" style="cursor:pointer;border:1px solid gray; height: 15px; width: 100%; font-size: 7pt;" size="20"/>
            </td>            
    </tr>
    <tr>
        <td>
        
        <table border="0" cellpadding="0" cellspacing="5" style="width:527px;">
        <tr>
            <td align="right" valign="middle">Message: </td>
            <td align="left" style="height: 45px" valign="top">
                <table border="0" cellpadding="0" cellspacing="2">
                <tr>
                    <td><textarea cols="70" rows="2" id="txtMssg" style="border:1px solid gray; width: 370px; height: 37px;" onkeyup="SendByKey(event.keyCode);"></textarea></td>
                    <td><input id="btnSend" type="button" value="Send" onclick="Send()" style="cursor:pointer;border:1px solid gray; height: 42px;"/></td>
                </tr>
                </table></td>  
        </tr>
        <tr>
            <td align="right" valign="middle" style="width:70px">User Name: </td>
            <td align="left">
                <table border="0" cellpadding="0" cellspacing="2">
                <tr>
                    <td><input id="txtName" type="text" maxlength="10" style="border:1px solid #aaaaaa; width: 145px;" onblur="ChangeUserName(this);"/ value="<%=SpilafisChatLogic.Chat.GetUserName()%>" />
                    </td>
                    <td>
                        &nbsp;&nbsp; Get source code!: <a href="http://www.spilafis.com.ar">http://www.spilafis.com.ar</a>
                    </td>
                </tr>
                </table>
            </td>  
        </tr>
        </table>

        </td>
        <td valign="middle">
            <br />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">Users Writing: &nbsp;&nbsp; <br />(max. <%=SpilafisChatLogic.Chat.MaxLoggedInUsers.ToString()%>) </td>
                    <td align="right"><span id="spnW">0</span> <br /><br /></td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;<br /></td>
                </tr>
                <tr>
                    <td align="left">Users Reading: &nbsp;&nbsp; </td>
                    <td align="right"><span id="spnR">0</span></td>
                </tr>
            </table>
        </td>
    </tr>
    </table>

    <br />
    
    <br />


<script type="text/javascript" language="javascript">

function ChangeUserName(otxtName)
{
    var tentative_name = otxtName.value;
    if(tentative_name=="")
        alert("You must enter a user name to be able to chat.");
    else
    {
        if(tentative_name!=last_user_name)
        {
            var otxtMssg = document.getElementById("txtMssg");
            var obtnSend = document.getElementById("btnSend");

            var ret = Chat.ChangeUserName(tentative_name);
            if(ret!=null && ret.error!=null && ret.error!="")
            {
                otxtName.value = last_user_name;
                alert(new String(ret.error).replace("System.Exception ",""));
            }
            else
            {
                last_user_name = otxtName.value;
                obtnSend.disabled = false;
                otxtMssg.disabled = false;
                otxtMssg.focus();
            }
        }
    }
}

function Send()
{
    var otxtName = document.getElementById("txtName");
    if(otxtName.value!="")
    {
        var otxtMssg = document.getElementById("txtMssg");
        if(!otxtMssg.disabled)
        {
            var ret = Chat.Post(otxtMssg.value);
            if(ret!=null && ret.error!=null)
            {
                alert(new String(ret.error).replace("System.Exception ",""));
            }
            otxtMssg.value = "";
            otxtMssg.focus();
        }
    }
    else
    {
        if(!otxtName.disabled)
        {
            alert("Enter a user name");
            otxtName.focus();
        }
    }
}

function SendByKey(keycode)
{
    if (keycode == 13)
        Send();
    event.returnValue = false;
}

var cycles = 20;
var add_wait_cycles = 20;
var reload_wait = 700;
var last_user_name = "";
var max_chat_lines = <%=SpilafisChatLogic.Chat.MaxChatLines%>;
function Reload()
{
    var ret;
    cycles++;;
    if(cycles>=add_wait_cycles)
    {
        cycles = 0;

        // Get users writing
        ret = Chat.GetUsersWriting();
        if(ret!=null && (ret.error==null || ret.error=="") && ret.value!=null && ret.value!="")
            document.getElementById("spnW").innerHTML = ret.value;

        // Get users reading
        ret = Chat.GetUsersReading();
        if(ret!=null && (ret.error==null || ret.error=="") && ret.value!=null && ret.value!="")
            document.getElementById("spnR").innerHTML = ret.value;
    }

    // If not logged in to write then try to logg in the user
    var otxtMssg = document.getElementById("txtMssg");
    if(otxtMssg.disabled)
    {
        var otxtName = document.getElementById("txtName");
        if(otxtName.value=="")
        {
            ret = Chat.GetNextUserName();
            if(ret!=null && ret.error==null && ret.value!=null && ret.value!="")
            {
                    otxtName.value = ret.value;
                    LoggedIn();
                    alert("You have been logged in");
            }
        }
        else
        {
            last_user_name = otxtName.value;
            otxtMssg.disabled = false;
            var obtnSend = document.getElementById("obtnSend");
            obtnSend.disabled = false;
            otxtMssg.focus();
        }
    }

    // Read Chat
    var ret = Chat.Read();
    if(ret!=null && ret.error!=null)
    {
        alert("A critical error ocurred: " + new String(ret.error).replace("System.Exception ","") + "\nPlease reload page to try again.");
        return;
    }
    var value = ret.value;
    if(value!=null && value!="")
    {
        var otxtChatFrame = document.getElementById("<%=txtChatFrame.ClientID%>");
        var already_read = otxtChatFrame.value;
        //var all = value + already_read;
        var all = already_read + value;
        if(all!="")
        {
            var arr = all.split("\n");
            if(arr.length>max_chat_lines)
            {
                all = "";
                //for(var i=0; i<max_chat_lines; i++)
                for(var i=(arr.length-max_chat_lines); i<arr.length; i++)
                    all += arr[i] + "\n";
            }
        }    
        otxtChatFrame.value = all;
        // Scroll down to the last read line
        otxtChatFrame.scrollTop=otxtChatFrame.scrollHeight;
    }

    window.setTimeout("Reload();", reload_wait);
}

function Start()
{
    Reload();

    // Initial scroll down to the last read line (in case Refresh is hit)
    var otxtChatFrame = document.getElementById("<%=txtChatFrame.ClientID%>");
    otxtChatFrame.scrollTop=otxtChatFrame.scrollHeight;
}

function LoggedIn()
{
    var otxtName = document.getElementById("txtName");
    var obtnSend = document.getElementById("btnSend");
    var otxtMssg = document.getElementById("txtMssg");
    last_user_name = otxtName.value;
    otxtName.disabled = false;
    obtnSend.disabled = false;
    otxtMssg.disabled = false;
    otxtMssg.focus();
}

// Call to start!
Start();
</script>


	
	</form>
	
</body>
</html>
