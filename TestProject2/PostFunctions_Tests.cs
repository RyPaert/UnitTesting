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

        [Fact]
        // Check errormessage when user don´t use image
        public void CheckImageErrorMessage()
        {
            IWebDriver driver = Start();

            IWebElement Test_AddNewPostIndex = driver.FindElement(By.Id("test_AddNewPostIndexButton"));
            Test_AddNewPostIndex.Click();

            Thread.Sleep(500);

            InsertPostDataWithOutImage(driver);

            Thread.Sleep(500);

            IWebElement ErrorMessage = driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
            var text = ErrorMessage.Text;

            Assert.True(text == "Palun lisa pilt!");
        }

        [Fact]
        //Check Like button
        public void LikeButton()
        {
            IWebDriver driver = Start();

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            Thread.Sleep(500);

            LogInAction(driver);

            Thread.Sleep(500);

            IWebElement IdOfLike = driver.FindElement(By.Id("btn"));
            IdOfLike.Click();

            IWebElement IdOfLikeCount = driver.FindElement(By.Id("like"));
            var count = IdOfLikeCount.Text;

            Assert.True(count == "1");
        }

        [Fact]
        // check if Details button work
        public void OpenPost()
        {
            IWebDriver driver = Start();

            IWebElement IdOfPostDetailsIndex = driver.FindElement(By.Id("Post"));
            IdOfPostDetailsIndex.Click();
        }


        [Fact]
        // Checks details data
        public void CheckPostDetailsViewText()
        {
            IWebDriver driver = Start();

            IWebElement IdOfPostDetailsIndex = driver.FindElement(By.Id("Post"));
            IdOfPostDetailsIndex.Click();

            IWebElement IdOfTitle = driver.FindElement(By.Id("test_TitleInDetailsView"));
            var TitleText = IdOfTitle.Text;

            IWebElement IdOfDescription = driver.FindElement(By.Id("test_DescriptionInDetailsView"));
            var DescriptionText = IdOfDescription.Text;

            IWebElement IdOfShowMore = driver.FindElement(By.Id("myBtn"));
            IdOfShowMore.Click();

            IWebElement IdOfName = driver.FindElement(By.Id("test_NameOndetailsView"));
            var NameText = IdOfName.Text;

            IWebElement IdOfAge = driver.FindElement(By.Id("test_AgeOnDetailsView"));
            var AgeText = IdOfAge.Text;

            IWebElement IdOFGender = driver.FindElement(By.Id("test_GenderOnDetailsView"));
            var GenderText = IdOFGender.Text;

            IWebElement IdOfSpecies = driver.FindElement(By.Id("test_SpeciesOnDetailsView"));
            var SpeciesText = IdOfSpecies.Text;

            Assert.True(TitleText == "Minu kass");
            Assert.True(DescriptionText == "Ta on kass");
            Assert.True(NameText == "Max");
            Assert.True(AgeText == "3");
            Assert.True(GenderText == "Mees");
            Assert.True(SpeciesText == "Kass");


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

        // Insert post data without image
        private static void InsertPostDataWithOutImage(IWebDriver driver)
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

        //NEGATIVE TESTS
        [Fact]
        // Checks details data
        public void CheckPostDetailsDontDisplayWrongData()
        {
            IWebDriver driver = Start();

            IWebElement IdOfPostDetailsIndex = driver.FindElement(By.Id("Post"));
            IdOfPostDetailsIndex.Click();

            IWebElement IdOfTitle = driver.FindElement(By.Id("test_TitleInDetailsView"));
            var TitleText = IdOfTitle.Text;

            IWebElement IdOfDescription = driver.FindElement(By.Id("test_DescriptionInDetailsView"));
            var DescriptionText = IdOfDescription.Text;

            IWebElement IdOfShowMore = driver.FindElement(By.Id("myBtn"));
            IdOfShowMore.Click();

            IWebElement IdOfName = driver.FindElement(By.Id("test_NameOndetailsView"));
            var NameText = IdOfName.Text;

            IWebElement IdOfAge = driver.FindElement(By.Id("test_AgeOnDetailsView"));
            var AgeText = IdOfAge.Text;

            IWebElement IdOFGender = driver.FindElement(By.Id("test_GenderOnDetailsView"));
            var GenderText = IdOFGender.Text;

            IWebElement IdOfSpecies = driver.FindElement(By.Id("test_SpeciesOnDetailsView"));
            var SpeciesText = IdOfSpecies.Text;

            Assert.False(TitleText == "Minu koer");
            Assert.False(DescriptionText == "Ta on koer");
            Assert.False(NameText == "Timm");
            Assert.False(AgeText == "5");
            Assert.False(GenderText == "Naine");
            Assert.False(SpeciesText == "Koer");


        }

        [Fact]
        //Check Like button
        public void LikeButtonCountIsRight()
        {
            IWebDriver driver = Start();

            IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
            idOfLogInIndex.Click();

            Thread.Sleep(500);

            LogInAction(driver);

            Thread.Sleep(500);

            IWebElement IdOfLike = driver.FindElement(By.Id("btn"));
            IdOfLike.Click();

            IWebElement IdOfLikeCount = driver.FindElement(By.Id("like"));
            var count = IdOfLikeCount.Text;

            Assert.False(count == "0");
        }

        [Fact]
        // Check errormessage when user don´t use image
        public void CheckIfImageErrorMessageIsRight()
        {
            IWebDriver driver = Start();

            IWebElement Test_AddNewPostIndex = driver.FindElement(By.Id("test_AddNewPostIndexButton"));
            Test_AddNewPostIndex.Click();

            Thread.Sleep(500);

            InsertPostDataWithOutImage(driver);

            Thread.Sleep(500);

            IWebElement ErrorMessage = driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
            var text = ErrorMessage.Text;

            Assert.False(text == "Palun lisa Image!");
        }

        [Fact]
        // Test Index title and description text
        public void CheckIndexDetailsDontDisplayWrongData()
        {
            IWebDriver driver = Start();

            Thread.Sleep(500);

            IWebElement dataofTitle = driver.FindElement(By.Id("test_IndexTitle"));
            var title = dataofTitle.Text;

            IWebElement dataofDescription = driver.FindElement(By.Id("test_IndexDescription"));
            var Description = dataofDescription.Text;

            Assert.False(title == "Minu Koer");

            Assert.False(Description == "Ta on Koer");

            Thread.Sleep(500);
        }
    }
}
