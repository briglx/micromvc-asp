using System;
using System.Collections.Generic;
using System.Text;

namespace MicroMvc
{
    /// <summary>
    /// Encapsulates Common Processes and workflow.
    /// </summary>
    public class CommonController : Controller
    {
        private void DefaultAction()
        {
            throw new NotImplementedException();
        }
        private void RedirectAction(string url, bool endResponse)
        {
            // Get a view
            RedirectView view = new RedirectView();

            // Get data
            RedirectViewData viewData = new RedirectViewData();
            viewData.Url = url;
            viewData.EndResponse = endResponse;

            // Bind
            view.ViewData = viewData;
            view.ProcessRequest(this.Context);
        }

        private void WriteAction(string message)
        {
            // Get a view
            TextView<string> view = new TextView<string>();

            // Bind data
            view.ViewData = message;
            view.ProcessRequest(this.Context);
        }

        public static void Redirect(string url)
        {
            CommonController controller = new CommonController();
            controller.RedirectAction(url, false);
        }
        public static void Write(string message)
        {
            CommonController controller = new CommonController();
            controller.WriteAction(message);
        }

        protected override void Execute()
        {
            this.DefaultAction();
        }
    }
}
