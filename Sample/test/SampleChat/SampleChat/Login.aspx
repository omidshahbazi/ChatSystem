<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="SampleChat.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="TextBox1" style="Z-INDEX: 100; LEFT: 364px; POSITION: absolute; TOP: 214px"
				runat="server" tabIndex="2"></asp:TextBox>
			<asp:Label id="Label2" style="Z-INDEX: 107; LEFT: 288px; POSITION: absolute; TOP: 213px" runat="server">UserName</asp:Label>
			<asp:TextBox id="TextBox2" style="Z-INDEX: 101; LEFT: 364px; POSITION: absolute; TOP: 181px"
				runat="server" tabIndex="1"></asp:TextBox>
			<asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 414px; POSITION: absolute; TOP: 267px" runat="server"
				Text="Button" tabIndex="3"></asp:Button>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" style="Z-INDEX: 103; LEFT: 535px; POSITION: absolute; TOP: 181px"
				runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" style="Z-INDEX: 104; LEFT: 535px; POSITION: absolute; TOP: 213px"
				runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
			<asp:Label id="Label1" style="Z-INDEX: 106; LEFT: 284px; POSITION: absolute; TOP: 179px" runat="server">UserID</asp:Label>
		</form>
	</body>
</HTML>
