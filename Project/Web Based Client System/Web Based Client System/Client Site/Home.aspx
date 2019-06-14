<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BinarySoftCo.Client_Site.Home" %>
<%@ Register TagPrefix="UC" Src="MemberList.ascx" TagName="MemberList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>سیستم گفتگو</title>
    <script src="HomeScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">

    <div id="MenuBar">
    
    <input id="bLogout" type="button" value="خروج" onclick="ChatSystem.Logout();" />
    
    </div>

    <div id="MemberListDIV">
    
    <UC:MemberList ID="MemberList1" runat="server" />

    </div>

    </form>
</body>
</html>
