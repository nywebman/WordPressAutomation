﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WordPressAutomation
{
    public class ListPostsPage
    {
        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    Driver.Instance.FindElement(By.Id("menu-pages")).Click();
                    Thread.Sleep(100);
                    Driver.Instance.FindElement(By.LinkText("All Pages")).Click();
                    break;
            }
        }


        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }
    }
    public enum PostType
    {
        Page
    }
}
