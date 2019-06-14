<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="Client_Site.Login" %>

<asp:ScriptManager id="sm" runat="server" >
	<Services>
		 <asp:ServiceReference Path="~/ChatService.asmx"/>
	</Services>
</asp:ScriptManager>


<script src="LoginScript.js" type="text/javascript"></script>
<link href="DefaulPage.css" rel="stylesheet" type="text/css" />

<h2>ورود</h2>

<table dir="rtl">
    <tr>
        <td>
            ایمیل :</td>
        <td>
            <input id="tbEmail" type="text" size="30" /></td>
    </tr>
    <tr>
        <td>
            کلمه عبور :</td>
        <td>
            <input id="tbPassword" type="password" size="30" /></td>
    </tr>
    <tr>
        <td style="height: 61px;">
            <input onclick="BinarySoftCo.ChatSystem.Login();" type="button" value="ورود" style="font-family:B zar,Tahoma; width: 70px; height: 24px;"/></td>
        <td class="style1">
            </td>
    </tr>
</table>

<script type="text/javascript">

    window.onload = function () {

        BinarySoftCo.ChatSystem.Init();

    }

</script>