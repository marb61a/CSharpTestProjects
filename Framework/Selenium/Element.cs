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

        public Element(IWebElement element, string name)
        {
            _element = element;
            Name = name;
        }

        public IWebElement Current => _element ?? throw new System.NullReferenceException("_element is null.");
        public string TagName => Current.TagName;
        public string Text => Current.Text;

        public bool Enabled => Current.Enabled;
        public bool Selected => Current.Selected;
        public bool Displayed => Current.Displayed;

        public Point Location => Current.Location;
        public Size Size => Current.Size;

        public void Clear()
        {
            Current.Clear();
        }

        public void Click()
        {
            FW.Log.Step($"Click {Name}");
            Current.Click();
        }

        public void Submit()
        {
            Current.Submit();
        }
    }
}