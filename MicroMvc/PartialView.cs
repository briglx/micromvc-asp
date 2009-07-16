using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace MicroMvc
{
    public class PartialView<T> : PartialView, IBaseView<T>
    {

        public new T ViewData { get { return (T)base.ViewData; } set { base.ViewData = (T)value; } }

    }

    public class PartialView : UserControl, IBaseView
    {
        public object ViewData { get; set; }

        public string ContentType { get; set; }

        public PartialView()
        {
            this.ContentType = "text/html";
        }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            using (System.IO.StringWriter sw = new System.IO.StringWriter(sb))
            {
                using (System.Web.UI.HtmlTextWriter textWriter = new System.Web.UI.HtmlTextWriter(sw))
                {
                    this.RenderControl(textWriter);
                }
            }

            return sb.ToString();
        }


        public bool IsReusable
        {
            get { return false; }
        }


        public void ProcessRequest(System.Web.HttpContext context)
        {
            string result = this.RenderView();

            context.Response.ContentType = this.ContentType;
            context.Response.Write(result);
            context.Response.End();
        }

        private string RenderView()
        {
            string value;
            StringBuilder sb = new StringBuilder();
            using (System.IO.StringWriter sw = new System.IO.StringWriter(sb))
            {
                using (System.Web.UI.HtmlTextWriter textWriter = new System.Web.UI.HtmlTextWriter(sw))
                {
                    this.RenderControl(textWriter);
                }
            }
            value = sb.ToString();

            return value;
        }

    }
}
