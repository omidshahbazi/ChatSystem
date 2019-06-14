<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BinarySoftCo.Parsian_Chat_Admin._Login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>مدیریت - پارسیان چت</title>
    <style type="text/css">
        .style1
        {
            width: 385px;
        }
        .style2
        {
            color: #FFFFFF;
            text-align: right;
            font-family: Tahoma;
        }
        .style3
        {
            color: #FFFFFF;
            text-align: right;
            font-family: Tahoma;
            width: 117px;
        }
    </style>
    </head>
<body bgcolor="#000000">
    <form id="login" runat="server">
    <div>
    
    <hr />
    <hr />
    <hr />
    
        <table align="center" class="style1">
            <tr>
                <td class="style2">
                    <asp:TextBox ID="tbUsername" Width="120 px" Font-Names="Tahoma" runat="server">
                    </asp:TextBox></td>
                <td class="style3">
                    نام کاربری</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:TextBox ID="tbPassword" Width="120 px" Font-Names="Tahoma" TextMode="Password" runat="server">
                    </asp:TextBox></td>
                <td class="style3">
                    کلمه عبور</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:TextBox ID="tbGraphicalText" Width="80 px" Font-Names="Tahoma" runat="server">
                    </asp:TextBox></td>
                <td class="style3">
                <asp:Image ID="iGraphText" runat="server" /> </td>
            </tr>
            <tr>
                <td class="style2">
                <asp:Button ID="bLogin" OnClick="bLogin_Click" Width="80 px" Text="ورود" runat="server" /></td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
        </table>
    
    
    <hr />
    <hr />
    <hr />
    
    </div>
    </form>
    </body>
</html>
