using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ZenTube.Repository
{
    public class YoutubeFactory
    {
        public async Task<YouTubeService> buildYoutubeService()
        {
            var apiKey = await loadAPIKey();
            return new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = "ZenTube"
            });
        }
        private async Task<string> loadAPIKey()
        {
            using (var jsonFileReader = new StreamReader(@"C:\Users\nick\source\repos\Zentube\ZenTube.Repository\youtubeAPIKey.json"))
            {
                string wholeJSONFile = await jsonFileReader.ReadToEndAsync();
                var youtubeAPIKey = JsonConvert.DeserializeObject<Dictionary<string,string>>(wholeJSONFile);
                return youtubeAPIKey["apiKey"];
            }
        }
    }
}
