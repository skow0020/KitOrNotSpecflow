using Appium_CSharp.api.android;
using Appium_CSharp.api.apps.kitornottest;
using Appium_CSharp.core;
using Appium_CSharp.core.managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace Appium_CSharp.Features.step_definitions
{
    [Binding]
    public sealed class Hooks
    {
        public static ScenarioContext testScenario;
        private static KitornotTest kitTest = Android.app.kitornottest;
        private static TestInfo testinfo = new TestInfo();
        private static List<Object> results = new List<Object>();
        private static JsonArrayAttribute jsonArray = new JsonArrayAttribute();
        private static Boolean dunit = false;

        [BeforeScenario]
        public void beforeScenario(ScenarioContext scenario)
        {
            testScenario = scenario;
            DriverManager.createDriver("VS9854G9e1c8906");
        }

        [AfterScenario]
        public void afterScenario(ScenarioContext scenario)
        {
            DriverManager.killDriver();
            Dictionary<String, String> result = new Dictionary<string, string>();
            result.Add("ID", TestInfo.id());
            result.Add("Name", TestInfo.name());
            result.Add("Suite", TestInfo.suite());

            if (scenario.TestError == null) { result.Add("Result", "Passed"); }
            else { result.Add("Result", "Passed"); }
            
            result.Add("Message", TestInfo.notes());
            results.Add(result); 
        }

        [AfterTestRun]
        public static void afterTestRun()
        {
            using (StreamWriter file = new StreamWriter(@"C:\Users\Colin\Desktop\Appium-CSharp\results.json", true))
            {
                file.WriteLine(JsonConvert.SerializeObject(results));
            }
        }

        public void write(string text)
        {
            using (StreamWriter file = new StreamWriter(@"C:\Users\Colin\Desktop\Appium-CSharp\results.json", true))
            {
                file.WriteLine(text);
            }
        }
    }

}
