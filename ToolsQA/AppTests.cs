using System;

public class AppTests
{
    /// <summary>
    /// This is simple example of test automation in C# with Selenium webdriver usage
    /// We will fill AutomationFormTest from: http://toolsqa.wpengine.com/automation-practice-form/
    /// Then we will check if we are redirected to new instance of the same page
    /// </summary>

    void AutomationFormTest()
    {
        /// <summary>
        /// This test will fill AutomationFormTest
        /// Then it will submit AutomationForm
        /// Next it will check if we are on a new instante of AutomationForm page
        /// </summary>

        SeleniumWrapper AppInstance = new SeleniumWrapper();
        AppInstance.Initialize();
        AppInstance.OpenApp();
        AppInstance.FillForm("Adrian", "Pralczak", 1991,
                                       0, 1, "Manual Tester",
                                       "Selenium Webdriver", 2, 2);
        bool IsEmpty = AppInstance.CheckIfFormEmpty();
        if (IsEmpty == true)
        {
            Console.WriteLine("Test passed. Form is empty");
        }
        else
        {
            Console.WriteLine("Test failed. Form is not empty");
        }
        AppInstance.Teardown();
    }


    static void Main()
    {
        /// <summary>
        /// This method will create new object of AppTests class and start AutomationFormTest test
        /// </summary>

        Console.WriteLine("Testing is started!");
        AppTests appTest = new AppTests();
        appTest.AutomationFormTest();
        Console.WriteLine("Testing has ended.");
        Console.ReadKey();
    }
}