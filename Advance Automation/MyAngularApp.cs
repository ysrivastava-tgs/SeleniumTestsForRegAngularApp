using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_Automation
{
    public class MyAngularApp
    {
        private IWebDriver driver;


        public MyAngularApp(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(driver, this);
        }
        public void Goto()
        {
            this.driver.Navigate().GoToUrl("http://localhost:4200/Portfolio-Angular/");
        }
    }
}
