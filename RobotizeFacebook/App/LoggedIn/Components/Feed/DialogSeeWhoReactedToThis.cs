﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RobotizeFacebook.Resources;
using RobotizeToolbox.CommonControls;
using RobotizeToolbox.Dialogs;

namespace RobotizeFacebook.App.LoggedIn.Pages
{
    public class DialogReactions : BaseDialog
    {
        public DialogReactions(RemoteWebDriver driver) : base(driver)
        {
            BaseXPath = $"//div[@aria-label='{ResHomePage.Reactions}']//div[@role='tab'][@tabindex='0'][{0}]//span";
        }

        protected override By ByForDialog => By.XPath($"//div[@aria-label='{ResHomePage.Reactions}']");

        public Button ButtonAllReactions =>
            new Button(Driver, By.XPath(string.Format(BaseXPath, 1)));
        public Button ButtonReactionsAtFirstIndex =>
            new Button(Driver, By.XPath(string.Format(BaseXPath, 2)));
        public Button ButtonReactionsAtSecondIndex =>
            new Button(Driver, By.XPath(string.Format(BaseXPath, 3)));
        public Button ButtonReactionsAtThirdIndex =>
            new Button(Driver, By.XPath(string.Format(BaseXPath, 4)));
        public Button ButtonReactionsAtFourthIndex =>
            new Button(Driver, By.XPath(string.Format(BaseXPath, 5)));
        public Button ButtonReactionsAtFifthIndex =>
            new Button(Driver, By.XPath(string.Format(BaseXPath, 6)));
        public Button ButtonReactionsAtSixthIndex =>
            new Button(Driver, By.XPath(string.Format(BaseXPath, 8)));
        public Button ButtonReactionsAtSeventhIndex =>
            new Button(Driver, By.XPath(string.Format(BaseXPath, 9)));

        public 
    }
}