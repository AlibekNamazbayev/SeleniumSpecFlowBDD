using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; 
using System;
using TechTalk.SpecFlow;
using Task1.PageObjects;

namespace Task1.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver = null!;
        private LoginPage _loginPage = null!;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _loginPage = new LoginPage(_driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.NavigateTo();
        }

        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            _loginPage.EnterCredentials("tomsmith", "SuperSecretPassword!");
            _loginPage.ClickLogin();
        }

        [Then(@"I should be redirected to the secure area")]
        public void ThenIShouldBeRedirectedToTheSecureArea()
        {
            // Wait up to 10 seconds for the URL to contain "/secure"
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            bool urlChanged = wait.Until(driver => driver.Url.Contains("/secure"));
            Assert.That(urlChanged, Is.True, "Secure area is not displayed after login.");
        }
    }
}
