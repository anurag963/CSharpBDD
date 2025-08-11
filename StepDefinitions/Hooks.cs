using automationCSharp.SetUp;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBDD.StepDefinitions
{
    [Binding]
    internal class Hooks
    {

        private TestContext context;
        BaseClass baseClass;

        public Hooks(TestContext context)
        {
            this.context = context;
        }

        // @Before
        [BeforeScenario]
        public void setUp()
        {
            //WebDriver driver = new ChromeDriver();
            baseClass = new BaseClass();
            IWebDriver driver = baseClass.Init();
            context.setDriver(driver);
        }

        //@After
        [AfterScenario]
        public void tearDown()
        {
            context.getDriver().Quit();
        }



    }
}
