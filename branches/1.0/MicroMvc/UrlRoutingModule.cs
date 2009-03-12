using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Compilation;

namespace MicroMvc
{
    public sealed class UrlRoutingModule : IHttpModule
    {
        private static RouteCollection _routes = RouteCollection.Instance;
      
        void IHttpModule.Init(HttpApplication context)
        {
            context.PostMapRequestHandler += new EventHandler(Application_PostMapRequestHandler);
            LoadConfiguration(); // Fired once when the module is first created.
        }

        private void Application_PostMapRequestHandler(object sender, EventArgs evargs)
        {

            RouteData routeData = _routes.GetRouteData(HttpContext.Current.Request.Url);

            // Found match
            if (routeData != null)
            {
                Route r = routeData.Route;
                Type type = BuildManager.GetType(r.Handler, true);
                Controller c = (Controller)Activator.CreateInstance(type);
                c.RouteData = routeData;

                HttpContext.Current.Handler = c;
            }
        }

        void IHttpModule.Dispose(){}

        private static void LoadConfiguration()
        {
            MvcSection mvcSection;
            mvcSection = (MvcSection)WebConfigurationManager.GetSection("microMvc");

            foreach (RouteSettings r in mvcSection.Routes)
            {
                _routes.Add(new Route(r.Url,r.Handler));
            }

            
        }

    }
}
