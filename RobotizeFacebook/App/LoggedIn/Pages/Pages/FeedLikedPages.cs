﻿using System;

namespace RobotizeFacebook.App.LoggedIn
{
    public class FeedLikedPages : Feed
    {
        public override string FeedUrl => "/pages/?category=liked&ref=bookmarks";
    }
}
