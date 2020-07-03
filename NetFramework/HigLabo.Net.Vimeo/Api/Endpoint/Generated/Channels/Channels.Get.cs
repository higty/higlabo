using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Vimeo.Api_3_2
{
    public partial class Channels
    {
        public partial class Get
        {
            public class Command : VimeoCommand
            {
                [VimeoParameterName("page")]
                public Int32? page { get; set; }
                [VimeoParameterName("per_page")]
                public Int32? per_page { get; set; }
                [VimeoParameterName("query")]
                public String query { get; set; }
                [VimeoParameterName("sort")]
                public Channels.Get.Command.SortValues sort { get; set; }
                [VimeoParameterName("direction")]
                public Channels.Get.Command.DirectionValues direction { get; set; }
                [VimeoParameterName("filter")]
                public Channels.Get.Command.FilterValues filter { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "channels/";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }

                public enum SortValues
                {
                    date,
                    alphabetical,
                    videos,
                    followers,
                }
                public enum DirectionValues
                {
                    asc,
                    desc,
                }
                public enum FilterValues
                {
                    featured,
                }
            }
            public class Result
            {
                [JsonProperty("total")]
                public Int64? total { get; set; }
                [JsonProperty("page")]
                public Int64? page { get; set; }
                [JsonProperty("per_page")]
                public Int64? per_page { get; set; }
                [JsonProperty("paging")]
                public Paging paging { get; set; }
                [JsonProperty("data")]
                public Data[] data { get; set; }

                public class Paging
                {
                    [JsonProperty("next")]
                    public String next { get; set; }
                    [JsonProperty("previous")]
                    public String previous { get; set; }
                    [JsonProperty("first")]
                    public String first { get; set; }
                    [JsonProperty("last")]
                    public String last { get; set; }
                }
                public class Data
                {
                    [JsonProperty("uri")]
                    public String uri { get; set; }
                    [JsonProperty("name")]
                    public String name { get; set; }
                    [JsonProperty("description")]
                    public String description { get; set; }
                    [JsonProperty("link")]
                    public String link { get; set; }
                    [JsonProperty("created_time")]
                    public DateTime? created_time { get; set; }
                    [JsonProperty("modified_time")]
                    public DateTime? modified_time { get; set; }
                    [JsonProperty("user")]
                    public User user { get; set; }
                    [JsonProperty("pictures")]
                    public Picture pictures { get; set; }
                    [JsonProperty("header")]
                    public Header header { get; set; }
                    [JsonProperty("privacy")]
                    public Privacy privacy { get; set; }
                    [JsonProperty("metadata")]
                    public Metadata metadata { get; set; }

                    public class User
                    {
                        [JsonProperty("uri")]
                        public String uri { get; set; }
                        [JsonProperty("name")]
                        public String name { get; set; }
                        [JsonProperty("link")]
                        public String link { get; set; }
                        [JsonProperty("location")]
                        public String location { get; set; }
                        [JsonProperty("bio")]
                        public String bio { get; set; }
                        [JsonProperty("created_time")]
                        public DateTime? created_time { get; set; }
                        [JsonProperty("account")]
                        public String account { get; set; }
                        [JsonProperty("pictures")]
                        public Picture pictures { get; set; }
                        [JsonProperty("websites")]
                        public Website[] websites { get; set; }
                        [JsonProperty("metadata")]
                        public Metadata metadata { get; set; }

                        public class Metadata
                        {
                            [JsonProperty("connections")]
                            public Connection connections { get; set; }
                            [JsonProperty("interactions")]
                            public Interaction interactions { get; set; }

                            public class Connection
                            {
                                [JsonProperty("activities")]
                                public Activity activities { get; set; }
                                [JsonProperty("albums")]
                                public Album albums { get; set; }
                                [JsonProperty("channels")]
                                public Channel channels { get; set; }
                                [JsonProperty("feed")]
                                public Feed feed { get; set; }
                                [JsonProperty("followers")]
                                public Follower followers { get; set; }
                                [JsonProperty("following")]
                                public Following following { get; set; }
                                [JsonProperty("groups")]
                                public Group groups { get; set; }
                                [JsonProperty("likes")]
                                public Like likes { get; set; }
                                [JsonProperty("portfolios")]
                                public Portfolio portfolios { get; set; }
                                [JsonProperty("videos")]
                                public Video videos { get; set; }
                                [JsonProperty("shared")]
                                public Shared shared { get; set; }
                                [JsonProperty("pictures")]
                                public Picture pictures { get; set; }

                                public class Activity
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                }
                                public class Album
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                                public class Channel
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                                public class Feed
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                }
                                public class Follower
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                                public class Following
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                                public class Group
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                                public class Like
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                                public class Portfolio
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                                public class Video
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                                public class Shared
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                                public class Picture
                                {
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                    [JsonProperty("options")]
                                    public String[] options { get; set; }
                                    [JsonProperty("total")]
                                    public Int64? total { get; set; }
                                }
                            }
                            public class Interaction
                            {
                                [JsonProperty("follow")]
                                public Follow follow { get; set; }

                                public class Follow
                                {
                                    [JsonProperty("added")]
                                    public Boolean? added { get; set; }
                                    [JsonProperty("added_time")]
                                    public String added_time { get; set; }
                                    [JsonProperty("uri")]
                                    public String uri { get; set; }
                                }
                            }
                        }
                        public class Picture
                        {
                            [JsonProperty("uri")]
                            public String uri { get; set; }
                            [JsonProperty("active")]
                            public Boolean? active { get; set; }
                            [JsonProperty("sizes")]
                            public Size[] sizes { get; set; }

                            public class Size
                            {
                                [JsonProperty("width")]
                                public Int64? width { get; set; }
                                [JsonProperty("height")]
                                public Int64? height { get; set; }
                                [JsonProperty("link")]
                                public String link { get; set; }
                            }
                        }
                        public class Website
                        {
                            [JsonProperty("name")]
                            public String name { get; set; }
                            [JsonProperty("link")]
                            public String link { get; set; }
                            [JsonProperty("description")]
                            public String description { get; set; }
                        }
                    }
                    public class Picture
                    {
                        [JsonProperty("uri")]
                        public String uri { get; set; }
                        [JsonProperty("active")]
                        public Boolean? active { get; set; }
                        [JsonProperty("sizes")]
                        public Size[] sizes { get; set; }

                        public class Size
                        {
                            [JsonProperty("width")]
                            public Int64? width { get; set; }
                            [JsonProperty("height")]
                            public Int64? height { get; set; }
                            [JsonProperty("link")]
                            public String link { get; set; }
                        }
                    }
                    public class Privacy
                    {
                        [JsonProperty("view")]
                        public String view { get; set; }
                    }
                    public class Metadata
                    {
                        [JsonProperty("connections")]
                        public Connection connections { get; set; }
                        [JsonProperty("interactions")]
                        public Interaction interactions { get; set; }

                        public class Connection
                        {
                            [JsonProperty("users")]
                            public User users { get; set; }
                            [JsonProperty("videos")]
                            public Video videos { get; set; }

                            public class User
                            {
                                [JsonProperty("uri")]
                                public String uri { get; set; }
                                [JsonProperty("options")]
                                public String[] options { get; set; }
                                [JsonProperty("total")]
                                public Int64? total { get; set; }
                            }
                            public class Video
                            {
                                [JsonProperty("uri")]
                                public String uri { get; set; }
                                [JsonProperty("options")]
                                public String[] options { get; set; }
                                [JsonProperty("total")]
                                public Int64? total { get; set; }
                            }
                        }
                        public class Interaction
                        {
                            [JsonProperty("follow")]
                            public Follow follow { get; set; }

                            public class Follow
                            {
                                [JsonProperty("added")]
                                public Boolean? added { get; set; }
                                [JsonProperty("added_time")]
                                public String added_time { get; set; }
                                [JsonProperty("type")]
                                public String type { get; set; }
                                [JsonProperty("uri")]
                                public String uri { get; set; }
                            }
                        }
                    }
                    public class Header
                    {
                        [JsonProperty("uri")]
                        public String uri { get; set; }
                        [JsonProperty("active")]
                        public Boolean? active { get; set; }
                        [JsonProperty("sizes")]
                        public Size[] sizes { get; set; }

                        public class Size
                        {
                            [JsonProperty("width")]
                            public Int64? width { get; set; }
                            [JsonProperty("height")]
                            public Int64? height { get; set; }
                            [JsonProperty("link")]
                            public String link { get; set; }
                        }
                    }
                }
            }
        }
    }
}
