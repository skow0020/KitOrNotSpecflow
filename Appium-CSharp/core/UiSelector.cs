using System;

namespace Appium_CSharp.core
{
    public class UiSelector
    {
        private string locator = "new UiSelector()";

        public UiSelector resourceID(string value)
        {
            locator += ".resourceId(\"" + value + "\")";
            return this;
        }

        public UiSelector className(string value)
        {
            locator += ".className(\"" + value + "\")";
            return this;
        }

        public UiSelector classNameMatches(string regex)
        {
            locator += ".classNameMatches(\"" + regex + "\")";
            return this;
        }

        public UiSelector text(string value)
        {
            locator += ".text(\"" + value + "\")";
            return this;
        }

        public UiSelector textContains(string value)
        {
            locator += ".textContains(\"" + value + "\")";
            return this;
        }

        public UiSelector index(int value)
        {
            locator += ".index(" + value + ")";
            return this;
        }

        public UiSelector clickable(Boolean value)
        {
            locator += ".index(" + value + ")";
            return this;
        }

        public UiSelector checkeded(Boolean value)
        {
            locator += ".index(" + value + ")";
            return this;
        }

        public UiSelector enabled(Boolean value)
        {
            locator += ".index(" + value + ")";
            return this;
        }

        public UiSelector description(string value)
        {
            locator += ".description(\"" + value + "\")";
            return this;
        }

        public UiSelector descriptionContains(string value)
        {
            locator += ".descriptionContains(\"" + value + "\")";
            return this;
        }

        public UiSelector descriptionMatches(string regex)
        {
            locator += ".descriptionMatches(\"" + regex + "\")";
            return this;
        }

        public UiSelector xPath(string xPath)
        {
            locator += xPath;
            return this;
        }

        public UiObject makeUiObject()
        {
            return new UiObject(locator);
        }
    }
}
