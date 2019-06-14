String.prototype.namespace = function (separator) { var ns = this.split(separator || '.'), p = window; for (i = 0; i < ns.length; i++) { p = p[ns[i]] = p[ns[i]] || {}; } };

"ChatSystem".namespace();

ChatSystem.Init = function () {

}

ChatSystem.Logout = function () {
    if (confirm('آیا مایل به ادامه می باشید ؟')) {

        try {
            BinarySoftCo.Client_Site.ChatService.Logout();

            window.location.href = "default.aspx";
        }
        catch (yy) {
            alert(yy.Message);
        }
    }
}