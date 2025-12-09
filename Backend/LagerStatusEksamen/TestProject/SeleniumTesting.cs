using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject;

[TestClass]
public class SeleniumTesting
{
    [TestMethod]
    public void TestButtonExistence()
    {
        // Arrange
        FirefoxOptions options = new FirefoxOptions();
        options.AddArguments("--headless=new()");

        IWebDriver driver = new FirefoxDriver();
        driver.Navigate().GoToUrl(@"https://zealand3.rasekh.dk/");


        // Act
        IWebElement buttonElement = driver.FindElement(By.Id("testButton1"));
        var buttonText = buttonElement.Text;

        // Assert
        Assert.AreEqual("Click Me", buttonText);
    }
}
