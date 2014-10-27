using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressAutomationTests
{
    [TestClass]
    public class PageTests
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestCategory("Login"), TestMethod]
        public void Can_Edit_A_Page()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("admin").WithPassword("password").Login();

            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.SelectPost("Sample Page");

         //   Assert.IsTrue(NewPostPage.IsInEditMode(),"Wasnt in edit mode");
            Assert.AreEqual("Sample Page",NewPostPage.Title,"Title did not match");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
