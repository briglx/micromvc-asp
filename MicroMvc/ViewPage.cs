using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Compilation;

namespace MicroMvc
{
    [Obsolete("Use PageView<T> instead")]
    public class ViewPage<T> : ViewPage, IBaseView<T>
    {
        public new T ViewData { get { return (T)base.ViewData; } set { base.ViewData = (T)value; } }
    }

    [Obsolete("Use PageView instead")]
    public class ViewPage : Page, IBaseView
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
