using automationCSharp.Model;
using automationCSharp.Utils;
using Microsoft.Testing.Platform.Configurations;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.SetUp
{
    internal class BaseClass
    {
        protected IWebDriver driver;
        protected DirectoryUtils directoryUtils;
        protected Config _configuration;

        public Config GetConfig()
        {
            if (_configuration == null)
            {
                /*directoryUtils = new DirectoryUtils();
                //var jsonStr = File.ReadAllText(directoryUtils.GetBaseDirectory() + "/config.json");
                var jsonStr = File.ReadAllText(Directory.GetCurrentDirectory() + "/config.json");*/


            var configPath = Path.Combine(AppContext.BaseDirectory, "config.json");

                if (!File.Exists(configPath))
                {
                    throw new FileNotFoundException($"Config file not found at: {configPath}");
                }

                var jsonStr = File.ReadAllText(configPath);



                _configuration = JsonConvert.DeserializeObject<Config>(jsonStr);
            }

            return _configuration;
        }


        public IWebDriver Init()
        {
            GetConfig();

            String runOnGrid = Environment.GetEnvironmentVariable("GRIDRUN");
            if (String.IsNullOrEmpty(runOnGrid))
            {
                runOnGrid = _configuration.Grid.RunOnGrid;
            }
            String browser = _configuration.Driver.Browser;

            Console.WriteLine("Run on Grid: " + runOnGrid);
            Console.WriteLine("Browser: " + browser);

            GetBrowser(runOnGrid, browser);

            Console.WriteLine(_configuration.Driver.Browser);
            driver.Manage().Window.Maximize();
            driver.Url = _configuration.Test.StageUrl;
            Thread.Sleep(2000);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_configuration.Driver.ImplicitWait);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_configuration.Driver.ImplicitWait);
            return driver;
        }

        public void GetBrowser(String runOnGrid, String browser)
        {
            if (runOnGrid.Equals("false"))
            {
                switch (_configuration.Driver.Browser)
                {
                    case "Chrome":
                    case "chrome":
                    ChromeOptions options = new ChromeOptions();
                       // ✅ Set a unique user data directory
                    string tempUserDataDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                    options.AddArgument($"--user-data-dir={tempUserDataDir}");
                    //options.AddArgument("--headless=new");
                    options.AddArgument("--disable-gpu");
                    options.AddArguments("start-maximized");
                    options.AddArguments("--no-sandbox");
                    options.AddArguments("--disable-dev-shm-usage");
                        driver = new ChromeDriver(options);
                        break;
                    case "FireFox":
                    case "FF":
                        driver = new FirefoxDriver();
                        break;
                    case "Edge":
                        driver = new EdgeDriver();
                        break;
                    default:
                        Console.WriteLine("Selected Browser is not available");
                        break;
                }
            }
            else
            {
                if (browser.Equals("chrome"))
                {
                    ChromeOptions options = new ChromeOptions();
                       // ✅ Set a unique user data directory
                    string tempUserDataDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                    options.AddArgument($"--user-data-dir={tempUserDataDir}");
                    options.AddArgument("--headless=new");
                    options.AddArgument("--disable-gpu");
                    options.AddArguments("start-maximized");
                    options.AddArguments("--no-sandbox");
                    options.AddArguments("--disable-dev-shm-usage");

                    //Console.WriteLine(hubUrl);
                    driver = new RemoteWebDriver(new Uri(_configuration.Grid.GridUrl), options);

                }

            }

        }

        public String gGetScreenshotBase64()
        {
            ITakesScreenshot ss = (ITakesScreenshot)driver;
            byte[] imageBytes = ss.GetScreenshot().AsByteArray;
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
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
