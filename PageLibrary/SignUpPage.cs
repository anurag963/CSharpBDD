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
    internal class SignUpPage : Pages
    {

        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
            sa = new SeleniumActions(driver);
            ReadLocators(this.GetType().Name);
        }

        public LogInPage EnterAccountInformationAndCreateAccount()
        {

            sa.WaitUntilElementIsDisplayed(GetLocator("signUpPage_TitleRadioBtn"));
            sa.ClickElement(GetLocator("signUpPage_TitleRadioBtn"));
            //step("username entered");
            return new LogInPage(driver);
        }

        public AccountCreatedPage SignUpNewUser(UserData data)
        {
            Console.WriteLine(data.title);
            sa.WaitUntilElementIsDisplayed(GetLocator("signUpPage_NameTxtBx"));
            sa.ClickElement(GetLocator("signUpPage_TitleRadioBtn", data.title));

            sa.ClearAndSetValueUSingSendKey(GetLocator("signUpPage_NameTxtBx"), data.name);
            sa.SetValueUSingSendKey(GetLocator("signUpPage_PasswordTxtBx"), data.password);

            String date = data.dob_MM_DD_YYYY;
            String month = date.Split("/")[0];
            String day = date.Split("/")[1];
            String year = date.Split("/")[2];
            sa.SelectDropDownOptionByText(GetLocator("signUpPage_DaysTxtBx"), day);
            sa.WaitUntilElementIsDisplayed(GetLocator("signUpPage_MonthsTxtBx"));
            sa.SelectDropDownOptionByValue(GetLocator("signUpPage_MonthsTxtBx"), month);
            sa.WaitUntilElementIsDisplayed(GetLocator("signUpPage_YearTxtBx"));
            sa.SelectDropDownOptionByText(GetLocator("signUpPage_YearTxtBx"), year);

            sa.SetValueUSingSendKey(GetLocator("signUpPage_AddressFirstNameTxtBx"), data.firstName);
            sa.SetValueUSingSendKey(GetLocator("signUpPage_AddressLastNameTxtBx"), data.lastName);
            sa.SetValueUSingSendKey(GetLocator("signUpPage_AddressAddress1TxtBx"), data.address);

            sa.SelectDropDownOptionByText(GetLocator("signUpPage_AddressCountryDdn"), data.country);
            sa.SetValueUSingSendKey(GetLocator("signUpPage_AddressStateTxtBx"), data.state);
            sa.SetValueUSingSendKey(GetLocator("signUpPage_AddressCityTxtBx"), data.city);
            sa.SetValueUSingSendKey(GetLocator("signUpPage_AddressZipcodeTxtBx"), data.zipcode);
            sa.SetValueUSingSendKey(GetLocator("signUpPage_AddressMobileNumberTxtBx"), data.phone);

            sa.ClickElement(GetLocator("signUpPage_CreateAccountBtn"));

            //step("username entered");
            return new AccountCreatedPage(driver);
        }





    }
}
