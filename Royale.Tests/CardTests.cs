using System.IO;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;
using Framework;
using Framework.Models;
using Framework.Services;
using Framework.Selenium;
using Tests.Base;

namespace Tests
{
    public class CardTests : TestBase
    {
        static IList<Card> apiCards = new ApiCardService().GetAllCards();

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_is_on_Cards_Page(Card card)
        {
            var cardOnPage = Pages.Cards.GoTo().GetCardByName(card.Name);

            Assert.That(cardOnPage.Displayed);

        }

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Card_Details_Page(Card card)
        {
            Pages.Cards.GoTo().GetCardByName(card.Name).Click();

            var cardOnPage = Pages.CardDetails.GetBaseCard();
            if(cardOnPage.Type == "troop")
            {
                cardOnPage.Type = "character";
            }

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
            Assert.That(card.Type.Contains(cardOnPage.Type));

        }
    }
}