﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RobotizeToolbox.Extensions;

namespace RobotizeToolbox.CommonControls
{
    public class ScrollControl : BaseDOMObject
    {
        public int CurrentRowIndex { get; set; }
        public int RowCount => Driver.FindElements(By.XPath($"{BaseXPath}//div[contains(@data-pagelet,'Feed')]")).Count;
        public string GetRowXPath(int positionInSet) => $"{BaseXPath}//div[@aria-posinset='{positionInSet}']";
        public string BaseXPath { get; set; }


        public ScrollControl(RemoteWebDriver driver, 
            By byForElement,
            string baseXPath = null,
            int currentRowIndex = 1) : base(driver, byForElement)
        {
            BaseXPath = baseXPath;
            CurrentRowIndex = currentRowIndex;
        }

        /// <summary>
        /// Scroll to the last row.
        /// </summary>
        public void ScrollingDownWithAGivenInterval(int scrollingDelay = 3000)
        {
            while (true)
            {
                var rowCountBeforeScroll = RowCount;
                ScrollFeedUnit(CurrentRowIndex++);
                var rowCountAfterScroll = RowCount;
                if (CurrentRowIndex >= RowCount && rowCountBeforeScroll == rowCountAfterScroll) break;
                Thread.Sleep(scrollingDelay);
            }
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Scroll to the first row.
        /// </summary>
        public void ScrollingUpWithAGivenInterval(int scrollingDelay = 3000)
        {
            while (true)
            {
                if (CurrentRowIndex <= 0) break;
                ScrollFeedUnit(CurrentRowIndex--);
                Thread.Sleep(scrollingDelay);
            }
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Scroll to left.
        /// </summary>
        public void ScrollingLeft(int scrollingDelay = 3000)
        {
        }

        /// <summary>
        /// Scroll to rigth.
        /// </summary>
        public void ScrollingRight(int scrollingDelay = 3000)
        {
           
        }

        /// <summary>
        /// Scroll up for a given position in set
        /// </summary>
        public void ScrollFeedUnit(int positionInSet)
        {
            ScrollToElement(Driver.FindElementWithTimeSpan(By.XPath(GetRowXPath(positionInSet))));
            Driver.FindElementWithTimeSpan(By.XPath(GetRowXPath(positionInSet)));
        }

        /// <summary>
        /// Scroll up for a given header text
        /// </summary>
        public void ScrollFeedUnit(string headerText)
        {
        }
    }
}