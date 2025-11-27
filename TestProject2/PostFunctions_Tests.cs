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


	}
}
