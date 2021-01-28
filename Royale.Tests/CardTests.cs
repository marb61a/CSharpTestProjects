using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;
using Framework.Models;
using Framework.Services;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Go to statsroyale.com site
            driver.Url = "https://statsroyale.com";

            // Click the accept cookies button on the popup panel
            driver.FindElement(By.CssSelector("#cmpwelcomebtnyes > a")).Click();
            
        }

        public void AfterEach(){
            // Close the browser window
            driver.Quit();
        }

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            // Click the cards link in the header
            // driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            var cardsPage = new CardsPage(driver);
            var iceSpirit = cardsPage.GoTo().GetCardByName("Ice Spirit");

            // Assert Ice Spirit is displayed
            Assert.That(iceSpirit.Displayed);

        }

        [Test]
        public void Ice_Spirit_headers_are_correct_on_Card_Details_Page()
        {

            new CardsPage(driver).GoTo().GetCardByName("Ice Spirit").Click();
            var cardDetails = new CardDetailsPage(driver);
            
            var (category, arena) = cardDetails.GetCardCategory();
            var cardName = cardDetails.Map.CardName.Text;
            var cardRarity = cardDetails.Map.CardRarity.Text.Split('\n').Last();

            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Troop", category);
            Assert.AreEqual("Arena 8", arena);
            Assert.AreEqual("Common", cardRarity);

        }

        [Test]
        [TestCase("Ice Spirit")]
        [TestCase("Mirror")]
        public void Mirror_headers_are_correct_on_Card_Details_Page()
        {

            new CardsPage(driver).GoTo().GetCardByName("Mirror").Click();
            var cardDetails = new CardDetailsPage(driver);

            var cardOnPage = cardDetails.GetBaseCard();
            var mirror = new InMemoryCardService().GetCardByName("Mirror");

            Assert.AreEqual(mirror.Name, cardOnPage.Name);
            Assert.AreEqual(mirror.Type, cardOnPage.Type);
            Assert.AreEqual(mirror.Arena, cardOnPage.Arena);
            Assert.AreEqual(mirror.Rarity, cardOnPage.Rarity);

        }

    }
}