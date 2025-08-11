using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBDD.StepDefinitions
{
    [Binding]
    internal class LoginPageStepDef
    {
        private TestContext context;

        public LoginPageStepDef(TestContext context)
        {
            this.context = context;
        }

        [Then("user is on the login page")]
        public void ThenUserIsOnTheLoginPage()
        {
            context.homePage.ClickOnLogInLink();
        }

        [When("user should be able to login with valid credentials")]
        public void WhenUserShouldBeAbleToLoginWithValidCredentials()
        {
            context.logInPage.LogInToApp("anuragkumar780@gmail.com", "Password@1");
        }


    }
}
