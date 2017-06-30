using Appium_CSharp.api.android;
using Appium_CSharp.api.apps.kitTest.photoAlbumActivity;
using Appium_CSharp.api.apps.kitTest.rating;
using Appium_CSharp.api.apps.kitTest.topCats;
using Appium_CSharp.api.apps.kitTest.userCatDetails;
using Appium_CSharp.api.interfaces;
using Appium_CSharp.core;
using OpenQA.Selenium;
using System;

namespace Appium_CSharp.api.apps.kitTest.home
{
    public class UserHomeActivity : Activity
    {
        public object waitToLoad()
        {
            try
            {
                gridImage0().waitToAppear(10);
                return Android.app.kitornottest.userHomeActivity;
            }
            catch (Exception e)
            {
                throw new Exception("User Home activity failed to load/open");
            }
        }

        public RatingActivity tapRatingActivityBtn()
        {
            try
            {
                ratingActivityBtn().tap();
                return Android.app.kitornottest.ratingActivity;
            }
            catch (NoSuchElementException e)
            {
                throw new Exception("Can't tap Rating activity button, element absent or blocked");
            }
        }

        public TopCatsActivity tapTopCatsBtn()
        {
            try
            {
                topCatsBtn().tap();
                return Android.app.kitornottest.topCatsActivity;
            }
            catch (NoSuchElementException e)
            {
                throw new Exception("Can't tap Top Cats activity button, element absent or blocked");
            }
        }

        public PhotoAlbumActivity tapAddCatImageBtn()
        {
            try
            {
                addImageBtn().tap();
                return Android.app.kitornottest.photoAlbumActivity;
            }
            catch (NoSuchElementException e)
            {
                throw new Exception("Can't tap Add Image Button, element absent or blocked");
            }
        }

        public PhotoAlbumActivity longClickTopLeftImg()
        {
            try
            {
                gridImage0().longClick();
                return Android.app.kitornottest.photoAlbumActivity;
            }
            catch (NoSuchElementException e)
            {
                throw new Exception("Can't tap top left image, element absent or blocked");
            }
        }

        public UserCatDetailsActivity tapTopLeftImg()
        {
            try
            {
                gridImage0().tap();
                return Android.app.kitornottest.userCatDetailsActivity;
            }
            catch (NoSuchElementException e)
            {
                throw new Exception("Can't tap top left image, element absent or blocked");
            }
        }

        public UiObject deleteBtn() { return new UiSelector().text("Delete").makeUiObject(); }
        public UiObject userCatsTitle() { return new UiSelector().resourceID("com.skow.kitornot:id/userPage").makeUiObject(); }
        public UiObject addImageBtn() { return new UiSelector().resourceID("com.skow.kitornot:id/addCat").makeUiObject(); }
        public UiObject ratingActivityBtn() { return new UiSelector().resourceID("com.skow.kitornot:id/ratingBtn").makeUiObject(); }
        public UiObject topCatsBtn() { return new UiSelector().resourceID("com.skow.kitornot:id/topCatsBtn").makeUiObject(); }
        public UiObject gridView() { return new UiSelector().resourceID("com.skow.kitornot:id/userCats").makeUiObject(); }
        public UiObject gridImage0() { return new UiSelector().className("android.widget.ImageView").index(0).makeUiObject(); }
        public UiObject gridImage1() { return new UiSelector().className("android.widget.ImageView").index(1).makeUiObject(); }
    }
}
