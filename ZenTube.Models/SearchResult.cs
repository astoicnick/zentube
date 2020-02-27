using System;
using System.Collections.Generic;
using System.Text;
using Google.Apis.YouTube.v3.Data;

namespace ZenTube.Models
{
    public class SearchResultModel
    {
        public string VideoId { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
