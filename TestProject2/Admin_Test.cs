using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject2
{
    public class Admin_Test
    {
        private static IWebDriver Start()
        {
            string driverlocation = "C:\\Users\\opilane\\source\\repos\\TestProject2\\bin\\Debug\\net8.0";
            string binaryLocation = "C:\\Users\\opilane\\source\\repos\\FirefoxPortable\\App\\Firefox64\\firefox.exe";

            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = binaryLocation;

            IWebDriver driver = new FirefoxDriver(driverlocation, options);
            driver.Url = "https://localhost:7260/";
            return driver;
         
        }
        [Fact]
        //registreerimine pos
        public void Register()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealRegister = driver.FindElement(By.Id("test_index_Register"));
            idOfRealRegister.Click();
            Thread.Sleep(500);

            GetRegisterData(driver);

            IWebElement idOfRealRegisterCreate = driver.FindElement(By.Id("Test_Register_Create"));
            idOfRealRegisterCreate.Click();
            Thread.Sleep(500);
        }
        //registreerimine andmete sisestus pos
        private static void GetRegisterData(IWebDriver driver) 
        {
            IWebElement idOfUserName = driver.FindElement(By.Id("test_register_userName"));
            idOfUserName.Clear();
            idOfUserName.SendKeys("Test username");
            Thread.Sleep(500);

            IWebElement idOfEmail = driver.FindElement(By.Id("test_regirster_email"));
            idOfEmail.Clear();
            idOfEmail.SendKeys("TestEmail@gmail.com");
            Thread.Sleep(500);

            IWebElement idOfPassword = driver.FindElement(By.Id("test_register_password"));
            idOfPassword.Clear();
            idOfPassword.SendKeys("TestPassword");
            Thread.Sleep(500);

            IWebElement idOfConfirmPassword = driver.FindElement(By.Id("test_register_confirmPassword"));
            idOfConfirmPassword.Clear();
            idOfConfirmPassword.SendKeys("TestPassword");
            Thread.Sleep(500);
        }
        //login pos
        [Fact]
        public void LogIn()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();
            Thread.Sleep(500);

            GetLogInData(driver);

            IWebElement idOfRealLogInCreate = driver.FindElement(By.Id("test_LogIn_Create"));
            idOfRealLogInCreate.Click();
            Thread.Sleep(500);
        }
        //login andmete sisestamine
        private static void GetLogInData(IWebDriver driver)
        {
            IWebElement idOfUserName = driver.FindElement(By.Id("test_logIn_userName"));
            idOfUserName.Clear();
            idOfUserName.SendKeys("Test username");
            Thread.Sleep(500);

            IWebElement idOfEmail = driver.FindElement(By.Id("test_logIn_userPassword"));
            idOfEmail.Clear();
            idOfEmail.SendKeys("TestPassword");
            Thread.Sleep(500);
 
        }

    }
}