using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


using MicroMvc;

namespace MicroMvc.Test
{
    [TestFixture]
    public class RouteCollectionTests
    {

        RouteCollection Routes = new RouteCollection();

        [SetUp]
        public void SetUp()
        {
            Routes.Add(new Route{Url = "Default.aspx/[category]/[color]"});
            Routes.Add(new Route{Url = "Default.aspx/[userId]"});            
        }

        [Test]
        public void GetRouteDataTest()
        {
            Uri uri = new Uri("http://example.com/default.aspx/jpmorgan");
            RouteData routeData = Routes.GetRouteData(uri);
            Assert.AreEqual("jpmorgan", routeData.Values["userId"]);
        }

        [Test]
        public void SecondRouteTest()
        {
            Uri uri = new Uri("http://example.com/default.aspx/fruit/yellow");
            RouteData routeData = Routes.GetRouteData(uri);

            Assert.AreEqual("yellow", routeData.Values["color"]);
            Assert.AreEqual("fruit", routeData.Values["category"]);
        }

    }
}
