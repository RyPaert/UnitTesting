using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string binaryLocation = "C:\\Users\\opilane\\source\\repos\\Testing\\FirefoxPortable\\App\\Firefox64\\firefox.exe";
            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = binaryLocation;

            IWebDriver driver = new FirefoxDriver("C:\\Users\\opilane\\source\\repos\\Testing\\TestProject2\\bin\\Debug\\net8.0", options);
            driver.Url = "https://localhost:44305/";

            IWebElement idOfRegisterIndex = driver.FindElement(By.Id("test_register_index"));
            idOfRegisterIndex.Click();

            Thread.Sleep(1000);

            InsertRegistrationData(driver);

            IWebElement registerAccount = driver.FindElement(By.Id("test_registerAccountButton"));
            registerAccount.Click();

        }

        private void InsertRegistrationData(IWebDriver driver)
        {
            IWebElement idofName = driver.FindElement(By.Id("test_Username"));
            idofName.SendKeys("Jane Doe");
            Thread.Sleep(500);

            IWebElement idofEmail = driver.FindElement(By.Id("test_Email"));
            idofEmail.SendKeys("Jane.Doe@gmail.com");
            Thread.Sleep(500);

            IWebElement idofPassword = driver.FindElement(By.Id("test_Password"));
            idofPassword.SendKeys("JaneDoe1234");
            Thread.Sleep(500);

            IWebElement idofConfirmPassword = driver.FindElement(By.Id("test_ConfirmPassword"));
            idofConfirmPassword.SendKeys("JaneDoe1234");
            Thread.Sleep(500);

        }
    }
}