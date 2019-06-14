<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Client_Site._Default" %>
<%@ Register TagPrefix="UC" Src="Login.ascx" TagName="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>سیستم گفتگو</title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
    <h1>سیستم گفتگو</h1>
    
    <UC:Login ID="Login1" runat="server" />

    </div>
    </form>
</body>
</html>
