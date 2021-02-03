using System;
using System.Text.RegularExpressions;
using Framework.Selenium;
using Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;
using Tests.Base;

namespace Tests
{
    public class CopyDeckTests : TestBase
    {
        [Test, Category("copydeck")]
        public void User_can_copy_the_deck()
        {
            Pages.DeckBuilder.GoTo().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.Yes();
            Assert.That(Pages.CopyDeck.Map.CopiedMessage.Displayed);
        }

        [Test, Category("copydeck")]
        public void User_opens_app_store()
        {
            Pages.DeckBuilder.GoTo().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.No().OpenAppStore();

            // Removes the Unicode character `\u0200e` by "replacing" it with empty
            var title = Regex.Replace(Driver.Title, @"\u0200e", string.Empty);

            Assert.That(title, Is.EqualTo("‎Clash Royale on the App Store"));

        }

        [Test, Category("copydeck")]
        public void User_opens_google_play()
        {
            Pages.DeckBuilder.GoTo().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.No().OpenGooglePlay();
            Assert.AreEqual("Clash Royale - Apps on Google Play", Driver.Title);
        }

    }
}