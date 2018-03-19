using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

public class SeleniumWrapper
{
    /// <summary>
    /// This class is a simple wrapper for some actions that can be done using Selenium webdriver
    /// </summary>

    public string Address = "http://toolsqa.wpengine.com/automation-practice-form/";
    IWebDriver driver;

    public void Initialize()
    {
        //Firefox driver initialization
        driver = new FirefoxDriver();
    }

    public void OpenApp()
    {
        //App opening
        driver.Url = this.Address;
    }

    public void Teardown()
    {
        //Closing browser
        driver.Quit();
    }

    public void FindClickType(By Locator, string Text = "")
    {
        /// <summary>
        /// This method will Find and Click an web element or Find, Click and Type to its field
        /// <param name="Locator">Id/Xpath locator string value</param>
        /// <param name="Text">Text, that we want to type into some web element</param>
        /// </summary>

        IWebElement FormField = driver.FindElement(Locator);
        FormField.Click();
        if (Text != "")
        {
            FormField.SendKeys(Text);
        }
         

    }

    public void DropDownSelect(string id, string option)
    {
        /// <summary>
        /// This method will select an option from Dropdown web element
        /// <param name="id">Id locator string value</param>
        /// <param name="option">String value of Dropdown web element option</param>
        /// </summary>
 
        string XPathQuery = String.Format(".//*[@id='{0}']/option[{1}]", id, option);
        By Locator = By.XPath(XPathQuery);
        IWebElement FormField = driver.FindElement(Locator);
        FormField.Click();
    }

    public void FillForm(string firstname, string lastname, int date,
                                   int gender, int experience_years, string profession,
                                   string tool, int continent, int command)
    {
        /// <summary>
        /// This method fill AutomationForm
        /// <param name="firstname">Person;s firstname</param>
        /// <param name="lastname">Person's lastname</param>
        /// <param name="date">Person's birthdate</param>
        /// <param name="gender">Person's gender</param>
        /// <param name="experience_years">Person's experience years in testing</param>
        /// <param name="profession">Person's profession</param>
        /// <param name="tool">Person's testing tool</param>
        /// <param name="continent">Person's Continent</param>
        /// <param name="command">Person's command</param>
        /// </summary>


        //Firstname typing
        By Locator = By.Name("firstname");
        FindClickType(Locator, firstname);

        //Lastname typing
        Locator = By.Name("lastname");
        FindClickType(Locator, lastname);

        //Gender selection
        string sex = "";
        if (gender == 0)
        {
            sex = "Male";
        }
        else
        {
            sex = "Female";
        }

        string XPathQuery = String.Format("//input[@type='radio' and @name='sex' and @value='{0}']", sex);
        Locator = By.XPath(XPathQuery);
        FindClickType(Locator);

        //Experience years selection
        XPathQuery = String.Format("//input[@type='radio' and @name='exp' and @value='{0}']", experience_years.ToString());
        Locator = By.XPath(XPathQuery);
        FindClickType(Locator);

        //Date typing
        Locator = By.Id("datepicker");
        FindClickType(Locator, date.ToString());

        //Profession selection
        XPathQuery = String.Format("//input[@type='checkbox' and @name='profession' and @value='{0}']", profession);
        Locator = By.XPath(XPathQuery);
        FindClickType(Locator);

        //Tool selection
        XPathQuery = String.Format("//input[@type='checkbox' and @name='tool' and @value='{0}']", tool);
        Locator = By.XPath(XPathQuery);
        FindClickType(Locator);

        //Continents selection
        DropDownSelect("continents", continent.ToString());

        //Commands selection
        DropDownSelect("selenium_commands", command.ToString());

        //Submit action
        Locator = By.Id("submit");
        FindClickType(Locator);
    }

    public bool CheckIfFormEmpty()
    {
        /// <summary>
        /// This method will check if not text is in firstname input
        /// and if gender radiobutton is not selected
        /// </summary>


        bool IsEmpty = false;

        int falseCounter = 0;

        //Firstname field checking
        By Locator = By.Name("firstname");
        IWebElement FormField = driver.FindElement(Locator);
        FormField.Click();
        string value = FormField.GetAttribute("value");
        if(value == "")
        {
            falseCounter++;
        }

        //Gender field checking
        string[] sex = new string[] {"Female", "Male"};

        for (int i =0; i <=1; i++)
        {
            string XPathQuery = String.Format("//input[@type='radio' and @name='sex' and @value='{0}']", sex[i]);
            Locator = By.XPath(XPathQuery);
            IWebElement FormField2 = driver.FindElement(Locator);
            bool value2 = FormField2.Selected;
            if (value2 == false)
            {
                falseCounter++;
            }
        }

        if (falseCounter == 3)
        {
            IsEmpty = true;
        }

        return IsEmpty;

    }

}