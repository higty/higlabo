using System;

namespace HigLabo.Net.Vimeo.Api_3_2
{
    public partial class ApiEndpoints
    {
        private Api_Users _Users;
        private Api_Channels _Channels;
        private Api_Videos _Videos;

        public Api_Users Users
        {
            get
            {
                if (_Users == null) _Users = new Api_Users(this);
                return _Users;
            }
        }
        public Api_Channels Channels
        {
            get
            {
                if (_Channels == null) _Channels = new Api_Channels(this);
                return _Channels;
            }
        }
        public Api_Videos Videos
        {
            get
            {
                if (_Videos == null) _Videos = new Api_Videos(this);
                return _Videos;
            }
        }

        public partial class Api_Users
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Users(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Users.Get.Result Get(Users.Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.Get.Command, Users.Get.Result>(command);
            }
            public Users.Get.Result Get(String query)
            {
                var cm = new Users.Get.Command();
                cm.query = query;
                return this.Get(cm);
            }
            public Users.Get.Result Get(Int32? page, Int32? per_page, String query, Users.Get.Command.SortValues sort, Users.Get.Command.DirectionValues direction)
            {
                var cm = new Users.Get.Command();
                cm.page = page;
                cm.per_page = per_page;
                cm.query = query;
                cm.sort = sort;
                cm.direction = direction;
                return this.Get(cm);
            }
            public Users.UserID_Get.Result UserID_Get(Users.UserID_Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.UserID_Get.Command, Users.UserID_Get.Result>(command);
            }
            public Users.UserID_Get.Result UserID_Get(String user_id)
            {
                var cm = new Users.UserID_Get.Command();
                cm.user_id = user_id;
                return this.UserID_Get(cm);
            }
            public Users.UserID_Videos_Get.Result UserID_Videos_Get(Users.UserID_Videos_Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Users.UserID_Videos_Get.Command, Users.UserID_Videos_Get.Result>(command);
            }
            public Users.UserID_Videos_Get.Result UserID_Videos_Get(String user_id)
            {
                var cm = new Users.UserID_Videos_Get.Command();
                cm.user_id = user_id;
                return this.UserID_Videos_Get(cm);
            }
            public Users.UserID_Videos_Get.Result UserID_Videos_Get(String user_id, Int32? page, Int32? per_page, String query, Users.UserID_Videos_Get.Command.FilterValues filter, Users.UserID_Videos_Get.Command.Filter_EmbeddableValues filter_embeddable, Users.UserID_Videos_Get.Command.Filter_PlayableValues filter_playable, Users.UserID_Videos_Get.Command.SortValues sort, Users.UserID_Videos_Get.Command.DirectionValues direction)
            {
                var cm = new Users.UserID_Videos_Get.Command();
                cm.user_id = user_id;
                cm.page = page;
                cm.per_page = per_page;
                cm.query = query;
                cm.filter = filter;
                cm.filter_embeddable = filter_embeddable;
                cm.filter_playable = filter_playable;
                cm.sort = sort;
                cm.direction = direction;
                return this.UserID_Videos_Get(cm);
            }
        }
        public partial class Api_Channels
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Channels(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Channels.Get.Result Get(Channels.Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Channels.Get.Command, Channels.Get.Result>(command);
            }
            public Channels.Get.Result Get()
            {
                var cm = new Channels.Get.Command();
                return this.Get(cm);
            }
            public Channels.Get.Result Get(Int32? page, Int32? per_page, String query, Channels.Get.Command.SortValues sort, Channels.Get.Command.DirectionValues direction, Channels.Get.Command.FilterValues filter)
            {
                var cm = new Channels.Get.Command();
                cm.page = page;
                cm.per_page = per_page;
                cm.query = query;
                cm.sort = sort;
                cm.direction = direction;
                cm.filter = filter;
                return this.Get(cm);
            }
            public Channels.ChannelID_Get.Result ChannelID_Get(Channels.ChannelID_Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Channels.ChannelID_Get.Command, Channels.ChannelID_Get.Result>(command);
            }
            public Channels.ChannelID_Get.Result ChannelID_Get(String channel_id)
            {
                var cm = new Channels.ChannelID_Get.Command();
                cm.channel_id = channel_id;
                return this.ChannelID_Get(cm);
            }
            public Channels.ChannelID_Videos_Get.Result ChannelID_Videos_Get(Channels.ChannelID_Videos_Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Channels.ChannelID_Videos_Get.Command, Channels.ChannelID_Videos_Get.Result>(command);
            }
            public Channels.ChannelID_Videos_Get.Result ChannelID_Videos_Get(String channel_id)
            {
                var cm = new Channels.ChannelID_Videos_Get.Command();
                cm.channel_id = channel_id;
                return this.ChannelID_Videos_Get(cm);
            }
            public Channels.ChannelID_Videos_Get.Result ChannelID_Videos_Get(String channel_id, Int32? page, Int32? per_page, String query, Channels.ChannelID_Videos_Get.Command.FilterValues filter, Channels.ChannelID_Videos_Get.Command.Filter_EmbeddableValues filter_embeddable, Channels.ChannelID_Videos_Get.Command.SortValues sort, Channels.ChannelID_Videos_Get.Command.DirectionValues direction)
            {
                var cm = new Channels.ChannelID_Videos_Get.Command();
                cm.channel_id = channel_id;
                cm.page = page;
                cm.per_page = per_page;
                cm.query = query;
                cm.filter = filter;
                cm.filter_embeddable = filter_embeddable;
                cm.sort = sort;
                cm.direction = direction;
                return this.ChannelID_Videos_Get(cm);
            }
        }
        public partial class Api_Videos
        {
            private ApiEndpoints _ApiEndpoints;

            public Api_Videos(ApiEndpoints apiEndpoints)
            {
                _ApiEndpoints = apiEndpoints;
            }

            public Videos.Get.Result Get(Videos.Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Videos.Get.Command, Videos.Get.Result>(command);
            }
            public Videos.Get.Result Get(String query)
            {
                var cm = new Videos.Get.Command();
                cm.query = query;
                return this.Get(cm);
            }
            public Videos.Get.Result Get(Int32? page, Int32? per_page, String query, Videos.Get.Command.SortValues sort, Videos.Get.Command.DirectionValues direction, Videos.Get.Command.FilterValues filter)
            {
                var cm = new Videos.Get.Command();
                cm.page = page;
                cm.per_page = per_page;
                cm.query = query;
                cm.sort = sort;
                cm.direction = direction;
                cm.filter = filter;
                return this.Get(cm);
            }
            public Videos.VideoID_Get.Result VideoID_Get(Videos.VideoID_Get.Command command)
            {
                return _ApiEndpoints._Client.GetResult<Videos.VideoID_Get.Command, Videos.VideoID_Get.Result>(command);
            }
            public Videos.VideoID_Get.Result VideoID_Get(String video_id)
            {
                var cm = new Videos.VideoID_Get.Command();
                cm.video_id = video_id;
                return this.VideoID_Get(cm);
            }
        }
    }
}
