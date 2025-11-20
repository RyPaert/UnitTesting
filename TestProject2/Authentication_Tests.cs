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

            InsertRegistrationData(driver);

            IWebElement registerAccount = driver.FindElement(By.Id("test_registerAccountButton"));
            registerAccount.Click();

        }
        private void InsertRegistrationData(IWebDriver driver)
        {
            IWebElement idofName = driver.FindElement(By.Id("test_Username"));
            idofName.SendKeys("Jane Doe");

            IWebElement idofEmail = driver.FindElement(By.Id("test_Email"));
            idofEmail.SendKeys("Jane.Doe@gmail.com");

            IWebElement idofPassword = driver.FindElement(By.Id("test_Password"));
            idofPassword.SendKeys("JaneDoe1234");

            IWebElement idofConfirmPassword = driver.FindElement(By.Id("test_ConfirmPassword"));
            idofConfirmPassword.SendKeys("JaneDoe1234");

        }

        [Fact]
        //Whene User already have a account
        public void HaveAnAccount()
        {
            IWebDriver driver = Start();

            IWebElement idOfRegisterIndex = driver.FindElement(By.Id("test_register_index"));
            idOfRegisterIndex.Click();

            IWebElement HaveAnaccountLink = driver.FindElement(By.Id("test_HaveAnAccount"));
            HaveAnaccountLink.Click();

            LogInAction(driver);

        }
        private void LogInAction(IWebDriver driver)
        {

            InsertLogInData(driver);

            IWebElement SubmitLoginForm = driver.FindElement(By.Id("test_LoginButton"));
            SubmitLoginForm.Click();
        }
        private void InsertLogInData(IWebDriver driver) 
        {
            IWebElement idOfName = driver.FindElement(By.Id("test_LoginUserName"));
            idOfName.SendKeys("Jane Doe");

            IWebElement idofPassword = driver.FindElement(By.Id("test_LogInPassword"));
            idofPassword.SendKeys("JaneDoe1234");

        }

        [Fact]
        //LogIn function Test
        public void LogIn()
        {
            IWebDriver driver = Start();

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            LogInAction(driver);

        }

        [Fact]
        //LogOut function test
        public void LogOut()
        {
            IWebDriver driver = Start();

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            LogInAction(driver);

            IWebElement idOfLogOutIndex = driver.FindElement(By.Id("test_logout_button"));
            idOfLogOutIndex.Click();

        }

        [Fact]
        // Check if login username is correct
        public void CheckCorrectUserName()
        {
            IWebDriver driver = Start();

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            LogInAction(driver);

            IWebElement dataofUserName = driver.FindElement(By.Id("CheckUserName"));
            var UserName = dataofUserName.Text;

            Assert.True(UserName == "Jane Doe");

        }


        //NEGATIVE TESTS

        [Fact]
        // Check what happent whene you enter wrong password in LogIn form
        public void CheckPassword()
        {
            IWebDriver driver = Start();

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            LogInActionWithWrongPassword(driver);

            IWebElement ErrorMessage = driver.FindElement(By.XPath("//div//ul//li"));
            var errorText = ErrorMessage.Text;

            Assert.False(errorText == "dewubuy");
        }

        [Fact]
        public void CheckFalseUserName()
        {
            IWebDriver driver = Start();

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            LogInAction(driver);

            IWebElement dataofUserName = driver.FindElement(By.Id("CheckUserName"));
            var UserName = dataofUserName.Text;

            Assert.False(UserName == "Jane Puu");

        }
        // Login with wrong password
        private void LogInActionWithWrongPassword(IWebDriver driver)
        {

            InsertWrongLogInData(driver);


            IWebElement SubmitLoginForm = driver.FindElement(By.Id("test_LoginButton"));
            SubmitLoginForm.Click();

        }
        // Insert wrong password to login form
        private void InsertWrongLogInData(IWebDriver driver)
        {
            IWebElement idOfName = driver.FindElement(By.Id("test_LoginUserName"));
            idOfName.SendKeys("Jane Doe");


            IWebElement idofPassword = driver.FindElement(By.Id("test_LogInPassword"));
            idofPassword.SendKeys("JaneDoe12");

        }
    }
}