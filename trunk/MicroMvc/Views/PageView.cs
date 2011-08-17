using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace MicroMvc.Views
{
    public class PageView<T> : PageView, IBaseView<T>
    {
        public new T ViewData { get { return (T)base.ViewData; } set { base.ViewData = (T)value; } }
    }
    public class PageView : Page, IBaseView
    {
        public int StatusCode { get; set; }
        
        protected override void OnPreRender(EventArgs e)
        {
            Response.ContentType = this.ContentType;
            Response.StatusCode = this.StatusCode;
        }

        public object ViewData { get; set; }
    }
}
