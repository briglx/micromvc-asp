using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MicroMvc.Views
{
    public class TextView<T> : BaseView<T>
    {

        public TextView()
        {
            this.ContentType = "text/text";
        }

        public override void ProcessRequest(HttpContext context)
        {
            string result = string.Empty;

            if (this.ViewData != null)
            {
                result = this.ViewData.ToString();
            }

            context.Response.ContentType = this.ContentType;
            context.Response.StatusCode = this.StatusCode;
            context.Response.Write(result);
            context.Response.End();
        }
    }
}
