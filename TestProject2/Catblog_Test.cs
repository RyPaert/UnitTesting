using System.Numerics;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Script;
using OpenQA.Selenium.Firefox;

namespace TestProject2
{
    [TestCaseOrderer(
       ordererTypeName: "TestProject2.Test_Case_Order",
        ordererAssemblyName:"TestProject2")]
    public class Catblog_Test
    {
        private static IWebDriver Start()
        {
            string driverlocation = "C:\\Users\\opilane\\source\\repos\\UnitTesting\\TestProject2\\driver";
            string binaryLocation = "C:\\Users\\opilane\\source\\repos\\FirefoxPortable\\App\\Firefox64\\firefox.exe";

            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = binaryLocation;

            IWebDriver driver = new FirefoxDriver(driverlocation, options);
            driver.Url = "https://localhost:7260/";
            return driver;

        }


        //ACCOUNT STUFF

        [Fact, TestPriority(1)]
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
        //I  HAVE ACCOUNT BUTTON
        [Fact]
        public void IHaveAccount()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealRegister = driver.FindElement(By.Id("test_index_Register"));
            idOfRealRegister.Click();
            Thread.Sleep(500);

            IWebElement idOfIHaveAccount = driver.FindElement(By.Id("test_I_Have_Account"));
            idOfIHaveAccount.Click();
        }
        //LOGIN
        [Fact, TestPriority(2)]
        public void LogIn()
        {
            IWebDriver driver = Start();

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

        //CONTROLLING USERNAME LOGIN
        [Fact]
        public void ControllUserName()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();
            Thread.Sleep(500);

            GetLogInData(driver);


            IWebElement idOfUSernameLable = driver.FindElement(By.Id("test_logIn_userName"));
            var username = idOfUSernameLable.Text;

            Assert.True(username == "Test username");

        }
        //REMEBER ME BUTTON
        [Fact, TestPriority(2)]
        public void RemeberMe()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();
            Thread.Sleep(500);

            IWebElement idOfRemeberMe = driver.FindElement(By.Id("test_remeberMe_button"));
            idOfRemeberMe.Click();
            Thread.Sleep(500);

            GetLogInData(driver);

        }

        
       
        //LOGOUT
        [Fact, TestPriority(3)]
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
        [Fact, TestPriority(4)]
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

        [Fact]
        //CREATE POST WITH NO IMAGE
        public void CreatePostWithNoImage()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();

            GetLogInData(driver);


            IWebElement idOfRealCreateNewPost = driver.FindElement(By.Id("test_Create_Post"));
            idOfRealCreateNewPost.Click();
            Thread.Sleep(500);

            GetCreateDataNoImage(driver);

            IWebElement IdOfNoImage = driver.FindElement(By.Id("test_NoImage"));
            var image = IdOfNoImage.Text;

            Assert.True(image == "Palun lisa pilt!");
        }

        //CREATE DATA WITH NO IMAGE
        private static void GetCreateDataNoImage(IWebDriver driver)
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

            IWebElement idOfRealCreateButton = driver.FindElement(By.Id("test_Create_Button"));
            idOfRealCreateButton.Click();
            Thread.Sleep(500);

        }

        //POST TITLE AND DESCRIPTION
        [Fact, TestPriority(5)]
        public void PostInfo()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();

            GetLogInData(driver);

            IWebElement IdOfPostInfo = driver.FindElement(By.Id("test_Create_Title_Lable"));
            var title = IdOfPostInfo.Text;

            IWebElement IdOfPostInfo2 = driver.FindElement(By.Id("test_Create_Description_Lable"));
            var description = IdOfPostInfo2.Text;

            Assert.True(title == "Krants kass");
            Assert.True(description == "bla bla cat");

        }

        //DETAILS
        [Fact, TestPriority(6)]
        public void DetailsPost()
        {
           IWebDriver driver = Start();

            IWebElement idOfRealDetails = driver.FindElement(By.Id("Post"));
            idOfRealDetails.Click();
            Thread.Sleep(500);

        }

        //DETAILS INFO POS
        [Fact]
        public void DetailsInfoPost()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealDetailsInfo = driver.FindElement(By.Id("Post"));
            idOfRealDetailsInfo.Click();
            Thread.Sleep(500);

            IWebElement idOfShowButton= driver.FindElement(By.Id("myBtn"));
            idOfShowButton.Click();
            Thread.Sleep(500);

            IWebElement IdOfPosttitle= driver.FindElement(By.Id("test_TitleInDetailsView"));
            var title = IdOfPosttitle.Text;

            IWebElement idofdescription = driver.FindElement(By.Id("test_DescriptionInDetailsView"));
            var description = idofdescription.Text;

            IWebElement IdOfPostName = driver.FindElement(By.Id("test_NameOndetailsView"));
            var name = IdOfPostName.Text;

            IWebElement IdOfPostAge = driver.FindElement(By.Id("test_AgeOnDetailsView"));
            var age = IdOfPostAge.Text;

            IWebElement IdOfPostGender = driver.FindElement(By.Id("test_GenderOnDetailsView"));
            var gender = IdOfPostGender.Text;

            IWebElement IdOfPostSpecies = driver.FindElement(By.Id("test_SpeciesOnDetailsView"));
            var species = IdOfPostSpecies.Text;

            Assert.True(title == "Krants kass");
            Assert.True(description == "bla bla cat");
            Assert.True(name == "Mihkel");
            Assert.True(age == "15");
            Assert.True(gender == "male");
            Assert.True(species == "krants");


        }

        //DETAILS INFO NEG
        [Fact]
        public void DetailsInfoPostNEG()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealDetailsInfo = driver.FindElement(By.Id("Post"));
            idOfRealDetailsInfo.Click();
            Thread.Sleep(500);

            IWebElement idOfShowButton = driver.FindElement(By.Id("myBtn"));
            idOfShowButton.Click();
            Thread.Sleep(500);

            IWebElement IdOfPosttitle = driver.FindElement(By.Id("test_TitleInDetailsView"));
            var title = IdOfPosttitle.Text;

            IWebElement idofdescription = driver.FindElement(By.Id("test_DescriptionInDetailsView"));
            var description = idofdescription.Text;

            IWebElement IdOfPostName = driver.FindElement(By.Id("test_NameOndetailsView"));
            var name = IdOfPostName.Text;

            IWebElement IdOfPostAge = driver.FindElement(By.Id("test_AgeOnDetailsView"));
            var age = IdOfPostAge.Text;

            IWebElement IdOfPostGender = driver.FindElement(By.Id("test_GenderOnDetailsView"));
            var gender = IdOfPostGender.Text;

            IWebElement IdOfPostSpecies = driver.FindElement(By.Id("test_SpeciesOnDetailsView"));
            var species = IdOfPostSpecies.Text;

            Assert.False(title == "Krants koer");
            Assert.False(description == "bla bla dog");
            Assert.False(name == "Ploompuu");
            Assert.False(age == "11");
            Assert.False(gender == "female");
            Assert.False(species == "sama mis krants");


        }

        ////LIKE
        [Fact//, TestPriority()
             ]
        public void PostLike()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();

            GetLogInData(driver);

            IWebElement idOfRealLike = driver.FindElement(By.Id("btn"));
            idOfRealLike.Click();
            Thread.Sleep(500);

            IWebElement IdOfLikeCountNumber = driver.FindElement(By.Id("like"));
            var count = IdOfLikeCountNumber.Text;

            Assert.False(count == "0");

        }

        //DELETE
        [Fact//, TestPriority()
             ]
        public void DeletePost()
        {
            IWebDriver driver = Start();

            IWebElement idOfRealLogIN = driver.FindElement(By.Id("test_indexLogIn"));
            idOfRealLogIN.Click();

            GetLogInData(driver);


            IWebElement idOfRealDeleteButton = driver.FindElement(By.Id("test_Delete_button"));
            idOfRealDeleteButton.Click();
            Thread.Sleep(500);

        }





    }
}