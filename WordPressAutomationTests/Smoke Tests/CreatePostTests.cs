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
    public class CreatePostTests : WordPressTest
    {
        [TestCategory("Login"), TestMethod]
        public void Admin_User_Can_Create_A_Basic_Post()
        {
            NewPostPage.GoTo();
            NewPostPage.CreatePost("this is the title".ToUpper()).WithBody("this is the body").Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title.ToUpper(),"this is the title".ToUpper(),"Title did not match new post");
        }
    }
}
