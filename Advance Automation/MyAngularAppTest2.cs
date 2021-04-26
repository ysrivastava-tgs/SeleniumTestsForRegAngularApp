using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Advance_Automation
{
    [TestClass]
    public class MyAngularAppTest2
    {
        [TestMethod]
        public void TestApp()
        {
            using (var driver = new ChromeDriver())
            {
                MyAngularApp app = new MyAngularApp(driver);
                app.Goto();
                var register = driver.FindElementById("register");
                register.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                  d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                  );
                var regTitle = driver.PageSource.Contains("Register");
                Assert.IsTrue(regTitle);
                driver.FindElementById("username").SendKeys("Test");
                driver.FindElementById("useremail").SendKeys("def@gmail.com");
                driver.FindElementById("userpassword").SendKeys("123456789");
                driver.FindElementById("userpassword2").SendKeys("12356789");
                driver.FindElementById("regbtn").Click();
                if(driver.FindElementById("result").Text=="Registered")
                {
                    driver.Navigate().GoToUrl("http://localhost:4200/Portfolio-Angular/");
                }
               
            }
        }
    }
}
