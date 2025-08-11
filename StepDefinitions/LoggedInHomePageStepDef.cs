using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBDD.StepDefinitions
{
    [Binding]
    internal class LoggedInHomePageStepDef
    {

        private TestContext context;

        public LoggedInHomePageStepDef(TestContext context)
        {
            this.context = context;
        }


        [Then("user should be redirected to the homepage")]
        public void ThenUserShouldBeRedirectedToTheHomepage()
        {
            Console.WriteLine("ThenUserShouldBeRedirectedToTheHomepage");
        }

        [Then("user should be able to see {string} link")]
        public void ThenUserShouldBeAbleToSeeLink(string logoutLink)
        {
            context.loggedInHomePage.VerifyLogoutLink(logoutLink);
        }


    }
}
