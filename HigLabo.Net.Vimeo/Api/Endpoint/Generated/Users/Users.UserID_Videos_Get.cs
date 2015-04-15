using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Vimeo.Api_3_2
{
    public partial class Users
    {
        public partial class UserID_Videos_Get
        {
            public class Command : VimeoCommand
            {
                public String user_id { get; set; }
                [VimeoParameterName("page")]
                public Int32? page { get; set; }
                [VimeoParameterName("per_page")]
                public Int32? per_page { get; set; }
                [VimeoParameterName("query")]
                public String query { get; set; }
                [VimeoParameterName("filter")]
                public Users.UserID_Videos_Get.Command.FilterValues filter { get; set; }
                [VimeoParameterName("filter_embeddable")]
                public Users.UserID_Videos_Get.Command.Filter_EmbeddableValues filter_embeddable { get; set; }
                [VimeoParameterName("filter_playable")]
                public Users.UserID_Videos_Get.Command.Filter_PlayableValues filter_playable { get; set; }
                [VimeoParameterName("sort")]
                public Users.UserID_Videos_Get.Command.SortValues sort { get; set; }
                [VimeoParameterName("direction")]
                public Users.UserID_Videos_Get.Command.DirectionValues direction { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "users/" + this.user_id + "/videos";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }

                public enum FilterValues
                {
                    embeddable,
                    playable,
                }
                public enum Filter_EmbeddableValues
                {
                    @true,
                    @false,
                }
                public enum Filter_PlayableValues
                {
                    @true,
                    @false,
                }
                public enum SortValues
                {
                    date,
                    alphabetical,
                    plays,
                    likes,
                    comments,
                    duration,
                    @default,
                    modified_time,
                }
                public enum DirectionValues
                {
                    asc,
                    desc,
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
                    [JsonProperty("duration")]
                    public Int64? duration { get; set; }
                    [JsonProperty("width")]
                    public Int64? width { get; set; }
                    [JsonProperty("language")]
                    public String language { get; set; }
                    [JsonProperty("height")]
                    public Int64? height { get; set; }
                    [JsonProperty("embed")]
                    public Embed embed { get; set; }
                    [JsonProperty("created_time")]
                    public DateTime? created_time { get; set; }
                    [JsonProperty("modified_time")]
                    public DateTime? modified_time { get; set; }
                    [JsonProperty("content_rating")]
                    public String[] content_rating { get; set; }
                    [JsonProperty("license")]
                    public String license { get; set; }
                    [JsonProperty("privacy")]
                    public Privacy privacy { get; set; }
                    [JsonProperty("pictures")]
                    public Picture pictures { get; set; }
                    [JsonProperty("tags")]
                    public Tag[] tags { get; set; }
                    [JsonProperty("stats")]
                    public Stat stats { get; set; }
                    [JsonProperty("metadata")]
                    public Metadata metadata { get; set; }
                    [JsonProperty("user")]
                    public User user { get; set; }
                    [JsonProperty("app")]
                    public String app { get; set; }
                    [JsonProperty("status")]
                    public String status { get; set; }
                    [JsonProperty("embed_presets")]
                    public String embed_presets { get; set; }

                    public class Embed
                    {
                        [JsonProperty("html")]
                        public String html { get; set; }
                    }
                    public class Privacy
                    {
                        [JsonProperty("view")]
                        public String view { get; set; }
                        [JsonProperty("embed")]
                        public String embed { get; set; }
                        [JsonProperty("download")]
                        public Boolean? download { get; set; }
                        [JsonProperty("add")]
                        public Boolean? add { get; set; }
                        [JsonProperty("comments")]
                        public String comments { get; set; }
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
                    public class Stat
                    {
                        [JsonProperty("plays")]
                        public Int64? plays { get; set; }
                    }
                    public class Metadata
                    {
                        [JsonProperty("connections")]
                        public Connection connections { get; set; }
                        [JsonProperty("interactions")]
                        public Interaction interactions { get; set; }

                        public class Connection
                        {
                            [JsonProperty("comments")]
                            public Comment comments { get; set; }
                            [JsonProperty("credits")]
                            public Credit credits { get; set; }
                            [JsonProperty("likes")]
                            public Like likes { get; set; }
                            [JsonProperty("pictures")]
                            public Picture pictures { get; set; }
                            [JsonProperty("texttracks")]
                            public Texttrack texttracks { get; set; }

                            public class Comment
                            {
                                [JsonProperty("uri")]
                                public String uri { get; set; }
                                [JsonProperty("options")]
                                public String[] options { get; set; }
                                [JsonProperty("total")]
                                public Int64? total { get; set; }
                            }
                            public class Credit
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
                            public class Picture
                            {
                                [JsonProperty("uri")]
                                public String uri { get; set; }
                                [JsonProperty("options")]
                                public String[] options { get; set; }
                                [JsonProperty("total")]
                                public Int64? total { get; set; }
                            }
                            public class Texttrack
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
                            [JsonProperty("watchlater")]
                            public Watchlater watchlater { get; set; }
                            [JsonProperty("like")]
                            public Like like { get; set; }

                            public class Watchlater
                            {
                                [JsonProperty("added")]
                                public Boolean? added { get; set; }
                                [JsonProperty("added_time")]
                                public String added_time { get; set; }
                                [JsonProperty("uri")]
                                public String uri { get; set; }
                            }
                            public class Like
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
                    }
                    public class Tag
                    {
                        [JsonProperty("uri")]
                        public String uri { get; set; }
                        [JsonProperty("name")]
                        public String name { get; set; }
                        [JsonProperty("tag")]
                        public String tag { get; set; }
                        [JsonProperty("canonical")]
                        public String canonical { get; set; }
                        [JsonProperty("metadata")]
                        public Metadata metadata { get; set; }

                        public class Metadata
                        {
                            [JsonProperty("connections")]
                            public Connection connections { get; set; }

                            public class Connection
                            {
                                [JsonProperty("videos")]
                                public Video videos { get; set; }

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
                        }
                    }
                }
            }
        }
    }
}
