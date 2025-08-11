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
    internal class ProductsDetailsPage:Pages
    {
        public ProductsDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            sa = new SeleniumActions(driver);
            ReadLocators(this.GetType().Name);
        }


        public ProductsDetailsPage verifyProductDetails(ProductDetails productDetails)
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("productsDetailsPage_ProductName"));
            String name = sa.GetText(GetLocator("productsDetailsPage_ProductName"));
            String category = sa.GetText(GetLocator("productsDetailsPage_Category"));
            String price = sa.GetText(GetLocator("productsDetailsPage_Price"));
            String availability = sa.GetText(GetLocator("productsDetailsPage_Availability"));
            String condition = sa.GetText(GetLocator("productsDetailsPage_Condition"));
            String brand = sa.GetText(GetLocator("productsDetailsPage_Brand"));

            Console.WriteLine(name);
            Console.WriteLine(category);
            Console.WriteLine(price);
            Console.WriteLine(availability);
            Console.WriteLine(condition);
            Console.WriteLine(brand);

            //addAttachment("verifyProductDetails", new ByteArrayInputStream(getScreenshotBYTE()));

            Assert.That(name, Is.EqualTo(productDetails.name));
            Assert.That(category, Is.EqualTo(productDetails.category));
            Assert.That(price, Is.EqualTo(productDetails.price));

            return this;
        }




    }
}
