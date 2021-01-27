using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));

            // Go to statsroyale.com site
            driver.Url = "https://statsroyale.com";
        }

        public void AfterEach(){

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

        public void Ice_Spirit_headers_are_correct_on_Details_Page()
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

    }
}