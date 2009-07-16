using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.Configuration;

namespace MicroMvc
{
    public class HtmlHelper
    {
        public static string RenderPartial(string viewName)
        {
            return HtmlHelper.RenderPartial(viewName, null);
        }
        public static string RenderPartial(string viewName, object model)
        {
            string value;
            Type type = BuildManager.GetCompiledType(viewName);

            // if type is null, could not determine page type
            if (type == null)
                throw new InvalidOperationException("View " + viewName + " not found");

            System.Web.UI.UserControl temp = new System.Web.UI.UserControl();
            PartialView partial = (PartialView)temp.LoadControl(viewName);
            partial.ViewData = model;

            StringBuilder sb = new StringBuilder();
            using (System.IO.StringWriter sw = new System.IO.StringWriter(sb))
            {
                using (System.Web.UI.HtmlTextWriter textWriter = new System.Web.UI.HtmlTextWriter(sw))
                {
                    partial.RenderControl(textWriter);
                }
            }
            value = sb.ToString();

            return value;
        }

        private  static IHttpHandler LoadView(string viewName)
        {
            // get the compiled type of referenced path
            Type type = BuildManager.GetCompiledType(viewName);

            // if type is null, could not determine page type
            if (type == null)
                throw new InvalidOperationException("View " + viewName + " not found");

            IHttpHandler view;
            if (typeof(UserControl).IsAssignableFrom(type))
            {
                System.Web.UI.UserControl temp = new System.Web.UI.UserControl();
                view = (IHttpHandler)temp.LoadControl(viewName);
            }
            else
            {
                view = (IHttpHandler)Activator.CreateInstance(type);
            }
            return view;
        }

        public static string Static(string path)
        {
            MvcSection mvcSection = (MvcSection)WebConfigurationManager.GetSection("microMvc");
            return string.Concat(mvcSection.Static.Directory, path);
        }
    }
}
