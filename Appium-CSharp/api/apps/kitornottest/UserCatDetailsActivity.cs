using Appium_CSharp.api.android;
using Appium_CSharp.api.interfaces;
using Appium_CSharp.core;
using System;

namespace Appium_CSharp.api.apps.kitTest.userCatDetails
{
    public class UserCatDetailsActivity: Activity
    {
        public object waitToLoad()
        {
            try
            {
                catImage().waitToAppear(10);
                return Android.app.kitornottest.userCatDetailsActivity;
            }
            catch (Exception e)
            {
                throw new Exception("User Cat Details activity failed to load/open");
            }
        }

        public UiObject catImage() { return new UiSelector().description("catImage").makeUiObject(); }
        public UiObject percentage() { return new UiSelector().resourceID("com.skow.kitornot:id/percent").makeUiObject(); }
    }

}
