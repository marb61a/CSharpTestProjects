using OpenQA.Selenium;
using Framework.Selenium;

namespace Royale.Pages
{
    public class CardsPage : PageBase
    {
        public readonly CardsPageMap Map;

        public CardsPage()
        {
            Map = new CardsPageMap();
        }

        public CardsPage GoTo()
        {
            HeaderNav.GoToCardsPage();
            return this;
        }
        public IWebElement GetCardByName(string cardName)
        {
            // Some cards have single names eg golem others such as Ice Spirit have more
            // Ice Spirit should become Ice+Spirit
            if(cardName.Contains(" "))
            {
                cardName = cardName.Replace(" ", "+");
            }

            return Map.Card(cardName);
        }
    }

    public class CardsPageMap
    {
        // Can get any card
        public IWebElement Card(string name) => Driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}