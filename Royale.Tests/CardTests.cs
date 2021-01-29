using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;
using Framework.Models;
using Framework.Services;
using Framework.Selenium;

namespace Tests
{
    public class CardTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();

            // Maximize the browser window
            Driver.Current.Manage().Window.Maximize();

            // Go to statsroyale.com site
            Driver.Current.Url = "https://statsroyale.com";

            // Click the accept cookies button on the popup panel
            Driver.Current.FindElement(By.CssSelector("#cmpwelcomebtnyes > a")).Click();
            
        }

        public void AfterEach(){
            // Close the browser window
            Driver.Current.Quit();
        }

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            // Click the cards link in the header
            // driver.FindElement(By.CssSelector("a[href='/cards']")).Click();
            var iceSpirit = Pages.Cards.GoTo().GetCardByName("Ice Spirit");

            // Assert Ice Spirit is displayed
            Assert.That(iceSpirit.Displayed);

        }

        static string[] cardNames = { "Ice Spirit", "Mirror" };

        [Test, Category("cards")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Card_Details_Page(string cardName)
        {
            Pages.Cards.GoTo().GetCardByName(cardName).Click();

            var cardOnPage = Pages.CardDetails.GetBaseCard();
            var card = new InMemoryCardService().GetCardByName(cardName);

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);

        }

    }
}