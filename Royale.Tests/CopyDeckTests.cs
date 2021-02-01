using System;
using System.Text.RegularExpressions;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;

namespace Tests
{
    public class CopyDeckTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            Pages.Init();
            Driver.GoTo("https://statsroyale.com");
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        [Test]
        public void User_can_copy_the_deck()
        {
            // Go to deck builder page
            Driver.FindElement(By.CssSelector("[href='/deckbuilder']")).Click();

            // Click add card manually
            Driver.FindElement(By.XPath("//a[text()='add cards manually']")).Click();

            // Click copy deck icon
            Driver.FindElement(By.CssSelector(".copyButton")).Click();

            // Click Yes
            Driver.FindElement(By.Id("button-open")).Click();

            // Assert that the "if click yes " message is being displayed
            var copyMessage = Driver.FindElement(By.CssSelector(".notes.active"));
            Assert.That(copyMessage.Displayed);
        }
    }
}