using automationCSharp.Model;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.UiActions
{
    internal class SeleniumActions
    {

        IWebElement element;
        WebDriverWait wait;
        IWebDriver driver;

        public SeleniumActions(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void ClickElement(By locator)
        {
            element = driver.FindElement(locator);
            element.Click();
        }

        public void ClearAndSetValueUSingSendKey(By locator, String value)
        {
            element = driver.FindElement(locator);
            element.Clear();
            element.SendKeys(value);
        }

        public void SetValueUSingSendKey(By locator, String value)
        {
           driver.FindElement(locator).SendKeys(value);
        }


        public void SelectDropDownOptionByText(By locator, String optionText)
        {
            SelectElement ddn = new SelectElement(driver.FindElement(locator));
            ddn.SelectByText(optionText);
        }

        public void SelectDropDownOptionByValue(By locator, String optionText)
        {
            SelectElement ddn = new SelectElement(driver.FindElement(locator));
            ddn.SelectByValue(optionText);
        }

        public bool IsElementDisplayed(By locator)
        {
            return driver.FindElement(locator).Displayed;
        }

        public IWebElement WaitUntilElementIsDisplayed(By locator)
        {
           return wait.Until(drv => drv.FindElement(locator));
        }

        public IWebElement WaitForElementPresence(By locator)
        {
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(drv =>
            {
                var element = drv.FindElement(locator);
                return element.Displayed ? element : null;
            });
        }

        public String GetText(By locator)
        {
            element = driver.FindElement(locator);
            return element.Text;
        }

        public IAlert WaitForAlert(int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv =>
            {
                try
                {
                    return drv.SwitchTo().Alert();
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            });
        }

        public void acceptAlert()
        {
           IAlert alert= WaitForAlert(10);
            alert.Accept();
        }


        public void SwitchToFrame(By locator)
        {
            element = driver.FindElement(locator);
            driver.SwitchTo().Frame(element);
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }





        public Byte[] getScreenshotInByte()
        {
            ITakesScreenshot ss = (ITakesScreenshot)driver;
            byte[] imageBytes = ss.GetScreenshot().AsByteArray;
            return imageBytes;
        }

    }
}
