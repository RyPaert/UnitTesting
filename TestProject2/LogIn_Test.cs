using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject2
{
    public class LogIn_Test
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
        //REG
        public void Register()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealRegister = driver.FindElement(By.Id("test_index_Register"));
            idOfRealRegister.Click();


            GetRegisterData(driver);

        }
        //REG DATA
        private static void GetRegisterData(IWebDriver driver)
        {
            IWebElement idOfUserName = driver.FindElement(By.Id("test_register_userName"));
            idOfUserName.Clear();
            idOfUserName.SendKeys("Test username");


            IWebElement idOfEmail = driver.FindElement(By.Id("test_regirster_email"));
            idOfEmail.Clear();
            idOfEmail.SendKeys("TestEmail@gmail.com");


            IWebElement idOfPassword = driver.FindElement(By.Id("test_register_password"));
            idOfPassword.Clear();
            idOfPassword.SendKeys("TestPassword");


            IWebElement idOfConfirmPassword = driver.FindElement(By.Id("test_register_confirmPassword"));
            idOfConfirmPassword.Clear();
            idOfConfirmPassword.SendKeys("TestPassword");

            IWebElement idOfRealRegisterCreate = driver.FindElement(By.Id("Test_Register_Create"));
            idOfRealRegisterCreate.Click();

        }
        //LOGIN
        [Fact]
        public void LogIn()
        {
            IWebDriver driver = Start();
            IWebElement idOfRealRegister = driver.FindElement(By.Id("test_index_Register"));
            idOfRealRegister.Click();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();
            Thread.Sleep(500);

            GetLogInData(driver);

        }

        //LOGIN DATA
        private static void GetLogInData(IWebDriver driver)
        {
            IWebElement idOfUserName = driver.FindElement(By.Id("test_logIn_userName"));
            idOfUserName.Clear();
            idOfUserName.SendKeys("Test username");


            IWebElement idOfEmail = driver.FindElement(By.Id("test_logIn_userPassword"));
            idOfEmail.Clear();
            idOfEmail.SendKeys("TestPassword");


            IWebElement idOfRealLogInCreate = driver.FindElement(By.Id("test_LogIn_Create"));
            idOfRealLogInCreate.Click();
            Thread.Sleep(500);

        }
        //LOGOUT
        [Fact]
        public void LogOut()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();


            GetLogInData(driver);

            IWebElement idOfLogOut = driver.FindElement(By.Id("test_logOut"));
            idOfLogOut.Click();

        }
        //CREATE
        [Fact]
        public void CreatePost()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();

            GetLogInData(driver);


            IWebElement idOfRealCreateNewPost = driver.FindElement(By.Id("test_Create_Post"));
            idOfRealCreateNewPost.Click();
            Thread.Sleep(500);

            GetCreateData(driver);

        }
        //CREATE DATA
        private static void GetCreateData(IWebDriver driver)
        {
            IWebElement idOfCreateName = driver.FindElement(By.Id("test_Create_Name"));
            idOfCreateName.Clear();
            idOfCreateName.SendKeys("Mihkel");
            Thread.Sleep(500);

            IWebElement idOfCreateSpecies = driver.FindElement(By.Id("test_Create_Species"));
            idOfCreateSpecies.Clear();
            idOfCreateSpecies.SendKeys("krants");
            Thread.Sleep(500);

            IWebElement idOfCreateAge = driver.FindElement(By.Id("test_Create_Age"));
            idOfCreateAge.Clear();
            idOfCreateAge.SendKeys("15");
            Thread.Sleep(500);

            IWebElement idOfCreateGender = driver.FindElement(By.Id("test_Create_Gender"));
            idOfCreateGender.Clear();
            idOfCreateGender.SendKeys("male");
            Thread.Sleep(500);

            IWebElement idOfCreateTitle = driver.FindElement(By.Id("test_Create_Title"));
            idOfCreateTitle.Clear();
            idOfCreateTitle.SendKeys("Krants kass");
            Thread.Sleep(500);

            IWebElement idOfCreateDescription = driver.FindElement(By.Id("test_Create_Description"));
            idOfCreateDescription.Clear();
            idOfCreateDescription.SendKeys("bla bla cat");
            Thread.Sleep(500);

            IWebElement uploadFile = driver.FindElement(By.Id("test_Create_Image"));
            uploadFile.SendKeys("C:\\Users\\opilane\\source\\repos\\UnitTesting\\TestProject2\\cat.jpg");
            Thread.Sleep(500);

            IWebElement idOfRealCreateButton = driver.FindElement(By.Id("test_Create_Button"));
            idOfRealCreateButton.Click();
            Thread.Sleep(500);

        }
        //DELETE
        [Fact]
        public void DeletePost()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();

            GetLogInData(driver);


            IWebElement idOfRealCreateButton = driver.FindElement(By.Id("test_Delete_button"));
            idOfRealCreateButton.Click();
            Thread.Sleep(500);

        }
      
     


    }
}