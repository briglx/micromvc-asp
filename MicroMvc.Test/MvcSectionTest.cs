using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;

using NUnit.Framework;


using MicroMvc;

namespace MicroMvc.Test
{
    [TestFixture]
    public class MvcSectionTest
    {
        [Test]
        public void GetRouteDataTest()
        {
            MvcSection section = (MvcSection)WebConfigurationManager.GetSection("apolloMvc");

            RouteSettings site = section.Routes["default"];
            Assert.AreEqual("/profile/{userId]",site.Url);


        }
    }
}
