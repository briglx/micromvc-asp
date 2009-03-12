using System;
using System.Collections.Generic;
using System.Text;

namespace MicroMvc
{
    public class ViewData
    {
        protected virtual string ResolveUrl(string relativeUrl)
        {
            return UrlHelper.ResolveUrl(relativeUrl);
        }
    }
}
