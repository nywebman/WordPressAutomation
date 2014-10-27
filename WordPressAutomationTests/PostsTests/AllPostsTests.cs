using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;
using WordPressAutomation.Workflows;

namespace WordPressAutomationTests.PostsTests
{
    [TestClass]
    public class AllPostsTests : WordPressTest
    {
        //Added posts show up in all posts
        [TestCategory("All Posts Page"), TestMethod]
        public void Added_Posts_Show_Up()
        { 
            //Go to posts, get post count, store
            ListPostsPage.GoTo(PostType.Posts);
            ListPostsPage.StoreCount();

            //add a new post
            PostCreator.CreatePost();

            //go to post get new post count
            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount,"Count of posts did not increase");
            
            //check for added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            //trash post (clean up)
            ListPostsPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount,"Couldnt trash post");
        }

        //can search a post
        [TestCategory("All Posts Page"), TestMethod]
        public void Can_Search_Posts()
        {
            //Create a new post
            PostCreator.CreatePost();

            //go to list posts
            ListPostsPage.GoTo(PostType.Posts);

            //search for post
            ListPostsPage.SearchForPost(PostCreator.PreviousTitle);

            //shceck that post show up in results
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            //clean up (trash posts)
            ListPostsPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldnt trash post"); //i added

        }
    }
}
