using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject2
{
	[TestCaseOrderer(
	ordererTypeName: "TestProject2.PriorityOrderer",
	ordererAssemblyName: "TestProject2")]
	public class AccountFunctions_Tests
    {
        private static IWebDriver Start()
        {
            string binaryLocation = "C:\\Users\\rylei\\Downloads\\FirefoxPortable\\App\\Firefox64\\firefox.exe";
            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = binaryLocation;

            IWebDriver driver = new FirefoxDriver("C:\\Users\\rylei\\source\\repos\\UnitTesting\\TestProject2\\driver\\geckodriver.exe", options);
            driver.Url = "https://localhost:7260/";
            return driver;
        }
		// Acceptance tests

		[Fact, TestPriority(1)]
		public void RegisterAccount()
		{
			IWebDriver driver = Start();

			IWebElement idOfRegisterIndex = driver.FindElement(By.Id("test_register_index"));
			idOfRegisterIndex.Click();

			InsertRegistrationData(driver);

			IWebElement registerAccount = driver.FindElement(By.Id("test_registerAccountButton"));
			registerAccount.Click();

			Thread.Sleep(500);
			driver.Quit();
		}

		[Fact, TestPriority(2)]
        public void LogIntoAccount()
        {
            IWebDriver driver = Start();
            IWebElement idOfLoginIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLoginIndex.Click();

            Login(driver);

			Thread.Sleep(500);
			driver.Quit();
		}

		[Fact, TestPriority(3)]
        public void AlreadyHaveAnAccount()
        {
            IWebDriver driver = Start();

			IWebElement idOfRegisterIndex = driver.FindElement(By.Id("test_register_index"));
			idOfRegisterIndex.Click();

			IWebElement HaveAnaccountLink = driver.FindElement(By.Id("test_AlreadyHaveAnAccount"));
			HaveAnaccountLink.Click();

            Login(driver);

			Thread.Sleep(500);
			driver.Quit();
		}

		[Fact, TestPriority(4)]
        public void Logout()
        {
            IWebDriver driver = Start();

			IWebElement idOfLoginIndex = driver.FindElement(By.Id("test_login_index"));
			idOfLoginIndex.Click();

			Login(driver);

            IWebElement idOfLogoutIndex = driver.FindElement(By.Id("test_Logout_Index"));
            idOfLogoutIndex.Click();

			Thread.Sleep(500);
			driver.Quit();
		}

        [Fact, TestPriority(5)]
        public void CheckLayoutUsername()
        {
            IWebDriver driver = Start();

			IWebElement idOfLoginIndex = driver.FindElement(By.Id("test_login_index"));
			idOfLoginIndex.Click();

            Login(driver);

            IWebElement layoutUsernameCheck = driver.FindElement(By.Id("test_layoutUsername"));
            var layoutUsername = layoutUsernameCheck.Text;

            Assert.True(layoutUsername == "Jane Doe");

			Thread.Sleep(500);
			driver.Quit();
		}
        [Fact, TestPriority(6)]
        public void RememberMeCheck()
        {
            IWebDriver driver = Start();

			IWebElement idOfLoginIndex = driver.FindElement(By.Id("test_login_index"));
			idOfLoginIndex.Click();

			Login(driver);

			Thread.Sleep(500);

			driver.SwitchTo().NewWindow(WindowType.Tab);
			driver.Navigate().GoToUrl("https://localhost:7260");

			IWebElement layoutUsernameCheck = driver.FindElement(By.Id("test_layoutUsername"));
			var layoutUsername = layoutUsernameCheck.Text;

			Assert.True(layoutUsername == "Jane Doe");

            Thread.Sleep(500);
			driver.Quit();
		}

        //Failure tests
        [Fact, TestPriority(7)]
        public void CheckFalseLayoutUsername()
        {
			IWebDriver driver = Start();

			IWebElement idOfLoginIndex = driver.FindElement(By.Id("test_login_index"));
			idOfLoginIndex.Click();

			Login(driver);

			IWebElement layoutUsernameCheck = driver.FindElement(By.Id("test_layoutUsername"));
			var layoutUsername = layoutUsernameCheck.Text;

			Assert.False(layoutUsername == "Jane D0e");

			Thread.Sleep(500);
			driver.Quit();
		}

        [Fact, TestPriority(8)]
		public void LoginWithWrongData()
		{
			IWebDriver driver = Start();
			IWebElement idOfLoginIndex = driver.FindElement(By.Id("test_login_index"));
			idOfLoginIndex.Click();

			IWebElement idOfName = driver.FindElement(By.Id("test_LoginUsername"));
			idOfName.SendKeys("Jane Doeeee");

			Thread.Sleep(500);

			IWebElement idofPassword = driver.FindElement(By.Id("test_LoginPassword"));
			idofPassword.SendKeys("JaneDoe12345125");

			Login(driver);

			Thread.Sleep(1000);
			driver.Quit();
		}

		// Test Functions
		private void InsertRegistrationData(IWebDriver driver)
        {
			IWebElement idofUsername = driver.FindElement(By.Id("test_Username"));
			idofUsername.SendKeys("Jane Doe");

			IWebElement idofEmail = driver.FindElement(By.Id("test_Email"));
			idofEmail.SendKeys("Jane.Doe@gmail.com");

			IWebElement idofPassword = driver.FindElement(By.Id("test_Password"));
			idofPassword.SendKeys("JaneDoe1234");

			IWebElement idofConfirmPassword = driver.FindElement(By.Id("test_ConfirmPassword"));
			idofConfirmPassword.SendKeys("JaneDoe1234");
		}
        private void InsertLoginData(IWebDriver driver)
        {
			IWebElement idOfName = driver.FindElement(By.Id("test_LoginUsername"));
			idOfName.SendKeys("Jane Doe");

			Thread.Sleep(500);

			IWebElement idofPassword = driver.FindElement(By.Id("test_LoginPassword"));
			idofPassword.SendKeys("JaneDoe1234");
		}
        private void Login(IWebDriver driver)
        {
            InsertLoginData(driver);

            IWebElement SubmitLoginForm = driver.FindElement(By.Id("test_LoginSubmitForm"));
            IWebElement RememberMeCheck = driver.FindElement(By.Id("test_LoginRememberMe"));

            RememberMeCheck.Click();
            SubmitLoginForm.Click();
        }
    }
}