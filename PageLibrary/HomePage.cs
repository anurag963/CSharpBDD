using automationCSharp.Model;
using automationCSharp.UiActions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.PageLibrary
{
    internal class HomePage : Pages
    {

        public HomePage(IWebDriver driver)
        {
            this.driver=driver;
            sa = new SeleniumActions(driver);
            ReadLocators(this.GetType().Name);
        }

        public LogInPage ClickOnLogInLink()
        {
           /* Dictionary<string, string> values = new Dictionary<string, string>()
            {
                 { "text", "/login" }
            };
            sa.clickElement(GetLocatorWithPlaceholders("homePage_LogInLink", values));*/

            sa.ClickElement(GetLocator("homePage_LogInLink"));
            return new LogInPage(driver);
        }


        public ContactUsPage ClickOnContactUsLink()
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("homePage_ContactUsLink"));
            sa.ClickElement(GetLocator("homePage_ContactUsLink"));
            //step("username entered");
            return new ContactUsPage(driver);
        }

        public ProductsPage ClickOnProductsLink()
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("homePage_ProductsLink"));
            sa.ClickElement(GetLocator("homePage_ProductsLink"));
            //step("username entered");

            return new ProductsPage(driver);
        }


    }
}
