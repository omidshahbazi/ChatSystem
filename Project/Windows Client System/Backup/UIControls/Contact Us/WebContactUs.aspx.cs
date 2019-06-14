using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BinarySoftCo.Tools.Mail;
using System.Drawing;

namespace BinarySoftCo.UIControls
{
    public partial class WebContactUs : System.Web.UI.Page
    {
        string smtpServerAddress = "mail.amasoftware.ir",
            emailAddress = "support@amasoftware.ir",
            password = "Omid(*)";
        int smtpPort = 25;

        protected void Page_Load(object sender, EventArgs e)
        {
            string name = "", email = "", subject = "", body = "";
            bool bcc = false;
            //
            if (Request["name"] != null)
                name = Request["name"];
            //
            if (Request["email"] != null)
                email = Request["email"];
            //
            if (Request["subject"] != null)
                subject = Request["subject"];
            //
            if (Request["body"] != null)
                body = Request["body"];
            //
            if (Request["bcc"] != null)
                bcc = Convert.ToBoolean(Request["bcc"]);
            //
            Mailer mail = new Mailer(smtpServerAddress, smtpPort, emailAddress, password);
            //
            //mail.BccList.Add("sh_omid_m@yahoo.com");
            //
            if (bcc)
                mail.BccList.Add(email);
            //
            mail.IsBodyHTML = true;
            //
            mail.Send(emailAddress,subject, subject,

                "<html width=\"500px\">" +
                "<div text-align=\"right\">" +
                "<p>" + "نام : " + name + "</p>" +
                "<p>" + "ایمیل : " + email + "</p>" +
                "<p>" + "عنوان : " +subject + "</p>" +
                "<p>" + "متن : " + body.Replace(Environment.NewLine, "<br/>").Replace("\n", "<br/>") + "</p>" +
                "</div>" +
                "</html>");
        }

        //protected void bSend_Click(object sender, EventArgs e)
        //{
        //    Mailer mail = new Mailer(smtpServerAddress, smtpPort, emailAddress, password);
        //    //
        //    //mail.BccList.Add("sh_omid_m@yahoo.com");
        //    //
        //    if (cbBcc.Checked)
        //        mail.BccList.Add(tbEmail.Text);
        //    //
        //    mail.IsBodyHTML = true;
        //    //
        //    if (mail.Send("support@amasoftware.ir", "پشتیبانی آما", "پشتیبانی آما",

        //        "<html width=\"500px\">" +
        //        "<div text-align=\"right\">" +
        //        "<p>" + "نام : " + tbName.Text + "</p>" +
        //        "<p>" + "ایمیل : " + tbEmail.Text + "</p>" +
        //        "<p>" + "عنوان : " + tbSubject.Text + "</p>" +
        //        "<p>" + "متن : " + tbMessage.Text.Replace(Environment.NewLine, "<br/>").Replace("\n", "<br/>") + "</p>" +
        //        "</div>" +
        //        "</html>"))
        //    {
        //        lResult.Text = "تیکت با موفقیت ارسال شد";
        //        lResult.ForeColor = Color.Green;
        //        //
        //        tbName.Text = tbEmail.Text = tbSubject.Text = tbMessage.Text = "";
        //        //
        //        return;
        //    }
        //    //
        //    lResult.Text = "ارسال تیکت با اشکال مواجه شد";
        //    lResult.ForeColor = Color.Red;
        //    bSend.Text = "تلاش مجدد";
        //}
    }
}