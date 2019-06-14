String.prototype.namespace = function (separator) { var ns = this.split(separator || '.'), p = window; for (i = 0; i < ns.length; i++) { p = p[ns[i]] = p[ns[i]] || {}; } };

"BinarySoftCo.ChatSystem".namespace();

BinarySoftCo.ChatSystem.Init = function () {

    //Global elements
    BinarySoftCo.ChatSystem.MemberList = document.getElementById("MemberList");
    BinarySoftCo.ChatSystem.ChatBoxDIV = document.getElementById("ChatBoxDIV");

    BinarySoftCo.ChatSystem.ChatWindowRefrence = null;

    BinarySoftCo.Client_Site.ChatService.InitialUserSession(BinarySoftCo.ChatSystem.InitUserSessionCallback);
    BinarySoftCo.Client_Site.ChatService.GetMy(BinarySoftCo.ChatSystem.GetMyCallback);
    BinarySoftCo.ChatSystem.GetMemberList();

    BinarySoftCo.Client_Site.ChatService.InitialDatabaseConncetion();

    //Establish constanst
    BinarySoftCo.ChatSystem.GetMemberListRefresh = 20000;
    BinarySoftCo.ChatSystem.StopRefresh = false;
}

BinarySoftCo.ChatSystem.DisconncetFromServer = function () {

    if (BinarySoftCo.ChatSystem.ChatWindowRefrence != null)
        try {
            BinarySoftCo.ChatSystem.ChatWindowRefrence.close();
        }
        catch (Err) {
        }

    BinarySoftCo.Client_Site.ChatService.DisconnectDatabaseTerminal();
}

BinarySoftCo.ChatSystem.GetMyCallback = function (Member) {
    document.title += ", " + Member.DisplayName;
}

BinarySoftCo.ChatSystem.InitUserSessionCallback = function (HasOpenSession) {
    if (!HasOpenSession)
        window.location.href = "default.aspx";
}

BinarySoftCo.ChatSystem.GetMemberList = function () {

    BinarySoftCo.Client_Site.ChatService.GetMemberList(BinarySoftCo.ChatSystem.GetMemberListCallback);

    if (!BinarySoftCo.ChatSystem.StopRefresh)
        setTimeout(BinarySoftCo.ChatSystem.GetMemberList, BinarySoftCo.ChatSystem.GetMemberListRefresh);
}

BinarySoftCo.ChatSystem.GetMemberListCallback = function (MembersList) {

    BinarySoftCo.ChatSystem.MemberList.innerHTML = "";

    for (var i = 0; i < MembersList.length; i++) {

        var div = document.createElement("div");

        var user = MembersList[i];
        
//        this.style.background='#bbbbbb'; this.style.color='#000000'" onmouseout="this.style.background='#efefef'; this.style.color=''"

        div.innerHTML = "<a style=\"text-decoration:none;\" href=\"javascript:void(0);\" onclick=\"BinarySoftCo.ChatSystem.ChatWith(" + user.DBID + ");\">" +
        "<div onmouseover=\"this.style.background='#FC9E61';\" onmouseout=\"this.style.background='#FFFFCC';\" " + 
        "style=\"cursor:hand; background-color:#FFFFCC; font-family:B Titr,Tahoma; text-decoration:none; margin:5px; padding-right:10px; height:25px; \">" + user.DisplayName + 
        "</div></a>";

        BinarySoftCo.ChatSystem.MemberList.appendChild(div);
    }
}



BinarySoftCo.ChatSystem.ChatWith = function (DBID) {

    BinarySoftCo.Client_Site.ChatService.SetChatWith(DBID);

    if (BinarySoftCo.ChatSystem.ChatWindowRefrence != null)
        BinarySoftCo.ChatSystem.ChatWindowRefrence.close();

    BinarySoftCo.ChatSystem.ChatWindowRefrence = window.open("chat.aspx", "چت", "resizable=1;width=700;height=500;top:200;left:300;");
    //
    //    BinarySoftCo.ChatSystem.ChatBoxDIV.innerHTML = "<UC:ChatBox ID=\"ChatBox1\" runat=\"server\" />";
}

//BinarySoftCo.ChatSystem.ChatWithCallback = function (IsAvailable) {

//    if (!IsAvailable) {

//        BinarySoftCo.ChatSystem.GetMemberList();
//        return;
//    }
//    //
//    BinarySoftCo.ChatSystem.ChatBoxDIV.innerHTML = "<UC:ChatBox ID=\"ChatBox1\" runat=\"server\" />";
//}

//Codeproject.Chat. = function (users) {
//    var list = document.createElement("UL");
//    for (var i = 0; i < users.length; i++) {
//        var element = document.createElement("LI");
//        var user = users[i];
//        element.innerHTML = user.UserName;
//        list.appendChild(element);
//    }
//    Codeproject.Chat.UserPanel.innerHTML = "";
//    Codeproject.Chat.UserPanel.appendChild(list);
//}