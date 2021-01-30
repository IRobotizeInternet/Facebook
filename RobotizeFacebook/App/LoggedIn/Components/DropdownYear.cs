﻿using OpenQA.Selenium.Remote;
using RobotizeLibrary.Extensions;
using RobotizeToolbox.Controls;

namespace RobotizeFacebook.App.LoggedIn
{
    public class DropdownYear : DropdownWithEnum<FilterYear>
    {
        public DropdownYear(RemoteWebDriver driver, ExtendBy byForDropdown) : base(driver, byForDropdown)
        {
        }
    }
}