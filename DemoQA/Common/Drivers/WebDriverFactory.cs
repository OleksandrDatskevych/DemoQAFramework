﻿using System.Collections.Concurrent;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using DemoQA.Data;

namespace DemoQA.Common.Drivers
{
    public class WebDriverFactory
    {
        private static readonly ConcurrentDictionary<string, IWebDriver> DriverCollection = new();

        public static IWebDriver Driver
        {
            get
            {
                if (!DriverCollection.ContainsKey(TestContextValues.ExecutableClassName))
                {
                    InitializeDriver();
                }

                return DriverCollection.First(pair => pair.Key == TestContextValues.ExecutableClassName).Value;
            }

            private set => DriverCollection.TryAdd(TestContextValues.ExecutableClassName, value);
        }

        public static Actions Actions => new(Driver);

        public static IJavaScriptExecutor JavaScriptExecutor => (IJavaScriptExecutor)Driver;

        public static void QuitDriver() => Driver.Quit();

        private static void InitializeDriver()
        {
            ChromeOptions options = new();
            options.AddArgument("force-device-scale-factor=0.8");
            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
        }
    }
}
