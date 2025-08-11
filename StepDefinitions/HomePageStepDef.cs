using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBDD.StepDefinitions
{
    [Binding]
    internal class HomePageStepDef
    {


        [Given("user is on the Home page")]
        public void GivenUserIsOnTheHomePage()
        {
            Console.WriteLine(">>> user is on the Home page");
        }


    }
}
