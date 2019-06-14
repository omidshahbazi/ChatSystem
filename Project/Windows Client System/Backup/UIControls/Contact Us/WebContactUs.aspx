<%@ Page Language="C#" %>
<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="System.Security.Cryptography" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
     <script runat="server">
         
         MailMessage message;
         SmtpClient client;
         
         string smtpServerAddress = "mail.amasoftware.ir",
            emailAddress = "support@amasoftware.ir",
            password = "Omid(*)";
         int smtpPort = 25;
         
         public static string DecodeString(string cipherString)
         {
             byte[] keyArray;
             byte[] toEncryptArray = Convert.FromBase64String(cipherString);

             AppSettingsReader settingsReader = new AppSettingsReader();

             MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
             keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("o)(*m7&@i*!d3&@"));
             hashmd5.Clear();

             TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
             tdes.Key = keyArray;
             tdes.Mode = CipherMode.ECB;
             tdes.Padding = PaddingMode.PKCS7;

             ICryptoTransform cTransform = tdes.CreateDecryptor();
             byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

             tdes.Clear();
             return UTF8Encoding.UTF8.GetString(resultArray);
         }

         protected void Page_Load(object sender, EventArgs e)
         {
             string name = "", email = "", subject = "", body = "";
             bool bcc = false;
             //
             if (Request["name"] != null)
                 name = DecodeString(Request["name"]);
             //
             if (Request["email"] != null)
                 email = DecodeString(Request["email"]);
             //
             if (Request["subject"] != null)
                 subject = DecodeString(Request["subject"]);
             //
             if (Request["body"] != null)
                 body = DecodeString(Request["body"]);
             //
             if (Request["bcc"] != null)
                 bcc = Convert.ToBoolean(Request["bcc"]);
             //
             try
             {
                 message = new MailMessage();
                 //
                 client = new SmtpClient(smtpServerAddress, smtpPort);
                 //
                 client.Credentials = new System.Net.NetworkCredential(emailAddress, password);
                 //
                 message.To.Add(emailAddress);
                 //
                 message.From = new System.Net.Mail.MailAddress(emailAddress, subject, Encoding.UTF8);
                 //
                 message.Subject = subject;
                 message.SubjectEncoding = Encoding.UTF8;
                 //
                 message.IsBodyHtml = true;
                 message.Body = "<html width=\"500px\">" +
                     "<div text-align=\"right\">" +
                     "<p>" + "نام : " + name + "</p>" +
                     "<p>" + "ایمیل : " + email + "</p>" +
                     "<p>" + "عنوان : " + subject + "</p>" +
                     "<p>" + "متن : " + body.Replace(Environment.NewLine, "<br/>").Replace("\n", "<br/>") + "</p>" +
                     "</div>" +
                     "</html>";
                 //
                 message.BodyEncoding = Encoding.UTF8;
                 //
                 if (bcc)
                     message.Bcc.Add(new MailAddress(email, "رونوشت"));
                 //
                 message.Priority = System.Net.Mail.MailPriority.High;
                 //
                 client.Timeout = 10000000;
                 //
                 client.Send(message);
             }
             catch (Exception er)
             {
             }
         }
    </script>
</head>
<body>
<form id="Form1" runat="server">
		<asp:Label ID="lab" runat="server"></asp:Label>
    </form>
</body>
</html>