using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace TestProject2
{
    public class AddNewPost_Tests
    {
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
        public void AddNewPost() 
        { 
            IWebDriver driver = Start();

            IWebElement Test_AddNewPostIndex = driver.FindElement(By.Id("test_AddNewPostIndexButton"));
            Test_AddNewPostIndex.Click();

            Thread.Sleep(500);

            InsertPostData(driver);
        }

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

            IWebElement Test_AddPost = driver.FindElement(By.Id("test_SubmitPostFormButton"));
            Test_AddPost.Click();
        }
    }
}
