using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

using MicroMvc;

namespace MicroMvc.Test
{
    [TestFixture]
    public class RouteDataTests
    {
        public RouteCollection Routes;

        [SetUp]
        public void SetUp()
        {
            Routes = new RouteCollection();

            Routes.Add(new Route
            {
                Url = "Default.aspx/[userId]"
            });
            Routes.Add(new Route
            {
                Url = @"/gadgets/workshops/workshop.ashx/[Action]\?monthYear=[strDate]"
            });
        }

        [Test]
        public void UserIDJPMorganTest()
        {
            Uri uri = new Uri("http://example.com/default.aspx/jpmorgan");
            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("jpmorgan", routeData.Values["userId"]);
        }

        [Test]
        public void UserIDBrlamoreTest()
        {
            Uri uri = new Uri("http://example.com/default.aspx/brlamore");
            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("brlamore", routeData.Values["userId"]);
        }


        [Test]
        public void ParsingBugTest()
        {
            Uri uri = new Uri("http://apophxl3t5483/Gadgets/workshops/workshop.ashx/workshopgroundstudent?monthYear=082008&zipCode=85040&milesRange=50");
            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("082008", routeData.Values["strDate"]);
        }

    }
}
