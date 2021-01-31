﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using RobotizeFacebook.App.LoggedIn.Enum;
using RobotizeFacebook.Resources;
using RobotizeLibrary.Extensions;
using RobotizeToolbox.CommonControls;
using RobotizeToolbox.Controls;
using RobotizeToolbox.Controls.TriggerControls;
using RobotizeToolbox.Dialogs;
using RobotizeToolbox.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotizeFacebook.App.LoggedIn.Pages.JobsComposer.ScheduleLiveVideoEvent
{
    public class MenuItemsScheduleLiveVideoEvent : MenuItems
    {
        public MenuItemsScheduleLiveVideoEvent()
        {
            BaseXPath = $"//div[@aria-label='{ResLeftNav.ScheduleLiveSettings}']";
            MenuItemsCommon = new MenuItemsCommon(BaseXPath);
        }

        public override void RunConformance()
        {
            throw new NotImplementedException();
        }

        public MenuItemsCommon MenuItemsCommon;

        public TextBox TextBoxEventName => new TextBox(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.EventName}']"));
        public TextBox TextBoxStartDate => new TextBox(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.StartDate}']"));
        public TextBox TextBoxStartTime => new TextBox(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.StartTime}']"));
        public TextBox TextBoxDescription => new TextBox(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.Description}']"));
        public Hyperlink<DialogEndDateAndTime> HyperlinkEndDateAndTime =>
            new Hyperlink<DialogEndDateAndTime>(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.EventName}']"));

        public EventTriggerButton<DialogEndDateAndTime> EventTriggerButtonEndDateAndTime =>
         new EventTriggerButton<DialogEndDateAndTime>(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.Next}']"));

        public DropdownSchedulePrivacy DropdownPrivacy => 
            new DropdownSchedulePrivacy(Driver, new ExtendBy($"{BaseXPath}//span[text()='{ResLeftNav.Privacy}']"));

        public class DropdownSchedulePrivacy : DropdownWithEnum<Privacy>
        {
            public DropdownSchedulePrivacy(RemoteWebDriver driver, ExtendBy byForDropdown) : base(driver, byForDropdown)
            {
            }
        }

        public Checkbox CheckboxGuestsCanInviteFriends =>
            new Checkbox(Driver, By.XPath($"{BaseXPath}//input[@aria-label='{ResLeftNav.GuestsCanInviteFriends}']"));

        public EventTriggerButton<DialogScheduleNext> EventTriggerButtonNext =>
            new EventTriggerButton<DialogScheduleNext>(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.Next}']"));

        public class DialogEndDateAndTime : BaseDialog
        {
            public DialogEndDateAndTime(RemoteWebDriver driver) : base(driver)
            {
            }

            protected override By ByForDialog => By.XPath($"//div[@aria-label='{ResLeftNav.ScheduleLiveSettings}']//span[text()='{ResLeftNav.EndDateAndTime}']");
            public TextBox TextBoxEndDate => new TextBox(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.EndDate}']"));
            public TextBox TextBoxEndTime => new TextBox(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.EndTime}']"));

        }
    }

    public class DialogScheduleNext : BaseDialog
    {
        public DialogScheduleNext(RemoteWebDriver driver) : base(driver)
        {
        }

        protected override By ByForDialog => throw new NotImplementedException();

        public FileUploader EventTriggerButtonUploadCoverPhoto =>
         new FileUploader(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.UploadCoverPhoto}']"));

        public EventTriggerButton<DialogChooseIllustration> EventTriggerButtonChooseIllustration =>
         new EventTriggerButton<DialogChooseIllustration>(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.ChooseIllustration}']"));

        public Button ButtonEditIllustrationOrPhoto => new Button(Driver, By.XPath($"{BaseXPath}//span[contains(text(),'{ResLeftNav.Edit}')]"));

        public IWebElement ButtonImageIllustration(int index)
        {
            var illustrations = Driver.FindElements(By.XPath($"//div[@aria-label='Schedule Live Settings']//img[contains(@alt,'Seasons') or contains(@alt,'Holiday') or contains(@alt,'Family')]"));
            if (illustrations.Count() < index) return null;
            return illustrations[index];
        }

        public EventTriggerButton<DialogEventSettings> EventTriggerButtonEventSettings =>
            new EventTriggerButton<DialogEventSettings>(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.EventSettings}']"));

        public EventTriggerButton<DialogEventSettings> EventTriggerButtonScheduleWithoutCreatingEvent =>
            new EventTriggerButton<DialogEventSettings>(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.ScheduleWithoutCreatingEvent}']"));

        public EventTriggerButton<DialogScheduleNext> EventTriggerButtonBack =>
            new EventTriggerButton<DialogScheduleNext>(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.Back}']"));

        public EventTriggerButton<DialogEventSettings> EventTriggerButtonSave =>
            new EventTriggerButton<DialogEventSettings>(Driver, By.XPath($"{BaseXPath}//span[text()='{ResLeftNav.CreateEvent}']"));

        public class DialogInvalidTime : BaseDialog
        {
            public DialogInvalidTime(RemoteWebDriver driver) : base(driver)
            {
            }

            protected override By ByForDialog => By.XPath($"//div[@aria-label='{ResLeftNav.InvalidTime}']");

            public Button ButtonOK => new Button(Driver, By.XPath($"//div[@aria-label='{ResLeftNav.InvalidTime}']//div[@aria-label='{ResLeftNav.OK}']"));
        }

    }
}
