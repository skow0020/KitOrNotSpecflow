namespace Appium_CSharp.core
{
    public class TestInfo
    {
        private static string
        TIMESTAMP,
        SUITE,
        ID,
        NAME,
        NOTES,
        EXPECTED,
        ACTUAL,
        VERSION,
        RESULT;

        public void reset()
        {
            TIMESTAMP = null;
            SUITE = null;
            ID = null;
            NAME = null;
            NOTES = null;
            EXPECTED = null;
            ACTUAL = null;
            VERSION = null;
            RESULT = null;
        }

        public TestInfo timestamp(string value)
        {
            TIMESTAMP = value;
            return this;
        }

        public TestInfo suite(string value)
        {
            SUITE = value;
            return this;
        }

        public TestInfo id(string value)
        {
            ID = value;
            return this;
        }

        public TestInfo name(string value)
        {
            NAME = value;
            return this;
        }

        public TestInfo notes(string value)
        {
            NOTES = value;
            return this;
        }

        public TestInfo expected(string value)
        {
            EXPECTED = value;
            return this;
        }

        public TestInfo actual(string value)
        {
            ACTUAL = value;
            return this;
        }

        public TestInfo version(string value)
        {
            VERSION = value;
            return this;
        }

        public static void result(string result)
        {
            VERSION = result;
        }

        public static string timestamp()
        {
            return TIMESTAMP;
        }

        public static string suite()
        {
            return SUITE;
        }

        public static string id()
        {
            return ID;
        }

        public static string name()
        {
            return NAME;
        }

        public static string notes()
        {
            return NOTES;
        }

        public static string expected()
        {
            return EXPECTED;
        }

        public static string actual()
        {
            return ACTUAL;
        }

        public static string version()
        {
            return VERSION;
        }

        public static string result() { return RESULT; }
    }
}
