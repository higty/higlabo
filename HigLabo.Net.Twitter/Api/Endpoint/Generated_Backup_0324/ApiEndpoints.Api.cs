using System;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class ApiEndpoints
    {
        private Api_Statuses _Statuses;
        private Api_Media _Media;
        private Api_Direct_Messages _Direct_Messages;
        private Api_Search _Search;
        private Api_Friendships _Friendships;
        private Api_Friends _Friends;
        private Api_Followers _Followers;
        private Api_Account _Account;
        private Api_Blocks _Blocks;
        private Api_Users _Users;
        private Api_Mutes _Mutes;
        private Api_Favorites _Favorites;
        private Api_Lists _Lists;
        private Api_Saved_Searches _Saved_Searches;
        private Api_Geo _Geo;
        private Api_Trends _Trends;
        private Api_Application _Application;
        private Api_Help _Help;

        public Api_Statuses Statuses
        {
            get
            {
                if (_Statuses == null) _Statuses = new Api_Statuses(this);
                return _Statuses;
            }
        }
        public Api_Media Media
        {
            get
            {
                if (_Media == null) _Media = new Api_Media(this);
                return _Media;
            }
        }
        public Api_Direct_Messages Direct_Messages
        {
            get
            {
                if (_Direct_Messages == null) _Direct_Messages = new Api_Direct_Messages(this);
                return _Direct_Messages;
            }
        }
        public Api_Search Search
        {
            get
            {
                if (_Search == null) _Search = new Api_Search(this);
                return _Search;
            }
        }
        public Api_Friendships Friendships
        {
            get
            {
                if (_Friendships == null) _Friendships = new Api_Friendships(this);
                return _Friendships;
            }
        }
        public Api_Friends Friends
        {
            get
            {
                if (_Friends == null) _Friends = new Api_Friends(this);
                return _Friends;
            }
        }
        public Api_Followers Followers
        {
            get
            {
                if (_Followers == null) _Followers = new Api_Followers(this);
                return _Followers;
            }
        }
        public Api_Account Account
        {
            get
            {
                if (_Account == null) _Account = new Api_Account(this);
                return _Account;
            }
        }
        public Api_Blocks Blocks
        {
            get
            {
                if (_Blocks == null) _Blocks = new Api_Blocks(this);
                return _Blocks;
            }
        }
        public Api_Users Users
        {
            get
            {
                if (_Users == null) _Users = new Api_Users(this);
                return _Users;
            }
        }
        public Api_Mutes Mutes
        {
            get
            {
                if (_Mutes == null) _Mutes = new Api_Mutes(this);
                return _Mutes;
            }
        }
        public Api_Favorites Favorites
        {
            get
            {
                if (_Favorites == null) _Favorites = new Api_Favorites(this);
                return _Favorites;
            }
        }
        public Api_Lists Lists
        {
            get
            {
                if (_Lists == null) _Lists = new Api_Lists(this);
                return _Lists;
            }
        }
        public Api_Saved_Searches Saved_Searches
        {
            get
            {
                if (_Saved_Searches == null) _Saved_Searches = new Api_Saved_Searches(this);
                return _Saved_Searches;
            }
        }
        public Api_Geo Geo
        {
            get
            {
                if (_Geo == null) _Geo = new Api_Geo(this);
                return _Geo;
            }
        }
        public Api_Trends Trends
        {
            get
            {
                if (_Trends == null) _Trends = new Api_Trends(this);
                return _Trends;
            }
        }
        public Api_Application Application
        {
            get
            {
                if (_Application == null) _Application = new Api_Application(this);
                return _Application;
            }
        }
        public Api_Help Help
        {
            get
            {
                if (_Help == null) _Help = new Api_Help(this);
                return _Help;
            }
        }

        public partial class Api_Statuses
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Statuses(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Statuses.Mentions_Timeline.Result[] Mentions_Timeline(Statuses.Mentions_Timeline.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Mentions_Timeline.Command, Statuses.Mentions_Timeline.Result[]>(command);
            }
            public Statuses.User_Timeline.Result[] User_Timeline(Statuses.User_Timeline.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.User_Timeline.Command, Statuses.User_Timeline.Result[]>(command);
            }
            public Statuses.Home_Timeline.Result[] Home_Timeline(Statuses.Home_Timeline.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Home_Timeline.Command, Statuses.Home_Timeline.Result[]>(command);
            }
            public Statuses.Retweets_Of_Me.Result[] Retweets_Of_Me(Statuses.Retweets_Of_Me.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Retweets_Of_Me.Command, Statuses.Retweets_Of_Me.Result[]>(command);
            }
            public Statuses.Retweets.Result[] Retweets(Statuses.Retweets.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Retweets.Command, Statuses.Retweets.Result[]>(command);
            }
            public Statuses.Show.Result[] Show(Statuses.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Show.Command, Statuses.Show.Result[]>(command);
            }
            public Statuses.Destroy.Result[] Destroy(Statuses.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Destroy.Command, Statuses.Destroy.Result[]>(command);
            }
            public Statuses.Update.Result Update(Statuses.Update.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Update.Command, Statuses.Update.Result>(command);
            }
            public Statuses.Retweet.Result[] Retweet(Statuses.Retweet.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Retweet.Command, Statuses.Retweet.Result[]>(command);
            }
            public Statuses.Oembed.Result[] Oembed(Statuses.Oembed.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Oembed.Command, Statuses.Oembed.Result[]>(command);
            }
            public Statuses.Retweeters_Ids.Result[] Retweeters_Ids(Statuses.Retweeters_Ids.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Retweeters_Ids.Command, Statuses.Retweeters_Ids.Result[]>(command);
            }
            public Statuses.Lookup.Result[] Lookup(Statuses.Lookup.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Lookup.Command, Statuses.Lookup.Result[]>(command);
            }
        }
        public partial class Api_Media
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Media(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Media.Upload.Result[] Upload(Media.Upload.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Media.Upload.Command, Media.Upload.Result[]>(command);
            }
        }
        public partial class Api_Direct_Messages
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Direct_Messages(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Direct_Messages.Sent.Result[] Sent(Direct_Messages.Sent.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Direct_Messages.Sent.Command, Direct_Messages.Sent.Result[]>(command);
            }
            public Direct_Messages.Show.Result[] Show(Direct_Messages.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Direct_Messages.Show.Command, Direct_Messages.Show.Result[]>(command);
            }
            public Direct_Messages.Get.Result[] Get(Direct_Messages.Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Direct_Messages.Get.Command, Direct_Messages.Get.Result[]>(command);
            }
            public Direct_Messages.Destroy.Result[] Destroy(Direct_Messages.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Direct_Messages.Destroy.Command, Direct_Messages.Destroy.Result[]>(command);
            }
            public Direct_Messages.New.Result[] New(Direct_Messages.New.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Direct_Messages.New.Command, Direct_Messages.New.Result[]>(command);
            }
        }
        public partial class Api_Search
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Search(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Search.Tweets.Result[] Tweets(Search.Tweets.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Search.Tweets.Command, Search.Tweets.Result[]>(command);
            }
        }
        public partial class Api_Friendships
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Friendships(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public String[] No_Retweets_Ids(Friendships.No_Retweets_Ids.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.No_Retweets_Ids.Command, String[]>(command);
            }
            public Friendships.Incoming.Result[] Incoming(Friendships.Incoming.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Incoming.Command, Friendships.Incoming.Result[]>(command);
            }
            public Friendships.Outgoing.Result[] Outgoing(Friendships.Outgoing.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Outgoing.Command, Friendships.Outgoing.Result[]>(command);
            }
            public Friendships.Create.Result[] Create(Friendships.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Create.Command, Friendships.Create.Result[]>(command);
            }
            public Friendships.Destroy.Result[] Destroy(Friendships.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Destroy.Command, Friendships.Destroy.Result[]>(command);
            }
            public Friendships.Update.Result[] Update(Friendships.Update.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Update.Command, Friendships.Update.Result[]>(command);
            }
            public Friendships.Show.Result[] Show(Friendships.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Show.Command, Friendships.Show.Result[]>(command);
            }
            public Friendships.Lookup.Result[] Lookup(Friendships.Lookup.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Lookup.Command, Friendships.Lookup.Result[]>(command);
            }
        }
        public partial class Api_Friends
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Friends(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Friends.Ids.Result[] Ids(Friends.Ids.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friends.Ids.Command, Friends.Ids.Result[]>(command);
            }
            public Friends.List.Result[] List(Friends.List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friends.List.Command, Friends.List.Result[]>(command);
            }
        }
        public partial class Api_Followers
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Followers(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Followers.List.Result[] List(Followers.List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Followers.List.Command, Followers.List.Result[]>(command);
            }
        }
        public partial class Api_Account
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Account(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Account.Settings_Get.Result[] Settings_Get(Account.Settings_Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Settings_Get.Command, Account.Settings_Get.Result[]>(command);
            }
            public Account.Verify_Credentials.Result[] Verify_Credentials(Account.Verify_Credentials.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Verify_Credentials.Command, Account.Verify_Credentials.Result[]>(command);
            }
            public Account.Settings_Post.Result[] Settings_Post(Account.Settings_Post.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Settings_Post.Command, Account.Settings_Post.Result[]>(command);
            }
            public Account.Update_Profile.Result[] Update_Profile(Account.Update_Profile.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Update_Profile.Command, Account.Update_Profile.Result[]>(command);
            }
            public Account.Update_Profile_Background_Image.Result[] Update_Profile_Background_Image(Account.Update_Profile_Background_Image.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Update_Profile_Background_Image.Command, Account.Update_Profile_Background_Image.Result[]>(command);
            }
            public Account.Update_Profile_Image.Result[] Update_Profile_Image(Account.Update_Profile_Image.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Update_Profile_Image.Command, Account.Update_Profile_Image.Result[]>(command);
            }
        }
        public partial class Api_Blocks
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Blocks(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Blocks.List.Result[] List(Blocks.List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Blocks.List.Command, Blocks.List.Result[]>(command);
            }
            public Blocks.Ids.Result[] Ids(Blocks.Ids.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Blocks.Ids.Command, Blocks.Ids.Result[]>(command);
            }
            public Blocks.Create.Result[] Create(Blocks.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Blocks.Create.Command, Blocks.Create.Result[]>(command);
            }
            public Blocks.Destroy.Result[] Destroy(Blocks.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Blocks.Destroy.Command, Blocks.Destroy.Result[]>(command);
            }
        }
        public partial class Api_Users
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Users(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Users.Lookup.Result[] Lookup(Users.Lookup.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Lookup.Command, Users.Lookup.Result[]>(command);
            }
            public Users.Show.Result[] Show(Users.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Show.Command, Users.Show.Result[]>(command);
            }
            public Users.Search.Result[] Search(Users.Search.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Search.Command, Users.Search.Result[]>(command);
            }
            public Users.Profile_Banner.Result[] Profile_Banner(Users.Profile_Banner.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Profile_Banner.Command, Users.Profile_Banner.Result[]>(command);
            }
            public Users.Suggestions_Category.Result[] Suggestions_Category(Users.Suggestions_Category.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Suggestions_Category.Command, Users.Suggestions_Category.Result[]>(command);
            }
            public Users.Suggestions.Result[] Suggestions(Users.Suggestions.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Suggestions.Command, Users.Suggestions.Result[]>(command);
            }
            public Users.Suggestions_Category_Members.Result[] Suggestions_Category_Members(Users.Suggestions_Category_Members.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Suggestions_Category_Members.Command, Users.Suggestions_Category_Members.Result[]>(command);
            }
            public Users.Report_Spam.Result[] Report_Spam(Users.Report_Spam.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Report_Spam.Command, Users.Report_Spam.Result[]>(command);
            }
        }
        public partial class Api_Mutes
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Mutes(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Mutes.Users_Create.Result[] Users_Create(Mutes.Users_Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Mutes.Users_Create.Command, Mutes.Users_Create.Result[]>(command);
            }
            public Mutes.Users_Destroy.Result[] Users_Destroy(Mutes.Users_Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Mutes.Users_Destroy.Command, Mutes.Users_Destroy.Result[]>(command);
            }
            public Mutes.Users_Ids.Result[] Users_Ids(Mutes.Users_Ids.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Mutes.Users_Ids.Command, Mutes.Users_Ids.Result[]>(command);
            }
            public Mutes.Users_List.Result[] Users_List(Mutes.Users_List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Mutes.Users_List.Command, Mutes.Users_List.Result[]>(command);
            }
        }
        public partial class Api_Favorites
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Favorites(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Favorites.List.Result[] List(Favorites.List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Favorites.List.Command, Favorites.List.Result[]>(command);
            }
            public Favorites.Destroy.Result[] Destroy(Favorites.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Favorites.Destroy.Command, Favorites.Destroy.Result[]>(command);
            }
            public Favorites.Create.Result[] Create(Favorites.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Favorites.Create.Command, Favorites.Create.Result[]>(command);
            }
        }
        public partial class Api_Lists
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Lists(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Lists.List.Result[] List(Lists.List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.List.Command, Lists.List.Result[]>(command);
            }
            public Lists.Statuses.Result[] Statuses(Lists.Statuses.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Statuses.Command, Lists.Statuses.Result[]>(command);
            }
            public Lists.Memberships.Result[] Memberships(Lists.Memberships.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Memberships.Command, Lists.Memberships.Result[]>(command);
            }
            public Lists.Subscribers.Result[] Subscribers(Lists.Subscribers.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Subscribers.Command, Lists.Subscribers.Result[]>(command);
            }
            public Lists.Subscribers_Create.Result[] Subscribers_Create(Lists.Subscribers_Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Subscribers_Create.Command, Lists.Subscribers_Create.Result[]>(command);
            }
            public Lists.Subscribers_Show.Result[] Subscribers_Show(Lists.Subscribers_Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Subscribers_Show.Command, Lists.Subscribers_Show.Result[]>(command);
            }
            public Lists.Members_Show.Result[] Members_Show(Lists.Members_Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Members_Show.Command, Lists.Members_Show.Result[]>(command);
            }
            public Lists.Members.Result[] Members(Lists.Members.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Members.Command, Lists.Members.Result[]>(command);
            }
            public Lists.Destroy.Result[] Destroy(Lists.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Destroy.Command, Lists.Destroy.Result[]>(command);
            }
            public Lists.Create.Result[] Create(Lists.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Create.Command, Lists.Create.Result[]>(command);
            }
            public Lists.Show.Result[] Show(Lists.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Show.Command, Lists.Show.Result[]>(command);
            }
            public Lists.Subscriptions.Result[] Subscriptions(Lists.Subscriptions.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Subscriptions.Command, Lists.Subscriptions.Result[]>(command);
            }
            public Lists.Ownerships.Result[] Ownerships(Lists.Ownerships.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Ownerships.Command, Lists.Ownerships.Result[]>(command);
            }
        }
        public partial class Api_Saved_Searches
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Saved_Searches(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Saved_Searches.List.Result[] List(Saved_Searches.List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Saved_Searches.List.Command, Saved_Searches.List.Result[]>(command);
            }
            public Saved_Searches.Show.Result[] Show(Saved_Searches.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Saved_Searches.Show.Command, Saved_Searches.Show.Result[]>(command);
            }
            public Saved_Searches.Create.Result[] Create(Saved_Searches.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Saved_Searches.Create.Command, Saved_Searches.Create.Result[]>(command);
            }
            public Saved_Searches.Destroy.Result[] Destroy(Saved_Searches.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Saved_Searches.Destroy.Command, Saved_Searches.Destroy.Result[]>(command);
            }
        }
        public partial class Api_Geo
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Geo(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Geo.Id_Place_Id.Result[] Id_Place_Id(Geo.Id_Place_Id.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Geo.Id_Place_Id.Command, Geo.Id_Place_Id.Result[]>(command);
            }
            public Geo.Reverse_Geocode.Result[] Reverse_Geocode(Geo.Reverse_Geocode.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Geo.Reverse_Geocode.Command, Geo.Reverse_Geocode.Result[]>(command);
            }
            public Geo.Search.Result[] Search(Geo.Search.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Geo.Search.Command, Geo.Search.Result[]>(command);
            }
            public Geo.Place.Result[] Place(Geo.Place.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Geo.Place.Command, Geo.Place.Result[]>(command);
            }
        }
        public partial class Api_Trends
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Trends(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Trends.Place.Result[] Place(Trends.Place.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Trends.Place.Command, Trends.Place.Result[]>(command);
            }
            public Trends.Available.Result[] Available(Trends.Available.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Trends.Available.Command, Trends.Available.Result[]>(command);
            }
            public Trends.Closest.Result[] Closest(Trends.Closest.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Trends.Closest.Command, Trends.Closest.Result[]>(command);
            }
        }
        public partial class Api_Application
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Application(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Application.Rate_Limit_Status.Result[] Rate_Limit_Status(Application.Rate_Limit_Status.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Application.Rate_Limit_Status.Command, Application.Rate_Limit_Status.Result[]>(command);
            }
        }
        public partial class Api_Help
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Help(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Help.Configuration.Result[] Configuration(Help.Configuration.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Help.Configuration.Command, Help.Configuration.Result[]>(command);
            }
            public Help.Languages.Result[] Languages(Help.Languages.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Help.Languages.Command, Help.Languages.Result[]>(command);
            }
            public Help.Privacy.Result[] Privacy(Help.Privacy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Help.Privacy.Command, Help.Privacy.Result[]>(command);
            }
            public Help.Tos.Result[] Tos(Help.Tos.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Help.Tos.Command, Help.Tos.Result[]>(command);
            }
        }
    }
}
