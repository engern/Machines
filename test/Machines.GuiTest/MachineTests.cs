using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Machines.GuiTest
{
    public class MachineTests
    {
        string test_url = "http://localhost:8080/";

        IWebDriver driver;

        [SetUp]
        public void start_Browser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        [Test]
        public void AddEditAndDeleteMachine()
        {
            driver.Url = test_url;

            var originalMachineName = Guid.NewGuid().ToString();
            var updatedMachineName = Guid.NewGuid().ToString();

            // add new machine
            driver.FindElement(By.Id("BtnAdd")).Click();
            driver.FindElement(By.Id("InputMachineName")).SendKeys(originalMachineName);
            driver.FindElement(By.Id("BtnSaveMachine")).Click();

            // Verify item in list, will throw exception and fail test if not present
            driver.FindElement(By.XPath($"//*[text()='{originalMachineName}']"));

            // edit item
            var editButton = driver.FindElement(By.XPath($"//div[@data-machinename='{originalMachineName}']/h3/i[@class='fas fa-pen']"));
            editButton.Click();

            
            var editInput = driver.FindElement(By.XPath($"//div[@data-machinename='{originalMachineName}']/h3/input"));
            editInput.Clear();
            editInput.SendKeys(updatedMachineName);

            var saveButton = driver.FindElement(By.XPath($"//div[@data-machinename='{originalMachineName}']/h3/i[@class='fas fa-save']"));
            saveButton.Click();

            // Verify new name in list, will throw exception and fail test if not present
            driver.FindElement(By.XPath($"//*[text()='{updatedMachineName}']"));

            //verify old name removed
            try
            {
                driver.FindElement(By.XPath($"//*[text()='{originalMachineName}']"));
                Assert.Fail("original item is still present"); // If it does not throw exception, item is still in list and the test should fail
            }
            catch { }

            // delete item
            var deleteButton = driver.FindElement(By.XPath($"//div[@data-machinename='{updatedMachineName}']/h3/i[@class='fas fa-times']"));
            deleteButton.Click();

            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(500); // Give the GUI some time to update

            //verify item delted
            try
            {
                driver.FindElement(By.XPath($"//*[text()='{updatedMachineName}']"));
                Assert.Fail("updated item is still present"); // If it does not throw exception, item is still in list and the test should fail
            }
            catch { }
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Close();
            driver.Quit();
        }
    }
}