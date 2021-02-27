﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RobotizeToolbox.CommonControls;

namespace RobotizeToolbox.Controls
{
    public class FileUploader : BaseDOMObject
    {
        public FileUploader(RemoteWebDriver driver, By byForElement) : base(driver, byForElement)
        {
            
        }
    }
}