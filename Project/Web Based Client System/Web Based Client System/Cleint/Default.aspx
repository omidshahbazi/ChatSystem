<html>
	<head>
	
		<title>پارسیان چت</title>
		
		
		<style type="text/css" media="screen">
			.chat_time {
				font-style: italic;
				font-size: 9px;
			}
		    #bSend
            {
                font-family: Tahoma;
                height: 33px;
                width: 60px;
            }
		    #frmMain
            {
                width: 559px;
            }
		</style>
		
		
		<script language="JavaScript" type="text/javascript">

		    var receiveReq = getXmlHttpRequestObject();
		    var sendReq = getXmlHttpRequestObject();
		    var mTimer;
		    var PostClientPage = 'PostClientPage.aspx';
		    //
		    var FromMemberID = -1;
		    var ToMemberID = 3;
		    //
		    var flagToSendSignal = true;
		    
		    //Function for initializating the page.
		    function StartChat() {

		        alert(document.getElementById("frmMain").getElementsByTagName("input").item(0).attributes.item(0));

		        FromMemberID = 7586597;
		        //
		        receiveReq.open("GET", PostClientPage +
		            '?Type=2' +
		            '&FromMemberID=' + FromMemberID +
		            '&Username=Omid' +
		            '&Password=123', true);
		        //
		        receiveReq.onreadystatechange = HandleReceiveChat;
		        //
		        receiveReq.send(null);

		        
		    
		        //Set the focus to the Message Box.
		        document.getElementById('tbMessage').focus();
		        
		        //Start Recieving Messages.
		        GetNewCommands();
		    }
		    
		    //Gets the browser specific XmlHttpRequest Object
		    function getXmlHttpRequestObject() {

		        if (window.XMLHttpRequest) {
		        
		            return new XMLHttpRequest();
		        }
		        else if (window.ActiveXObject) {
		        
		            return new ActiveXObject("Microsoft.XMLHTTP");
		        }
		        else {
		        
		            document.getElementById('p_status').innerHTML = 'Status: Cound not create XmlHttpRequest Object.  Consider upgrading your browser.';
		        }
		    }

		    //Gets the current messages from the server
		    function GetNewCommands() {

		        receiveReq = getXmlHttpRequestObject();
		        //
		        if (receiveReq.readyState == 4 || receiveReq.readyState == 0) {

		            if (flagToSendSignal) {
		                //Send Client Signal
		                sendReq.open("POST",
		            PostClientPage +
		            '?Type=20' +
		            '&FromMemberID=' + FromMemberID, true);
		                //
		                sendReq.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
		                //
		                sendReq.send(null);
		                //
		                flagToSendSignal = false;
		            }
		            else
		                flagToSendSignal = true;
		            //
		            receiveReq.open("GET", 
		            PostClientPage +
		            '?Type=19' +
		            '&FromMemberID=' + FromMemberID, true);
		            //
		            receiveReq.onreadystatechange = HandleReceiveChat;
		            //
		            receiveReq.send(null);
		        }
		    }
		    
		    //Add a message to the chat server.
		    function SendChatText() {

		        if (document.getElementById('tbMessage').value == '') {
		        
		            return;
		        }

		        if (sendReq.readyState == 4 || sendReq.readyState == 0) {
		        
		            sendReq.open("POST", 
		            PostClientPage +
		            '?Type=1' +
		            '&FromMemberID=' + FromMemberID +
		            '&ToMemberID=' + ToMemberID +
		            '&Message=' + document.getElementById('tbMessage').value, true);
		            //
		            sendReq.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
		            //
		            sendReq.onreadystatechange = HandleSendChat;
		            //
		            sendReq.send(null);
		            //
		            AddToDiv_Chat(document.getElementById('tbMessage').value + " : من");
		            //
		            document.getElementById('tbMessage').value = '';
		        }
		    }
		    
		    //When our message has been sent, update our page.
		    function HandleSendChat() {
		    
		        //Clear out the existing timer so we don't have 
		        //multiple timer instances running.
		        clearInterval(mTimer);
		        //
		        GetNewCommands();
		    }
		    
		    //Function for handling the return of chat text
		    function HandleReceiveChat() {

		        if (receiveReq.readyState == 4) {

		            var xmldoc = receiveReq.responseXML;
		            var command_nodes = xmldoc.getElementsByTagName("Command");
		            //
		            for (i = 0; i < command_nodes.length; i++) {
		                
		                var Type_node = parseInt(command_nodes[i].getElementsByTagName("Type")[0].firstChild.nodeValue, null);
		                var FromMemberID_node = parseInt(command_nodes[i].getElementsByTagName("FromMemberID")[0].firstChild.nodeValue, null);
		                var Content_node = command_nodes[i].getElementsByTagName("Content")[0].firstChild.nodeValue;
		                var MetaData_node = command_nodes[i].getElementsByTagName("MetaData")[0].firstChild.nodeValue;
		                //
		                if (Type_node == 1) {
		                
		                    AddToDiv_Chat(FromMemberID + ' : ' + Content_node);
		                }
		                else if (Type_node == 4) {

		                alert("ورود موفق");
		                FromMemberID = parseInt(Content_node);
		                
		                }
		                else if (Type_node == 5) {

		                    alert("ورود ناموفق");
		                }
		            }
		            //
		            mTimer = setTimeout('GetNewCommands();', 2000); //Refresh our chat in 2 seconds
		        }
		    }

		    function AddToDiv_Chat(Content) {

		        var chat_div = document.getElementById('div_chat');
		        chat_div.innerHTML += '&nbsp;';
		        chat_div.innerHTML += Content + '<br />';
		        chat_div.scrollTop = chat_div.scrollHeight;
		    
		    }
		    
		    //This functions handles when the user presses enter.  Instead of submitting the form, we
		    //send a new message to the server and return false.
		    function BlockSubmit() {
		    
		        SendChatText();
		        return false;
		    }
		    
		    //This cleans out the database so we can start a new chat session.
//		    function resetChat() {
//		        if (sendReq.readyState == 4 || sendReq.readyState == 0) {
//		            sendReq.open("POST", PostClientPage + '?Type=19&FromMemberID=' + FromMemberID, true);
//		            sendReq.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
//		            sendReq.onreadystatechange = handleResetChat;
//		            //
//		            document.getElementById('tbMessage').value = '';
//		        }
//		    }
		    
		    //This function handles the response after the page has been refreshed.
//		    function handleResetChat() {
//		        document.getElementById('div_chat').innerHTML = '';
//		        GetNewCommands();
		    //		    }	

		</script>
		
	</head>
	
	<body onload="javascript:StartChat();" style="text-align: left">
	
		<h3 style="border-style: ridge; border-width: thin; text-align: center; font-family: Tahoma; width: 100%;">پارسیان چت</h3>
		
		<div id="div_chat" 
            
            
        
        
            
        style="height: 300px; width: 75%; overflow: auto; background-color: #CCCCCC; border: 1px solid #555555; font-family: Tahoma; font-size: small; text-align: right; top: 80px; left: 12%; position: absolute;">
			
		</div>
		
		<form id="frmMain" onsubmit="return BlockSubmit();" 
    style="position: absolute; top: 410px; left: 25%; height: 72px; width: 49%; text-align: center;">
			<br />
			
			<input type="text" id="tbMessage" name="tbMessage" 
                
                style="width: 82%; font-family: Tahoma; text-align: right; height: 44px; left: 10%; vertical-align: middle;" />
            <input type="button" name="bSend" id="bSend" value="ارسال" 
                onclick="javascript:SendChatText();" style="vertical-align: middle" />
					
			</form>
         
	</body>
	
</html>