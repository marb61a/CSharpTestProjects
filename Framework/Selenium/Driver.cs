using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Selenium
{
    public static class Driver 
    {
        [ThreadStatic]
        public static IWebDriver _driver;

        [ThreadStatic]
        public static Wait Wait;

        public static void Init()
        {
            FW.Log.Info("Browser: Chrome");
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
            Wait = new Wait(10);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public static string Title => Current.Title;

        public static void GoTo(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            // Debug.WriteLine(url);
            FW.Log.Info(url);
            Current.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public static void Quit()
        {
            FW.Log.Info("Close Browser");
            Current.Quit();
        }

    }
}