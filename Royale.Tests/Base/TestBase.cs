using Framework;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Royale.Pages;

namespace Tests.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Init();

            // Maximize the browser window
            // Driver.Current.Manage().Window.Maximize();
            Driver.GoTo(FW.Config.Test.Url);

            // Click the accept cookies button on the popup panel
            // Driver.Current.FindElement(By.CssSelector("#cmpwelcomebtnyes > a")).Click();
        }
    }
}