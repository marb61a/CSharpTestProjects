using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class DeckBuilderPage : PageBase
    {
        public readonly DeckBuilderPageMap Map;

        public DeckBuilderPage()
        {
            Map = new DeckBuilderPageMap();
        }

        public DeckBuilderPage GoTo()
        {
            HeaderNav.Map.DeckBuilderLink.Click();
            Driver.Wait.Until(drvr => Map.AddCardsManuallyLink.Displayed);
            return this;
        }

        public void AddCardsManually()
        {
            Map.AddCardsManuallyLink.Click();
            Driver.Wait.Until(drvr => Map.CopyDeckIcon.Displayed);
        }

        public void CopySuggestedDeck()
        {
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        public IWebElement AddCardsManuallyLink => Driver.FindElement(By.CssSelector(""));
        public IWebElement CopyDeckIcon => Driver.FindElement(By.XPath("//a[text()='add cards manually']"));
    }

}