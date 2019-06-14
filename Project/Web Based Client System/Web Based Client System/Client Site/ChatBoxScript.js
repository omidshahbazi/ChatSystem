String.prototype.namespace = function (separator) { var ns = this.split(separator || '.'), p = window; for (i = 0; i < ns.length; i++) { p = p[ns[i]] = p[ns[i]] || {}; } };

"BinarySoftCo.ChatSystem".namespace();

BinarySoftCo.ChatSystem.Init = function () {

    //Global elements
    BinarySoftCo.ChatSystem.ChatBodyDIV = document.getElementById("ChatBodyDIV");
    BinarySoftCo.ChatSystem.ChatMessageDIV = document.getElementById("ChatMessageDIV");
    BinarySoftCo.ChatSystem.MessageBox = document.getElementById("tbMessage");

    BinarySoftCo.Client_Site.ChatService.InitialUserSession(BinarySoftCo.ChatSystem.InitUserSessionCallback);
//    BinarySoftCo.Client_Site.ChatService.InitialDatabaseConncetion();
    BinarySoftCo.Client_Site.ChatService.GetMy(BinarySoftCo.ChatSystem.GetMyCallback);
    BinarySoftCo.Client_Site.ChatService.GetMember(BinarySoftCo.ChatSystem.GetMemberCallback);

    //Establish constanst
    BinarySoftCo.ChatSystem.My = null;
    BinarySoftCo.ChatSystem.ChatWithMemberID = -1;
    BinarySoftCo.ChatSystem.LastMessageID = -1;
    BinarySoftCo.ChatSystem.LastAddedDIV = null;
    BinarySoftCo.ChatSystem.LastLineAddByMe = false;
    BinarySoftCo.ChatSystem.Member = null;
    BinarySoftCo.ChatSystem.GetMessageRefresh = 5000;
    BinarySoftCo.ChatSystem.StopRefresh = false;

    BinarySoftCo.ChatSystem.MessageBox.focus();
}

BinarySoftCo.ChatSystem.GetMyCallback = function (Member) {

    BinarySoftCo.ChatSystem.My = Member;
}

BinarySoftCo.ChatSystem.GetMemberCallback = function (Member) {

    BinarySoftCo.ChatSystem.Member = Member;
    document.title += ", " + Member.FirstName;
}

BinarySoftCo.ChatSystem.InitUserSessionCallback = function (HasOpenSession) {

    if (!HasOpenSession)
        window.close();
}

BinarySoftCo.ChatSystem.SendMessage = function () {

    var message = BinarySoftCo.ChatSystem.MessageBox.value;

    if (message.trim() != "")
        BinarySoftCo.Client_Site.ChatService.SendMessage(message, BinarySoftCo.ChatSystem.SendMessageCallback);
}

BinarySoftCo.ChatSystem.SendMessageCallback = function (MessageID) {

    if (MessageID == null) {

        alert(".ارسال پیغام با مشکل مواجه شد.لطفا مجددا تلاش کنید");
        return;
    }

    BinarySoftCo.ChatSystem.AddMessageToDIV("من", BinarySoftCo.ChatSystem.MessageBox.value, BinarySoftCo.ChatSystem.My.Gender, true);
    //    BinarySoftCo.ChatSystem.AddMessageToDIV(BinarySoftCo.ChatSystem.Member.FirstName, BinarySoftCo.ChatSystem.MessageBox.value, BinarySoftCo.ChatSystem.Member.Gender, false);

    BinarySoftCo.ChatSystem.GetLatestMessages();

    BinarySoftCo.ChatSystem.MessageBox.focus();
    BinarySoftCo.ChatSystem.MessageBox.value = "";
}

BinarySoftCo.ChatSystem.GetLatestMessages = function () {

    BinarySoftCo.Client_Site.ChatService.GetLatestMessages(BinarySoftCo.ChatSystem.LastMessageID, BinarySoftCo.ChatSystem.Member.DBID, BinarySoftCo.ChatSystem.GetLatestMessagesCallback);

    if (!BinarySoftCo.ChatSystem.StopRefresh)
        setTimeout(BinarySoftCo.ChatSystem.GetLatestMessages, BinarySoftCo.ChatSystem.GetMessageRefresh);
}

BinarySoftCo.ChatSystem.GetLatestMessagesCallback = function (messages) {

    for (var i = 0; i < messages.length; i++) {

        var message = messages[i];

        BinarySoftCo.ChatSystem.AddMessageToDIV(BinarySoftCo.ChatSystem.Member.FirstName, message.Body, BinarySoftCo.ChatSystem.Member.Gender, false);

        BinarySoftCo.ChatSystem.LastMessageID = message.DBID;
    }
}

BinarySoftCo.ChatSystem.AddMessageToDIV = function (DiplayName, Body, Gender, LocalMessage) {

    var flag = (BinarySoftCo.ChatSystem.LastLineAddByMe == LocalMessage);

    if (!flag)
        BinarySoftCo.ChatSystem.LastAddedDIV = document.createElement("div");

    //(new Date()).format("HH:MM") + "hs"


    var inner = BinarySoftCo.ChatSystem.LastAddedDIV.innerHTML;

    inner += "<div style=\"margin:5px; width:90%;\">";

    if (!flag) {

        var imgURL = "Media/ManAvator.png";
        if (!Gender)
            imgURL = "Media/WomanAvator.png";

        inner += "<div><div style=\"float:right; width:100%; height:80px; font-family:Tahoma; overflow:hidden;\">" +
         "<img src=\"" + imgURL + "\" width=\"50px\" height=\"50px\"/><div>" + DiplayName + "</div></div>";
    }

    inner += "<div style=\";text-align:right; font-family:Tahoma;\">" + Body + "</div></div></div>";

    BinarySoftCo.ChatSystem.LastAddedDIV.innerHTML = inner;

    BinarySoftCo.ChatSystem.ChatBodyDIV.appendChild(BinarySoftCo.ChatSystem.LastAddedDIV);

    BinarySoftCo.ChatSystem.LastLineAddByMe = LocalMessage;

    BinarySoftCo.ChatSystem.ChatMessageDIV.scrollTop = BinarySoftCo.ChatSystem.ChatMessageDIV.scrollHeight;
}

BinarySoftCo.ChatSystem.CheckSend = function (e) {

    if (window.event)
        keynum = e.keyCode;
    else if (e.which)
        keynum = e.which;
    //
    if (keynum == 13)
        BinarySoftCo.ChatSystem.SendMessage();
}

//Codeproject.Chat.ArrangeMessages = function (messages) {
//    for (var i = 0; i < messages.length; i++) {
//        var element = document.createElement("LI");
//        var message = messages[i];
//        //(new Date()).format("HH:MM") + "hs"
//        element.innerHTML = "<span class=\"userName\">" + message.UserName + "</span>";
//        element.innerHTML += ": " + message.MessageBody;

//        Codeproject.Chat.MessageList.appendChild(element);

//        Codeproject.Chat.MessagePanel.scrollTop = Codeproject.Chat.MessagePanel.scrollHeight;
//    }
//}