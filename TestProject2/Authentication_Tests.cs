using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject2
{
    [TestCaseOrderer(
    ordererTypeName: "TestProject2.PriorityOrderer",
    ordererAssemblyName: "TestProject2")]
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

            public static bool Test1Called;
            public static bool Test2Called;
            public static bool Test3Called;
            public static bool Test4Called;
            public static bool Test5Called;
            public static bool Test6Called;
            public static bool Test7Called;
            public static bool Test8Called;

            [Fact, TestPriority(1)]
            // Registreerimimne
            public void SignUpUser()
            {
                Test1Called = true;

                Assert.False(Test2Called);
                Assert.False(Test3Called);
                Assert.False(Test4Called);
                Assert.False(Test5Called);
                Assert.False(Test6Called);
                Assert.False(Test7Called);
                Assert.False(Test8Called);

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

            [Fact, TestPriority(2)]
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

                IWebElement RemeberMeButton = driver.FindElement(By.Id("test_rememberMeButton"));
                RemeberMeButton.Click();

                SubmitLoginForm.Click();
            }
            private void InsertLogInData(IWebDriver driver)
            {
                IWebElement idOfName = driver.FindElement(By.Id("test_LoginUserName"));
                idOfName.SendKeys("Jane Doe");

                IWebElement idofPassword = driver.FindElement(By.Id("test_LogInPassword"));
                idofPassword.SendKeys("JaneDoe1234");

            }

            [Fact, TestPriority(3)]
            //LogIn function Test
            public void LogIn()
            {
                IWebDriver driver = Start();

                IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
                idOfLogInIndex.Click();

                LogInAction(driver);

            }

            [Fact, TestPriority(4)]
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

            [Fact, TestPriority(5)]
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

            [Fact, TestPriority(6)]
            public void CheckRememberMe()
            {
                IWebDriver driver = Start();

                IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
                idOfLogInIndex.Click();

                LogInAction(driver);

                Thread.Sleep(500);

                driver.SwitchTo().NewWindow(WindowType.Tab);
                driver.Navigate().GoToUrl("https://localhost:7260/");

                IWebElement dataofUserName = driver.FindElement(By.Id("CheckUserName"));
                var UserName = dataofUserName.Text;

                Assert.True(UserName == "Jane Doe");
            }


            //NEGATIVE TESTS

            [Fact, TestPriority(7)]
            // Check what happent whene you enter wrong password in LogIn form
            public void CheckPasswordErroeMessage()
            {
                IWebDriver driver = Start();

                IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
                idOfLogInIndex.Click();

                LogInActionWithWrongPassword(driver);

                IWebElement ErrorMessage = driver.FindElement(By.XPath("//div//ul//li"));
                var errorText = ErrorMessage.Text;

                Assert.False(errorText == "dewubuy");
            }

            [Fact, TestPriority(8)]
            //Check if username is false
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