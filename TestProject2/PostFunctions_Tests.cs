using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
	[TestCaseOrderer(
	ordererTypeName: "TestProject2.PriorityOrderer",
	ordererAssemblyName: "TestProject2")]
	public class PostFunctions_Tests
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

        [Fact, TestPriority(9)]
		public void AddNewPost()
		{
			IWebDriver driver = Start();

			IWebElement Test_AddNewPostIndex = driver.FindElement(By.Id("Test_AddNewPostLayoutButton"));
			Test_AddNewPostIndex.Click();

			Thread.Sleep(500);

			InsertPostData(driver);

			Thread.Sleep(500);

			Thread.Sleep(500);
			driver.Quit();
		}

		[Fact, TestPriority(10)]
		public void CheckIndexDetailsInfo()
		{
			IWebDriver driver = Start();

			Thread.Sleep(500);

			IWebElement dataofTitle = driver.FindElement(By.Id("Test_IndexTitle"));
			var title = dataofTitle.Text;

			IWebElement dataofDescription = driver.FindElement(By.Id("Test_IndexDescription"));
			var Description = dataofDescription.Text;

			Assert.True(title == "Minu kass");

			Assert.True(Description == "Ta on kass");

			Thread.Sleep(500);
			driver.Quit();
		}

		[Fact, TestPriority(19)]
		public void DeletePost()
		{
			IWebDriver driver = Start();
			Thread.Sleep(500);

			IWebElement idOfLoginIndex = driver.FindElement(By.Id("test_login_index"));
			idOfLoginIndex.Click();

			Thread.Sleep(500);

			Login(driver);

			Thread.Sleep(500);

			IWebElement idOfDeleteButton = driver.FindElement(By.Id("test_DeleteButton"));
			idOfDeleteButton.Click();

			Thread.Sleep(500);
			driver.Quit();

		}

		[Fact, TestPriority(11)]
		public void CheckImageErrorMessage()
		{
			IWebDriver driver = Start();

			IWebElement Test_AddNewPostIndex = driver.FindElement(By.Id("Test_AddNewPostLayoutButton"));
			Test_AddNewPostIndex.Click();

			Thread.Sleep(500);

			InsertPostDataWithOutImage(driver);

			Thread.Sleep(500);

			IWebElement ErrorMessage = driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
			var text = ErrorMessage.Text;

			Assert.True(text == "Palun lisa pilt!");

			Thread.Sleep(500);
			driver.Quit();
		}

		[Fact, TestPriority(12)]
		public void LikeButton()
		{
			IWebDriver driver = Start();

			IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
			idOfLogInIndex.Click();

			Thread.Sleep(500);

			Login(driver);

			Thread.Sleep(500);

			IWebElement IdOfLike = driver.FindElement(By.Id("btn"));
			IdOfLike.Click();

			IWebElement IdOfLikeCount = driver.FindElement(By.Id("like"));
			var count = IdOfLikeCount.Text;

			Assert.True(count == "1");

			Thread.Sleep(500);
			driver.Quit();
		}

		[Fact, TestPriority(13)]
		public void OpenPost()
		{
			IWebDriver driver = Start();

			IWebElement IdOfPostDetailsIndex = driver.FindElement(By.Id("Post"));
			IdOfPostDetailsIndex.Click();

			Thread.Sleep(500);
			driver.Quit();
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
			IWebElement idofDescription = driver.FindElement(By.Id("test_DescriptionLabel"));
			idofDescription.SendKeys("Ta on kass");
			Thread.Sleep(500);

			IWebElement uploadFile = driver.FindElement(By.Id("test_FileUpload"));
			string imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cat.png");
			uploadFile.SendKeys(imgPath);

			IWebElement Test_AddPost = driver.FindElement(By.Id("test_SubmitPostFormButton"));
			Test_AddPost.Click();
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
			IWebElement idofDescription = driver.FindElement(By.Id("test_DescriptionLabel"));
			idofDescription.SendKeys("Ta on kass");
			Thread.Sleep(500);

			IWebElement Test_AddPost = driver.FindElement(By.Id("test_SubmitPostFormButton"));
			Test_AddPost.Click();
		}

		//Failure Tests

		[Fact, TestPriority(15)]
		public void LikeButtonCountIsRight()
		{
			IWebDriver driver = Start();

			IWebElement idOfLogInIndex = driver.FindElement(By.Id("test_login_index"));
			idOfLogInIndex.Click();

			Thread.Sleep(500);

			Login(driver);

			Thread.Sleep(500);

			IWebElement IdOfLike = driver.FindElement(By.Id("btn"));
			IdOfLike.Click();

			IWebElement IdOfLikeCount = driver.FindElement(By.Id("like"));
			var count = IdOfLikeCount.Text;

			Assert.False(count == "0");

			Thread.Sleep(500);
			driver.Quit();
		}

		[Fact, TestPriority(16)]
		public void CheckIfImageErrorMessageIsRight()
		{
			IWebDriver driver = Start();

			IWebElement Test_AddNewPostIndex = driver.FindElement(By.Id("Test_AddNewPostLayoutButton"));
			Test_AddNewPostIndex.Click();

			Thread.Sleep(500);

			InsertPostDataWithOutImage(driver);

			Thread.Sleep(500);

			IWebElement ErrorMessage = driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
			var text = ErrorMessage.Text;

			Assert.False(text == "Palun lisa Image!");

			Thread.Sleep(500);
			driver.Quit();
		}
	}
}
