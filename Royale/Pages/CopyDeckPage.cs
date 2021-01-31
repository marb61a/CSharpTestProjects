using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CopyDeckPage
    {
        public readonly CopyDeckPageMap Map;

        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public CopyDeckPage Yes()
        {

        }
    }

    public class CopyDeckPageMap
    {
        public IWebElement YesButton => Driver.FindElement(By.Id("button-open"));
        
    }    
}