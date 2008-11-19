using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MicroMvc
{
    public interface IBaseView<T> : IHttpHandler
    {
        T ViewData { get; set; }
    }
}
