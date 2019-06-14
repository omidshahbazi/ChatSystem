using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.IO;
using BinarySoftCo.ChatSystem.ServerDataLayer;

namespace BinarySoftCo.Parsian_Chat_Admin
{
    public partial class _Main : System.Web.UI.Page
    {
        private void LoadMembers()
        {
            DataTable dtData = Variables.BaseData.GetAllMemebersInfoBase();
            //
            dtData.Columns["PersonID"].Caption = "کد";
            //
            //grid1.DataSource = dtData;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMembers();
            }
        }
    }
}
