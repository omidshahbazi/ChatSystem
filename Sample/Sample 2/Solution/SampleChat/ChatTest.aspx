<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChatTest.aspx.cs" Inherits="SampleChat.ChatTest" %>
<%@ Register TagPrefix="UC" Src="~/Chat/Controls/Chat.ascx" TagName="Chat" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
	<link href="/styles/chat.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<h1>Sample chat client</h1>
	<form id="Form1" runat="server" onsubmit="return false;">
		<UC:Chat ID="Chat1" runat="server" />
	</form>
</body>
</html>
