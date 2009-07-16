using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Compilation;

namespace MicroMvc
{
    public class ViewPage<T> : ViewPage, IBaseView<T>
    {
        public new T ViewData { get { return (T)base.ViewData; } set { base.ViewData = (T)value; } }
    }

    public class ViewPage : Page, IBaseView
    {

        public string ContentType { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            Response.ContentType = this.ContentType;
        }


        public object ViewData { get; set; }

    }
}
