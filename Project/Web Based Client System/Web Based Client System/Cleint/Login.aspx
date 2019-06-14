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
            }
		    #frmMain
            {
                width: 507px;
                font-family: Tahoma;
            }
		    .style1
            {
                width: 94%;
            }
            .style2
            {
                width: 88px;
                text-align: right;
            }
            .style3
            {
                text-align: center;
            }
            #bLogin
            {
                font-family: Tahoma;
                width: 63px;
            }
		</style>
		
		
		<script language="JavaScript" type="text/javascript">

		    var receiveReq = getXmlHttpRequestObject();
		    var mTimer;
		    var PostClientPage = 'PostClientPage.aspx';
		    var FromMemberID;
		    
		    //Function for initializating the page.
		    function StartChat() {

		        FromMemberID = Math.round(Math.random() * 7586597);

		        //Set the focus to the Message Box.
		        document.getElementById('tbUsername').focus();
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
		        
		            try {
		            
                        return new ActiveXObject('Msxml2.XMLHTTP');
                        
                    } catch(e) {
                    
                        try {
                        
		                    return new ActiveXObject("Microsoft.XMLHTTP");
                            
                        } catch(e) {
                      
                        }
                    }

//		            document.getElementById('p_status').innerHTML = 'Status: Cound not create XmlHttpRequest Object.  Consider upgrading your browser.';
		        }
		    }

		    //Gets the current messages from the server
		    function SendLoginInfo() {

		        if (document.getElementById('tbUsername').value != '' &&
                    document.getElementById('tbPassword').value != '')
                    
		            if (receiveReq.readyState == 4 || receiveReq.readyState == 0) {

		            //
		            receiveReq.open("GET", PostClientPage +
		            '?Type=2' +
		            '&FromMemberID=' + FromMemberID +
		            '&Username=' + document.getElementById('tbUsername').value +
		            '&Password=' + document.getElementById('tbPassword').value, true);
		            //
		            receiveReq.onreadystatechange = HandleReceiveCommands;
		            //
		            receiveReq.send(null);
		            //
		            GetNewCommands();
		        }
		    } 
		    
		    //Gets the current messages from the server
		    function GetNewCommands() {

		        receiveReq = getXmlHttpRequestObject();
		        //
		        if (receiveReq.readyState == 4 || receiveReq.readyState == 0) {

		            receiveReq.open("GET",
		            PostClientPage +
		            '?Type=19' +
		            '&FromMemberID=' + FromMemberID, true);
		            //
		            receiveReq.onreadystatechange = HandleReceiveCommands;
		            //
		            receiveReq.send(null);
		        }
		    }
		    
		    //Function for handling the return of chat text
		    function HandleReceiveCommands() {

		        if (receiveReq.readyState == 4) {

		            var command_nodes = receiveReq.responseXML.getElementsByTagName("Command");
		            //
		            for (i = 0; i < command_nodes.length; i++) {
		                
		                var Type_node = parseInt(command_nodes[i].getElementsByTagName("Type")[0].firstChild.nodeValue, null);
		                var FromMemberID_node = parseInt(command_nodes[i].getElementsByTagName("FromMemberID")[0].firstChild.nodeValue, null);
		                var Content_node = command_nodes[i].getElementsByTagName("Content")[0].firstChild.nodeValue;
		                var MetaData_node = command_nodes[i].getElementsByTagName("MetaData")[0].firstChild.nodeValue;
		                //
		                if (Type_node == 4) {

		                    frmLogin.method = 'POST';
		                    frmLogin.action = 'Default.aspx';
		                    //
		                    var myInput = document.createElement("input");
		                    myInput.setAttribute("name", "FromMemberID");
		                    myInput.setAttribute("value", parseInt(Content_node).toString());
		                    frmLogin.appendChild(myInput);
		                    //
		                    myInput = document.createElement("input1");
		                    myInput.setAttribute("name", "Username");
		                    myInput.setAttribute("value", document.getElementById('tbUsername').value);
		                    frmLogin.appendChild(myInput);
		                    //
		                    document.body.appendChild(frmLogin);
		                    frmLogin.submit();
		                    //
//		                    var sendReq = getXmlHttpRequestObject();
//		                    //
//		                    sendReq.open("POST", 'Default.aspx', true);
//		                    //
//		                    sendReq.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
//		                    //
//		                    sendReq.send('FromMemberID=' + FromMemberID +
//		                        '&Username=' + document.getElementById('tbUsername').value);
//		                    alert("4");
		                }
		                else if (Type_node == 5) {

		                    document.getElementById('tbPassword').value = '';
		                    document.getElementById('tbUsername').focus();
		                }
		            }
		            //
		            mTimer = setTimeout('GetNewCommands();', 1000); //Refresh our chat in 2 seconds
		        }
		    }
		    
		    function BlockSubmit() {
		        
		        SendLoginInfo();
		        return false;
		    }
		    
		    

		</script>
		
	</head>
	
	<body onload="javascript:StartChat();" style="text-align: left">
	
		<h3 style="border-style: ridge; border-width: thin; text-align: center; font-family: Tahoma; width: 273px;">
            پارسیان چت</h3>
		
		<form id="frmLogin" name="frmLogin" onsubmit="return BlockSubmit();" 
        style="border-style: dashed; width: 274px; font-family: Tahoma;">
			<p class="style3">
                ورود اعضا            <table align="center" class="style1">
                    <tr>
                        <td class="style2">
                            <input type="text" id="tbUsername" name="tbMessage" 
                style="width: 150px; font-family: Tahoma; " /></td>
                        <td>
&nbsp;: نام کاربری</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <input type="password" id="tbPassword" name="tbPassword" 
                style="width: 150px; font-family: Tahoma; " /></td>
                        <td>
                            &nbsp;: کلمه عبور</td>
                    </tr>
                </table>
                <div class="style3">
                    <br />
                    <input id="bLogin" name="bLogin" onclick="javascript:SendLoginInfo();"
                        type="button" value="ورود" />&nbsp;
                </div>
            </p>
         </form>
         
	</body>
	
</html>