using System;

namespace HigLabo.Net.Vimeo.Api_3_2
{
    public partial class ApiEndpoints
    {
        private Api_Channels _Channels;
        private Api_Videos _Videos;

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
            public Channels.Get.Result Get(Int32 page, Int32 per_page, String query, Channels.Get.Command.SortValues sort, Channels.Get.Command.DirectionValues direction, Channels.Get.Command.FilterValues filter)
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
            public Videos.Get.Result Get(Int32 page, Int32 per_page, String query, Videos.Get.Command.SortValues sort, Videos.Get.Command.DirectionValues direction, Videos.Get.Command.FilterValues filter)
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
        }
    }
}
