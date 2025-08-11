using automationCSharp.Model;
using automationCSharp.UiActions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.PageLibrary
{
    internal class ProductsPage:Pages
    {

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            sa = new SeleniumActions(driver);
            ReadLocators(this.GetType().Name);
        }


        public ProductsPage VerifyHeaderDisplayed()
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("productsPage_AllProductsHeader"));
            bool isHeaderDisplayed = sa.IsElementDisplayed(GetLocator("productsPage_AllProductsHeader"));
            Assert.That(isHeaderDisplayed, Is.True, "Headere not displayed");
            //addAttachment("validateHeader", new ByteArrayInputStream(GetScreenshotBYTE()));
            return this;
        }
        public ProductsPage VerifyFirstProductImageDisplayed()
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("productsPage_Products"));
            bool isDisplayed = sa.IsElementDisplayed(GetLocator("productsPage_Products"));
            Assert.That(isDisplayed, Is.True, "FirstProductImag not displayed");
            return this;
        }

        public ProductsDetailsPage clickViewProduct(String productNo)
        {
            Dictionary<String, String> values = new Dictionary<string, string>()
            {
                  { "text", productNo }
            };

            By productDetailsLink = GetLocatorWithPlaceholders("productsPage_ProductDetailsLink", values);
            sa.WaitUntilElementIsDisplayed(productDetailsLink);
            sa.ClickElement(productDetailsLink);
            return new ProductsDetailsPage(driver);
        }


    }
}
