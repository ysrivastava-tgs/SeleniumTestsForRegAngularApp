using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_Automation
{
    
    public class MyAngularAppTest
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
                var pageTitle = driver.PageSource.Contains("Register");
                Assert.IsTrue(pageTitle);
            }
        }
    }
}
