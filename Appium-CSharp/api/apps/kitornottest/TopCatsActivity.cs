using Appium_CSharp.api.android;
using Appium_CSharp.api.apps.kitTest.topCatDetails;
using Appium_CSharp.api.interfaces;
using Appium_CSharp.core;
using System;

namespace Appium_CSharp.api.apps.kitTest.topCats
{
    public class TopCatsActivity : Activity
    {
        public object waitToLoad()
        {
            try
            {
                topCatTitle().waitToAppear(10);
                return Android.app.kitornottest.topCatsActivity;
            }
            catch (Exception e)
            {
                throw new Exception("Top Cats activity failed to load/open");
            }
        }

        public TopCatDetailsActivity tapCatInGrid()
        {
            try
            {
                gridImage0().tap();
                return Android.app.kitornottest.topCatDetailsActivity;
            }
            catch (Exception e)
            {
                throw new Exception("Can't tap image in Top Cats grid, element absent or blocked");
            }
        }

        public UiObject topCatTitle() { return new UiSelector().resourceID("com.skow.kitornot:id/topCatsLabel").makeUiObject(); }
        public UiObject gridview() { return new UiSelector().resourceID("com.skow.kitornot:id/topCats").makeUiObject(); }
        public UiObject gridImage0() { return new UiSelector().className("android.widget.ImageView").index(0).makeUiObject(); }
        public UiObject gridImage1() { return new UiSelector().className("android.widget.ImageView").index(1).makeUiObject(); }
    }
}


