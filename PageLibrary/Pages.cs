using automationCSharp.UiActions;
using automationCSharp.Utils;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace automationCSharp.PageLibrary
{
    internal class Pages
    {

        protected SeleniumActions sa;
        protected IWebDriver driver;
        protected DirectoryUtils directoryUtils;
        private Dictionary<String, String> locators;

        protected void ReadLocators(String pageName)
        {
            directoryUtils = new DirectoryUtils();
            //var jsonStr = File.ReadAllText(directoryUtils.GetBaseDirectory() + "/locators//" + pageName + ".json");

            var locatorFilePath = Path.Combine(directoryUtils.GetBaseDirectory(), "Locators", pageName + ".json");

            if (!File.Exists(locatorFilePath))
            {
                throw new FileNotFoundException($"Locator file not found: {locatorFilePath}");
            }

            var jsonStr = File.ReadAllText(locatorFilePath);

            locators = JsonConvert.DeserializeObject<Dictionary<String, String>>(jsonStr);
        }

        private string GetLocatorValue(string key)
        {
            return locators[key];

            // This should be implemented to fetch from your source, like a dictionary or resource file
            throw new NotImplementedException();
        }


        // Equivalent to the Java getLocator method
        protected By GetLocator(string key, params object[] args)
        {
            string raw = GetLocatorValue(key);


            if (raw == null) throw new Exception($"Locator not found: {key}");

            var parts = raw.Split(new[] { ':' }, 2);
            if (parts.Length != 2) throw new Exception($"Invalid locator format: {raw}");

            string type = parts[0];
            string pattern = parts[1];
            string formattedLocator = string.Format(pattern, args);

            return type.ToLower() switch
            {
                "id" => By.Id(formattedLocator),
                "name" => By.Name(formattedLocator),
                "css" => By.CssSelector(formattedLocator),
                "xpath" => By.XPath(formattedLocator),
                _ => throw new Exception($"Unknown locator type: {type}")
            };
        }


        public By GetLocatorWithPlaceholders(string key, Dictionary<string, string> replacements)
        {
            string raw = GetLocatorValue(key);

            if (raw == null) throw new Exception($"Locator not found: {key}");

            var parts = raw.Split(new[] { ':' }, 2);
            if (parts.Length != 2) throw new Exception($"Invalid locator format: {raw}");

            string type = parts[0];
            string locatorTemplate = parts[1];

            foreach (var entry in replacements)
            {
                locatorTemplate = locatorTemplate.Replace("${" + entry.Key + "}", entry.Value);
            }

            // Optional: check for unresolved placeholders
            if (Regex.IsMatch(locatorTemplate, @"\$\{.+?}"))
            {
                throw new Exception($"Unresolved placeholders in locator: {locatorTemplate}");
            }

            return type.ToLower() switch
            {
                "id" => By.Id(locatorTemplate),
                "name" => By.Name(locatorTemplate),
                "css" => By.CssSelector(locatorTemplate),
                "xpath" => By.XPath(locatorTemplate),
                _ => throw new Exception($"Unknown locator type: {type}")
            };
        }

        public String TakeScreenshot(String testName)
        {
            string fullPath = null;
            try
            {
                DirectoryUtils directoryUtils = new DirectoryUtils();

                string directoryPath = directoryUtils.GetBaseDirectory() + "ScreenCaptures";

                Console.WriteLine(directoryPath);
                if (!(Directory.Exists(directoryPath)))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string fileName = testName + "_" + DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".png";
                Console.WriteLine(fileName);

                fullPath = Path.Combine(directoryPath, fileName);
                Console.WriteLine(fullPath);

                ITakesScreenshot ss = (ITakesScreenshot)driver;
                Screenshot sst = ss.GetScreenshot();
                sst.SaveAsFile(fullPath);
                return fullPath;
            }
            catch (Exception ex)
            {
                //log.Info("Exception in method " + MethodBase.GetCurrentMethod().Name + ", exception is : " + ex.Message);
                throw ex;

            }
        }

        public Byte[] GetScreenshotInByte()
        {
            ITakesScreenshot ss = (ITakesScreenshot)driver;
            //Screenshot sst = ss.GetScreenshot();
            byte[] imageBytes = ss.GetScreenshot().AsByteArray;
            return imageBytes;
        }




    }
}
