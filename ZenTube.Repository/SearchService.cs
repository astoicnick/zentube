using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenTube.Models;

namespace ZenTube.Repository
{
    public class SearchService
    {
        private YoutubeFactory _youtubeFactory;
        public async IAsyncEnumerable<SearchResultModel> SearchForVideos(string searchQuery)
        {
            _youtubeFactory = new YoutubeFactory();
            var youtubeService = await _youtubeFactory.buildYoutubeService();
            var req = youtubeService.Search.List("snippet");
            req.Q = searchQuery;
            req.MaxResults = 25;
            req.RelevanceLanguage = "en";
            var res = await req.ExecuteAsync();
            foreach (var item in res.Items.Select(i => new SearchResultModel() 
            {
                VideoId = i.Id.VideoId,
                Title = i.Snippet.Title,
                Description = i.Snippet.Description,
                PublishedAt = i.Snippet.PublishedAt
            }))
            {
                yield return item;
            }
        }
        // Still working on combining the search of videos and channels.
        //                                                              //
        //public async IAsyncEnumerable<Channel> searchForChannel(string channel)
        //{
        //    var req = ytService.Channels.List("contentDetails");
        //    req.Id = channel;
        //    var res = await req.ExecuteAsync();
        //    foreach (var item in res.Items.ToList())
        //    {
        //        yield return item;
        //    }
        //}
    }
}
