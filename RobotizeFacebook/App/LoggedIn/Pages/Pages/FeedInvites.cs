﻿using System;

namespace RobotizeFacebook.App.LoggedIn
{
    public class FeedInvites : FeedComponent
    {
        public override string FeedUrl => "/pages/?category=invites&ref=bookmarks";

        public override void RunConformance()
        {
            throw new NotImplementedException();
        }
    }
}
