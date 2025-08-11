using automationCSharp.UiActions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.PageLibrary
{
    internal class LogInPage : Pages
    {

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
            sa = new SeleniumActions(driver);
            ReadLocators(this.GetType().Name);
        }


        public LoggedInHomePage LogInToApp(String userName, String password)
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("logInPage_EmailAddressTxtBx"));
            sa.SetValueUSingSendKey(GetLocator("logInPage_EmailAddressTxtBx"), userName);
            sa.SetValueUSingSendKey(GetLocator("logInPage_PasswordTxtBx"), password);
            sa.ClickElement(GetLocator("logInPage_LogInBtn"));
            //step("username entered");
            return new LoggedInHomePage(driver);
        }

        public LogInPage VerifyLogInLink(String textToVerify)
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("logInPage_LogInLink"));
            String text = sa.GetText(GetLocator("logInPage_LogInLink"));
           // step("username entered");
            //addAttachment("verifyLogInLink", new ByteArrayInputStream(getScreenshotBYTE()));
            Assert.That(text, Is.EqualTo(textToVerify));
            return this;
        }

        public SignUpPage NewUserSighUp(String userName, String email)
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("logInPage_SignUpNameTxtBx"));
            sa.SetValueUSingSendKey(GetLocator("logInPage_SignUpNameTxtBx"), userName);
            sa.SetValueUSingSendKey(GetLocator("logInPage_SignUpEmailTxtBx"), email);
            sa.ClickElement(GetLocator("logInPage_SignUpBtn"));
            //step("username entered");
            return new SignUpPage(driver);
        }




    }
}
