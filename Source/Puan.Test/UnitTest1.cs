using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puan.API;
using Xunit.Sdk;

namespace Puan.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dicon dicon = new Dicon();
            dicon.loginAsync();
        }
    }
}
