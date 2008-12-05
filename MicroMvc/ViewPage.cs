using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Compilation;

namespace MicroMvc
{
    public class ViewPage<T> : Page, IBaseView<T>
    {
        private T _viewData;
        public T ViewData { get; set; }

        public static ViewPage<T> LoadView(string viewName) 
        {
            Type type = BuildManager.GetCompiledType(viewName);

            // if type is null, could not determine page type
            if (type == null)
                throw new InvalidOperationException("View " + viewName + " not found");

            ViewPage<T> viewPage = (ViewPage<T>)Activator.CreateInstance(type);

            return viewPage;
        }

        public T GetViewData()
        {
            
                return _viewData;
        }

        public void SetViewData(object value)
        {
            _viewData = (T)value;
        }

    }
}
