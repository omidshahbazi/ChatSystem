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
using System.Collections.Generic;

using BinarySoftCo.ChatSystem.ServerDataLayer;
using BinarySoftCo.ChatSystem.ServerNetworking;

namespace Cleint
{
    public partial class PostClientPage : System.Web.UI.Page
    {
        private void SendCommandListToClient(List<Command> list)
        {
            string xml = "<?xml version=\"1.0\" ?>" + Environment.NewLine + "<root>" + Environment.NewLine;
            //
            foreach (Command c in list)
            {
                xml += "\t" + "<Command>" + Environment.NewLine + "\t\t";
                xml += "<Type>" + (int)c.Type + "</Type>" + Environment.NewLine + "\t\t";
                xml += "<FromMemberID>" + c.FromMemberID + "</FromMemberID>" + Environment.NewLine + "\t\t";
                xml += "<Content>" + c.Content + " </Content>" + Environment.NewLine + "\t\t";
                xml += "<MetaData>" + c.MetaData + " </MetaData>" + Environment.NewLine + "\t";
                xml += "</Command>" + Environment.NewLine;
            }
            xml += "</root>";
            //
            //Send out the AJAX response.
            Response.Write(xml);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("Expires", "Mon, 26 Jul 1997 05:00:00 GMT");
            Response.AddHeader("Last-Modified", DateTime.UtcNow.ToString());
            Response.AddHeader("Cache-Control", "no-cache, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            Response.AddHeader("Content-Type", "text/xml; charset=utf-8");
            //
            BaseData bd = new BaseData();
            //
            if (Request.QueryString["Type"] != null)
            {
                CommandsType ct = (CommandsType)int.Parse(Request.QueryString["Type"]);
                //
                if (ct == CommandsType.SignIn)
                {
                    Command cmd = new Command(Request.QueryString["Username"], Request.QueryString["Password"]);
                    //
                    bd.AddIncomingCommand(new Command(-1,
                        cmd.Type,
                        int.Parse(Request.QueryString["FromMemberID"]),
                        cmd.ToMemberID,
                        cmd.Content,
                        cmd.MetaData));
                }
                else if (ct == CommandsType.GetCommands)
                {
                    List<Command> list = bd.GetOutgoingCommandsFor(int.Parse(Request.QueryString["FromMemberID"]));
                    //
                    SendCommandListToClient(list);
                    //
                    foreach (Command c in list)
                        bd.DeleteCommand(c.DBID);
                }
                else if (ct == CommandsType.Message)
                {
                    Command cmd = new Command(int.Parse(Request.QueryString["ToMemberID"]), Request.QueryString["Message"], true);
                    //
                    bd.AddIncomingCommand(new Command(-1,
                        cmd.Type,
                        int.Parse(Request.QueryString["FromMemberID"]),
                        cmd.ToMemberID,
                        cmd.Content,
                        cmd.MetaData));
                }
                else if (ct == CommandsType.HTTPClientSignal)
                {
                    Command cmd = new Command(CommandsType.HTTPClientSignal);
                    //
                    bd.AddIncomingCommand(new Command(-1,
                        cmd.Type,
                        int.Parse(Request.QueryString["FromMemberID"]),
                        cmd.ToMemberID,
                        cmd.Content,
                        cmd.MetaData));
                }
            }
            //
            //string xml = "<?xml version=\"1.0\" ?><root>";
            ////
            //if (Request.QueryString["chat"] == null)
            //{
            //    xml += "You are not currently in a chat session";
            //    xml += "<message id=\"0\">";
            //    xml += "<user>Admin</user>";
            //    xml += "<text>You are not currently in a chat session.</text>";
            //    xml += "<time>" + DateTime.Now.Hour + " " + DateTime.Now.Minute + "</time>";
            //    xml += "</message>";
            //}
            //else
            //{
            //    int last = 0;
            //    //
            //    if (Request.QueryString["last"] != null)
            //    {
            //        last = int.Parse(Request.QueryString["last"]);
            //    }
            //    //
            //    //Dim msgCommand As New SqlCommand("SELECT message_id, user_name, message, post_time FROM message WHERE chat_id = @chat_id and message_id > " & last, conn)
            //    //Dim paramChatID As New SqlParameter("chat_id", Data.SqlDbType.Int)
            //    //paramChatID.Value = CInt(Request.QueryString("chat"))
            //    //msgCommand.Parameters.Add(paramChatID)
            //    //Dim reader As SqlDataReader = msgCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
            //    //'//Loop through each message and create an XML message node for each.
            //    //'Notice that we're making use of Server.HtmlEncode to avoid script injection attacks.
            //    //while( reader.Read)
            //    //{
            //    //    xml &= "<message id=""" & reader.Item("message_id") & """>"
            //    //    xml &= "<user>" & Server.HtmlEncode(reader.Item("user_name")) & "</user>"
            //    //    xml &= "<text>" & Server.HtmlEncode(reader.Item("message")) & "</text>"
            //    //    xml &= "<time>" & reader.Item("post_time") & "</time>"
            //    //    xml &= "</message>"
            //    //}
            //    //xml &= "</root>"
            //    //conn.Close()
            //    //'Send out the AJAX response.
            //    //Response.Write(xml)
            //}
        }
    }
}