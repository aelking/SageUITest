using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SageUITest.Model;
using SeleniumExtras.PageObjects;
using System;
using System.Linq;

namespace SageUITest.Pages
{
    public class ObjectivesOverview : PageObject
    {
        IWebElement newButton;

        public ObjectivesOverview(IWebDriver driver) : base(driver)
        {
        }

        public void CreateNewObjective(Objective objective)
        {
            var wait = new WebDriverWait(this.driver, new TimeSpan(0, 1, 0));
            wait.Until(ExpectedConditions.ElementExists(new ByChained(By.CssSelector("wx-button-open[operation-id='create']"), By.TagName("button"))));
            newButton = this.driver.FindElement(new ByChained(By.CssSelector("wx-button-open[operation-id='create']"), By.TagName("button")));
            newButton.Click();

            var newObjectiveDialog = new NewObjectiveDialog(driver);
            newObjectiveDialog.FillForm(objective.Name,
                                        objective.Description,
                                        objective.Measure,
                                        objective.StrategicGoal,
                                        objective.Contributes,
                                        objective.StartDate,
                                        objective.EndDate,
                                        objective.NextReviewDate,
                                        objective.Weight,
                                        objective.IsRequiredForBonus,
                                        objective.IsPrivate);

            newObjectiveDialog.Save();

        }

        internal class NewObjectiveDialog : PageObject
        {
            [FindsBy(How = How.Name, Using = "name")]
            IWebElement name;

            [FindsBy(How = How.Name, Using = "description")]
            IWebElement description;

            [FindsBy(How = How.Name, Using = "measure")]
            IWebElement measure;

            [FindsBy(How = How.Name, Using = "strategicObjective")]
            IWebElement strategicObjective;

            [FindsBy(How = How.Name, Using = "contributesTo")]
            IWebElement contributesTo;

            [FindsBy(How = How.Name, Using = "startdate")]
            IWebElement startdate;

            [FindsBy(How = How.Name, Using = "endDate")]
            IWebElement endDate;

            [FindsBy(How = How.Name, Using = "nextreviewdate")]
            IWebElement nextreviewdate;

            [FindsBy(How = How.Name, Using = "weight")]
            IWebElement weight;

            IWebElement saveButton;

            public NewObjectiveDialog(IWebDriver driver) : base(driver)
            {
            }

            internal void FillForm(string name,
                                   string description,
                                   string measure,
                                   string strategicGoal,
                                   string contributes,
                                   DateTime startDate,
                                   DateTime endDate,
                                   DateTime nextReviewDate,
                                   int weight,
                                   string isRequiredForBonus,
                                   string isPrivate)
            {
                this.name.SendKeys(name);
                this.description.SendKeys(description);
                this.measure.SendKeys(measure);
                //this.startdate.SendKeys(startDate.ToLongDateString());
                //this.endDate.SendKeys(endDate.ToLongDateString());
                //this.nextreviewdate.SendKeys(nextReviewDate.ToLongDateString());
                this.weight.SendKeys(weight.ToString($"{0:1}"));
            }

            internal void Save()
            {
                var saveButton = this.driver.FindElements(By.XPath("//button[text() = 'Save']")).First(d => d.Displayed);

                saveButton.Click();
            }
        }
    }
}
