﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RobotizeFacebook.Resources;
using RobotizeToolbox.CommonControls;
using RobotizeToolbox.Dialogs;

namespace RobotizeFacebook.App.LoggedIn
{
    public class DialogNotificationSettings : BaseDialog
    {
        public DialogNotificationSettings(RemoteWebDriver driver) : base(driver)
        {
            BaseXPath = $"//div[@aria-label='{ResMiscellaneous.NotificationSettings}'][@role='dialog']";
        }

        protected override By ByForDialog => By.XPath(BaseXPath);
        
        public Button ButtonSavedItems => new Button(Driver, By.XPath($"//span[contains(text(),'{ResNotificationSettings.SavedItems}')]/../../../../../../..//div[@role='button']"));
        public Button ButtonRecommendationsForYou => new Button(Driver, By.XPath($"//span[contains(text(),'{ResNotificationSettings.RecommendationsForYou}')]/../../../../../../..//div[@role='button']"));
        public Button ButtonSimilarItems => new Button(Driver, By.XPath($"//span[contains(text(),'{ResNotificationSettings.SimilarItems}')]/../../../../../../..//div[@role='button']"));
        public Button ButtonBuyAndSellGroups => new Button(Driver, By.XPath($"//span[contains(text(),'{ResNotificationSettings.BuyAndSellGroups}')]/../../../../../../..//div[@role='button']"));
        public Button ButtonListingStatus => new Button(Driver, By.XPath($"//span[contains(text(),'{ResNotificationSettings.ListingStatus}')]/../../../../../../..//div[@role='button']"));
        public Button ButtonFeaturedItems => new Button(Driver, By.XPath($"//span[contains(text(),'{ResNotificationSettings.FeaturedItems}')]/../../../../../../..//div[@role='button']"));
        public Button ButtonReducedPrices => new Button(Driver, By.XPath($"//span[contains(text(),'{ResNotificationSettings.ReducedPrices}')]/../../../../../../..//div[@role='button']"));
        public Button ButtonMessageReminders => new Button(Driver, By.XPath($"//span[contains(text(),'{ResNotificationSettings.MessageReminders}')]/../../../../../../..//div[@role='button']"));

        public Button ButtonDont => new Button(Driver, By.XPath($"//div[@aria-label='Notification Settings'][@role='dialog']//span[text()='{ResNotificationSettings.Done}']"));
    }
}