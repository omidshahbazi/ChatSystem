using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace BinarySoftCo.Tools.General
{
    public static class TextString
    {
        public static string HTMLTagsToText(string HTML, bool allowHarmlessTags)
        {
            if (string.IsNullOrEmpty(HTML))
                return "";
            if (allowHarmlessTags)
                return Regex.Replace(HTML, "", string.Empty);
            //
            return Regex.Replace(HTML, @"<(.|\n)*?>", string.Empty);
            //
            //return Regex.Replace(HTML, @"<{0}[^>]*?>[\w|\t|\r|\W]*?</{0}>", string.Empty);
            //
            //int index = HTML.ToLower().IndexOf("<body>");
            ////
            //if (index > -1)
            //    HTML = HTML.Remove(0, index + 6);
            ////
            //index = HTML.ToLower().IndexOf("</body>");
            ////
            //if (index > -1)
            //    HTML = HTML.Remove(index, HTML.Length - index - 1);
            ////
            //return HTML;
        }

        public static string HTMLTagsToText(string HTML)
        {
            return HTMLTagsToText(HTML, false);
        }

        public static string TextToHTMLTags(string Text, bool allowHarmlessTags)
        {
            //Create a StringBuilder object from the string input
            //parameter
            StringBuilder sb = new StringBuilder(Text);
            //Replace all double white spaces with a single white space
            //and &nbsp;
            sb.Replace("  ", " &nbsp;");
            //Check if HTML tags are not allowed
            if (!allowHarmlessTags)
            {
                //Convert the brackets into HTML equivalents
                sb.Replace("<", "&lt;");
                sb.Replace(">", "&gt;");
                //Convert the double quote
                sb.Replace("\"", "&quot;");
            }
            //Create a StringReader from the processed string of
            //the StringBuilder object
            StringReader sr = new StringReader(sb.ToString());
            StringWriter sw = new StringWriter();
            //Loop while next character exists
            while (sr.Peek() > -1)
            {
                //Read a line from the string and store it to a temp
                //variable
                string temp = sr.ReadLine();
                //write the string with the HTML break tag
                //Note here write method writes to a Internal StringBuilder
                //object created automatically
                sw.Write(temp + "<br>");
            }
            //Return the final processed text
            return sw.GetStringBuilder().ToString();
        }
    }
}
