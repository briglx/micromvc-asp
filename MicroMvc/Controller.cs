using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;

namespace MicroMvc
{
    public abstract class Controller : IHttpHandler
    {

        HttpContext _context;
        HttpRequest  _request;
        HttpResponse _response;
        RouteData _routeData;

        public HttpContext Context
        {
            get { return _context; }
            set { _context = value; }
        }
        public HttpRequest Request
        {
            get { return _request; }
            set { _request = value; }
        }
        public HttpResponse Response
        {
            get { return _response; }
            set { _response = value; }
        }
        public RouteData RouteData
        {
            get { return _routeData; }
            set { _routeData = value; }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {

            this.Context = context;
            this.Request = context.Request;
            this.Response = context.Response;
            Execute();
        }

        protected abstract void Execute();

        protected internal virtual IHttpHandler LoadView(string viewName)
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
    }
}
