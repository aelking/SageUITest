using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Linq;

namespace SageUITest.Pages
{
    public class SagePeople : PageObject
    {
        [FindsBy(How = How.Id, Using = "wx-header__hamburger")]
        IWebElement menuButton;

        [FindsBy(How = How.LinkText, Using = "Performance")]
        IWebElement performanceMenu;

        public SagePeople(IWebDriver driver) : base(driver)
        {

        }

        public ObjectivesOverview GoToObjectivesOverview()
        {
            var wait = new WebDriverWait(this.driver, new TimeSpan(0, 1, 0));
            wait.Until(ExpectedConditions.ElementExists(By.Id("wx-header__hamburger")));
            menuButton.Click();

            // Expand the performance tab
            var allLinks = driver.FindElements(new ByChained(By.CssSelector("a[data-target='#item-user-5']"), By.ClassName("wx-sidebar-menu__arrow-container")));

            allLinks.Last().Click();

            // Click on the objectives link
            var objectives = driver.FindElement(By.LinkText("Objectives"));
            objectives.Click();

            return new ObjectivesOverview(driver);
        }

    }
}
