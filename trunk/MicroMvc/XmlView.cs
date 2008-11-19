using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace MicroMvc
{
    public class XmlView<T> : IBaseView<T>
    {

        public T ViewData { get; set; }
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            XmlSerializer x = new XmlSerializer(this.ViewData.GetType());
            StringWriter stream = new StringWriter();
            x.Serialize(stream, this.ViewData);
            stream.Flush();
            String result = stream.ToString();

            context.Response.ContentType = "text/xml";
            context.Response.Write(result);
            context.Response.End();
        }
    }
}
