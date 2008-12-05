using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MicroMvc
{
    public class RedirectView : IBaseView<RedirectViewData>
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
        public RedirectViewData() : this(string.Empty, false) { }
        public RedirectViewData(string url, bool endResponse)
        {
            this.Url = url;
            this.EndResponse = endResponse;
        }

        public string Url { get; set; }
        public bool EndResponse { get; set; }
        
        
    }
}
