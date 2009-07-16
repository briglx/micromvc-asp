using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MicroMvc
{
    public class TextView<T> : IBaseView<T>
    {
        public T ViewData { get; set; }
        public string ContentType { get; set; }

        public TextView()
        {
            this.ContentType = "text/text";
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string result = this.ViewData.ToString();

            context.Response.ContentType = this.ContentType;
            context.Response.Write(result);
            context.Response.End();
        }
        object IBaseView.ViewData
        {
            get
            {
                return this.ViewData;
            }
            set
            {
                this.ViewData = (T)value;
            }
        }
    }
}
