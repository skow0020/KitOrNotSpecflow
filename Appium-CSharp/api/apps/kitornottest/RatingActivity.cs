using Appium_CSharp.api.android;
using Appium_CSharp.api.interfaces;
using Appium_CSharp.core;
using System;

namespace Appium_CSharp.api.apps.kitTest.rating
{
    public class RatingActivity : Activity
    {
        public object waitToLoad()
        {
            try
            {
                thumbUp().waitToAppear(10);
                return Android.app.kitornottest.ratingActivity;
            }
            catch (Exception e)
            {
                throw new Exception("Rating activity failed to load/open");
            }
        }

        public UiObject catImage() { return new UiSelector().description("catImage").makeUiObject(); }
        public UiObject thumbUp() { return new UiSelector().description("Thumbs up").makeUiObject(); }
        public UiObject thumbDown() { return new UiSelector().description("Thumbs down").makeUiObject(); }
    }
}
