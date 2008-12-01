using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MicroMvc
{
    public class RedirectView : IHttpHandler
    {
        public RedirectViewData ViewData { get; set; }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Redirect(this.ViewData.Url,this.ViewData.EndResponse);
        }

    }

    public class RedirectViewData
    {
        public string Url { get; set; }
        public bool EndResponse { get; set; }
    }
}
