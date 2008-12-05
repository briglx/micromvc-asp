using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;


using MicroMvc;

namespace MicroMvc.Test
{
    [TestFixture]
    public class RouteCollectionTests
    {

        RouteCollection Routes = RouteCollection.Instance;
        delegate RouteData AsyncGetRouteData(Uri url);
        static string realString = "";
        static int count = 1;


        [SetUp]
        public void SetUp()
        {
            Routes.Add(new Route { Url = "Default.aspx/[category]/[color]" });
            Routes.Add(new Route { Url = "Default.aspx/[userId]" });
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

        [Test]
        public void MulitThreadTest()
        {
            Thread start = new Thread(new ThreadStart(GetRouteData));

            start.Start();
            for (int x = 0; x < 1000; x++)
            {

                if (false)
                {
                    GetRouteData();
                }
                else
                {
                    Thread a = new Thread(new ThreadStart(GetRouteData));
                    Thread b = new Thread(new ThreadStart(GetRouteData));
                    a.Start();
                    b.Start();
                    
                }
            }
            Thread.Sleep(1000);
            start.Join();
            Assert.IsTrue(true);

        }

        private void GetRouteData()
        {
            Routes.GetRouteData(new Uri("http://example.com/default.aspx/fruit/yellow"));
        }
    }
}

