using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Bing.SampleConsoleApp
{
    public class BingClientPlayground
    {
        public BingClient BingClient { get; set; } = new();

        public async ValueTask ExecuteAsync()
        {
            SetSetting();
            await SearchFromSpecifiedDomain();
            Console.WriteLine("■Completed");
        }
        private void SetSetting()
        {
            var apiKey = File.ReadAllText("C:\\Dev\\BingApiKey.txt");
            BingClient = new BingClient(apiKey);
        }

        private async ValueTask Search()
        {
            var cl = BingClient;
            var p = new SearchParameter();
            p.Q = "Lamin Yamal";
            p.ResultCount = 20;
            p.Market = BingMarket.Spain;
            var res = await cl.Search(p);
            if (res.WebPages != null)
            {
                foreach (var item in res.WebPages.Value)
                {
                    Console.WriteLine("-------------------------------------");
                    if (item.PublishTime.HasValue)
                    {
                        Console.WriteLine(item.PublishTime.Value.ToString("yyyy/MM/dd HH:mm"));
                    }
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Url);
                    Console.WriteLine("");
                }
            }
        }
        private async ValueTask SearchFromSpecifiedDomain()
        {
            var cl = BingClient;
            var p = new SearchParameter();
            p.Q = "Lamin Yamal site:marca.com";
            p.ResultCount = 20;
            p.Market = BingMarket.Spain;
            var res = await cl.Search(p);
            if (res.WebPages != null)
            {
                foreach (var item in res.WebPages.Value)
                {
                    Console.WriteLine("-------------------------------------");
                    if (item.PublishTime.HasValue)
                    {
                        Console.WriteLine(item.PublishTime.Value.ToString("yyyy/MM/dd HH:mm"));
                    }
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Url);
                    Console.WriteLine("");
                }
            }
        }
        private async ValueTask SearchImage()
        {
            var cl = BingClient;
            var p = new ImagesSearchParameter();
            p.Q = "Lamin Yamal";
            var res = await cl.SearchImages(p);
            foreach (var item in res.Value)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(item.Name);
                Console.WriteLine(item.ContentUrl);
                Console.WriteLine(item.ThumbnailUrl);
                Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
                Console.WriteLine("");
            }
        }
        private async ValueTask SearchTrendingImage()
        {
            var cl = BingClient;
            var p = new ImagesTrendingParameter();
            p.Market = BingMarket.UnitedStatesSpanish;
            p.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_1 like Mac OS X) AppleWebKit/536.26 (KHTML; like Gecko) Mobile/10B142 iPhone4;1 BingWeb/3.03.1428.20120423";
            p.MSEdgeClientId = "00B4230B74496E7A13CC2C1475056FF4";
            p.MSEdgeClientIP = "11.22.33.44";
            var res = await cl.TrendingImages(p);
            foreach (var category in res.Categories)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(category.Title);

                foreach (var item in category.Tiles)
                {
                    Console.WriteLine(item.Query.Text);
                    Console.WriteLine(item.Query.WebSearchUrl);
                    Console.WriteLine(item.Image.ImageId);
                    Console.WriteLine(item.Image.ThumbnailUrl);
                    Console.WriteLine("");
                }
            }
        }
        private async ValueTask SearchVideo()
        {
            var cl = BingClient;
            var p = new VideosSearchParameter();
            p.Q = "Lamin Yamal";
            var res = await cl.SearchVideos(p);
            foreach (var item in res.Value)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(item.Name);
                Console.WriteLine(item.ContentUrl);
                Console.WriteLine(item.Description);
                Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
                Console.WriteLine("");
            }

            if (res.Value.Length > 0)
            {
                var videoId = res.Value.First().VideoId;
                var res1 = await cl.VideosDetails(videoId);
                Console.WriteLine(JsonConvert.SerializeObject(res1.VideoResult, Formatting.Indented));
            }
        }
        private async ValueTask SearchTrendingVideo()
        {
            var cl = BingClient;
            var p = new VideosTrendingParameter();
            p.Market = BingMarket.UnitedStatesSpanish;
            p.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_1 like Mac OS X) AppleWebKit/536.26 (KHTML; like Gecko) Mobile/10B142 iPhone4;1 BingWeb/3.03.1428.20120423";
            p.MSEdgeClientId = "00B4230B74496E7A13CC2C1475056FF4";
            p.MSEdgeClientIP = "11.22.33.44";
            var res = await cl.TrendingVideos(p);
            foreach (var item in res.BannerTiles)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(item.Query.DisplayText);
                Console.WriteLine(item.Query.WebSearchUrl);
                Console.WriteLine(item.Image.ThumbnailUrl);
                Console.WriteLine("");
            }
        }
    }
}
