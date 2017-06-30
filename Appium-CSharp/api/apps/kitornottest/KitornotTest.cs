using Appium_CSharp.api.android;
using Appium_CSharp.api.apps.kitTest.home;
using Appium_CSharp.api.apps.kitTest.login;
using Appium_CSharp.api.apps.kitTest.photoAlbumActivity;
using Appium_CSharp.api.apps.kitTest.rating;
using Appium_CSharp.api.apps.kitTest.selectImageActivity;
using Appium_CSharp.api.apps.kitTest.topCatDetails;
using Appium_CSharp.api.apps.kitTest.topCats;
using Appium_CSharp.api.apps.kitTest.userCatDetails;
using Appium_CSharp.api.interfaces;
using Appium_CSharp.core;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using System;

namespace Appium_CSharp.api.apps.kitornottest
{
    public class KitornotTest : Application
    {
        public Login login = new Login();
        public UserHomeActivity userHomeActivity = new UserHomeActivity();
        public RatingActivity ratingActivity = new RatingActivity();
        public TopCatsActivity topCatsActivity = new TopCatsActivity();
        public TopCatDetailsActivity topCatDetailsActivity = new TopCatDetailsActivity();
        public UserCatDetailsActivity userCatDetailsActivity = new UserCatDetailsActivity();
        public PhotoAlbumActivity photoAlbumActivity = new PhotoAlbumActivity();
        public SelectImageActivity selectImageActivity = new SelectImageActivity();

        public string activityID()
        {
            throw new NotImplementedException();
        }

        public void clearData()
        {
            Android.adb.clearAppsData(packageID());
        }

        public void forceStop()
        {
            Android.adb.forceStopApp(packageID());
        }

        public object open()
        {
            Android.adb.openAppsActivity(packageID(), activityID());
            return null;
        }

        public string packageID()
        {
            throw new NotImplementedException();
        }

        public void verifyElementExists(UiObject element)
        {
            Assert.IsTrue(element.exists(), "Element was not found: " + element);
        }

        public void clickBack() { Android.driver.PressKeyCode(AndroidKeyCode.Back); }
    }
}
