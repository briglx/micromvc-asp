using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;


namespace MicroMvc
{
    public class JsonView<T> : BaseView<T>
    {
        public JsonView()
        {
            this.ContentType = "text/json";
        }
        public override void ProcessRequest(HttpContext context)
        {

            // Perform JSON to datawrapper collection returning string value
            string result = JSONSerializer.ToJSON(this.ViewData);

            context.Response.ContentType = this.ContentType;
            context.Response.StatusCode = this.StatusCode;
            context.Response.Write(result);
            context.Response.End();
        }
    }
}
