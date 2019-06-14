
var ie=document.all;
var nn6=document.getElementById&&!document.all;
var isdrag=false;
var x,y,tx,ty;
var fobj;
//To Enable Drag and Drop of DIV
function movemouse(e)
{
  if (isdrag)
  {
    fobj.style.left = nn6 ? tx + e.clientX - x : tx + event.clientX - x;
    fobj.style.top  = nn6 ? ty + e.clientY - y : ty + event.clientY - y;
    return false;
  }
}

function selectmouse(e) 
{
  fobj = nn6 ? e.target : event.srcElement;
  if (fobj.parentElement.tagName!="DIV" && fobj.tagName=="DIV")
  {
		isdrag = true;
		tx = parseInt(fobj.style.left+0);
		ty = parseInt(fobj.style.top+0);
		x = nn6 ? e.clientX : event.clientX;
		y = nn6 ? e.clientY : event.clientY;
		document.onmousemove=movemouse;
		return false;
  }
}
document.onmousedown=selectmouse;
document.onmouseup=new Function("isdrag=false");

//StringBuggerLikeClase
 function StringBuffer() { 
   this.buffer = []; 
 } 

 StringBuffer.prototype.append = function append(string) { 
   this.buffer.push(string); 
   return this; 
 }; 

 StringBuffer.prototype.toString = function toString() { 
   return this.buffer.join(""); 
 }; 
	//To Get room Datas on Specific Intervals
	function GetRoomDatas()
	{
		var PublicRoom=document.getElementById("Public_Rooms");
		var Rooms=PublicRoom.getElementsByTagName("DIV");
		var PrivateRooms=document.getElementById("Private_Rooms");
		PrivateRooms=PrivateRooms.getElementsByTagName("DIV");
		var UserTableCollection=document.getElementById("Users");
		var Roomsopened=new StringBuffer();
		for(var i=0;i<Rooms.length;i++)
		{
			var ChatRoom=document.getElementById("div_"+Rooms[i].id);
			if(ChatRoom!=null)
			{
				Roomsopened.append(Rooms[i].id);
				Roomsopened.append(",");;
			}
		}
		for(var i=0;i<PrivateRooms.length;i++)
		{
			var ChatRoom=document.getElementById("div_"+PrivateRooms[i].id);
			if(ChatRoom!=null)
			{
				Roomsopened.append(PrivateRooms[i].id);
				Roomsopened.append(",");
			}
		}
		var val=Chat.getMessageHash(Roomsopened.toString());
		if(val.value==null)
		{
			return ;
		}
		for(var i=0;i<val.value.length;i++)
		{
			//forUpdatingUserList
			if( val.value[i].Key=="-TotUsers-")
				{
					UserTableCollection.innerHTML=val.value[i].Value;
				}
				
			else if( val.value[i].Key=="-PrivateRooms-")
				{
					document.getElementById("Private_Rooms").innerHTML=val.value[i].Value;
				}
			else
				{
					var ChatRoom=document.getElementById("div_"+val.value[i].Key);
					if(ChatRoom!=null)
					{
						var InnerHtml=new StringBuffer();
						for (var j=0;j<val.value[i].Value.length;j++)
							{
								InnerHtml.append(val.value[i].Value[j].Message);
								InnerHtml.append("\n");
							}
						ChatRoom.children(messageDIVno).innerText=InnerHtml.toString();
						ChatRoom.scrollIntoView(false);
					}
				}
		}
	}
	
	//To Create A Room Based On Room DoubleClick
		function CreateDiv(DivID,Roomid)
			{
				ParentElement=document.getElementById("TRCHAT");
				var Divelement=document.createElement("DIV");
				Divelement.align="right";
				Divelement.setAttribute('id',DivID);
				Divelement.setAttribute('name',DivID);
				Divelement.style.width=250;
				Divelement.style.height=300;
				Divelement.style.left=200;
				Divelement.style.top=170;
				Divelement.style.position='absolute';
				Divelement.style.background='#9fc9d3';
				Divelement.style.cursor='Move';
			    ParentElement.appendChild(Divelement);
			
				//To Add a Room Heading
				var minimbutton=document.createElement('SPAN');
				minimbutton.setAttribute('id',DivID+'SPAN');
				minimbutton.innerText=Roomid+"\t\t";
				minimbutton.style.Align='left';
				Divelement.appendChild(minimbutton);
				
				//To Add a Close Button
				var closebutton=document.createElement('a');
				closebutton.setAttribute('id',DivID+'close');
				closebutton.setAttribute('align','right');
				closebutton.onclick=clos;
				closebutton.innerText='X';
				closebutton.style.cursor='hand';
				closebutton.style.Align='right';
				Divelement.appendChild(closebutton);
				Divelement.appendChild(document.createElement("br"));
				Divelement.appendChild(document.createElement("br"));
			
				//To Add a  TEXTAREA for Chat
				var DivMessages=document.createElement('TEXTAREA');
				DivMessages.setAttribute('className','TEXTAREA.ro');
				DivMessages.style.width=Divelement.style.width;
				DivMessages.style.height=parseInt(Divelement.style.height)-50;
				DivMessages.setAttribute('id',DivID+'TXTAREA');
				DivMessages.setAttribute('readOnly','true');
				Divelement.appendChild(DivMessages);
				
				//To Add a  TextBox
				var txtbutton=document.createElement('input');
				txtbutton.setAttribute('id',DivID+'txt');
				txtbutton.setAttribute('type','text');
				txtbutton.setAttribute('className','CustomTextbox');
				txtbutton.style.width=200;
				txtbutton.tabindex=0;
				Divelement.appendChild(txtbutton);
				
				//To Add a send Button
				var Postbutton=document.createElement('input');
				Postbutton.setAttribute('id',DivID+'send');
				Postbutton.setAttribute('type','submit');
				Postbutton.setAttribute('value','Post');
				Postbutton.setAttribute('className','normalbutton');
				Postbutton.tabindex=0;
				Postbutton.onclick= PostData;
				Divelement.appendChild(Postbutton);
			}
			function PostData(e)
			{
				obj= nn6 ? e.target : event.srcElement;
				var parentdiv=obj.parentNode;
				var message=parentdiv.childNodes[txtboxNo].value;
				parentdiv.childNodes[txtboxNo].value='';
				var RoomID=parentdiv.id;
				RoomID=RoomID.split("_");
				var Val=Chat.PostMessage(RoomID[1],message);
				parentdiv.childNodes[messageDIVno].innerText+="\n"+Val.value;
				return false;
			}
			setInterval(GetRoomDatas,6000);



