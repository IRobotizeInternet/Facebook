﻿namespace RobotizeFacebook.Pages.LoggedIn
{
    public class FeedContainerActivityLog : FeedContainer
    {
        public override string FeedUrl => "/allactivity/?category_key=SEARCH&log_filter=search";
    }
}
