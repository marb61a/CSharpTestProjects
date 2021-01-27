using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardsPage
    {
        public readonly CardsPageMap Map;

        public CardsPage(IWebDriver driver)
        {
            Map = new CardsPageMap(driver);
        }

        public CardsPage GoTo()
        {
            
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
        IWebDriver _driver;

        public CardsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }


        // Can get any card
        public IWebElement Card(string name) => _driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}