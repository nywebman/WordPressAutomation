using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressAutomationTests
{
    [TestClass]
    public class LoginTests : WordPressTest
    {
        [TestCategory("Login"), TestMethod]
        public void Admin_User_Can_Login()
        {
            //Still makes sense for a sense that only it only tests login even though other
            //ones are also logging in
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");
        }

    }
}
