using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string binaryLocation = "";
            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = binaryLocation;

            IWebDriver driver = new FirefoxDriver("", options);
            driver.Url = "https://github.com/RyPaert";

            Thread.Sleep(1000);

        }
    }
}