using System.IO;
using System.Linq;
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

        public void Ice_Spirit_headers_are_correct_on_Details_Page()
        {
            // Go to statsroyale.com site
            driver.Url = "https://statsroyale.com";

            // Click the cards link in the header
            driver.FindElement(By.CssSelector("a[href='/cards']")).Click();

            // Go to ice spirit
            driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
            
            // Assert basic header stats
            var cardName = driver.FindElement(By.CssSelector("[class*='cardName']")).Text;
            var cardCategories = driver.FindElement(By.CssSelector(".card__rariry")).Text.Split(", ");
            var cardType = cardCategories[0];
            var cardArena = cardCategories[1];
            var cardRarity = driver.FindElement(By.CssSelector(".card__common")).Text;

            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", cardType);
            Assert.AreEqual("Arena 8", cardArena);
            Assert.AreEqual("Common", cardRarity);

        }

    }
}