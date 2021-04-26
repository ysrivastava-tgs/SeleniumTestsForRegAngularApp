using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Advance_Automation
{
    [TestClass]
    public class IFrameTest
    {
        [TestMethod]
        public void TestCaseOne()
        {
            using(var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("file://D:/seleniun using dot net framework/SeleniumTests/Advance Automation/iframetest.html");
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => ((IJavaScriptExecutor)d)
                .ExecuteScript("return document.readyState").Equals("complete"));
                var iframes = driver.FindElementsByTagName("iframe");
                Assert.IsTrue(iframes.Count == 2);
                driver.SwitchTo().Frame(0);
                var text = driver.PageSource.Contains("responsive sites");
                Assert.IsTrue(text);
                driver.SwitchTo().DefaultContent();//if we want to switch diiferent iframes, use this method
                driver.SwitchTo().Frame(1);
                var text2 = driver.PageSource.Contains("Online Bootcamp");
                Assert.IsTrue(text2);

            }
        }
    }
}
