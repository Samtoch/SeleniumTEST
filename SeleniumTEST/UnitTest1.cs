using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTEST
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://propertynovel.com/");
            Assert.That(driver.Url, Is.EqualTo("https://propertynovel.com/"));
            Assert.That(driver.Title, Is.EqualTo("Net Novel Realty, Best Choice App for Real Estate and Property Management"));
            //Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://propertynovel.com/Home/Login");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("toch1@gmail.com");
        }

        [Test]
        public void Test3()
        {
            driver.Navigate().GoToUrl("https://propertynovel.com/Home/Login");
            driver.FindElement(By.Id("password-field")).Clear();
            driver.FindElement(By.Id("password-field")).SendKeys("mypassword");
        }

        [Test]
        public void Button()
        {
            driver.Navigate().GoToUrl("https://propertynovel.com/Home/Login");
            driver.FindElement(By.Id("load-btn")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void Login()
        {
            driver.Navigate().GoToUrl("https://propertynovel.com/Home/Login");

            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("tochi1@gmail.com");

            driver.FindElement(By.Id("password-field")).Clear();
            driver.FindElement(By.Id("password-field")).SendKeys("mypassword");

            driver.FindElement(By.Id("load-btn")).Submit();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void DetectElementText()
        {
            driver.Navigate().GoToUrl("https://propertynovel.com/");

            Assert.That(driver.FindElement(By.XPath("//*[@id=\"introCarousel\"]/div/div[1]/div/div/h2")).Text, Is.EqualTo("We are professional"));
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}