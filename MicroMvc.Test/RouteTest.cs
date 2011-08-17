using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

using MicroMvc;

namespace MicroMvc.Test
{
    [TestFixture]
    public class RouteTest
    {

        [Test]
        public void RoutePatternTest()
        {
            Route r = new Route();
            r.Url = "Default.aspx/[userId]";

            Assert.AreEqual("Default.aspx/(?<userId>[^/^?]+)", r.Pattern);
        }

        [Test]
        public void RoutePatternTest2()
        {
            Route r = new Route();
            r.Url = "Default.aspx/[userName]";

            Assert.AreEqual("Default.aspx/(?<userName>[^/^?]+)", r.Pattern);
        }

        [Test]
        public void UrlMatchTest()
        {
            Route r = new Route();
            r.Url = "Default.aspx/[userName]";

            Uri uri = new Uri("http://example.com/default.aspx/jpmorgan");

            Assert.IsTrue(r.Match(uri));
        }

        [Test]
        public void UrlMatchTest2()
        {
            Route r = new Route();
            r.Url = "Default.aspx/[abba]";

            Uri uri = new Uri("http://example.com/default.aspx/brlamore/hi");

            Assert.IsTrue(r.Match(uri));
        }

        [Test]
        public void ParametersCountTest()
        {
            Route r = new Route();
            r.Url = "Default.aspx/[abba]";

            Assert.AreEqual(1,r.Parameters.Count);
        }

        [Test]
        public void ParametersCountTest2()
        {
            Route r = new Route();
            r.Url = "Default.aspx/[abba]/[real]/[cool]/";

            Assert.AreEqual(3, r.Parameters.Count);
        }

        [Test]
        public void ParametersNameTest()
        {
            Route r = new Route();
            r.Url = "Default.aspx/[abba]";

            Assert.AreEqual("abba", r.Parameters[0]);
        }

        [Test]
        public void MultipleParametersNameTest()
        {
            Route r = new Route();
            r.Url = "Default.aspx/[abba]/[cats]";

            Assert.AreEqual("abba", r.Parameters[0]);
            Assert.AreEqual("cats", r.Parameters[1]);
        }

       


    }
}
