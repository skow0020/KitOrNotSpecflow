using Appium_CSharp.api.apps;
using Appium_CSharp.core;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appium_CSharp.api.android
{
    class Android
    {
        public static AndroidDriver<AppiumWebElement> driver;
        public static ADB adb;
        public static Apps app = new Apps();
    }
}
