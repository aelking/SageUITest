using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SageUITest.Pages
{
    class LoginPage : PageObject
    {
        [FindsBy(How = How.Id, Using = "username")]
        IWebElement usernameTextBox;

        [FindsBy(How = How.Id, Using = "password")]
        IWebElement passwordTextBox;

        [FindsBy(How = How.Id, Using = "Login")]
        IWebElement logInButton;

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public SagePeople LogIn(string username, string password)
        {
            usernameTextBox.SendKeys(username);
            passwordTextBox.SendKeys(password);
            logInButton.Click();

            return new SagePeople(this.driver);
        }
    }
}
