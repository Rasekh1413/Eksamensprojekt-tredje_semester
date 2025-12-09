using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace TestProject;

[TestClass]
public class SeleniumTesting
{
    [TestMethod]
    public void TestButtonExistence()
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
        Assert.AreEqual("Load shelves", buttonText);
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
        IWebElement selectAction = driver.FindElement(By.Id("PackageTypeTable")).
            FindElement(By.Name("selectObject"));
        var selectActionText = selectAction.Text;

        // Assert
        Assert.AreEqual("Jet the Hawk", selectActionText);
    }
}
