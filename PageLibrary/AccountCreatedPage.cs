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
    internal class AccountCreatedPage:Pages
    {

        public AccountCreatedPage(IWebDriver driver)
        {
            this.driver = driver;
            sa = new SeleniumActions(driver);
            ReadLocators(this.GetType().Name);
        }


        public AccountCreatedPage VerifyLogInLink(String textToVerify)
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("accountCreatedPage_TitleRadioBtn"));
            String text = sa.GetText(GetLocator("accountCreatedPage_TitleRadioBtn"));
            //step("username entered");
            //addAttachment("verifyLogInLink", new ByteArrayInputStream(getScreenshotBYTE()));
            //Assert.assertEquals(text, textToVerify);
            Assert.That(text, Is.EqualTo(textToVerify));
            return this;
        }

        public void TakeScreenshotAccountSuccessPage(String name)
        {
            TakeScreenshot(name);

        }


    }
}
