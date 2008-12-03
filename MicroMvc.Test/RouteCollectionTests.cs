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

        RouteCollection Routes = RouteCollection.Instance;
        delegate RouteData AsyncGetRouteData(Uri url);
        static string realString = "";
        static int count = 1;


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

        [Test]
        public void MulitThreadTest()
        {
            int testCount = 100000;

            Uri uri = new Uri("http://example.com/default.aspx/fruit/yellow");

            string s = "";

            for (int x = 0; x < testCount; x++)
            {
                // Call async call to GetRouteData
                AsyncGetRouteData asyncGetData = new AsyncGetRouteData(GetRouteData);
                AsyncGetRouteData asyncGetData2 = new AsyncGetRouteData(GetRouteData2);
                AsyncGetRouteData asyncGetData3 = new AsyncGetRouteData(GetRouteData3);

                asyncGetData.BeginInvoke(uri, null, null);
                s += ".";
                asyncGetData2.BeginInvoke(uri, null, null);
                s += "x";
                asyncGetData3.BeginInvoke(uri, null, null);
                s += "-";

                
            }

            System.Diagnostics.Trace.Write("Done " + count);

            while (count < (3 * testCount)) ;

            System.Diagnostics.Trace.Write("Done again " + count);
            Assert.AreNotEqual(s, realString);

        }

        private RouteData GetRouteData(Uri url)
        {
            // Radomize a wait
            Random r = new Random();

            realString += ".";
            count++;

            int x = r.Next(1, 2);
            System.Threading.Thread.Sleep(x);
            return Routes.GetRouteData(url);

        }
        private RouteData GetRouteData2(Uri url)
        {
            // Radomize a wait
            Random r = new Random();

            realString += "x";
            count++;

            int x = r.Next(2, 3);
            System.Threading.Thread.Sleep(x);
            return Routes.GetRouteData(url);

        }
        private RouteData GetRouteData3(Uri url)
        {
            // Radomize a wait
            Random r = new Random();

            realString += "-";
            count++;

            int x = r.Next(3, 4);
            System.Threading.Thread.Sleep(x);
            return Routes.GetRouteData(url);

        }

    }
}

