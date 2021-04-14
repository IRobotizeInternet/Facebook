﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Polly;
using Polly.Retry;
using RobotizeFacebook.Services;
using RobotizeFacebook.Utilities;
using System;

namespace RobotizeFacebook.WebDrivers
{
    public class Chrome : WebDriver//, IDisposable
    {
        public Chrome(string baseUrl):base(baseUrl) { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override RemoteWebDriver Driver(bool useExistingBrowser = true)
        {
            // when useExistingBrowser is set open chrome
            if (useExistingBrowser) ServiceBrowser.OpenBrowser();

            if (string.IsNullOrEmpty(BaseURL))
            {
                throw new Exception($"{nameof(BaseURL)} is not set.");
            }

            // NOTE: This will cause problem when we run this code 
            // in multi threaded program. Remove this code, to avoid 
            // running into problems when experimenting with parallel runs.
            ServiceTask.CloseTask(nameof(ChromeDriver));
            var options = new ChromeOptions
            {
                DebuggerAddress = $"{AppSettings.DebuggerBrowserUrl}:{ AppSettings.DebuggerBrowserPort}"
            };
            
            options.AddArgument("no-sandbox");

            //options.AddArguments(@"user-data-dir=C:\Users\amhus\AppData\Local\Google\Chrome\User Data\Default" /*Profile Path*/);
            //options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";

            ChromeDriver driver = null;

            RetryPolicy().Execute(() =>
            {
                driver = new ChromeDriver(options);
            });

            SelectTab(driver);

            // If using existing window then you may not need to maximize it here.
            //driver.Manage().Window.Maximize();

            // set default culture 
            ServiceCulture.SetDefaultCulture(AppSettings.DefaultCulture);

            return driver;
        }

        private RemoteWebDriver GetRemoteWebDriver()
        {
            var options = new ChromeOptions();
            //Environment.SetEnvironmentVariable("prefs", DriverLocation);

            options.AddArguments(@"user-data-dir=C:\Users\amhus\AppData\Local\Google\Chrome\User Data\Default" /*Profile Path*/);
            options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            ChromeDriver driver = null;

            // Using Polly library: https://github.com/App-vNext/Polly
            var policy = Policy
              .Handle<InvalidOperationException>()
              .WaitAndRetry(10, t => TimeSpan.FromSeconds(10));

            policy.Execute(() =>
            {
                driver = new ChromeDriver(DriverLocation, options, TimeSpan.FromSeconds(WebDriverTimeoutInSeconds));
            });

            driver.Manage().Window.Maximize();

            // set default culture 
            ServiceCulture.SetDefaultCulture(AppSettings.DefaultCulture);

            return driver;
        }

        public void SelectTab(RemoteWebDriver driver)
        {
            foreach(var tab in driver.WindowHandles)
            {
                if (driver.Url.Contains($"{AppSettings.BaseURL}")) return;
                driver.SwitchTo().Window(tab);
            }

            RetryPolicy().Execute(() =>
            {
                driver.Navigate().GoToUrl(BaseURL);
            });
        }

        private RetryPolicy RetryPolicy(int retryCount = 10)
        {
            return Policy
              .Handle<InvalidOperationException>()
              .WaitAndRetry(retryCount, t => TimeSpan.FromSeconds(10));
        }

        private void CommandLineTextFromChrome(RemoteWebDriver driver)
        {
            // Below code is used to verify the remote debugging and the port used.
            driver.Navigate().GoToUrl("chrome://version/");
            driver.FindElementById("command_line").Text.Contains("--remote-debugging-port=9222");
        }
    }
}
