﻿using System;

namespace RobotizeFacebook.App.LoggedIn
{
    public class FeedStories : FeedComponent
    {
        public override string FeedUrl => "/stories";

        public override void RunConformance()
        {
            throw new NotImplementedException();
        }
    }
}
