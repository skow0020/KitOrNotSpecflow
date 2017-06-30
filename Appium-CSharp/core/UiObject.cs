using Appium_CSharp.api.android;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Drawing;

namespace Appium_CSharp.core
{
    public class UiObject
    {
        private string locator;

        public UiObject(string locator)
        {
            this.locator = locator;
        }

        private Boolean isXpath()
        {
            return !locator.Contains("UiSelector");
        }

        public Boolean exists()
        {
            try
            {
                IWebElement element;
                if (isXpath()) element = Android.driver.FindElementByXPath(locator);
                else element = Android.driver.FindElementByAndroidUIAutomator(locator);
                return element.Displayed;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        public Boolean isCheckable()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("checkable").Equals("true");
        }

        public Boolean isClickable()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("clickable").Equals("true");
        }

        public Boolean isEnabled()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("enabled").Equals("true");
        }

        public Boolean isFocusable()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("focusable").Equals("true");
        }

        public Boolean isFocused()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("focused").Equals("true");
        }

        public Boolean isScrollable()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("scrollable").Equals("true");
        }

        public Boolean isLongClickable()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("longClickable").Equals("true");
        }

        public Boolean isSelected()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("selected").Equals("true");
        }

        public string getText()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("name");
        }

        public Point getLocation()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.Location;
        }

        public string getResourceId()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("resourceId");
        }

        public string getClassName()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("className");
        }

        public string getContentDescription()
        {
            IWebElement element;
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);
            return element.GetAttribute("contentDesc");
        }

        public UiObject clearText()
        {
            if (isXpath()) Android.driver.FindElementByXPath(locator).Clear();
            else Android.driver.FindElementByAndroidUIAutomator(locator).Clear();
            return this;
        }

        public UiObject typeText(string value)
        {
            if (isXpath()) Android.driver.FindElementByXPath(locator).SendKeys(value);
            else Android.driver.FindElementByAndroidUIAutomator(locator).SendKeys(value);
            return this;
        }

        public UiObject tap()
        {
            if (isXpath()) Android.driver.FindElementByXPath(locator).Click();
            else Android.driver.FindElementByAndroidUIAutomator(locator).Click();
            return this;
        }

        public UiObject longClick()
        {
            IWebElement element;
           
            if (isXpath()) element = Android.driver.FindElementByXPath(locator);
            else element = Android.driver.FindElementByAndroidUIAutomator(locator);

            TouchAction action = new TouchAction(Android.driver);
            action.LongPress(element).Release().Perform();

            return this;
        }

        public UiObject scrollTo()
        {
            //ScrollTo is deprecated - must use swipe somehow
            //       if (!locator.contains("text")) throw new RuntimeException("Scroll to method can only be used with text attributes and current locator: " + locator + " does not contain any text attributes");
            //       if (isXpath()) Android.driver.scrollTo(locator.substring(locator.indexOf("@text-\""), locator.indexOf("\"}")).replace("@text-\"", ""));
            //       else
            //       {
            //           string text;
            //           if (locator.contains("textContains")) text = locator.substring(locator.indexOf(".textContains(\""), locator.indexOf("\")")).replace(".textContains(\"", "");
            //           else text = locator.substring(locator.indexOf(".text(\""), locator.indexOf("\")")).replace(".text(\"", "");
            //           Android.driver.scrollTo(text);
            //       }
            return this;
        }

        public UiObject waitToAppear(int seconds)
        {
            Timer timer = new Timer();
            timer.start();
            while (!timer.expired(seconds)) if (exists()) break;
            if (timer.expired(seconds) && !exists()) throw new Exception("Element " + locator + " failed to appear within " + seconds + " seconds");
            return this;
        }

        public UiObject waitToDisappear(int seconds)
        {
            Timer timer = new Timer();
            timer.start();
            while (!timer.expired(seconds)) if (!exists()) break;
            if (timer.expired(seconds) && exists()) throw new Exception("Element " + locator + " failed to disappear within " + seconds + " seconds");
            return this;
        }
    }
}
