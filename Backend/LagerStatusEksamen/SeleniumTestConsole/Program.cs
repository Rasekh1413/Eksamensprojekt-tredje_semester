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

IWebElement loadsShelves = driver.FindElement(By.Name("Load shelves"));
Console.WriteLine("Button text: " + loadsShelves.Text);

for (int i = 0; i < 10; i++)
{
    loadsShelves.Click();
}

IWebElement loadPackageTypes = driver.FindElement(By.Name("Load package types"));
loadPackageTypes.Click();



Console.WriteLine("Process to quit driver.");
Console.ReadLine();
driver.Quit();