using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MicroMvc
{
    public interface IBaseView<T> : IBaseView
    {
       new T ViewData { get; set; }
    }

    public interface IBaseView : IHttpHandler
    {
        Object ViewData { get; set; }
    }

}
