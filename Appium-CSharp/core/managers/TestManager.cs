using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Appium_CSharp.core.managers
{
    public class TestManager
    {
        public static TestInfo testinfo = new TestInfo();
        public static List<Object> results = new List<Object>();
        public static JsonArrayAttribute jsonArray = new JsonArrayAttribute();

        [SetUp]
        public void Init()
        {
            DriverManager.createDriver("VS9854G9e1c8906");
        }

        [TearDown]
        public void Cleanup()
        {
            DriverManager.killDriver();
            Console.WriteLine(testinfo);
        }
    }


}
