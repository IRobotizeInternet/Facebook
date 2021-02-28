﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RobotizeToolbox.Extensions;
using System;
using System.Threading;

namespace RobotizeFacebook.App.LoggedIn.Pages
{
    public class FeedControl : BaseFeed
    {
        
        public string BaseXPath { get; set; }
        public FeedControl(RemoteWebDriver driver, 
            By byForElement,
            string baseXPath) : base(driver, byForElement)
        {
            BaseXPath = baseXPath;
            CurrentRowIndex = 1;
        }

        public override int RowCount => Driver.FindElements(By.XPath($"{BaseXPath}//div[contains(@data-pagelet,'FeedUnit')]")).Count;;
        public override string GetRowXPath(int positionInSet)=>$"{BaseXPath}//div[@aria-posinset='{positionInSet}']";

    }
}
