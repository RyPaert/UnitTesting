using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace TestProject2
{
    public class PostFunctions_Tests
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
        // Test Add New Post Function
        public void AddNewPost() 
        { 
            IWebDriver driver = Start();

            IWebElement Test_AddNewPostIndex = driver.FindElement(By.Id("test_AddNewPostIndexButton"));
            Test_AddNewPostIndex.Click();

            Thread.Sleep(500);

            InsertPostData(driver);

            Thread.Sleep(500);
        }
        // Insert Post data
        private static void InsertPostData(IWebDriver driver)
        {
            IWebElement idofName = driver.FindElement(By.Id("test_NameLabel"));
            idofName.SendKeys("Max");
            Thread.Sleep(500);
            IWebElement idofSpecies = driver.FindElement(By.Id("test_SpeciesLabel"));
            idofSpecies.SendKeys("Kass");
            Thread.Sleep(500);
            IWebElement idofAge = driver.FindElement(By.Id("test_AgeLabel"));
            idofAge.Clear();
            idofAge.SendKeys("3");
            Thread.Sleep(500);
            IWebElement idofGender = driver.FindElement(By.Id("test_GenderLabel"));
            idofGender.SendKeys("Mees");
            Thread.Sleep(500);
            IWebElement idofTitle = driver.FindElement(By.Id("test_TitleLabel"));
            idofTitle.SendKeys("Minu kass");
            Thread.Sleep(500);
            IWebElement idofDescription = driver.FindElement(By.Id("test_Descriptionlabel"));
            idofDescription.SendKeys("Ta on kass");
            Thread.Sleep(500);

            IWebElement uploadFile = driver.FindElement(By.Id("test_FileUpload"));
            uploadFile.SendKeys("C:\\Users\\opilane\\source\\repos\\UnitTesting\\TestProject2\\Sources\\Cat.jpg");

            IWebElement Test_AddPost = driver.FindElement(By.Id("test_SubmitPostFormButton"));
            Test_AddPost.Click();
        }
        [Fact]
        // Test Index title and description text
        public void CheckIndexDetailsInfo()
        {
            IWebDriver driver = Start();

            Thread.Sleep(500);

            IWebElement dataofTitle = driver.FindElement(By.Id("test_IndexTitle"));
            var title = dataofTitle.Text;

            IWebElement dataofDescription = driver.FindElement(By.Id("test_IndexDescription"));
            var Description = dataofDescription.Text;

            Assert.True(title == "Minu kass");

            Assert.True(Description == "Ta on kass");

            Thread.Sleep(500);
        }

        [Fact]
        // Test delete function
        public void DeletePost()
        {
            IWebDriver driver = Start();
            Thread.Sleep(500);

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            Thread.Sleep(500);

            LogInAction(driver);

            Thread.Sleep(500);

            IWebElement idOfDeleteButton = driver.FindElement(By.Id("test_DeleteButton"));
            idOfDeleteButton.Click();

            Thread.Sleep(500);

        }
        // Login Function
        private void LogInAction(IWebDriver driver)
        {
            Thread.Sleep(500);

            InsertLogInData(driver);

            Thread.Sleep(500);

            IWebElement SubmitLoginForm = driver.FindElement(By.Id("test_LoginButton"));
            SubmitLoginForm.Click();

            Thread.Sleep(500);
        }
        // Insert Login data
        private void InsertLogInData(IWebDriver driver)
        {
            IWebElement idOfName = driver.FindElement(By.Id("test_LoginUserName"));
            idOfName.SendKeys("Jane Doe");

            Thread.Sleep(500);

            IWebElement idofPassword = driver.FindElement(By.Id("test_LogInPassword"));
            idofPassword.SendKeys("JaneDoe1234");

            Thread.Sleep(500);
        }
    }
}
