﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RobotizeToolbox.Extensions
{
    public static class RemoteWebDriverExtension
    {
        /// <summary>
        /// Return the web element matching the selector.
        /// </summary>
        public static IWebElement FindElementWithTimeSpan(this RemoteWebDriver driver, By by, int timeSpanInSeconds = 30)
        {
            ICollection<IWebElement> elements = null;

            // Using Polly library: https://github.com/App-vNext/Polly
            var policy = Policy
              .Handle<InvalidOperationException>()
              .WaitAndRetry(10, t => TimeSpan.FromSeconds(timeSpanInSeconds));

            policy.Execute(() =>
            {
                try
                {
                    elements = driver.FindElements(by);
                    return elements.Any();
                }
                catch (TimeoutException ex)
                {
                    Trace.WriteLine($"Timed our exception{ex.Message} \n {ex.InnerException}");
                    return false;
                }
            });

            // If no elements found then throw an exception.
            if (elements == null || !elements.Any()) Trace.WriteLine($"No element found matching criteria '{by}'");

            // If found more than one element then throw an exception.
            if (elements.Count() > 1) Trace.WriteLine($"More than one element found matching criteria '{by}'");

            return elements?.First();
        }

        /// <summary>
        /// Return the web element matching the selector.
        /// </summary>
        public static IWebElement FindSingleElement(this RemoteWebDriver driver, By by)
        {
            var elements =  driver.FindElements(by);

            // If no elements found then throw an exception.
            if (!elements.Any()) Trace.WriteLine($"{nameof(NoSuchElementException)} occured, element found matching criteria '{by}' not found");

            // If found more than one element then throw an exception.
            if (elements.Count() > 1) Trace.WriteLine($"More than one element found matching criteria '{by}'");

            return elements?.First();
        }

        /// <summary>
        /// Return the visible web elements matching the selector.
        /// </summary>
        public static IEnumerable<IWebElement> FindVisibleElementsWait(
            this RemoteWebDriver driver, 
            By byForElement, 
            int timeoutSeconds = 60)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            IEnumerable<IWebElement> elements = null;

            _ = wait.Until(d =>
            {
                elements = driver.FindElements(byForElement).Where(x => x.Displayed);
                return elements.Any();
            });

            return elements;
        }

        /// <summary>
        /// Wait until element is appear.
        /// </summary>
        public static void WaitUntilElementAppears(
            this RemoteWebDriver driver,
            By byForElement,
            int timeoutSeconds = 60)
        {
            var wait = new DefaultWait<By>(byForElement)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Timeout = TimeSpan.FromSeconds(timeoutSeconds)
            };

            _ = wait.Until(x =>
            {
                try
                {
                    var element = driver.FindElement(x);
                    return false;
                }
                catch (NoSuchElementException) { return true; }
                catch (ElementNotVisibleException) { return true; }
                catch (StaleElementReferenceException) { return true; }
            });
        }

        /// <summary>
        /// Wait if the element is visible.
        /// </summary>
        public static void WaitUntilElementDisappears(
            this RemoteWebDriver driver,
            By byForElement,
            int timeoutSeconds = 60)
        {
            var wait = new DefaultWait<By>(byForElement)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Timeout = TimeSpan.FromSeconds(timeoutSeconds)
            };

            _ = wait.Until(x =>
             {
                 try
                 {
                     var element = driver.FindElement(x);
                     return false;
                 }
                 catch (NoSuchElementException){ return true; }
                 catch (ElementNotVisibleException) { return true; }
                 catch (StaleElementReferenceException) { return true; }
             });
        }
    }
}
