using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace MicroMvc
{
    public class XmlView<T> : BaseView<T>
    {
        public XmlView()
        {
            this.ContentType = "text/xml";
        }
        public override void ProcessRequest(HttpContext context)
        {
            XmlSerializer x = new XmlSerializer(this.ViewData.GetType());
            StringWriter stream = new StringWriter();
            x.Serialize(stream, this.ViewData);
            stream.Flush();
            String result = stream.ToString();

            context.Response.ContentType = "text/xml";
            context.Response.StatusCode = this.StatusCode;
            context.Response.Write(result);
            context.Response.End();
        }
    }
}
