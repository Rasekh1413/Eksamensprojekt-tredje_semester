using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

// Headless mode, good for unit-testing
//FirefoxOptions options = new FirefoxOptions();
//ChromeOptions options = new ChromeOptions();
//options.AddArguments("--headless=new()");

IWebDriver driver = new FirefoxDriver();
//IWebDriver driver = new ChromeDriver();

driver.Navigate().GoToUrl(@"https://zealand3.rasekh.dk/");

Console.WriteLine("driver url " + driver.Url);

//IWebElement inputElement = driver.FindElement(By.Id("input1"));
//inputElement.SendKeys("Hello FROM Katerina");

// I cannot see if the button is being clicked on, despite how the
// button has a hover element and changes hue while clicked
IWebElement loadTable = driver.FindElement(By.ClassName("btn"));
Console.WriteLine("Button text: " + loadTable.Text);
loadTable.Click();

IWebElement selectAction = driver.FindElement(By.Id("PackageTypeTable")).
    FindElement(By.Name("selectObject"));
selectAction.Click();

Console.WriteLine("Process to quit driver.");
Console.ReadLine();
driver.Quit();