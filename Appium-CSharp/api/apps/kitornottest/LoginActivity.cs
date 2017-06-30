using Appium_CSharp.api.android;
using Appium_CSharp.api.interfaces;
using Appium_CSharp.core;
using NUnit.Framework;
using System;

namespace Appium_CSharp.api.apps.kitTest.login
{
    public class Login : Activity
    {
        public object waitToLoad()
        {
            try
            {
                login_signup_button().waitToAppear(10);
                return Android.app.kitornottest.login;
            }
            catch (Exception e)
            {
                throw new Exception("Login activity failed to load/open");
            }
        }

        public void login(String username, String password)
        {
            Assert.IsTrue(this.userName().exists(), "Could not find element: " + this.userName());
            Assert.IsTrue(this.password().exists(), "Could not find element: " + this.password());
            Assert.IsTrue(this.login_signup_button().exists(), "Could not find element: " + this.login_signup_button());
            Assert.IsTrue(this.login_signup_text().exists(), "Could not find element: " + this.login_signup_text());
            Assert.IsTrue(this.logo().exists(), "Could not find element: " + this.logo());

            this.userName().clearText();
            this.userName().typeText(username);
            this.password().clearText();
            this.password().typeText(password);
            this.login_signup_button().tap();
        }

        public UiObject logo() { return new UiSelector().description("Cat Backside").makeUiObject(); }
        public UiObject userName() { return new UiSelector().resourceID("com.skow.kitornot:id/username").makeUiObject(); }
        public UiObject password() { return new UiSelector().resourceID("com.skow.kitornot:id/password").makeUiObject(); }
        public UiObject login_signup_button() { return new UiSelector().resourceID("com.skow.kitornot:id/login_signup_btn").makeUiObject(); }
        public UiObject login_signup_text() { return new UiSelector().resourceID("com.skow.kitornot:id/login_signup_txt").makeUiObject(); }
        public UiObject contact() { return new UiSelector().resourceID("com.skow.kitornot:id/contact_txt").makeUiObject(); }
    }
}
