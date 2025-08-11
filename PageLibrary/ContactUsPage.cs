using automationCSharp.UiActions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.PageLibrary
{
    internal class ContactUsPage : Pages
    {
        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
            sa = new SeleniumActions(driver);
            ReadLocators(this.GetType().Name);
        }
        public ContactUsPage FillContactUsFormAndSubmit(String name, String email, String subject, String message, String filePathToUpload)
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("contactUs_NameTxtBx"));
            sa.SetValueUSingSendKey(GetLocator("contactUs_NameTxtBx"), name);
            sa.SetValueUSingSendKey(GetLocator("contactUs_EmailTxtBx"), email);
            sa.SetValueUSingSendKey(GetLocator("contactUs_SubjectTxtBx"), subject);
            sa.SetValueUSingSendKey(GetLocator("contactUs_MessageTxtBx"), message);
            sa.SetValueUSingSendKey(GetLocator("contactUs_Upload_file"), filePathToUpload);

            sa.ClickElement(GetLocator("contactUsPage_SubmitBtn"));
            sa.acceptAlert();
            return this;
        }

        public ContactUsPage VerifySuccessMessage()
        {
            sa.WaitUntilElementIsDisplayed(GetLocator("contactUsPage_SubmitSuccessMessage"));
            Boolean isMessageDisplayed = sa.IsElementDisplayed(GetLocator("contactUsPage_SubmitSuccessMessage"));
            //step("username entered");
            Assert.That(isMessageDisplayed, Is.True, "success message not displayed");            
            return this;
        }






    }
}
