using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject
{
    [TestClass]
    public class MySeleniumTests
    {
        private IWebDriver driver;
        private string appURL;
        //[TestMethod]
        [TestCategory("Chrome")]
        public void EnregistrerTest()
        {
            Console.WriteLine("Début du test EnregistrerTest");
            // Naviguer vers Bing.com
            appURL = "https://demo.nopcommerce.com/register?returnUrl=%2F";
            driver.Navigate().GoToUrl(appURL);
            System.Threading.Thread.Sleep(30000);
            // Trouver l'élément de recherche par son ID et saisir une requête de recherche
            IWebElement radioButton = driver.FindElement(By.Id("gender-female"));
            radioButton.Click();
            IWebElement nomBox = driver.FindElement(By.Id("FirstName"));
            nomBox.SendKeys("ryhab");
            IWebElement prenBox = driver.FindElement(By.Id("LastName"));
            prenBox.SendKeys("elmoncer");
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Name("DateOfBirthDay")));
            dropDown.SelectByValue("10");
            dropDown = new SelectElement(driver.FindElement(By.Name("DateOfBirthMonth")));
            dropDown.SelectByValue("5");
            dropDown = new SelectElement(driver.FindElement(By.Name("DateOfBirthYear")));
            dropDown.SelectByValue("1999");
            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys("ryhab1@gmail.com");
            IWebElement company = driver.FindElement(By.Id("Company"));
            company.SendKeys("Iset");
            IWebElement pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("29418145");
            IWebElement confpass = driver.FindElement(By.Id("ConfirmPassword"));
            confpass.SendKeys("29418145");
            driver.FindElement(By.Id("register-button")).Click();
            //*[@id="register-button"]
            Console.WriteLine("Fin du test EnregistrerTest");

        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void LoginTest()
        {
            appURL = "https://demo.nopcommerce.com/login?returnUrl=%2F";
            driver.Navigate().GoToUrl(appURL);
            System.Threading.Thread.Sleep(30000);
            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys("ryhab1@gmail.com");
            IWebElement pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("29418145");
            driver.FindElement(By.CssSelector(".button-1.login-button")).Click();
            string expectedUrl = "https://demo.nopcommerce.com/";
            Assert.AreEqual(expectedUrl, driver.Url, "L'URL après l'enregistrement ne correspond pas.");

        }

        [TestInitialize]
        public void SetupTest()
        {
            appURL = "https://demo.nopcommerce.com/register?returnUrl=%2F";
            string browser = "Chrome"; // Changez le navigateur selon vos besoins

            // Initialiser le pilote du navigateur en fonction du choix
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }
        [TestMethod]
        [TestCategory("Chrome")]
        public void SearchTest()
        {
            appURL = "https://demo.nopcommerce.com/";
            driver.Navigate().GoToUrl(appURL);
            System.Threading.Thread.Sleep(1000);
            IWebElement search = driver.FindElement(By.Id("small-searchterms"));
            search.SendKeys("Shoes");
            driver.FindElement(By.CssSelector(".button-1.search-box-button")).Click();
            driver.FindElement(By.CssSelector(".button-2.product-box-add-to-cart-button")).Click();
            appURL = "https://demo.nopcommerce.com/nike-floral-roshe-customized-running-shoes";
            driver.Navigate().GoToUrl(appURL);
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Name("product_attribute_6")));
            dropDown.SelectByValue("6");
            dropDown = new SelectElement(driver.FindElement(By.Name("product_attribute_7")));
            dropDown.SelectByValue("7");
            IWebElement spanElement = driver.FindElement(By.ClassName("attribute-square"));
            spanElement.Click();
            driver.FindElement(By.Id("add-to-cart-button-24")).Click();

            //*[@id="add-to-cart-button-24"]
            //*[@id="product_attribute_6"]
        }

        [TestCleanup]
        public void CleanupTest()
        {
            System.Threading.Thread.Sleep(70000);
         
            driver.Quit();
        }
    }
}