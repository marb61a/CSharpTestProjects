using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace Framework
{
    public class Window
    {
        public ReadOnlyCollection<string> CurrentWindows => Driver.Current.WindowHandles;

        public void SwitchTo(int windowIndex)
        {
            Driver.Current.SwitchTo().Window(CurrentWindows[windowIndex]);
        }

        public Size ScreenSize
        {
            get 
            {
                
            }
        }

        public void Maximize()
        {

        }
    }
}