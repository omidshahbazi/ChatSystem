<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="BinarySoftCo.Client_Site.Chat" %>
<%@ Register TagPrefix="UC" Src="ChatBox.ascx" TagName="ChatBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>چت</title>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return false;">
    <div style="height:100%;">

    <div id="ChatBoxDIV">
    
    <UC:ChatBox ID="ChatBox1" runat="server" />

    </div>
    
    </div>
    </form>
</body>
</html>
