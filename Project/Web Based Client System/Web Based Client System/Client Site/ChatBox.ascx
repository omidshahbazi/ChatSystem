<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatBox.ascx.cs" Inherits="BinarySoftCo.Client_Site.ChatBox" %>

<asp:ScriptManager id="sm" runat="server" >
	<Services>
		 <asp:ServiceReference Path="~/ChatService.asmx"/>
	</Services>
</asp:ScriptManager>


<script src="ChatBoxScript.js" type="text/javascript"></script>

<link href="HomePage.css" rel="stylesheet" type="text/css" />

<div style="background-color: #E0EBEB;  width:100%;" 
    align="center">

    <div />
    <div id="ChatPanel" style="margin: 10px; height: 100%; background-color: #E1E1E1;">
   
	    <div id="ChatMessageDIV" style="height: 400px; overflow:auto;">

	    <div id="ChatBodyDIV" style="height: 100%">

        </div>
			
		</div>

	</div>

	<div id="chatFooter" style="margin: 10px; height: 30px; vertical-align: bottom;">

		<input type="text" id="tbMessage" onkeypress="BinarySoftCo.ChatSystem.CheckSend(event);" style="width: 90%; font-family: Tahoma;" />

		<input type="button" id="bSend" value="S" style="display:none;"  onclick="BinarySoftCo.ChatSystem.SendMessage();return false;" />

	</div>

</div>

<script type="text/javascript">

    window.onload = function () {

        BinarySoftCo.ChatSystem.Init();
    }

</script>