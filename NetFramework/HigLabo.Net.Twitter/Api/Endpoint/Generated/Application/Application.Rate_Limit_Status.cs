using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Application
    {
        public partial class Rate_Limit_Status
        {
            public class Command : TwitterCommand
            {
                public String resources { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/application/rate_limit_status.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("rate_limit_context")]
                public Rate_Limit_Context rate_limit_context { get; set; }
                [JsonProperty("resources")]
                public Resource resources { get; set; }

                public class Rate_Limit_Context
                {
                    [JsonProperty("access_token")]
                    public String access_token { get; set; }
                }
                public class Resource
                {
                    [JsonProperty("users")]
                    public User users { get; set; }
                    [JsonProperty("statuses")]
                    public Statuse statuses { get; set; }
                    [JsonProperty("help")]
                    public Help help { get; set; }
                    [JsonProperty("search")]
                    public Search search { get; set; }

                    public class User
                    {
                        [JsonProperty("/users/profile_banner")]
                        public Users_Profile_Banner users_profile_banner { get; set; }
                        [JsonProperty("/users/suggestions/:slug/members")]
                        public Users_Suggestions_Slug_Member users_suggestions_slug_members { get; set; }
                        [JsonProperty("/users/show/:id")]
                        public Users_Show_Id users_show_id { get; set; }
                        [JsonProperty("/users/suggestions")]
                        public Users_Suggestion users_suggestions { get; set; }
                        [JsonProperty("/users/lookup")]
                        public Users_Lookup users_lookup { get; set; }
                        [JsonProperty("/users/search")]
                        public Users_Search users_search { get; set; }
                        [JsonProperty("/users/contributors")]
                        public Users_Contributor users_contributors { get; set; }
                        [JsonProperty("/users/contributees")]
                        public Users_Contributee users_contributees { get; set; }
                        [JsonProperty("/users/suggestions/:slug")]
                        public Users_Suggestions_Slug users_suggestions_slug { get; set; }

                        public class Users_Profile_Banner
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Users_Suggestions_Slug_Member
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Users_Show_Id
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Users_Suggestion
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Users_Lookup
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Users_Search
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Users_Contributor
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Users_Contributee
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Users_Suggestions_Slug
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                    }
                    public class Statuse
                    {
                        [JsonProperty("/statuses/mentions_timeline")]
                        public Statuses_Mentions_Timeline statuses_mentions_timeline { get; set; }
                        [JsonProperty("/statuses/lookup")]
                        public Statuses_Lookup statuses_lookup { get; set; }
                        [JsonProperty("/statuses/show/:id")]
                        public Statuses_Show_Id statuses_show_id { get; set; }
                        [JsonProperty("/statuses/oembed")]
                        public Statuses_Oembed statuses_oembed { get; set; }
                        [JsonProperty("/statuses/retweeters/ids")]
                        public Statuses_Retweeters_Id statuses_retweeters_ids { get; set; }
                        [JsonProperty("/statuses/home_timeline")]
                        public Statuses_Home_Timeline statuses_home_timeline { get; set; }
                        [JsonProperty("/statuses/user_timeline")]
                        public Statuses_User_Timeline statuses_user_timeline { get; set; }
                        [JsonProperty("/statuses/retweets/:id")]
                        public Statuses_Retweets_Id statuses_retweets_id { get; set; }
                        [JsonProperty("/statuses/retweets_of_me")]
                        public Statuses_Retweets_Of_Me statuses_retweets_of_me { get; set; }

                        public class Statuses_Mentions_Timeline
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Statuses_Lookup
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Statuses_Show_Id
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Statuses_Oembed
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Statuses_Retweeters_Id
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Statuses_Home_Timeline
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Statuses_User_Timeline
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Statuses_Retweets_Id
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Statuses_Retweets_Of_Me
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                    }
                    public class Help
                    {
                        [JsonProperty("/help/privacy")]
                        public Help_Privacy help_privacy { get; set; }
                        [JsonProperty("/help/tos")]
                        public Help_To help_tos { get; set; }
                        [JsonProperty("/help/configuration")]
                        public Help_Configuration help_configuration { get; set; }
                        [JsonProperty("/help/languages")]
                        public Help_Language help_languages { get; set; }

                        public class Help_Privacy
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Help_To
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Help_Configuration
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                        public class Help_Language
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                    }
                    public class Search
                    {
                        [JsonProperty("/search/tweets")]
                        public Search_Tweet search_tweets { get; set; }

                        public class Search_Tweet
                        {
                            [JsonProperty("limit")]
                            public Int64? limit { get; set; }
                            [JsonProperty("remaining")]
                            public Int64? remaining { get; set; }
                            [JsonProperty("reset")]
                            public Int64? reset { get; set; }
                        }
                    }
                }
            }
        }
    }
}
