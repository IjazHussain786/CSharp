using Logger.Interfaces;
using System;
using System.Text;

namespace Logger.Layouts
{
    public class XMLLayout : ILayout
    {
        public string Format(string msg, ReportLevel level, DateTime date)
        {
            var output = new StringBuilder();
            output.AppendLine("<log>");
            output.AppendLine("<date>" + date + "</date>");
            output.AppendLine("<level>" + level + "</level>");
            output.AppendLine("<message>" + msg + "</message>");
            output.AppendLine("</log>");

            return output.ToString();
        }
    }
}
