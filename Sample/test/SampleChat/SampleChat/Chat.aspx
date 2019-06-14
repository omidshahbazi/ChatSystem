<%@ Page language="c#" Codebehind="Chat.aspx.cs" AutoEventWireup="false" Inherits="SampleChat.Chat" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>WebForm1</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
<STYLE type=text/css>BODY {
	SCROLLBAR-FACE-COLOR: #eaeaea; SCROLLBAR-HIGHLIGHT-COLOR: #eaeaea; SCROLLBAR-SHADOW-COLOR: #eaeaea; SCROLLBAR-3DLIGHT-COLOR: #eaeaea; SCROLLBAR-ARROW-COLOR: #666666; SCROLLBAR-TRACK-COLOR: #f7f7f7; SCROLLBAR-DARKSHADOW-COLOR: #697074
}
</STYLE>

<style>.skin0 {
	BORDER-RIGHT: black 2px solid; BORDER-TOP: black 2px solid; FONT-SIZE: 14px; Z-INDEX: 100; VISIBILITY: hidden; BORDER-LEFT: black 2px solid; WIDTH: 165px; CURSOR: default; LINE-HEIGHT: 20px; BORDER-BOTTOM: black 2px solid; FONT-FAMILY: Verdana; POSITION: absolute; BACKGROUND-COLOR: menu
}
.menuitems {
	PADDING-RIGHT: 10px; PADDING-LEFT: 10px
}
</style>

<script src="DragAndPost.js"></script>

<script>
			var txtboxNo=5;
			var messageDIVno=4;
			function clos(e)
			{
				obj= nn6 ? e.target : event.srcElement;
				parentDIV=obj.parentNode;
				document.getElementById("TRCHAT").removeChild(parentDIV);
			}
			function addChatRoom(obj)
			{
				if(!document.getElementById("div_"+obj.id))
				CreateDiv("div_"+obj.id,obj.innerText);
			}
			
		</script>
</HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Form1 onsubmit="return false;" method=post 
runat="server">
<table id=tblParent height="100%" width="100%" border=1>
  <tr>
    <td id=TRROOMS vAlign=top width="20%" 
      runat="server"><span><b>Public 
      Rooms</B></SPAN> 
      <div id=Public_Rooms runat="server" 
      name="Public_Rooms"></DIV><span><b 
      >Private Rooms</B></SPAN> 
      <div id=Private_Rooms runat="server" 
      name="Private_Rooms"></DIV></TD>
    <td id=TRCHAT width="60%" runat="server"></TD>
    <td id=TRUSERS vAlign=top width="20%" 
      runat="server"><span><b 
      >Users</B></SPAN>&nbsp; 
      <div id=Users 
runat="server"></DIV></TD></TR></TABLE>
<div class=skin0 id=ie5menu onmouseover=highlightie5(event) style="Z-INDEX: 100" 
onclick=jumptoie5(event) onmouseout=lowlightie5(event) 
display:none>
<div class=menuitems id=ADD>Add Private Room</DIV>
<div class=menuitems id=DELETE>Delete Private Room</DIV>
<div class=menuitems id=ADDUSER>Invite User to 
Room</DIV></DIV>
<script>
var ie5=document.all&&document.getElementById;
var ns6=document.getElementById&&!document.all
if (ie5||ns6)
var menuobj=document.getElementById("ie5menu");
var PrivateRoomID='';
function showmenuie5(e)
{
	window.event.cancelBubble = true;
	var firingobj=ie5? event.srcElement : e.target;
	var Actualobj=firingobj;
	var j=0;
	var show=false;
	while(j<5)
	{
		if(firingobj.id=="TRROOMS")
		{
			show=true;
			break;
		}
		firingobj=firingobj.parentNode;
		j++;
	}
if(show==true&&firingobj.id=="TRROOMS")
{
	if(Actualobj.parentNode.id=="Private_Rooms")
	{
		menuobj.childNodes(2).style.visibility="visible";
		PrivateRoomID=Actualobj.id;
	}
	else
	{
		menuobj.childNodes(2).style.visibility="hidden";
	}
	
	var rightedge=ie5? document.body.clientWidth-event.clientX : window.innerWidth-e.clientX
	var bottomedge=ie5? document.body.clientHeight-event.clientY : window.innerHeight-e.clientY
	if (rightedge<menuobj.offsetWidth)
	menuobj.style.left=ie5? document.body.scrollLeft+event.clientX-menuobj.offsetWidth : window.pageXOffset+e.clientX-menuobj.offsetWidth
	else
	menuobj.style.left=ie5? document.body.scrollLeft+event.clientX : window.pageXOffset+e.clientX
	if (bottomedge<menuobj.offsetHeight)
	menuobj.style.top=ie5? document.body.scrollTop+event.clientY-menuobj.offsetHeight : window.pageYOffset+e.clientY-menuobj.offsetHeight
	else
	menuobj.style.top=ie5? document.body.scrollTop+event.clientY : window.pageYOffset+e.clientY
	menuobj.style.visibility="visible";
}

return false;
}

function hidemenuie5(e)
{
	menuobj.style.visibility="hidden";
}

function highlightie5(e)
{
	var firingobj=ie5? event.srcElement : e.target;
	if (firingobj.className=="menuitems"||ns6&&firingobj.parentNode.className=="menuitems")
	{
		if (ns6&&firingobj.parentNode.className=="menuitems")
		{
			firingobj=firingobj.parentNode; //up one node
		}
	firingobj.style.backgroundColor="highlight"
	firingobj.style.color="white"
	}
}

function lowlightie5(e)
{
	var firingobj=ie5? event.srcElement : e.target
	if (firingobj.className=="menuitems"||ns6&&firingobj.parentNode.className=="menuitems")
	{
		if (ns6&&firingobj.parentNode.className=="menuitems")
		{
			firingobj=firingobj.parentNode; //up one node
		}
		firingobj.style.backgroundColor=""
		firingobj.style.color="black"
	}
}

function jumptoie5(e)
{
	var firingobj=ie5? event.srcElement : e.target;
	if (firingobj.className=="menuitems"||ns6&&firingobj.parentNode.className=="menuitems")
	{
		if (ns6&&firingobj.parentNode.className=="menuitems")
		{
			firingobj=firingobj.parentNode;
		}
		if(firingobj.id=="ADD")
		{
			var Roomid= prompt("Enter The Room Name");
			var PrivateRooms=document.getElementById("Private_Rooms");
			if(PrivateRooms!=null&&Roomid!=null)
			{
				var val=Chat.CreatePrivateRooms(Roomid);
				if(val.value!=null)
				{
					PrivateRooms.innerHTML+=val.value;
				}
				else
				{
					alert("Try Choosing Another Name");
				}
			}	
		}
		else if(firingobj.id=="DELETE")
		{
		}
		else if(firingobj.id=="ADDUSER")
		{
			var Userid= prompt("Enter The User ID");
			Chat.AddUsersPrivateRooms(PrivateRoomID,Userid);
			PrivateRoomID='';
		}
	}
}
if (ie5||ns6)
{
	menuobj.style.display='';
	document.oncontextmenu=showmenuie5;
	document.onclick=hidemenuie5;
}

			</script>
</FORM>
	</body>
</HTML>
