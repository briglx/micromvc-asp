using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace MicroMvc
{
    public class ViewPage<T> : Page, IBaseView<T>
    {
        public T ViewData { get; set; }
    }
}
