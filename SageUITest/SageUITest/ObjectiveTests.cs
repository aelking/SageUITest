using AutoFixture;
using OpenQA.Selenium.Firefox;
using SageUITest.Model;
using SageUITest.Pages;
using System;
using Xunit;

namespace SageUITest
{
    public class ObjectiveTests
    {
        private string Url = "https://login.salesforce.com/";
        private string Username = "john.sher@test.com";
        private string Password = "tester123";

        [Fact]
        public void CreateANewDraftObjective()
        {
            var driver = new FirefoxDriver();
            driver.Url = Url;

            var loginPage = new LoginPage(driver);
            var sagePeople = loginPage.LogIn(Username, Password);
            var objectivesOverview = sagePeople.GoToObjectivesOverview();

            // Generate Test Data
            var fixture = new Fixture();
            var newObjective = fixture.Create<Objective>();

            objectivesOverview.CreateNewObjective(newObjective);

            // Was the objective created?
        }
    }
}
