using Appium_CSharp.api.android;
using Appium_CSharp.api.apps.kitTest.selectImageActivity;
using Appium_CSharp.api.interfaces;
using Appium_CSharp.core;
using OpenQA.Selenium;
using System;

namespace Appium_CSharp.api.apps.kitTest.photoAlbumActivity
{
    public class PhotoAlbumActivity : Activity
    {
        public object waitToLoad()
        {
            try
            {
                selectAlbumTitle().waitToAppear(10);
                return Android.app.kitornottest.photoAlbumActivity;
            }
            catch (Exception e)
            {
                throw new Exception("Photo Album activity failed to load/open");
            }
        }

        public SelectImageActivity tapMainImage()
        {
            try
            {
                mainCameraImg().tap();
                return Android.app.kitornottest.selectImageActivity;
            }
            catch (NoSuchElementException e)
            {
                throw new Exception("Can't tap main image button, element absent or blocked");
            }
        }

        public UiObject selectAlbumTitle() { return new UiSelector().text("Select album").makeUiObject(); }
        public UiObject mainCameraImg() { return new UiSelector().className("android.view.View").makeUiObject(); }
    }
}
