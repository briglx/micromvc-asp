using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MicroMvc.WebTest
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FormattedName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public string statusMessage { get; set; }
    }
}
