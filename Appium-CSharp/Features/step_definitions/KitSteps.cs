using Appium_CSharp.api.android;
using Appium_CSharp.api.apps.kitornottest;
using Appium_CSharp.api.apps.kitTest.home;
using Appium_CSharp.api.apps.kitTest.topCats;
using Appium_CSharp.core;
using Appium_CSharp.Features.step_definitions;
using Appium_CSharp.helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace Appium_CSharp.step_definitions
{
    [Binding]
    public sealed class KitSteps
    {
        private Support support = new Support();
        private static KitornotTest kitTest = Android.app.kitornottest;
        private UserHomeActivity userhome = kitTest.userHomeActivity;
        private TopCatsActivity topCats = kitTest.topCatsActivity;
        TestInfo testinfo = new TestInfo();

        [When(@"I perform a simple search on '(.*)'")]
        [Given(@"test info id '(.*)' and name '(.*)'")]
        public void testInfoIdAndName(String id, String name)
        {
            testinfo.id(id).name(name).suite(Hooks.testScenario.ScenarioInfo.Tags.ToString());
        }

        [Given(@"I am on the login screen")]
        public void IAmOnTheLoginScreen()
        {
            support.loginScreen();
        }

        [Given(@"I log in with user '(.*)' and password '(.*)'")]
        public void ILogInWithUserAndPassword(String username, String password)
        {
            support.login(username, password);
        }

        [Then(@"I am on the user home screen")]
        public void IAmOnTheUserHomeScreen()
        {
            support.verifyUserHome();
        }

        [Then(@"I am on the rating activity screen$")]
        public void iAmOnTheRatingActivityScreen()
        {
            support.verifyRatingActivity();
        }

        [Then(@"I am on the top cats activity screen")]
        public void iAmOnTheTopCatsActivityScreen()
        {
            support.verifyTopCats();
        }

        [When(@"I tap the rating activitiy button")]
        public void iTapTheRatingActivitiyButton()
        {
            userhome.tapRatingActivityBtn().waitToLoad();
        }

        [When(@"I tap the top cats activitiy button")]
        public void iTapTheTopCatsActivitiyButton()
        {
            userhome.tapTopCatsBtn().waitToLoad();
        }

        [When(@"I tap the add cat image button")]
        public void iTapTheAddCatImageButton()
        {
            userhome.tapAddCatImageBtn().waitToLoad();
        }

        [Then(@"I can add an image")]
        public void iCanAddAnImage()
        {
            support.verifyImageAdd();
        }

        [Then(@"I can remove an image")]
        public void iCanRemoveAnImage()
        {
            support.verifyImageDelete();
        }

        [Then(@"login fails")]
        public void loginFails()
        {
            support.verifyInvalidLogin();
        }

        [When(@"I tap a cat in the top cats list")]
        public void iTapACatInTheTopCatsList()
        {
            topCats.tapCatInGrid().waitToLoad();
        }

        [Then(@"I am on the top cats details activity screen")]
        public void iAmOnTheTopCatsDetailsActivityScreen()
        {
            support.verifyTopCatDetails();
        }

        [When(@"I tap a user cat image in the list")]
        public void iTapAUserCatImageInTheList()
        {
            userhome.tapTopLeftImg().waitToLoad();
        }

        [Then(@"I am on the user cat details activity screen")]
        public void iAmOnTheUserCatDetailsActivityScreen()
        {
            support.verifyUserCatDetails();
        }
    }
}
