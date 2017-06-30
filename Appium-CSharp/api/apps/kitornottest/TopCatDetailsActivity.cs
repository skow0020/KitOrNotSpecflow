using Appium_CSharp.api.android;
using Appium_CSharp.api.interfaces;
using Appium_CSharp.core;
using System;

namespace Appium_CSharp.api.apps.kitTest.topCatDetails
{
    public class TopCatDetailsActivity : Activity
    {
        public object waitToLoad()
        {
            try
            {
                catImage().waitToAppear(10);
                return Android.app.kitornottest.topCatDetailsActivity;
            }
            catch (Exception e)
            {
                throw new Exception("Top Cat Details activity failed to load/open");
            }
        }

        public UiObject catImage() { return new UiSelector().description("catImage").makeUiObject(); }
        public UiObject percentage() { return new UiSelector().resourceID("com.skow.kitornot:id/percent").makeUiObject(); }
    }
}
