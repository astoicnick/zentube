using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenTube.MVC.Models
{
    public class SearchModel
    {
        public string Keyword { get; set; }
        public IAsyncEnumerable<SearchResultSnippet> Results { get; set; } = null;
    }
}
