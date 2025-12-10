using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Act
        IWebElement ptTable = wait.Until(
            ExpectedConditions.ElementIsVisible(By.ClassName("Dashboard"))
        );

        IWebElement selectAction = ptTable.FindElement(By.Name("selectObject"));
        var selectActionText = selectAction.Text;

        // Assert
        Assert.AreEqual("", selectActionText);
    }
}
