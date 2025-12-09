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
        //options.AddArguments("--headless=new()");

        IWebDriver driver = new FirefoxDriver();
        driver.Navigate().GoToUrl(@"https://zealand3.rasekh.dk/");

        // Act
        IWebElement loadShelves = driver.FindElement(By.Name("Load shelves"));
        var buttonText = loadShelves.Text;

        // Assert
        Assert.AreEqual("Click Me", buttonText);
    }
}
