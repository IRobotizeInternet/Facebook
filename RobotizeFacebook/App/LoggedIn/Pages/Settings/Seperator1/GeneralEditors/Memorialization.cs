﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RobotizeFacebook.App.NotLoggedIn.Help;
using RobotizeToolbox.CommonControls;
using RobotizeToolbox.Controls.TriggerControls;
using RobotizeToolbox.Dialogs;
using RobotizeFacebook.Resources;

namespace RobotizeFacebook.App.LoggedIn.Settings.Tabs.Seperator1
{
    public class Memorialization: BaseEditor
    {
        public SearchBoxSharingWithYourFriends ComboboxChooseAFriend => 
            new SearchBoxSharingWithYourFriends(Driver, By.XPath($"//input[@placeholder={ResMiscellaneous.ChooseAFriend}]"), string.Empty);
        public Button ButtonAdd => new Button(Driver, By.XPath($"//button[text()={ResMiscellaneous.Add}]"));
        public Hyperlink<DialogDeleteYourAccountInFuture> Link =>
            new Hyperlink<DialogDeleteYourAccountInFuture>(Driver, By.XPath($"//input[@value={ResMiscellaneous.RequestThatYourAccountBeDeletedAfterYouPassAway}]"));
    }

    public class DialogDeleteYourAccountInFuture : BaseDialog
    {
        public DialogDeleteYourAccountInFuture(RemoteWebDriver driver) : base(driver)
        {
        }

        protected override By ByForDialog => By.XPath($"//div/h3[text()={ResMiscellaneous.DeleteYourAccountInTheFuture}]");

        public Button ButtonDeleteAfterDeath => new Button(Driver, By.XPath("//button[text()='Delete After Death']"));
        public Button ButtonCancel => new Button(Driver, By.XPath("//a[text()='Cancel']"));
        public Hyperlink<PageHelpChooseALegacyContact> LinkLearnMore => 
            new Hyperlink<PageHelpChooseALegacyContact>(Driver, By.XPath("//div[@role='dialog']//a[text()='Learn More']"));
    }
}