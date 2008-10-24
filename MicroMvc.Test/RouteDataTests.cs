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

    }
}
