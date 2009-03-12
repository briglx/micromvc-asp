using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using MicroMvc;

namespace MicroMvc.WebTest.Controllers
{
    public class StudentController : Controller
    {
        private void Default()
        {
            // Show the Default View
            Student s = new Student();
            s.FirstName = this.RouteData.Values["name"];
            s.LastName = "Howza";
            s.Phone = "555-4459";


            IBaseView<Student> baseView;
            if (false)
            {
                baseView = (ViewPage<Student>)LoadView("~/Views/Default.aspx");
            }
            else
            {
                baseView = new XmlView<Student>();
            }
            baseView.ViewData = s;
            baseView.ProcessRequest(this.Context);

        }

        protected override void Execute()
        {
            Default();
        }
    }
}
