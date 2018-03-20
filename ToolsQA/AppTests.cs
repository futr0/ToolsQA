using System;
using NUnit.Framework;

[TestFixture]
public class AppTests
{
    /// <summary>
    /// Simple example of test automation in C# with usage of: Selenium webdriver and NUnit
    /// </summary>
    /// 

    public SeleniumWrapper AppInstance;

    [SetUp]
    public void Init()
    {
        AppInstance = new SeleniumWrapper();
        AppInstance.Initialize();
    }

    [Test]
    [TestCase("by_link", "Link Test", "http://toolsqa.com/automation-practice-table/")]
    [TestCase("by_partial_link", "Partial Link", "http://toolsqa.com/automation-practice-form/")]
    [TestCase("by_link", "Partial Link", "http://fakesite.com/")]
    public void RedirectLinkTest(string link_type, string link_text, string expected_page)
    {
        AppInstance.OpenApp();
        AppInstance.FindElementByLink(link_type, link_text);
        bool IsExpectedPage = AppInstance.CheckActualPage(expected_page);
        Assert.IsTrue(IsExpectedPage);
        Console.WriteLine("Test passed. User was redirected to correct page");
    }

    [Test]
    [TestCase("Adrian", "Palczak", 1991, 0, 1, "Manual Tester", "Selenium Webdriver", 2, 2)]
    [TestCase("Grzegorz", "Krawczyk", 1991, 0, 1, "Manual Tester", "QTP", 1, 3)]
    [TestCase("Invalid", "Data", 2000, 0, 0, "Automation Tester", "Fake", 1, 0)]
    public void AutomationFormTest(string name, string surname, int year,
                                   int gender, int exp_years, string profession,
                                   string tool, int continent, int command)
    {
        /// <summary>
        /// This test will fill AutomationFormTest
        /// Then it will submit AutomationForm from: http://toolsqa.wpengine.com/automation-practice-form/
        /// Next it will check if we are on a new instante of AutomationForm page
        /// <param name="name">Person;s firstname</param>
        /// <param name="surname">Person's lastname</param>
        /// <param name="year">Person's birthdate</param>
        /// <param name="gender">Person's gender</param>
        /// <param name="exp_years">Person's experience years in testing</param>
        /// <param name="profession">Person's profession</param>
        /// <param name="tool">Person's testing tool</param>
        /// <param name="continent">Person's Continent</param>
        /// <param name="command">Person's command</param>
        /// </summary>

        AppInstance.OpenApp();
        AppInstance.FillForm(name, surname, year,
                                       gender, exp_years, profession,
                                       tool, continent, command);
        bool IsEmpty = AppInstance.CheckIfFormEmpty();
        Assert.IsTrue(IsEmpty);
        Console.WriteLine("Test passed. Form is empty");
    }

    [TearDown]
    public void CloseApp()
    {
        AppInstance.Teardown();

    }


    static void Main()

    {
        /// <summary>
        /// Main method must be somewhere...
        /// </summary>
    }
}