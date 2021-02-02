using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Framework.Selenium
{
    public class Element : IWebElement
    {
        private readonly IWebElement _element;
        public readonly string Name;
        public By FoundBy { get; set; }

        public Element()
        {
            
        }
    }
}