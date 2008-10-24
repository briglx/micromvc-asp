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
            s.FirstName = "John";
            s.LastName = "Howza";
            s.Phone = "555-4459";

            ViewPage<Student> v = (ViewPage<Student>)LoadView("~/Views/Default.aspx");

            v.ViewData = s;

            v.ProcessRequest(this.Context);
            

        }

        protected override void Execute()
        {
            Default();
        }
    }
}
