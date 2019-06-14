String.prototype.namespace = function (separator) { var ns = this.split(separator || '.'), p = window; for (i = 0; i < ns.length; i++) { p = p[ns[i]] = p[ns[i]] || {}; } };

"BinarySoftCo.ChatSystem".namespace();

BinarySoftCo.ChatSystem.Init = function () {

    //Global elements
    BinarySoftCo.ChatSystem.EmailBox = document.getElementById("tbEmail");
    BinarySoftCo.ChatSystem.PasswordBox = document.getElementById("tbPassword");

    BinarySoftCo.ChatSystem.EmailBox.focus();
    BinarySoftCo.ChatSystem.PasswordBox.value = "";

    BinarySoftCo.Client_Site.ChatService.InitialUserSession(BinarySoftCo.ChatSystem.InitUserSessionCallback);

//    BinarySoftCo.Client_Site.ChatService.InitialDatabaseConncetion(BinarySoftCo.ChatSystem.InitDBConnectionCallback);
}

BinarySoftCo.ChatSystem.InitDBConnectionCallback = function (Connceted) {
    if (!Connceted)
        alert(".اتصال به سرور با مشکل مواجه شد");
}

BinarySoftCo.ChatSystem.InitUserSessionCallback = function (HasOpenSession) {
    if (HasOpenSession)
        window.location.href = "home.aspx";
}

BinarySoftCo.ChatSystem.Login = function () {

    BinarySoftCo.Client_Site.ChatService.Login(
    BinarySoftCo.ChatSystem.EmailBox.value,
    BinarySoftCo.ChatSystem.PasswordBox.value,
    BinarySoftCo.ChatSystem.LoginCallback);
}

BinarySoftCo.ChatSystem.LoginCallback = function (CanLogin) {

    if (CanLogin)
        window.location.href = "home.aspx";
    else
        alert(".اطلاعات ورود شما صحیح نمی باشد");
}