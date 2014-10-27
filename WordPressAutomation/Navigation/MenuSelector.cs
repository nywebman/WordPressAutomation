using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WordPressAutomation
{
    public class MenuSelector
    {

        public static void Select(string topLevelMenuId, string subMenuLinkText)
        {
            Driver.Instance.FindElement(By.Id(topLevelMenuId)).Click();
            Driver.Wait(TimeSpan.FromSeconds(1));
            Driver.Instance.FindElement(By.LinkText(subMenuLinkText)).Click();
        }
    } 
}
