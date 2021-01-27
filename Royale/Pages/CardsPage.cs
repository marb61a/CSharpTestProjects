using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardsPage
    {

    }

    public class CardsPageMap
    {
        IWebDriver _driver;

        public CardsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement IceSpiritCard => _driver.FindElement(By.CssSelector("a[href*='Ice+Spirit']"));
    }
}