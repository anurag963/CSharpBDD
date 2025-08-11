using Allure.Net.Commons;
using automationCSharp.UiActions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.PageLibrary
{
    internal class LoggedInHomePage:Pages
    {

        public LoggedInHomePage(IWebDriver driver)
        {
            this.driver = driver;
            sa = new SeleniumActions(driver);
            ReadLocators(this.GetType().Name);
        }

        public LoggedInHomePage VerifyLogoutLink(String textToVerify)
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("loggedInHomePage_LogOutLink"));
            String text = sa.GetText(GetLocator("loggedInHomePage_LogOutLink"));

            //AllureApi.Step("VerifyLogoutLink step");
            //AllureApi.AddAttachment("Logout Link Text", "image/png", GetScreenshotInByte());
            //AllureApi.AddAttachment("Logout Link Text", "text/plain", GetScreenshotInByte());
            Assert.That(text, Is.EqualTo(textToVerify));
            return this;
        }

        public void AttachScreenshot(IWebDriver driver, string name = "screenshot")
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            byte[] bytes = screenshot.AsByteArray;
            //AllureLifecycle.Instance.AddAttachment(name, "image/png", bytes);
        }

        public LogInPage ClickLogOutLink()
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("loggedInHomePage_LogOutLink"));
            sa.ClickElement(GetLocator("loggedInHomePage_LogOutLink"));
            //step("username entered");
            return new LogInPage(driver);
        }

        public DeleteAccountPage ClickDeleteAccountLink()
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("loggedInHomePage_DeleteAccountLink"));
            sa.ClickElement(GetLocator("loggedInHomePage_DeleteAccountLink"));
            //step("username entered");
            return new DeleteAccountPage(driver);
        }

    }


}

