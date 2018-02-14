using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

using Selenium;

namespace SeleniumTests
{
    [TestFixture]
    public class WebUrlClick_RC
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        /// <summary>
        /// Valid for older version
        /// java -jar C:\zheng\Test\selenium\RCServer\selenium-server-standalone-2.53.1.jar
        /// Only test for IE.
        /// Firefox have version match requirement
        /// ref http://blog.csdn.net/u011159607/article/details/53317489
        /// selenium RC+JAVA 运行所遇到的问题
        /// IE need to turn off protect mode to work out
        /// While webdriver test need to turn on protect mode, jsut clarify
        /// Need to install RC nuget package
        /// Install-Package Selenium.RC -Version 3.1.0
        /// 
        /// Test working with standalone server 2.51, nuget RC 2.51
        /// 
        /// Backed 3.1 can work with warning 3.2 will report error for dup declaration
        /// IWebDriver driver = new FirefoxDriver();
        /// selenium = new WebDriverBackedSelenium(driver, "https://www.github.com/");
        /// Backed depend on both RC and WebDriver
        /// Need to install Backed nuget package
        /// 
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            //selenium = new DefaultSelenium("localhost", 4444, "*chrome C:/Program Files(x86)/Google/Chrome/Application/chrome.exe", "https://github.com/");
            //selenium = new DefaultSelenium("localhost", 4444, "*googlechrome", "https://github.com/");
            selenium = new DefaultSelenium("localhost", 4444, "*iexplore", "https://github.com/");
            //selenium = new DefaultSelenium("localhost", 4444, "iexploreproxy", "https://github.com/");
            //selenium = new DefaultSelenium("localhost", 4444, "*iexplore C:/Program Files/Internet Explorer/iexplore.exe", "https://github.com/");
            //selenium = new DefaultSelenium("localhost", 4444, "*firefox C://zheng//Test//selenium//FirefoxPortable64//FirefoxPortable.exe", "https://github.com/");
            //selenium = new DefaultSelenium("localhost", 4444, "*firefox", "https://github.com/");

            //IWebDriver driver = new FirefoxDriver();
            //selenium = new WebDriverBackedSelenium(driver, "https://www.github.com/");

            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheWebUrlClick_RCTest()
        {
            selenium.Open("/SeleniumHQ/selenium/wiki/SeIDEReleaseNotes");
            selenium.Click("link=SeleniumHQ");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("css=span.repo.js-repo");
            selenium.WaitForPageToLoad("30000");
        }
    }
}
