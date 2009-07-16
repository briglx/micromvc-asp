using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

using MicroMvc;
using MicroMvc.Test.Web;

namespace MicroMvc.Test
{
    [TestFixture]
    public class ViewTests
    {
        [Test, Ignore]
        public void LoadViewTest()
        {
            //IBaseView<TestViewData> view = ViewPage<TestViewData>.LoadView("~/Views/TestView.aspx");
            Assert.IsTrue(true);
        }
    }
}
