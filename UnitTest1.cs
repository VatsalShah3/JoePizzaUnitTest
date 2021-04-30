using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestJoePizza
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://vatsalazureappnew.azurewebsites.net/");
                //driver.Navigate().GoToUrl("https://localhost:44391/");

                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );

                var cartBtn = driver.FindElementsByTagName("button");
                Assert.IsNotNull(cartBtn);

                var cartLink = driver.FindElementById("cartLink");
                Assert.IsNotNull(cartLink);

                var rand = new Random();
                var clickButtonRandomly = rand.Next(0, 8);

                cartBtn[clickButtonRandomly].Click();
                cartLink.Click();

                var cartTitle = driver.PageSource.Contains("My Cart");
                Assert.IsTrue(cartTitle);

                var email = driver.FindElementById("customerEmail");
                Assert.IsNotNull(email);
                email.SendKeys("vatsal@gmail.com");

                var name = driver.FindElementById("customerName");
                Assert.IsNotNull(name);
                name.SendKeys("Vatsal Shah");

                var address = driver.FindElementById("customerAddress");
                Assert.IsNotNull(address);
                address.SendKeys("Chunkin Street, Malad,  Mumbai");
                
                var pin = driver.FindElementById("customerPin");
                Assert.IsNotNull(pin);
                pin.SendKeys("123456");

                var placeOrderBtn = driver.FindElementById("placeOrder");
                Assert.IsNotNull(placeOrderBtn);
                placeOrderBtn.Click();

                var expectedUrl = "https://vatsalazureappnew.azurewebsites.net/OrderSuccess";
                var redirectUrl = driver.Url;
                Assert.AreEqual(expectedUrl, redirectUrl);

                var orderTitle = driver.PageSource.Contains("Your order has been placed");
                Assert.IsTrue(orderTitle);

                var homeLinkBtn = driver.FindElementById("homeLink");
                Assert.IsNotNull(homeLinkBtn);
                homeLinkBtn.Click();

                var expectedUrlForHome = "https://vatsalazureappnew.azurewebsites.net/";
                var redirectUrlHome = driver.Url;
                Assert.AreEqual(expectedUrlForHome, redirectUrlHome);

                Console.WriteLine(cartBtn);
            }
        }
    }
}
