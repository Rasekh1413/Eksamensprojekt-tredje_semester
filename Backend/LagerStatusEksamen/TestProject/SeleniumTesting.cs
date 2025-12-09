using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace TestProject;

[TestClass]
public class SeleniumTesting
{
    [TestMethod]
    public void TestAddButtonExistence()
    {
        // Arrange
        FirefoxOptions options = new FirefoxOptions();
        //ChromeOptions options = new ChromeOptions();
        options.AddArguments("--headless=new()");

        IWebDriver driver = new FirefoxDriver();
        //IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(@"https://zealand3.rasekh.dk/");

        // Act
        IWebElement loadShelves = driver.FindElement(By.ClassName("btn"));
        var buttonText = loadShelves.Text;

        // Assert
        Assert.AreEqual("Add", buttonText);
    }

    [TestMethod]
    public void TestSelectAction()
    {
        // Arrange
        FirefoxOptions options = new FirefoxOptions();
        //ChromeOptions options = new ChromeOptions();
        options.AddArguments("--headless=new()");

        IWebDriver driver = new FirefoxDriver();
        //IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(@"https://zealand3.rasekh.dk/");

        // Act
        IWebElement selectAction = driver.FindElement(By.CssSelector("table.Dashboard"))
            .FindElement(By.CssSelector("input[type='radio'][name='selectObject]'"));
        var selectActionText = selectAction.Text;

        // Assert
        Assert.AreEqual("Jet the Hawk", selectActionText);
    }
}
