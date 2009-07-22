using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace MicroMvc
{
    public class PageView<T> : PageView, IBaseView<T>
    {
        public new T ViewData { get { return (T)base.ViewData; } set { base.ViewData = (T)value; } }
    }
    public class PageView : Page, IBaseView
    {
        public int StatusCode { get; set; }

        public PageView()
        {
            this.StatusCode = 0;
            this.ContentType = "text/html";
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (this.StatusCode != 0)
            {
                Response.StatusCode = this.StatusCode;
            }
        }
        public object ViewData { get; set; }
    }
}
