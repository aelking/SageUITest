using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SageUITest.Pages
{
    public class PageObject
    {
        public IWebDriver driver { get; }

        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
