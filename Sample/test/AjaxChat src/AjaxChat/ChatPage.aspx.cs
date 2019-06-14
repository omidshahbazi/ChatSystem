using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Globalization;

/// <summary>
/// License and Disclaimer: All the intructions, code, html and everything presented with this solution is provided 'as is' with no warranties what so ever.
/// The only condition for you to use this software is that you keep the link to http://www.spilafis.com.ar in the chat page as provided. Please support freeware keeping the link and clicking on my sponsors.
/// Thank you!
/// </summary>
public partial class ChatPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Register AJAX
        Ajax.Utility.RegisterTypeForAjax(typeof(SpilafisChatLogic.Chat));
        
        UpdateUsersGridView();
    }

    public void UpdateUsersGridView()
    {
        // Update grid
        grvUsers.DataSource = SpilafisChatLogic.Chat.GetUsersDataSource();
        grvUsers.DataBind();
    }
    protected void btnRefresh_ServerClick(object sender, EventArgs e)
    {
        UpdateUsersGridView();
    }
}
