using automationCSharp.UiActions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.PageLibrary
{
    internal class DeleteAccountPage:Pages
    {
        public DeleteAccountPage(IWebDriver driver)
        {
            this.driver = driver;
            sa = new SeleniumActions(driver);
            ReadLocators(this.GetType().Name);
        }


        public DeleteAccountPage VerifyAccountDeletionMessage(String textToVerify)
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("deleteAccountPage_LogInLink"));
            String text = sa.GetText(GetLocator("deleteAccountPage_LogInLink"));
           //step("username entered");
            //addAttachment("verifyLogoutLink", new ByteArrayInputStream(getScreenshotBYTE()));
            Assert.That(text, Is.EqualTo(textToVerify));
            return this;
        }



    }
}
