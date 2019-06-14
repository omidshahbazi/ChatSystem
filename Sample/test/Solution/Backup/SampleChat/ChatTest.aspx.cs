using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SampleChat
{
	public partial class ChatTest : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			SessionWrapper session = new SessionWrapper(Session);
			if (session.User == null)
			{
				session.User = new SampleChat.Chat.SiteUser(Convert.ToInt32(Request["u"]), Request["n"]);
			}

			base.OnLoad(e);
		}
	}
}
