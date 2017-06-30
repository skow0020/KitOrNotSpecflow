using Appium_CSharp.api.android;
using Appium_CSharp.api.apps.kitornottest;
using Appium_CSharp.core;
using NUnit.Framework;
using System;
using System.Threading;

namespace Appium_CSharp.helpers
{
    public class Support
    {
        private static KitornotTest kitTest = Android.app.kitornottest ;

        public void loginScreen()
        {
            core.Timer timer = new core.Timer();
            timer.start();
            while (!timer.expired(10))
            {
                try
                {
                    Thread.Sleep(500);
                    if (!kitTest.login.userName().exists()) kitTest.clickBack();
                }
                catch (Exception e) { }
            }
        }

        public void verifyExistence(UiObject element, string errorMsg=null)
        {
            if (errorMsg == null) { errorMsg = "Could not find element: " + element; }
            Assert.IsTrue(element.exists(), errorMsg);
        }

        public void login(String username, String password)
        {
            verifyExistence(kitTest.login.userName());
            verifyExistence(kitTest.login.password());
            verifyExistence(kitTest.login.login_signup_button());
            verifyExistence(kitTest.login.login_signup_text());
            verifyExistence(kitTest.login.logo());

            if (kitTest.login.login_signup_text().getText().Equals("Log In")) kitTest.login.login_signup_text().tap();
            kitTest.login.userName().clearText();
            kitTest.login.userName().typeText(username);
            kitTest.login.password().clearText();
            kitTest.login.password().typeText(password);
            kitTest.login.login_signup_button().tap();
        }

        public void verifyUserHome()
        {
            verifyExistence(kitTest.userHomeActivity.userCatsTitle());
            verifyExistence(kitTest.userHomeActivity.addImageBtn());
            verifyExistence(kitTest.userHomeActivity.gridView());
            verifyExistence(kitTest.userHomeActivity.ratingActivityBtn());
            verifyExistence(kitTest.userHomeActivity.topCatsBtn());
        }

        public void verifyRatingActivity()
        {
            verifyExistence(kitTest.ratingActivity.catImage());
            verifyExistence(kitTest.ratingActivity.thumbDown());
            verifyExistence(kitTest.ratingActivity.thumbUp());
        }

        public void verifyTopCats()
        {
            verifyExistence(kitTest.topCatsActivity.topCatTitle());
            verifyExistence(kitTest.topCatsActivity.gridview());
            verifyExistence(kitTest.topCatsActivity.gridImage0());
            verifyExistence(kitTest.topCatsActivity.gridImage1());
        }

        public void verifyImageAdd()
        {
            verifyExistence(kitTest.photoAlbumActivity.selectAlbumTitle());
            kitTest.photoAlbumActivity.tapMainImage().waitToLoad();
            verifyExistence(kitTest.selectImageActivity.selectAlbumTitle());
            kitTest.selectImageActivity.tapSelectImage().waitToLoad();
            kitTest.userHomeActivity.gridImage0().waitToAppear(5);
            verifyExistence(kitTest.userHomeActivity.gridImage0());
        }

        public void verifyImageDelete()
        {
            kitTest.userHomeActivity.gridImage0().longClick();
            verifyExistence(kitTest.userHomeActivity.deleteBtn());
            kitTest.userHomeActivity.deleteBtn().tap();
            kitTest.userHomeActivity.gridImage0().waitToDisappear(5);
            Assert.IsTrue(!kitTest.userHomeActivity.gridImage0().exists());
        }

        public void verifyInvalidLogin()
        {
            Assert.IsTrue(!kitTest.userHomeActivity.ratingActivityBtn().exists(), "Login worked on invalid credentials!");
            verifyExistence(kitTest.login.userName());
            verifyExistence(kitTest.login.userName());
        }

        public void verifyTopCatDetails()
        {
            verifyExistence(kitTest.topCatDetailsActivity.catImage());
            verifyExistence(kitTest.topCatDetailsActivity.percentage());
        }

        public void verifyUserCatDetails()
        {
            verifyExistence(kitTest.userCatDetailsActivity.catImage());
            verifyExistence(kitTest.userCatDetailsActivity.percentage());
        }
    }

}
