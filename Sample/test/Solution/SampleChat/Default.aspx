<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleChat._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
	<link href="/styles/chat.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<h1>Sample chat client</h1>
	<p>In order to test the chat client you will need multiple browsers (IE, FF, Chrome) in order to simulate multiple sessions.</p>
	<p>For each browser session, click on a different user to login.</p>
	<h2>Login as</h2>
	<ul>
		<li><a href="ChatTest.aspx?u=1&amp;n=User 1">User 1</a></li>
		<li><a href="ChatTest.aspx?u=2&amp;n=User 2">User 2</a></li>
		<li><a href="ChatTest.aspx?u=3&amp;n=User 3">User 3</a></li>
		<li><a href="ChatTest.aspx?u=4&amp;n=User 4">User 4</a></li>
	</ul>
</body>
</html>
