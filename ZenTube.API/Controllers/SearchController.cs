using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZenTube.Models;
using ZenTube.Repository;

namespace ZenTube.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors()]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public async IAsyncEnumerable<SearchResultModel> getSearchResults(string keyword)
        {
            var searchService = new SearchService();
            await foreach (var item in searchService.SearchForVideos(keyword))
            {
                yield return item;
            }
        }
    }
}
