using System;
using OpenQA.Selenium;

namespace Framework.Selenium
{
    public sealed class WaitConditions
    {
        public static Func<IWebDriver, bool> ElementDisplayed(IWebElement element)
        {
            bool condition(IWebDriver driver)
            {
                return element.Displayed;
            }

            return condition;
        }

        public static Func<IWebDriver, IWebElement> ElementIsDisplayed(IWebElement element)
        {
            IWebElement condition(IWebDriver driver)
            {
                try
                {
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (ElementNotVisibleException)
                {
                    return null;
                }
                
            }

            return condition;
        }
    }
}