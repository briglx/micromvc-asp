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
            Routes = RouteCollection.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            Routes = null;
        }

        [Test]
        public void UserIDJPMorganTest()
        {
            Routes.Add(new Route
            {
                Url = "Default.aspx/[userId]"
            });
            Uri uri = new Uri("http://example.com/default.aspx/jpmorgan");
            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("jpmorgan", routeData.Values["userId"]);
        }

        [Test]
        public void UserIDBrlamoreTest()
        {
            Routes.Add(new Route
            {
                Url = "Default.aspx/[userId]"
            });
            Uri uri = new Uri("http://example.com/default.aspx/brlamore");
            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("brlamore", routeData.Values["userId"]);
        }


        [Test]
        public void ParsingBugTest()
        {
            Routes.Add(new Route
            {
                Url = @"/gadgets/workshops/workshop.ashx/[Action]\?monthYear=[strDate]&zipCode"
            });
            Uri uri = new Uri("http://apophxl3t5483/Gadgets/workshops/workshop.ashx/workshopgroundstudent?monthYear=082008&zipCode=85040&milesRange=50");
            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("082008", routeData.Values["strDate"]);
        }

        [Test]
        public void OptionalParameterBugTest()
        {
            Routes.Add(new Route
            {
                Url = "Default.aspx/[userId]/(resultFormat=[ResultFormat])?"
            });

            Uri uri = new Uri("http://apophxl3t5483/Default.aspx/brig/resultFormat=xml");
            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("xml",routeData.Values["ResultFormat"]);
        }

        [Test]
        public void NoTrailingSlashTest()
        {
            Routes.Add(new Route
            {
                Url = @"/profile/[userId]/[action]/?$"
            });

            Uri uri = new Uri("http://ecampus.phoenix.edu/community/profile/brlamore/edit");
            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("edit", routeData.Values["action"]);

        }

        [Test]
        public void TrailingSlashTest()
        {
            Routes.Add(new Route
            {
                Url = @"/profile/[userId]/[action]/?$"
            });

            Uri uri = new Uri("http://ecampus.phoenix.edu/community/profile/brlamore/edit/");
            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("edit", routeData.Values["action"]);
          
        }

        [Test]
        public void ParamterTest()
        {
            Routes.Add(new Route
            {
                Url = @"roster/[orgaId]/[course]/[courseId]/[groupId]/([view]\?[action]=[param])?"
            });


            Uri uri = new Uri("http://ecampus.phoenix.edu/community/roster/4/gmt/550/gmt550ab32/default?sort=fn");

            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("default", routeData.Values["view"]);
            Assert.AreEqual("sort", routeData.Values["action"]);
            Assert.AreEqual("fn", routeData.Values["param"]);
        }
        [Test]
        public void ParamterWithOutTest()
        {
            Routes.Add(new Route
            {
                Url = @"roster/[orgaId]/[course]/[courseId]/[groupId]/([view]\?[action]=[param])?"
            });


            Uri uri = new Uri("http://ecampus.phoenix.edu/community/roster/4/gmt/550/gmt550ab32/");

            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("gmt550ab32", routeData.Values["groupId"]);
        }

        [Test]
        public void SortTest()
        {
            Routes.Add(new Route
            {
                Url = @"roster/[orgaId]/[course]/[courseId]/[groupId]/([view])?"
            });


            Uri uri = new Uri("http://ecampus.phoenix.edu/community/roster/4/gmt/550/gmt550ab32/default?sort=fn");

            RouteData routeData = this.Routes.GetRouteData(uri);
            Assert.AreEqual("gmt550ab32", routeData.Values["groupId"]);
            Assert.AreEqual("default", routeData.Values["view"]);
        }

      

    }
}
