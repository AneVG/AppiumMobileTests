using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace AppiumSummatorMobileTests
{
    public class SummatorTests
    {
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
        private const string AppiumUri = "http://127.0.0.1:4723/wd/hub";
        private const string app = @"C:\Users\anelia.georgieva\Desktop\ANI\com.example.androidappsummator.apk";

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", app);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(AppiumUri), options);          
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }


        [Test]
        public void Test_Summator_App_TwoPositiveValues()
        {
            //Arrange
            var field1 = driver.FindElementById("com.example.androidappsummator:id/editText1");
            field1.SendKeys("5");

            var field2 = driver.FindElementById("com.example.androidappsummator:id/editText2");
            field2.SendKeys("15");

            //Act
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
            calcButton.Click();

            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum").Text;

            //Assert
            Assert.That(resultField, Is.EqualTo("20"));

        }
    }
}