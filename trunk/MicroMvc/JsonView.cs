using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;


namespace MicroMvc
{
    public class JsonView<T> : IBaseView<T>
    {

        public T ViewData { get; set; }
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {

            // Perform JSON to datawrapper collection returning string value
            string result = JSONSerializer.ToJSON(this.ViewData);
           //result = jsonCB + "(" + result + ")";

            //XmlSerializer x = new XmlSerializer(this.ViewData.GetType());
            //StringWriter stream = new StringWriter();
            //x.Serialize(stream, this.ViewData);
            //stream.Flush();
            //String result = stream.ToString();

            context.Response.ContentType = "text/json";
            context.Response.Write(result);
            context.Response.End();
        }
    }
}
