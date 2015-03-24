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
            public Statuses.Mentions_Timeline.Result[] Mentions_Timeline()
            {
                var cm = new Statuses.Mentions_Timeline.Command();
                return this.Mentions_Timeline(cm);
            }
            public Statuses.Mentions_Timeline.Result[] Mentions_Timeline(String since_id, String max_id)
            {
                var cm = new Statuses.Mentions_Timeline.Command();
                cm.since_id = since_id;
                cm.max_id = max_id;
                return this.Mentions_Timeline(cm);
            }
            public Statuses.Mentions_Timeline.Result[] Mentions_Timeline(Int64? count, String since_id, String max_id, Boolean? trim_user, Boolean? contributor_details, Boolean? include_entities)
            {
                var cm = new Statuses.Mentions_Timeline.Command();
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.trim_user = trim_user;
                cm.contributor_details = contributor_details;
                cm.include_entities = include_entities;
                return this.Mentions_Timeline(cm);
            }
            public Statuses.User_Timeline.Result[] User_Timeline(Statuses.User_Timeline.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.User_Timeline.Command, Statuses.User_Timeline.Result[]>(command);
            }
            public Statuses.User_Timeline.Result[] User_Timeline()
            {
                var cm = new Statuses.User_Timeline.Command();
                return this.User_Timeline(cm);
            }
            public Statuses.User_Timeline.Result[] User_Timeline(String since_id, String max_id)
            {
                var cm = new Statuses.User_Timeline.Command();
                cm.since_id = since_id;
                cm.max_id = max_id;
                return this.User_Timeline(cm);
            }
            public Statuses.User_Timeline.Result[] User_Timeline(Int64? count, String since_id, String max_id, Int64? user_id, Boolean? trim_user, Boolean? exclude_replies, Boolean? contributor_details, Boolean? include_rts)
            {
                var cm = new Statuses.User_Timeline.Command();
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.user_id = user_id;
                cm.trim_user = trim_user;
                cm.exclude_replies = exclude_replies;
                cm.contributor_details = contributor_details;
                cm.include_rts = include_rts;
                return this.User_Timeline(cm);
            }
            public Statuses.User_Timeline.Result[] User_Timeline(Int64? count, String since_id, String max_id, String screen_name, Boolean? trim_user, Boolean? exclude_replies, Boolean? contributor_details, Boolean? include_rts)
            {
                var cm = new Statuses.User_Timeline.Command();
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.screen_name = screen_name;
                cm.trim_user = trim_user;
                cm.exclude_replies = exclude_replies;
                cm.contributor_details = contributor_details;
                cm.include_rts = include_rts;
                return this.User_Timeline(cm);
            }
            public Statuses.Home_Timeline.Result[] Home_Timeline(Statuses.Home_Timeline.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Home_Timeline.Command, Statuses.Home_Timeline.Result[]>(command);
            }
            public Statuses.Home_Timeline.Result[] Home_Timeline()
            {
                var cm = new Statuses.Home_Timeline.Command();
                return this.Home_Timeline(cm);
            }
            public Statuses.Home_Timeline.Result[] Home_Timeline(String since_id, String max_id)
            {
                var cm = new Statuses.Home_Timeline.Command();
                cm.since_id = since_id;
                cm.max_id = max_id;
                return this.Home_Timeline(cm);
            }
            public Statuses.Home_Timeline.Result[] Home_Timeline(Int64? count, String since_id, String max_id, Boolean? trim_user, Boolean? exclude_replies, Boolean? contributor_details, Boolean? include_entities)
            {
                var cm = new Statuses.Home_Timeline.Command();
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.trim_user = trim_user;
                cm.exclude_replies = exclude_replies;
                cm.contributor_details = contributor_details;
                cm.include_entities = include_entities;
                return this.Home_Timeline(cm);
            }
            public Statuses.Retweets_Of_Me.Result[] Retweets_Of_Me(Statuses.Retweets_Of_Me.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Retweets_Of_Me.Command, Statuses.Retweets_Of_Me.Result[]>(command);
            }
            public Statuses.Retweets_Of_Me.Result[] Retweets_Of_Me()
            {
                var cm = new Statuses.Retweets_Of_Me.Command();
                return this.Retweets_Of_Me(cm);
            }
            public Statuses.Retweets_Of_Me.Result[] Retweets_Of_Me(String since_id, String max_id)
            {
                var cm = new Statuses.Retweets_Of_Me.Command();
                cm.since_id = since_id;
                cm.max_id = max_id;
                return this.Retweets_Of_Me(cm);
            }
            public Statuses.Retweets_Of_Me.Result[] Retweets_Of_Me(Int64? count, String since_id, String max_id, Boolean? trim_user, Boolean? include_entities, Boolean? include_user_entities)
            {
                var cm = new Statuses.Retweets_Of_Me.Command();
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.trim_user = trim_user;
                cm.include_entities = include_entities;
                cm.include_user_entities = include_user_entities;
                return this.Retweets_Of_Me(cm);
            }
            public Statuses.Retweets.Result[] Retweets(Statuses.Retweets.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Retweets.Command, Statuses.Retweets.Result[]>(command);
            }
            public Statuses.Retweets.Result[] Retweets(String id)
            {
                var cm = new Statuses.Retweets.Command();
                cm.id = id;
                return this.Retweets(cm);
            }
            public Statuses.Retweets.Result[] Retweets(String id, Int64? count, Boolean? trim_user)
            {
                var cm = new Statuses.Retweets.Command();
                cm.id = id;
                cm.count = count;
                cm.trim_user = trim_user;
                return this.Retweets(cm);
            }
            public Statuses.Show.Result Show(Statuses.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Show.Command, Statuses.Show.Result>(command);
            }
            public Statuses.Show.Result Show(String id)
            {
                var cm = new Statuses.Show.Command();
                cm.id = id;
                return this.Show(cm);
            }
            public Statuses.Show.Result Show(String id, Boolean? trim_user, Boolean? include_my_retweet, Boolean? include_entities)
            {
                var cm = new Statuses.Show.Command();
                cm.id = id;
                cm.trim_user = trim_user;
                cm.include_my_retweet = include_my_retweet;
                cm.include_entities = include_entities;
                return this.Show(cm);
            }
            public Statuses.Destroy.Result Destroy(Statuses.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Destroy.Command, Statuses.Destroy.Result>(command);
            }
            public Statuses.Destroy.Result Destroy(String id)
            {
                var cm = new Statuses.Destroy.Command();
                cm.id = id;
                return this.Destroy(cm);
            }
            public Statuses.Destroy.Result Destroy(String id, Boolean? trim_user)
            {
                var cm = new Statuses.Destroy.Command();
                cm.id = id;
                cm.trim_user = trim_user;
                return this.Destroy(cm);
            }
            public Statuses.Update.Result Update(Statuses.Update.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Update.Command, Statuses.Update.Result>(command);
            }
            public Statuses.Update.Result Update(String status)
            {
                var cm = new Statuses.Update.Command();
                cm.status = status;
                return this.Update(cm);
            }
            public Statuses.Update.Result Update(String status, String in_reply_to_status_id, Boolean? possibly_sensitive, String lat, String @long, String place_id, Boolean? display_coordinates, Boolean? trim_user, String media_ids)
            {
                var cm = new Statuses.Update.Command();
                cm.status = status;
                cm.in_reply_to_status_id = in_reply_to_status_id;
                cm.possibly_sensitive = possibly_sensitive;
                cm.lat = lat;
                cm.@long = @long;
                cm.place_id = place_id;
                cm.display_coordinates = display_coordinates;
                cm.trim_user = trim_user;
                cm.media_ids = media_ids;
                return this.Update(cm);
            }
            public Statuses.Retweet.Result Retweet(Statuses.Retweet.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Retweet.Command, Statuses.Retweet.Result>(command);
            }
            public Statuses.Retweet.Result Retweet(String id)
            {
                var cm = new Statuses.Retweet.Command();
                cm.id = id;
                return this.Retweet(cm);
            }
            public Statuses.Retweet.Result Retweet(String id, Boolean? trim_user)
            {
                var cm = new Statuses.Retweet.Command();
                cm.id = id;
                cm.trim_user = trim_user;
                return this.Retweet(cm);
            }
            public Statuses.Oembed.Result Oembed(Statuses.Oembed.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Oembed.Command, Statuses.Oembed.Result>(command);
            }
            public Statuses.Oembed.Result Oembed(String id, String url)
            {
                var cm = new Statuses.Oembed.Command();
                cm.id = id;
                cm.url = url;
                return this.Oembed(cm);
            }
            public Statuses.Oembed.Result Oembed(String id, String url, String maxwidth, Boolean? hide_media, Boolean? hide_thread, Boolean? omit_script, String align, String related, String lang, String widget_type, String hide_tweet)
            {
                var cm = new Statuses.Oembed.Command();
                cm.id = id;
                cm.url = url;
                cm.maxwidth = maxwidth;
                cm.hide_media = hide_media;
                cm.hide_thread = hide_thread;
                cm.omit_script = omit_script;
                cm.align = align;
                cm.related = related;
                cm.lang = lang;
                cm.widget_type = widget_type;
                cm.hide_tweet = hide_tweet;
                return this.Oembed(cm);
            }
            public Statuses.Retweeters_Ids.Result Retweeters_Ids(Statuses.Retweeters_Ids.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Retweeters_Ids.Command, Statuses.Retweeters_Ids.Result>(command);
            }
            public Statuses.Retweeters_Ids.Result Retweeters_Ids(String id)
            {
                var cm = new Statuses.Retweeters_Ids.Command();
                cm.id = id;
                return this.Retweeters_Ids(cm);
            }
            public Statuses.Retweeters_Ids.Result Retweeters_Ids(String id, String cursor, Boolean? stringify_ids)
            {
                var cm = new Statuses.Retweeters_Ids.Command();
                cm.id = id;
                cm.cursor = cursor;
                cm.stringify_ids = stringify_ids;
                return this.Retweeters_Ids(cm);
            }
            public Statuses.Lookup.Result[] Lookup(Statuses.Lookup.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Statuses.Lookup.Command, Statuses.Lookup.Result[]>(command);
            }
            public Statuses.Lookup.Result[] Lookup(String id)
            {
                var cm = new Statuses.Lookup.Command();
                cm.id = id;
                return this.Lookup(cm);
            }
            public Statuses.Lookup.Result[] Lookup(String id, Boolean? include_entities, Boolean? trim_user, Boolean? map)
            {
                var cm = new Statuses.Lookup.Command();
                cm.id = id;
                cm.include_entities = include_entities;
                cm.trim_user = trim_user;
                cm.map = map;
                return this.Lookup(cm);
            }
        }
        public partial class Api_Media
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Media(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Media.Upload.Result Upload(Media.Upload.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Media.Upload.Command, Media.Upload.Result>(command);
            }
            public Media.Upload.Result Upload(String media)
            {
                var cm = new Media.Upload.Command();
                cm.media = media;
                return this.Upload(cm);
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
            public Direct_Messages.Sent.Result[] Sent()
            {
                var cm = new Direct_Messages.Sent.Command();
                return this.Sent(cm);
            }
            public Direct_Messages.Sent.Result[] Sent(String since_id, String max_id)
            {
                var cm = new Direct_Messages.Sent.Command();
                cm.since_id = since_id;
                cm.max_id = max_id;
                return this.Sent(cm);
            }
            public Direct_Messages.Sent.Result[] Sent(Int64? count, String since_id, String max_id, String page, Boolean? include_entities)
            {
                var cm = new Direct_Messages.Sent.Command();
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.page = page;
                cm.include_entities = include_entities;
                return this.Sent(cm);
            }
            public Direct_Messages.Show.Result[] Show(Direct_Messages.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Direct_Messages.Show.Command, Direct_Messages.Show.Result[]>(command);
            }
            public Direct_Messages.Show.Result[] Show(String id)
            {
                var cm = new Direct_Messages.Show.Command();
                cm.id = id;
                return this.Show(cm);
            }
            public Direct_Messages.Get.Result[] Get(Direct_Messages.Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Direct_Messages.Get.Command, Direct_Messages.Get.Result[]>(command);
            }
            public Direct_Messages.Get.Result[] Get()
            {
                var cm = new Direct_Messages.Get.Command();
                return this.Get(cm);
            }
            public Direct_Messages.Get.Result[] Get(String since_id, String max_id)
            {
                var cm = new Direct_Messages.Get.Command();
                cm.since_id = since_id;
                cm.max_id = max_id;
                return this.Get(cm);
            }
            public Direct_Messages.Get.Result[] Get(Int64? count, String since_id, String max_id, Boolean? include_entities, String skip_status)
            {
                var cm = new Direct_Messages.Get.Command();
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Get(cm);
            }
            public Direct_Messages.Destroy.Result Destroy(Direct_Messages.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Direct_Messages.Destroy.Command, Direct_Messages.Destroy.Result>(command);
            }
            public Direct_Messages.Destroy.Result Destroy(String id)
            {
                var cm = new Direct_Messages.Destroy.Command();
                cm.id = id;
                return this.Destroy(cm);
            }
            public Direct_Messages.Destroy.Result Destroy(String id, Boolean? include_entities)
            {
                var cm = new Direct_Messages.Destroy.Command();
                cm.id = id;
                cm.include_entities = include_entities;
                return this.Destroy(cm);
            }
            public Direct_Messages.New.Result New(Direct_Messages.New.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Direct_Messages.New.Command, Direct_Messages.New.Result>(command);
            }
            public Direct_Messages.New.Result New(String text)
            {
                var cm = new Direct_Messages.New.Command();
                cm.text = text;
                return this.New(cm);
            }
            public Direct_Messages.New.Result New(String text, String screen_name)
            {
                var cm = new Direct_Messages.New.Command();
                cm.text = text;
                cm.screen_name = screen_name;
                return this.New(cm);
            }
            public Direct_Messages.New.Result New(String text, Int64? user_id)
            {
                var cm = new Direct_Messages.New.Command();
                cm.text = text;
                cm.user_id = user_id;
                return this.New(cm);
            }
        }
        public partial class Api_Search
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Search(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Search.Tweets.Result Tweets(Search.Tweets.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Search.Tweets.Command, Search.Tweets.Result>(command);
            }
            public Search.Tweets.Result Tweets(String q)
            {
                var cm = new Search.Tweets.Command();
                cm.q = q;
                return this.Tweets(cm);
            }
            public Search.Tweets.Result Tweets(String q, String since_id, String max_id)
            {
                var cm = new Search.Tweets.Command();
                cm.q = q;
                cm.since_id = since_id;
                cm.max_id = max_id;
                return this.Tweets(cm);
            }
            public Search.Tweets.Result Tweets(String q, Int32? count, String since_id, String max_id, String geocode, String lang, String locale, String result_type, String until, Boolean? include_entities, String callback)
            {
                var cm = new Search.Tweets.Command();
                cm.q = q;
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.geocode = geocode;
                cm.lang = lang;
                cm.locale = locale;
                cm.result_type = result_type;
                cm.until = until;
                cm.include_entities = include_entities;
                cm.callback = callback;
                return this.Tweets(cm);
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
            public String[] No_Retweets_Ids()
            {
                var cm = new Friendships.No_Retweets_Ids.Command();
                return this.No_Retweets_Ids(cm);
            }
            public String[] No_Retweets_Ids(Boolean? stringify_ids)
            {
                var cm = new Friendships.No_Retweets_Ids.Command();
                cm.stringify_ids = stringify_ids;
                return this.No_Retweets_Ids(cm);
            }
            public Friendships.Incoming.Result Incoming(Friendships.Incoming.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Incoming.Command, Friendships.Incoming.Result>(command);
            }
            public Friendships.Incoming.Result Incoming()
            {
                var cm = new Friendships.Incoming.Command();
                return this.Incoming(cm);
            }
            public Friendships.Incoming.Result Incoming(String cursor, Boolean? stringify_ids)
            {
                var cm = new Friendships.Incoming.Command();
                cm.cursor = cursor;
                cm.stringify_ids = stringify_ids;
                return this.Incoming(cm);
            }
            public Friendships.Outgoing.Result Outgoing(Friendships.Outgoing.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Outgoing.Command, Friendships.Outgoing.Result>(command);
            }
            public Friendships.Outgoing.Result Outgoing()
            {
                var cm = new Friendships.Outgoing.Command();
                return this.Outgoing(cm);
            }
            public Friendships.Outgoing.Result Outgoing(String cursor, Boolean? stringify_ids)
            {
                var cm = new Friendships.Outgoing.Command();
                cm.cursor = cursor;
                cm.stringify_ids = stringify_ids;
                return this.Outgoing(cm);
            }
            public Friendships.Create.Result Create(Friendships.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Create.Command, Friendships.Create.Result>(command);
            }
            public Friendships.Create.Result Create()
            {
                var cm = new Friendships.Create.Command();
                return this.Create(cm);
            }
            public Friendships.Create.Result Create(String screen_name, Boolean? follow)
            {
                var cm = new Friendships.Create.Command();
                cm.screen_name = screen_name;
                cm.follow = follow;
                return this.Create(cm);
            }
            public Friendships.Create.Result Create(Int64? user_id, Boolean? follow)
            {
                var cm = new Friendships.Create.Command();
                cm.user_id = user_id;
                cm.follow = follow;
                return this.Create(cm);
            }
            public Friendships.Destroy.Result Destroy(Friendships.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Destroy.Command, Friendships.Destroy.Result>(command);
            }
            public Friendships.Destroy.Result Destroy()
            {
                var cm = new Friendships.Destroy.Command();
                return this.Destroy(cm);
            }
            public Friendships.Destroy.Result Destroy(String screen_name)
            {
                var cm = new Friendships.Destroy.Command();
                cm.screen_name = screen_name;
                return this.Destroy(cm);
            }
            public Friendships.Destroy.Result Destroy(Int64? user_id)
            {
                var cm = new Friendships.Destroy.Command();
                cm.user_id = user_id;
                return this.Destroy(cm);
            }
            public Friendships.Update.Result Update(Friendships.Update.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Update.Command, Friendships.Update.Result>(command);
            }
            public Friendships.Update.Result Update()
            {
                var cm = new Friendships.Update.Command();
                return this.Update(cm);
            }
            public Friendships.Update.Result Update(String screen_name, String device, String retweets)
            {
                var cm = new Friendships.Update.Command();
                cm.screen_name = screen_name;
                cm.device = device;
                cm.retweets = retweets;
                return this.Update(cm);
            }
            public Friendships.Update.Result Update(Int64? user_id, String device, String retweets)
            {
                var cm = new Friendships.Update.Command();
                cm.user_id = user_id;
                cm.device = device;
                cm.retweets = retweets;
                return this.Update(cm);
            }
            public Friendships.Show.Result Show(Friendships.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Show.Command, Friendships.Show.Result>(command);
            }
            public Friendships.Show.Result Show()
            {
                var cm = new Friendships.Show.Command();
                return this.Show(cm);
            }
            public Friendships.Show.Result Show(String source_id, String source_screen_name, String target_id, String target_screen_name)
            {
                var cm = new Friendships.Show.Command();
                cm.source_id = source_id;
                cm.source_screen_name = source_screen_name;
                cm.target_id = target_id;
                cm.target_screen_name = target_screen_name;
                return this.Show(cm);
            }
            public Friendships.Lookup.Result[] Lookup(Friendships.Lookup.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friendships.Lookup.Command, Friendships.Lookup.Result[]>(command);
            }
            public Friendships.Lookup.Result[] Lookup()
            {
                var cm = new Friendships.Lookup.Command();
                return this.Lookup(cm);
            }
            public Friendships.Lookup.Result[] Lookup(String screen_name)
            {
                var cm = new Friendships.Lookup.Command();
                cm.screen_name = screen_name;
                return this.Lookup(cm);
            }
            public Friendships.Lookup.Result[] Lookup(Int64? user_id)
            {
                var cm = new Friendships.Lookup.Command();
                cm.user_id = user_id;
                return this.Lookup(cm);
            }
        }
        public partial class Api_Friends
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Friends(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Friends.Ids.Result Ids(Friends.Ids.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friends.Ids.Command, Friends.Ids.Result>(command);
            }
            public Friends.Ids.Result Ids()
            {
                var cm = new Friends.Ids.Command();
                return this.Ids(cm);
            }
            public Friends.Ids.Result Ids(Int64? count, String screen_name, String cursor, Boolean? stringify_ids)
            {
                var cm = new Friends.Ids.Command();
                cm.count = count;
                cm.screen_name = screen_name;
                cm.cursor = cursor;
                cm.stringify_ids = stringify_ids;
                return this.Ids(cm);
            }
            public Friends.Ids.Result Ids(Int64? count, Int64? user_id, String cursor, Boolean? stringify_ids)
            {
                var cm = new Friends.Ids.Command();
                cm.count = count;
                cm.user_id = user_id;
                cm.cursor = cursor;
                cm.stringify_ids = stringify_ids;
                return this.Ids(cm);
            }
            public Friends.List.Result List(Friends.List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Friends.List.Command, Friends.List.Result>(command);
            }
            public Friends.List.Result List()
            {
                var cm = new Friends.List.Command();
                return this.List(cm);
            }
            public Friends.List.Result List(Int32? count, String screen_name, String cursor, Boolean? skip_status, Boolean? include_user_entities)
            {
                var cm = new Friends.List.Command();
                cm.count = count;
                cm.screen_name = screen_name;
                cm.cursor = cursor;
                cm.skip_status = skip_status;
                cm.include_user_entities = include_user_entities;
                return this.List(cm);
            }
            public Friends.List.Result List(Int32? count, Int64? user_id, String cursor, Boolean? skip_status, Boolean? include_user_entities)
            {
                var cm = new Friends.List.Command();
                cm.count = count;
                cm.user_id = user_id;
                cm.cursor = cursor;
                cm.skip_status = skip_status;
                cm.include_user_entities = include_user_entities;
                return this.List(cm);
            }
        }
        public partial class Api_Followers
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Followers(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Followers.List.Result List(Followers.List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Followers.List.Command, Followers.List.Result>(command);
            }
            public Followers.List.Result List()
            {
                var cm = new Followers.List.Command();
                return this.List(cm);
            }
            public Followers.List.Result List(Int32? count, String screen_name, String cursor, Boolean? skip_status, Boolean? include_user_entities)
            {
                var cm = new Followers.List.Command();
                cm.count = count;
                cm.screen_name = screen_name;
                cm.cursor = cursor;
                cm.skip_status = skip_status;
                cm.include_user_entities = include_user_entities;
                return this.List(cm);
            }
            public Followers.List.Result List(Int32? count, Int64? user_id, String cursor, Boolean? skip_status, Boolean? include_user_entities)
            {
                var cm = new Followers.List.Command();
                cm.count = count;
                cm.user_id = user_id;
                cm.cursor = cursor;
                cm.skip_status = skip_status;
                cm.include_user_entities = include_user_entities;
                return this.List(cm);
            }
        }
        public partial class Api_Account
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Account(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Account.Settings_Get.Result Settings_Get(Account.Settings_Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Settings_Get.Command, Account.Settings_Get.Result>(command);
            }
            public Account.Verify_Credentials.Result Verify_Credentials(Account.Verify_Credentials.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Verify_Credentials.Command, Account.Verify_Credentials.Result>(command);
            }
            public Account.Verify_Credentials.Result Verify_Credentials()
            {
                var cm = new Account.Verify_Credentials.Command();
                return this.Verify_Credentials(cm);
            }
            public Account.Verify_Credentials.Result Verify_Credentials(Boolean? include_entities, Boolean? skip_status)
            {
                var cm = new Account.Verify_Credentials.Command();
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Verify_Credentials(cm);
            }
            public Account.Settings_Post.Result Settings_Post(Account.Settings_Post.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Settings_Post.Command, Account.Settings_Post.Result>(command);
            }
            public Account.Settings_Post.Result Settings_Post()
            {
                var cm = new Account.Settings_Post.Command();
                return this.Settings_Post(cm);
            }
            public Account.Settings_Post.Result Settings_Post(String trend_location_woeid, Boolean? sleep_time_enabled, String start_sleep_time, String end_sleep_time, String time_zone, String lang)
            {
                var cm = new Account.Settings_Post.Command();
                cm.trend_location_woeid = trend_location_woeid;
                cm.sleep_time_enabled = sleep_time_enabled;
                cm.start_sleep_time = start_sleep_time;
                cm.end_sleep_time = end_sleep_time;
                cm.time_zone = time_zone;
                cm.lang = lang;
                return this.Settings_Post(cm);
            }
            public Account.Update_Profile.Result Update_Profile(Account.Update_Profile.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Update_Profile.Command, Account.Update_Profile.Result>(command);
            }
            public Account.Update_Profile.Result Update_Profile()
            {
                var cm = new Account.Update_Profile.Command();
                return this.Update_Profile(cm);
            }
            public Account.Update_Profile.Result Update_Profile(String name, String url, String location, String description, String profile_link_color, Boolean? include_entities, String skip_status)
            {
                var cm = new Account.Update_Profile.Command();
                cm.name = name;
                cm.url = url;
                cm.location = location;
                cm.description = description;
                cm.profile_link_color = profile_link_color;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Update_Profile(cm);
            }
            public Account.Update_Profile_Background_Image.Result Update_Profile_Background_Image(Account.Update_Profile_Background_Image.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Update_Profile_Background_Image.Command, Account.Update_Profile_Background_Image.Result>(command);
            }
            public Account.Update_Profile_Background_Image.Result Update_Profile_Background_Image()
            {
                var cm = new Account.Update_Profile_Background_Image.Command();
                return this.Update_Profile_Background_Image(cm);
            }
            public Account.Update_Profile_Background_Image.Result Update_Profile_Background_Image(String image, String tile, Boolean? include_entities, String skip_status, String use)
            {
                var cm = new Account.Update_Profile_Background_Image.Command();
                cm.image = image;
                cm.tile = tile;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                cm.use = use;
                return this.Update_Profile_Background_Image(cm);
            }
            public Account.Update_Profile_Image.Result Update_Profile_Image(Account.Update_Profile_Image.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Account.Update_Profile_Image.Command, Account.Update_Profile_Image.Result>(command);
            }
            public Account.Update_Profile_Image.Result Update_Profile_Image(String image)
            {
                var cm = new Account.Update_Profile_Image.Command();
                cm.image = image;
                return this.Update_Profile_Image(cm);
            }
            public Account.Update_Profile_Image.Result Update_Profile_Image(String image, Boolean? include_entities, String skip_status)
            {
                var cm = new Account.Update_Profile_Image.Command();
                cm.image = image;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Update_Profile_Image(cm);
            }
        }
        public partial class Api_Blocks
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Blocks(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Blocks.List.Result List(Blocks.List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Blocks.List.Command, Blocks.List.Result>(command);
            }
            public Blocks.List.Result List()
            {
                var cm = new Blocks.List.Command();
                return this.List(cm);
            }
            public Blocks.List.Result List(Boolean? include_entities, String skip_status, String cursor)
            {
                var cm = new Blocks.List.Command();
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                cm.cursor = cursor;
                return this.List(cm);
            }
            public Blocks.Ids.Result Ids(Blocks.Ids.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Blocks.Ids.Command, Blocks.Ids.Result>(command);
            }
            public Blocks.Ids.Result Ids()
            {
                var cm = new Blocks.Ids.Command();
                return this.Ids(cm);
            }
            public Blocks.Ids.Result Ids(Boolean? stringify_ids, String cursor)
            {
                var cm = new Blocks.Ids.Command();
                cm.stringify_ids = stringify_ids;
                cm.cursor = cursor;
                return this.Ids(cm);
            }
            public Blocks.Create.Result Create(Blocks.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Blocks.Create.Command, Blocks.Create.Result>(command);
            }
            public Blocks.Create.Result Create()
            {
                var cm = new Blocks.Create.Command();
                return this.Create(cm);
            }
            public Blocks.Create.Result Create(String screen_name, Boolean? include_entities, Boolean? skip_status)
            {
                var cm = new Blocks.Create.Command();
                cm.screen_name = screen_name;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Create(cm);
            }
            public Blocks.Create.Result Create(Int64? user_id, Boolean? include_entities, Boolean? skip_status)
            {
                var cm = new Blocks.Create.Command();
                cm.user_id = user_id;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Create(cm);
            }
            public Blocks.Destroy.Result Destroy(Blocks.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Blocks.Destroy.Command, Blocks.Destroy.Result>(command);
            }
            public Blocks.Destroy.Result Destroy()
            {
                var cm = new Blocks.Destroy.Command();
                return this.Destroy(cm);
            }
            public Blocks.Destroy.Result Destroy(String screen_name, Boolean? include_entities, String skip_status)
            {
                var cm = new Blocks.Destroy.Command();
                cm.screen_name = screen_name;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Destroy(cm);
            }
            public Blocks.Destroy.Result Destroy(Int64? user_id, Boolean? include_entities, String skip_status)
            {
                var cm = new Blocks.Destroy.Command();
                cm.user_id = user_id;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Destroy(cm);
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
            public Users.Lookup.Result[] Lookup()
            {
                var cm = new Users.Lookup.Command();
                return this.Lookup(cm);
            }
            public Users.Lookup.Result[] Lookup(String screen_name, Boolean? include_entities)
            {
                var cm = new Users.Lookup.Command();
                cm.screen_name = screen_name;
                cm.include_entities = include_entities;
                return this.Lookup(cm);
            }
            public Users.Lookup.Result[] Lookup(Int64? user_id, Boolean? include_entities)
            {
                var cm = new Users.Lookup.Command();
                cm.user_id = user_id;
                cm.include_entities = include_entities;
                return this.Lookup(cm);
            }
            public Users.Show.Result Show(Users.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Show.Command, Users.Show.Result>(command);
            }
            public Users.Show.Result Show(Int64 user_id, Boolean? include_entities)
            {
                var cm = new Users.Show.Command();
                cm.user_id = user_id;
                cm.include_entities = include_entities;
                return this.Show(cm);
            }
            public Users.Show.Result Show(String screen_name, Boolean? include_entities)
            {
                var cm = new Users.Show.Command();
                cm.screen_name = screen_name;
                cm.include_entities = include_entities;
                return this.Show(cm);
            }
            public Users.Show.Result Show(Int64 user_id, String screen_name)
            {
                var cm = new Users.Show.Command();
                cm.user_id = user_id;
                cm.screen_name = screen_name;
                return this.Show(cm);
            }
            public Users.Search.Result[] Search(Users.Search.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Search.Command, Users.Search.Result[]>(command);
            }
            public Users.Search.Result[] Search(String q)
            {
                var cm = new Users.Search.Command();
                cm.q = q;
                return this.Search(cm);
            }
            public Users.Search.Result[] Search(String q, Int32? count, String page, Boolean? include_entities)
            {
                var cm = new Users.Search.Command();
                cm.q = q;
                cm.count = count;
                cm.page = page;
                cm.include_entities = include_entities;
                return this.Search(cm);
            }
            public Users.Profile_Banner.Result Profile_Banner(Users.Profile_Banner.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Profile_Banner.Command, Users.Profile_Banner.Result>(command);
            }
            public Users.Profile_Banner.Result Profile_Banner()
            {
                var cm = new Users.Profile_Banner.Command();
                return this.Profile_Banner(cm);
            }
            public Users.Profile_Banner.Result Profile_Banner(String screen_name)
            {
                var cm = new Users.Profile_Banner.Command();
                cm.screen_name = screen_name;
                return this.Profile_Banner(cm);
            }
            public Users.Profile_Banner.Result Profile_Banner(Int64? user_id)
            {
                var cm = new Users.Profile_Banner.Command();
                cm.user_id = user_id;
                return this.Profile_Banner(cm);
            }
            public Users.Suggestions_Category.Result Suggestions_Category(Users.Suggestions_Category.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Suggestions_Category.Command, Users.Suggestions_Category.Result>(command);
            }
            public Users.Suggestions_Category.Result Suggestions_Category(String slug)
            {
                var cm = new Users.Suggestions_Category.Command();
                cm.slug = slug;
                return this.Suggestions_Category(cm);
            }
            public Users.Suggestions_Category.Result Suggestions_Category(String slug, String lang)
            {
                var cm = new Users.Suggestions_Category.Command();
                cm.slug = slug;
                cm.lang = lang;
                return this.Suggestions_Category(cm);
            }
            public Users.Suggestions.Result[] Suggestions(Users.Suggestions.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Suggestions.Command, Users.Suggestions.Result[]>(command);
            }
            public Users.Suggestions.Result[] Suggestions()
            {
                var cm = new Users.Suggestions.Command();
                return this.Suggestions(cm);
            }
            public Users.Suggestions.Result[] Suggestions(String lang)
            {
                var cm = new Users.Suggestions.Command();
                cm.lang = lang;
                return this.Suggestions(cm);
            }
            public Users.Suggestions_Category_Members.Result[] Suggestions_Category_Members(Users.Suggestions_Category_Members.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Suggestions_Category_Members.Command, Users.Suggestions_Category_Members.Result[]>(command);
            }
            public Users.Suggestions_Category_Members.Result[] Suggestions_Category_Members(String slug)
            {
                var cm = new Users.Suggestions_Category_Members.Command();
                cm.slug = slug;
                return this.Suggestions_Category_Members(cm);
            }
            public Users.Report_Spam.Result Report_Spam(Users.Report_Spam.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Report_Spam.Command, Users.Report_Spam.Result>(command);
            }
            public Users.Report_Spam.Result Report_Spam()
            {
                var cm = new Users.Report_Spam.Command();
                return this.Report_Spam(cm);
            }
            public Users.Report_Spam.Result Report_Spam(String screen_name)
            {
                var cm = new Users.Report_Spam.Command();
                cm.screen_name = screen_name;
                return this.Report_Spam(cm);
            }
            public Users.Report_Spam.Result Report_Spam(Int64? user_id)
            {
                var cm = new Users.Report_Spam.Command();
                cm.user_id = user_id;
                return this.Report_Spam(cm);
            }
        }
        public partial class Api_Mutes
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Mutes(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Mutes.Users_Create.Result Users_Create(Mutes.Users_Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Mutes.Users_Create.Command, Mutes.Users_Create.Result>(command);
            }
            public Mutes.Users_Create.Result Users_Create()
            {
                var cm = new Mutes.Users_Create.Command();
                return this.Users_Create(cm);
            }
            public Mutes.Users_Create.Result Users_Create(String screen_name)
            {
                var cm = new Mutes.Users_Create.Command();
                cm.screen_name = screen_name;
                return this.Users_Create(cm);
            }
            public Mutes.Users_Create.Result Users_Create(Int64? user_id)
            {
                var cm = new Mutes.Users_Create.Command();
                cm.user_id = user_id;
                return this.Users_Create(cm);
            }
            public Mutes.Users_Destroy.Result Users_Destroy(Mutes.Users_Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Mutes.Users_Destroy.Command, Mutes.Users_Destroy.Result>(command);
            }
            public Mutes.Users_Destroy.Result Users_Destroy()
            {
                var cm = new Mutes.Users_Destroy.Command();
                return this.Users_Destroy(cm);
            }
            public Mutes.Users_Destroy.Result Users_Destroy(String screen_name)
            {
                var cm = new Mutes.Users_Destroy.Command();
                cm.screen_name = screen_name;
                return this.Users_Destroy(cm);
            }
            public Mutes.Users_Destroy.Result Users_Destroy(Int64? user_id)
            {
                var cm = new Mutes.Users_Destroy.Command();
                cm.user_id = user_id;
                return this.Users_Destroy(cm);
            }
            public Mutes.Users_Ids.Result Users_Ids(Mutes.Users_Ids.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Mutes.Users_Ids.Command, Mutes.Users_Ids.Result>(command);
            }
            public Mutes.Users_Ids.Result Users_Ids()
            {
                var cm = new Mutes.Users_Ids.Command();
                return this.Users_Ids(cm);
            }
            public Mutes.Users_Ids.Result Users_Ids(String cursor)
            {
                var cm = new Mutes.Users_Ids.Command();
                cm.cursor = cursor;
                return this.Users_Ids(cm);
            }
            public Mutes.Users_List.Result Users_List(Mutes.Users_List.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Mutes.Users_List.Command, Mutes.Users_List.Result>(command);
            }
            public Mutes.Users_List.Result Users_List()
            {
                var cm = new Mutes.Users_List.Command();
                return this.Users_List(cm);
            }
            public Mutes.Users_List.Result Users_List(String cursor, Boolean? include_entities, Boolean? skip_status)
            {
                var cm = new Mutes.Users_List.Command();
                cm.cursor = cursor;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Users_List(cm);
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
            public Favorites.List.Result[] List()
            {
                var cm = new Favorites.List.Command();
                return this.List(cm);
            }
            public Favorites.List.Result[] List(String since_id, String max_id)
            {
                var cm = new Favorites.List.Command();
                cm.since_id = since_id;
                cm.max_id = max_id;
                return this.List(cm);
            }
            public Favorites.List.Result[] List(Int64? count, String since_id, String max_id, Int64? user_id, Boolean? include_entities)
            {
                var cm = new Favorites.List.Command();
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.user_id = user_id;
                cm.include_entities = include_entities;
                return this.List(cm);
            }
            public Favorites.List.Result[] List(Int64? count, String since_id, String max_id, String screen_name, Boolean? include_entities)
            {
                var cm = new Favorites.List.Command();
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.screen_name = screen_name;
                cm.include_entities = include_entities;
                return this.List(cm);
            }
            public Favorites.Destroy.Result Destroy(Favorites.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Favorites.Destroy.Command, Favorites.Destroy.Result>(command);
            }
            public Favorites.Destroy.Result Destroy(String id)
            {
                var cm = new Favorites.Destroy.Command();
                cm.id = id;
                return this.Destroy(cm);
            }
            public Favorites.Destroy.Result Destroy(String id, Boolean? include_entities)
            {
                var cm = new Favorites.Destroy.Command();
                cm.id = id;
                cm.include_entities = include_entities;
                return this.Destroy(cm);
            }
            public Favorites.Create.Result Create(Favorites.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Favorites.Create.Command, Favorites.Create.Result>(command);
            }
            public Favorites.Create.Result Create(String id)
            {
                var cm = new Favorites.Create.Command();
                cm.id = id;
                return this.Create(cm);
            }
            public Favorites.Create.Result Create(String id, Boolean? include_entities)
            {
                var cm = new Favorites.Create.Command();
                cm.id = id;
                cm.include_entities = include_entities;
                return this.Create(cm);
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
            public Lists.List.Result[] List()
            {
                var cm = new Lists.List.Command();
                return this.List(cm);
            }
            public Lists.List.Result[] List(String screen_name, Boolean? reverse)
            {
                var cm = new Lists.List.Command();
                cm.screen_name = screen_name;
                cm.reverse = reverse;
                return this.List(cm);
            }
            public Lists.List.Result[] List(Int64? user_id, Boolean? reverse)
            {
                var cm = new Lists.List.Command();
                cm.user_id = user_id;
                cm.reverse = reverse;
                return this.List(cm);
            }
            public Lists.Statuses.Result[] Statuses(Lists.Statuses.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Statuses.Command, Lists.Statuses.Result[]>(command);
            }
            public Lists.Statuses.Result[] Statuses(String list_id, String slug)
            {
                var cm = new Lists.Statuses.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                return this.Statuses(cm);
            }
            public Lists.Statuses.Result[] Statuses(String list_id, String slug, String since_id, String max_id)
            {
                var cm = new Lists.Statuses.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.since_id = since_id;
                cm.max_id = max_id;
                return this.Statuses(cm);
            }
            public Lists.Statuses.Result[] Statuses(String list_id, String slug, Int64? count, String since_id, String max_id, String owner_screen_name, String owner_id, String include_entities, String include_rts)
            {
                var cm = new Lists.Statuses.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.count = count;
                cm.since_id = since_id;
                cm.max_id = max_id;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                cm.include_entities = include_entities;
                cm.include_rts = include_rts;
                return this.Statuses(cm);
            }
            public Lists.Memberships.Result Memberships(Lists.Memberships.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Memberships.Command, Lists.Memberships.Result>(command);
            }
            public Lists.Memberships.Result Memberships()
            {
                var cm = new Lists.Memberships.Command();
                return this.Memberships(cm);
            }
            public Lists.Memberships.Result Memberships(Int32? count, String screen_name, String cursor, String filter_to_owned_lists)
            {
                var cm = new Lists.Memberships.Command();
                cm.count = count;
                cm.screen_name = screen_name;
                cm.cursor = cursor;
                cm.filter_to_owned_lists = filter_to_owned_lists;
                return this.Memberships(cm);
            }
            public Lists.Memberships.Result Memberships(Int32? count, Int64? user_id, String cursor, String filter_to_owned_lists)
            {
                var cm = new Lists.Memberships.Command();
                cm.count = count;
                cm.user_id = user_id;
                cm.cursor = cursor;
                cm.filter_to_owned_lists = filter_to_owned_lists;
                return this.Memberships(cm);
            }
            public Lists.Subscribers.Result Subscribers(Lists.Subscribers.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Subscribers.Command, Lists.Subscribers.Result>(command);
            }
            public Lists.Subscribers.Result Subscribers(String list_id, String slug)
            {
                var cm = new Lists.Subscribers.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                return this.Subscribers(cm);
            }
            public Lists.Subscribers.Result Subscribers(String list_id, String slug, Int64? count, String owner_screen_name, String owner_id, String cursor, String include_entities, String skip_status)
            {
                var cm = new Lists.Subscribers.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.count = count;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                cm.cursor = cursor;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Subscribers(cm);
            }
            public Lists.Subscribers_Create.Result Subscribers_Create(Lists.Subscribers_Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Subscribers_Create.Command, Lists.Subscribers_Create.Result>(command);
            }
            public Lists.Subscribers_Create.Result Subscribers_Create(String list_id, String slug)
            {
                var cm = new Lists.Subscribers_Create.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                return this.Subscribers_Create(cm);
            }
            public Lists.Subscribers_Create.Result Subscribers_Create(String list_id, String slug, String owner_screen_name, String owner_id)
            {
                var cm = new Lists.Subscribers_Create.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                return this.Subscribers_Create(cm);
            }
            public Lists.Subscribers_Show.Result Subscribers_Show(Lists.Subscribers_Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Subscribers_Show.Command, Lists.Subscribers_Show.Result>(command);
            }
            public Lists.Subscribers_Show.Result Subscribers_Show(String list_id, String slug, Int64 user_id, String screen_name)
            {
                var cm = new Lists.Subscribers_Show.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.user_id = user_id;
                cm.screen_name = screen_name;
                return this.Subscribers_Show(cm);
            }
            public Lists.Subscribers_Show.Result Subscribers_Show(String list_id, String slug, String screen_name, String owner_screen_name, String owner_id, String include_entities, String skip_status)
            {
                var cm = new Lists.Subscribers_Show.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.screen_name = screen_name;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Subscribers_Show(cm);
            }
            public Lists.Subscribers_Show.Result Subscribers_Show(String list_id, String slug, Int64 user_id, String owner_screen_name, String owner_id, String include_entities, String skip_status)
            {
                var cm = new Lists.Subscribers_Show.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.user_id = user_id;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Subscribers_Show(cm);
            }
            public Lists.Members_Show.Result Members_Show(Lists.Members_Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Members_Show.Command, Lists.Members_Show.Result>(command);
            }
            public Lists.Members_Show.Result Members_Show(String list_id, String slug, Int64 user_id, String screen_name)
            {
                var cm = new Lists.Members_Show.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.user_id = user_id;
                cm.screen_name = screen_name;
                return this.Members_Show(cm);
            }
            public Lists.Members_Show.Result Members_Show(String list_id, String slug, String screen_name, String owner_screen_name, String owner_id, String include_entities, String skip_status)
            {
                var cm = new Lists.Members_Show.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.screen_name = screen_name;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Members_Show(cm);
            }
            public Lists.Members_Show.Result Members_Show(String list_id, String slug, Int64 user_id, String owner_screen_name, String owner_id, String include_entities, String skip_status)
            {
                var cm = new Lists.Members_Show.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.user_id = user_id;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Members_Show(cm);
            }
            public Lists.Members.Result Members(Lists.Members.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Members.Command, Lists.Members.Result>(command);
            }
            public Lists.Members.Result Members(String list_id, String slug)
            {
                var cm = new Lists.Members.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                return this.Members(cm);
            }
            public Lists.Members.Result Members(String list_id, String slug, Int64? count, String owner_screen_name, String owner_id, String cursor, Boolean? include_entities, String skip_status)
            {
                var cm = new Lists.Members.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.count = count;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                cm.cursor = cursor;
                cm.include_entities = include_entities;
                cm.skip_status = skip_status;
                return this.Members(cm);
            }
            public Lists.Destroy.Result Destroy(Lists.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Destroy.Command, Lists.Destroy.Result>(command);
            }
            public Lists.Destroy.Result Destroy(String list_id, String slug)
            {
                var cm = new Lists.Destroy.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                return this.Destroy(cm);
            }
            public Lists.Destroy.Result Destroy(String list_id, String slug, String owner_screen_name, String owner_id)
            {
                var cm = new Lists.Destroy.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                return this.Destroy(cm);
            }
            public Lists.Create.Result Create(Lists.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Create.Command, Lists.Create.Result>(command);
            }
            public Lists.Create.Result Create(String name)
            {
                var cm = new Lists.Create.Command();
                cm.name = name;
                return this.Create(cm);
            }
            public Lists.Create.Result Create(String name, String mode, String description)
            {
                var cm = new Lists.Create.Command();
                cm.name = name;
                cm.mode = mode;
                cm.description = description;
                return this.Create(cm);
            }
            public Lists.Show.Result Show(Lists.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Show.Command, Lists.Show.Result>(command);
            }
            public Lists.Show.Result Show(String list_id, String slug)
            {
                var cm = new Lists.Show.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                return this.Show(cm);
            }
            public Lists.Show.Result Show(String list_id, String slug, String owner_screen_name, String owner_id)
            {
                var cm = new Lists.Show.Command();
                cm.list_id = list_id;
                cm.slug = slug;
                cm.owner_screen_name = owner_screen_name;
                cm.owner_id = owner_id;
                return this.Show(cm);
            }
            public Lists.Subscriptions.Result Subscriptions(Lists.Subscriptions.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Subscriptions.Command, Lists.Subscriptions.Result>(command);
            }
            public Lists.Subscriptions.Result Subscriptions()
            {
                var cm = new Lists.Subscriptions.Command();
                return this.Subscriptions(cm);
            }
            public Lists.Subscriptions.Result Subscriptions(Int32? count, String screen_name, String cursor)
            {
                var cm = new Lists.Subscriptions.Command();
                cm.count = count;
                cm.screen_name = screen_name;
                cm.cursor = cursor;
                return this.Subscriptions(cm);
            }
            public Lists.Subscriptions.Result Subscriptions(Int32? count, Int64? user_id, String cursor)
            {
                var cm = new Lists.Subscriptions.Command();
                cm.count = count;
                cm.user_id = user_id;
                cm.cursor = cursor;
                return this.Subscriptions(cm);
            }
            public Lists.Ownerships.Result Ownerships(Lists.Ownerships.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Lists.Ownerships.Command, Lists.Ownerships.Result>(command);
            }
            public Lists.Ownerships.Result Ownerships()
            {
                var cm = new Lists.Ownerships.Command();
                return this.Ownerships(cm);
            }
            public Lists.Ownerships.Result Ownerships(Int32? count, String screen_name, String cursor)
            {
                var cm = new Lists.Ownerships.Command();
                cm.count = count;
                cm.screen_name = screen_name;
                cm.cursor = cursor;
                return this.Ownerships(cm);
            }
            public Lists.Ownerships.Result Ownerships(Int32? count, Int64? user_id, String cursor)
            {
                var cm = new Lists.Ownerships.Command();
                cm.count = count;
                cm.user_id = user_id;
                cm.cursor = cursor;
                return this.Ownerships(cm);
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
            public Saved_Searches.Show.Result Show(Saved_Searches.Show.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Saved_Searches.Show.Command, Saved_Searches.Show.Result>(command);
            }
            public Saved_Searches.Show.Result Show(String id)
            {
                var cm = new Saved_Searches.Show.Command();
                cm.id = id;
                return this.Show(cm);
            }
            public Saved_Searches.Create.Result Create(Saved_Searches.Create.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Saved_Searches.Create.Command, Saved_Searches.Create.Result>(command);
            }
            public Saved_Searches.Create.Result Create(String query)
            {
                var cm = new Saved_Searches.Create.Command();
                cm.query = query;
                return this.Create(cm);
            }
            public Saved_Searches.Destroy.Result Destroy(Saved_Searches.Destroy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Saved_Searches.Destroy.Command, Saved_Searches.Destroy.Result>(command);
            }
            public Saved_Searches.Destroy.Result Destroy(String id)
            {
                var cm = new Saved_Searches.Destroy.Command();
                cm.id = id;
                return this.Destroy(cm);
            }
        }
        public partial class Api_Geo
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Geo(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Geo.Id_Place_Id.Result Id_Place_Id(Geo.Id_Place_Id.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Geo.Id_Place_Id.Command, Geo.Id_Place_Id.Result>(command);
            }
            public Geo.Id_Place_Id.Result Id_Place_Id(String place_id)
            {
                var cm = new Geo.Id_Place_Id.Command();
                cm.place_id = place_id;
                return this.Id_Place_Id(cm);
            }
            public Geo.Reverse_Geocode.Result Reverse_Geocode(Geo.Reverse_Geocode.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Geo.Reverse_Geocode.Command, Geo.Reverse_Geocode.Result>(command);
            }
            public Geo.Reverse_Geocode.Result Reverse_Geocode(String lat, String @long)
            {
                var cm = new Geo.Reverse_Geocode.Command();
                cm.lat = lat;
                cm.@long = @long;
                return this.Reverse_Geocode(cm);
            }
            public Geo.Reverse_Geocode.Result Reverse_Geocode(String lat, String @long, String accuracy, String granularity, String max_results, String callback)
            {
                var cm = new Geo.Reverse_Geocode.Command();
                cm.lat = lat;
                cm.@long = @long;
                cm.accuracy = accuracy;
                cm.granularity = granularity;
                cm.max_results = max_results;
                cm.callback = callback;
                return this.Reverse_Geocode(cm);
            }
            public Geo.Search.Result Search(Geo.Search.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Geo.Search.Command, Geo.Search.Result>(command);
            }
            public Geo.Search.Result Search()
            {
                var cm = new Geo.Search.Command();
                return this.Search(cm);
            }
            public Geo.Search.Result Search(String lat, String @long, String query, String ip, String granularity, String accuracy, String max_results, String contained_within, String attribute_street_address, String callback)
            {
                var cm = new Geo.Search.Command();
                cm.lat = lat;
                cm.@long = @long;
                cm.query = query;
                cm.ip = ip;
                cm.granularity = granularity;
                cm.accuracy = accuracy;
                cm.max_results = max_results;
                cm.contained_within = contained_within;
                cm.attribute_street_address = attribute_street_address;
                cm.callback = callback;
                return this.Search(cm);
            }
            public Geo.Place.Result Place(Geo.Place.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Geo.Place.Command, Geo.Place.Result>(command);
            }
            public Geo.Place.Result Place(String name, String contained_within, String token, String lat, String @long)
            {
                var cm = new Geo.Place.Command();
                cm.name = name;
                cm.contained_within = contained_within;
                cm.token = token;
                cm.lat = lat;
                cm.@long = @long;
                return this.Place(cm);
            }
            public Geo.Place.Result Place(String name, String contained_within, String token, String lat, String @long, String attribute_street_address, String callback)
            {
                var cm = new Geo.Place.Command();
                cm.name = name;
                cm.contained_within = contained_within;
                cm.token = token;
                cm.lat = lat;
                cm.@long = @long;
                cm.attribute_street_address = attribute_street_address;
                cm.callback = callback;
                return this.Place(cm);
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
            public Trends.Place.Result[] Place(String id)
            {
                var cm = new Trends.Place.Command();
                cm.id = id;
                return this.Place(cm);
            }
            public Trends.Place.Result[] Place(String id, String exclude)
            {
                var cm = new Trends.Place.Command();
                cm.id = id;
                cm.exclude = exclude;
                return this.Place(cm);
            }
            public Trends.Available.Result[] Available(Trends.Available.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Trends.Available.Command, Trends.Available.Result[]>(command);
            }
            public Trends.Closest.Result[] Closest(Trends.Closest.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Trends.Closest.Command, Trends.Closest.Result[]>(command);
            }
            public Trends.Closest.Result[] Closest(String lat, String @long)
            {
                var cm = new Trends.Closest.Command();
                cm.lat = lat;
                cm.@long = @long;
                return this.Closest(cm);
            }
        }
        public partial class Api_Application
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Application(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Application.Rate_Limit_Status.Result Rate_Limit_Status(Application.Rate_Limit_Status.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Application.Rate_Limit_Status.Command, Application.Rate_Limit_Status.Result>(command);
            }
            public Application.Rate_Limit_Status.Result Rate_Limit_Status()
            {
                var cm = new Application.Rate_Limit_Status.Command();
                return this.Rate_Limit_Status(cm);
            }
            public Application.Rate_Limit_Status.Result Rate_Limit_Status(String resources)
            {
                var cm = new Application.Rate_Limit_Status.Command();
                cm.resources = resources;
                return this.Rate_Limit_Status(cm);
            }
        }
        public partial class Api_Help
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Help(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Help.Configuration.Result Configuration(Help.Configuration.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Help.Configuration.Command, Help.Configuration.Result>(command);
            }
            public Help.Languages.Result[] Languages(Help.Languages.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Help.Languages.Command, Help.Languages.Result[]>(command);
            }
            public Help.Privacy.Result Privacy(Help.Privacy.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Help.Privacy.Command, Help.Privacy.Result>(command);
            }
            public Help.Tos.Result Tos(Help.Tos.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Help.Tos.Command, Help.Tos.Result>(command);
            }
        }
    }
}
