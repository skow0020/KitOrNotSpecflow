using Appium_CSharp.api.android;
using Appium_CSharp.api.apps.kitTest.home;
using Appium_CSharp.api.interfaces;
using Appium_CSharp.core;
using OpenQA.Selenium;
using System;

namespace Appium_CSharp.api.apps.kitTest.selectImageActivity
{
    public class SelectImageActivity : Activity
    {
        public object waitToLoad()
        {
            try
            {
                selectAlbumTitle().waitToAppear(10);
                return Android.app.kitornottest.selectImageActivity;
            }
            catch (Exception e)
            {
                throw new Exception("Select Image activity failed to load/open");
            }
        }

        public UserHomeActivity tapSelectImage()
        {
            try
            {
                mainScreen().tap();
                return Android.app.kitornottest.userHomeActivity;
            }
            catch (NoSuchElementException e)
            {
                throw new Exception("Can't tap select image button, element absent or blocked");
            }
        }

        public UiObject selectAlbumTitle() { return new UiSelector().text("Select image").makeUiObject(); }
        public UiObject mainScreen() { return new UiSelector().className("android.view.View").makeUiObject(); }

    }
}

