<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberList.ascx.cs" Inherits="BinarySoftCo.Client_Site.MemberList" %>

<asp:ScriptManager id="sm" runat="server" >
	<Services>
		 <asp:ServiceReference Path="~/ChatService.asmx"/>
	</Services>
</asp:ScriptManager>


<script src="MemberListScript.js" type="text/javascript"></script>

<link href="HomePage.css" rel="stylesheet" type="text/css" />

<div>

<div id="MemberList"></div>

</div>

<script type="text/javascript">

    window.onload = function () {

        BinarySoftCo.ChatSystem.Init();

    }

    window.onunload = function () {

        BinarySoftCo.ChatSystem.DisconncetFromServer();

    }
</script>