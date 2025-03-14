using OpenQA.Selenium;

namespace Task1.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private const string LoginUrl = "http://the-internet.herokuapp.com/login";

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Navigate to the login page
        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(LoginUrl);
        }

        // Enter username and password
        public void EnterCredentials(string username, string password)
        {
            var usernameField = _driver.FindElement(By.Id("username"));
            usernameField.Clear();
            usernameField.SendKeys(username);

            var passwordField = _driver.FindElement(By.Id("password"));
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        // Click the login button
        public void ClickLogin()
        {
            _driver.FindElement(By.CssSelector("button.radius")).Click();
        }

        // Verify if the secure area page is displayed
        public bool IsSecureAreaDisplayed()
        {
            // After a successful login, the URL should contain '/secure'
            return _driver.Url.Contains("/secure");
        }
    }
}
