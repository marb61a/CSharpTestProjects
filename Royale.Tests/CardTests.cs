using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }

        public void AfterEach(){

        }

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            // Go to statsroyale.com site
            driver.Url = "https://statsroyale.com";

            // Click the cards link in the header
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();

            // Assert Ice Spirit is displayed
            var iceSpirit = driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
            Assert.That(iceSpirit.Displayed);
            
        }
    }
}