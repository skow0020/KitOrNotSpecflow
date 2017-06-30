using Appium_CSharp.api.android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;

namespace Appium_CSharp.core.managers
{
    class DriverManager
    {
        private static string nodeJS = "C:/Users/Colin/AppData/Roaming/nvm/v6.10.0/node.exe";
        private static string appiumJS = "C:/Program Files(x86)/Appium/node_modules/.bin/appium/node_modules/appium/bin/appium.js";
        private static AppiumLocalService service;
        private static string deviceID = "VS9854G9e1c8906";

        private static Dictionary<string, Uri> hosts;

        private static DesiredCapabilities getCaps(string deviceID)
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("udid", deviceID);
            caps.SetCapability("platformVersion", "6.0");
            caps.SetCapability("deviceName", "MyAndroid");
            caps.SetCapability("platformName", "Android");
            caps.SetCapability("fullReset", "true");
            caps.SetCapability("app", "C:\\Users\\Colin\\Desktop\\Appium-CSharp\\Appium-CSharp\\apks\\kit-or-not.apk");
            return caps;
        }

        private static Uri host(string deviceID)
        {
            if (hosts == null)
            {
                hosts = new Dictionary<string, Uri>();
                hosts.Add(deviceID, new Uri("http://127.0.0.1:4723/wd/hub"));
                //For running tests in parallel on different appium servers
                //            hosts.put("deviceID", new URL("http://127.0.0.1:4724/wd/hub"));
                //            hosts.put("deviceID", new URL("http://127.0.0.1:4725/wd/hub"));
            }
            return hosts[deviceID];
        }

        private static List<string> getAvailableDevices()
        {
            List<string> availableDevices = new List<string>();
            availableDevices.Add(deviceID);
            //ArrayList connectedDevices = ADB.getConnectedDevices();

            ////Check if package is installed on the device
            //foreach (Object connectedDevice in connectedDevices)
            //{
            //    string device = connectedDevice.ToString();
            //    ArrayList apps = new ADB(device).getInstalledPackages();
            //    if (!apps.Contains(unlockPackage)) availableDevices.Add(device);
            //    else
            //        Console.Out.WriteLine("Device: " + device + " has " + unlockPackage + " installed, assuming it is under testing");
            //}
            //if (availableDevices.Count() == 0) throw new Exception("Not a single device is available for testing at this time");
            return availableDevices;
        }

        private static AppiumLocalService createService()
        {
            string [] parts = host(deviceID).ToString().Split(':');
            service = new AppiumServiceBuilder()
                .UsingDriverExecutable(new FileInfo(nodeJS))
                .WithAppiumJS(new FileInfo(appiumJS))
                .WithIPAddress(parts[1].Replace("//", ""))
                .UsingPort(Int32.Parse(parts[2].Replace("/wd/hub", "")))
                .Build();
        return service;
    }

    public static void createDriver(string deviceID)
    {
        //createService().Start();
        Android.driver = new AndroidDriver<AppiumWebElement>(host(deviceID), getCaps(deviceID));
        Android.adb = new ADB(deviceID);
    }

    public static void killDriver()
    {
        if (Android.driver != null)
        {
            Android.driver.Quit();
            //Android.adb.uninstallApp(unlockPackage);
            //service.Dispose();
        }
        else
        {
            //MyLogger.log.info("Android Driver is not initialized, nothing to kill");
        }
    }
}
}
