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


          
            // Pick the best view based on URL content type
            IBaseView<Student> baseView;
            if (this.Request.Url.ToString().Contains("?xml"))
            {
                baseView = new XmlView<Student>();
            }
            else if (this.Request.Url.ToString().Contains("?json"))
            {
                baseView = new JsonView<Student>();
            }
            else
            {
                baseView = (ViewPage<Student>)LoadView("~/Views/Default.aspx");
            }

            // Bind data to view and display
            baseView.ViewData = s;
            baseView.ProcessRequest(this.Context);

        }

        protected override void Execute()
        {
            Default();
        }
    }
}
