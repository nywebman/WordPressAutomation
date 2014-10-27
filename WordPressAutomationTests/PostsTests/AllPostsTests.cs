using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordPressAutomationTests.PostsTests
{
    [TestClass]
    public class AllPostsTests : WordPressTest
    {
        //added posts show up in all posts
        //bulk action
        //can search
        //etc ideas for tests...

        //Added posts show up in all posts
        //can trash a post
        //can search a post


        [TestCategory("All Posts Page"), TestMethod]
        public void Added_Posts_Show_Up()
        { 
            //Go to posts, get post count, store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            //add a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Aded posts show up, title")
                .WithBody("Added posts show up, body")
                .Publish();

            //go to postsm get new post count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount,"Count of posts did not increase");
            
            //check for added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle("Aded posts show up, title"));

            //trash post (clean up)
            ListPostsPage.TrashPost("Aded posts show up, title");
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount,"Couldnt trash post");
        }
    }
}
