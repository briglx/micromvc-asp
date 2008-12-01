using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MicroMvc;

namespace MicroMvc.Test
{
    [TestFixture]
    public class CommonControllerTests
    {
        [Test, Ignore]
        public void WriteTest()
        {
            CommonController.Write("Hello!");
        }

        [Test, Ignore]
        public void RedirectTest()
        {
            CommonController.Redirect("http://example.com");
        }
    }
}
