using automationCSharp.PageLibrary;
using automationCSharp.Utils;
//using CSharpBDD.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBDD.StepDefinitions
{
    internal class TestContext
    {

        private IWebDriver driver;

       public DirectoryUtils directoryUtils;
       public ModelUtils modelUtils;
       public HomePage homePage;
       public LogInPage logInPage;
       public LoggedInHomePage loggedInHomePage;
       public DeleteAccountPage deleteAccountPage;
       public ContactUsPage contactUsPage;


        public void setDriver(IWebDriver driver)
        {
            this.driver = driver;
            this.homePage = new HomePage(driver);
            this.logInPage = new LogInPage(driver);
            this.loggedInHomePage = new LoggedInHomePage(driver);
            this.deleteAccountPage = new DeleteAccountPage(driver);
            this.contactUsPage = new ContactUsPage(driver);
            this.directoryUtils = new DirectoryUtils();
            this.modelUtils = new ModelUtils();
        }


        public IWebDriver getDriver()
        {
            return driver;
        }

        public HomePage getHomePage()
        {
            return homePage;
        }
        public LogInPage getLoginPage()
        {
            return logInPage;
        }
        public LoggedInHomePage getLoggedInHomePagePage()
        {
            return loggedInHomePage;
        }
        public DeleteAccountPage getDeleteAccountPagePage()
        {
            return deleteAccountPage;
        }
        public ContactUsPage getContactUsPagePage()
        {
            return contactUsPage;
        }
        public DirectoryUtils getDirectoryUtils()
        {
            return directoryUtils;
        }
        public ModelUtils getModelUtils()
        {
            return modelUtils;
        }






    }
}
