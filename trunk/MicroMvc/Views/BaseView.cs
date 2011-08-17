using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MicroMvc.Views
{
    public interface IBaseView<T> : IBaseView
    {
       new T ViewData { get; set; }
    }

    public interface IBaseView : IHttpHandler
    {
        Object ViewData { get; set; }
        string ContentType { get; set; }
        int StatusCode { get; set; }
    }

    public abstract class BaseView<T> : BaseView, IBaseView<T>
    {
        public new T ViewData { get { return (T)base.ViewData; } set { base.ViewData = (T)value; } }
    }

    public abstract class BaseView : IBaseView
    {
        public BaseView()
        {
            this.StatusCode = 200;
            this.ContentType = "text/plain";
        }
        public Object ViewData { get; set; }
        public string ContentType { get; set; }
        public int StatusCode { get; set; }

        public virtual bool IsReusable
        {
            get { return false; }
        }

        public virtual void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }

}
