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
    public partial class _Login : System.Web.UI.Page
    {
        private void GenerateNewText()
        {
            string filePath = Server.MapPath("") + @"\gt.bmp";
            //
            Application["gtText"] = Guid.NewGuid().ToString().Substring(0, 8);
            //
            if (File.Exists(filePath))
                File.Delete(filePath);
            Bitmap bmp = new Bitmap(60, 20);
            //
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(Brushes.White, new Rectangle(new Point(), bmp.Size));
                g.DrawString(Application["gtText"].ToString(), new Font("Tahoma", 10), Brushes.Black, new PointF(1, 2));
                
            }
            //
            bmp.Save(filePath);
            //
            iGraphText.ImageUrl = "gt.bmp";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GenerateNewText();
        }

        protected void bLogin_Click(object sender, EventArgs e)
        {
            if (Application["gtText"].ToString() != tbGraphicalText.Text)
            {
                if (Variables.BaseData.GetUserLoginStatus(tbUsername.Text, tbPassword.Text))
                {
                    FormsAuthentication.Authenticate(tbUsername.Text, tbPassword.Text);
                    //
                    //if (Request["ReturnUrl"] == null)
                        FormsAuthentication.RedirectFromLoginPage(tbUsername.Text, true);
                    //else
                    //    Response.Redirect(Request["ReturnUrl"]);
                }
                else
                    Server.Transfer("login.aspx");
            }
            else
            {
                tbGraphicalText.Text = "";
                tbGraphicalText.Focus();
            }
        }
    }
}
