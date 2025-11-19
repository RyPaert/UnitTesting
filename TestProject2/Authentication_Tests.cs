using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject2
{
    public class Authentication_Tests
    {
        //POSITIVE TESTS

        // this is Start method
        private static IWebDriver Start()
        {
            string binasryLocation = "C:\\Users\\opilane\\source\\repos\\Download\\FirefoxPortable\\App\\Firefox64\\firefox.exe";
            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = binasryLocation;

            IWebDriver driver = new FirefoxDriver("C:\\Users\\opilane\\source\\repos\\UnitTesting\\TestProject2\\driver\\geckodriver.exe", options);
            driver.Url = "https://localhost:7260/";
            return driver;
        }

        [Fact]
        // Registreerimimne
        public void SignUpUser()
        {
            IWebDriver driver = Start();

            IWebElement idOfRegisterIndex = driver.FindElement(By.Id("test_register_index"));
            idOfRegisterIndex.Click();

            Thread.Sleep(1000);

            InsertRegistrationData(driver);

            IWebElement registerAccount = driver.FindElement(By.Id("test_registerAccountButton"));
            registerAccount.Click();

            Thread.Sleep(500);

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

        [Fact]
        //Whene User already have a account
        public void HaveAnAccount()
        {
            IWebDriver driver = Start();

            IWebElement idOfRegisterIndex = driver.FindElement(By.Id("test_register_index"));
            idOfRegisterIndex.Click();

            Thread.Sleep(500);

            IWebElement HaveAnaccountLink = driver.FindElement(By.Id("test_HaveAnAccount"));
            HaveAnaccountLink.Click();

            LogInAction(driver);

            Thread.Sleep(500);
        }
        private void LogInAction(IWebDriver driver)
        {
            Thread.Sleep(500);

            InsertLogInData(driver);

            Thread.Sleep(500);

            IWebElement SubmitLoginForm = driver.FindElement(By.Id("test_LoginButton"));
            SubmitLoginForm.Click();

            Thread.Sleep(500);
        }
        private void InsertLogInData(IWebDriver driver) 
        {
            IWebElement idOfName = driver.FindElement(By.Id("test_LoginUserName"));
            idOfName.SendKeys("Jane Doe");

            Thread.Sleep(500);

            IWebElement idofPassword = driver.FindElement(By.Id("test_LogInPassword"));
            idofPassword.SendKeys("JaneDoe1234");

        }

        [Fact]
        //LogIn function Test
        public void LogIn()
        {
            IWebDriver driver = Start();

            Thread.Sleep(500);

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            Thread.Sleep(500);

            LogInAction(driver);

            Thread.Sleep(500);
        }

        [Fact]
        //LogOut function test
        public void LogOut()
        {
            IWebDriver driver = Start();

            Thread.Sleep(500);

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            Thread.Sleep(500);

            LogInAction(driver);

            Thread.Sleep(500);

            IWebElement idOfLogOutIndex = driver.FindElement(By.Id("test_logout_button"));
            idOfLogOutIndex.Click();

            Thread.Sleep(500);
        }

        [Fact]
        // Check if login username is correct
        public void CheckUserName()
        {
            IWebDriver driver = Start();

            Thread.Sleep(500);

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            Thread.Sleep(500);

            LogInAction(driver);

            Thread.Sleep(500);

            IWebElement dataofUserName = driver.FindElement(By.Id("CheckUserName"));
            var UserName = dataofUserName.Text;

            Assert.True(UserName == "Jane Doe");

            Thread.Sleep(500);
        }


        //NEGATIVE TESTS

        [Fact]
        // Check what happent whene you enter wrong password in LogIn form
        public void CheckPassword()
        {
            IWebDriver driver = Start();

            Thread.Sleep(500);

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            Thread.Sleep(500);

            LogInActionWithWrongPassword(driver);
        }
        // Login with wrong password
        private void LogInActionWithWrongPassword(IWebDriver driver)
        {
            Thread.Sleep(500);

            InsertWrongLogInData(driver);

            Thread.Sleep(500);

            IWebElement SubmitLoginForm = driver.FindElement(By.Id("test_LoginButton"));
            SubmitLoginForm.Click();

            Thread.Sleep(500);
        }
        // Insert wrong password to login form
        private void InsertWrongLogInData(IWebDriver driver)
        {
            IWebElement idOfName = driver.FindElement(By.Id("test_LoginUserName"));
            idOfName.SendKeys("Jane Doe");

            Thread.Sleep(500);

            IWebElement idofPassword = driver.FindElement(By.Id("test_LogInPassword"));
            idofPassword.SendKeys("JaneDoe12");

        }
    }
}