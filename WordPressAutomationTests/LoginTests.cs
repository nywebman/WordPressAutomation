using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressAutomationTests
{
    [TestClass]
    public class LoginTests
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestCategory("Login"), TestMethod]
        public void Admin_User_Can_Login()
        {
            LoginPage.GoTo();

            //written in fluent manner
            LoginPage.LoginAs("admin")
                .WithPassword("password")
                .Login();

            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
