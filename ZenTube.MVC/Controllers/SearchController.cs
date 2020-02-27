using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Mvc;
using ZenTube.MVC.Models;
using ZenTube.Repository;

namespace ZenTube.MVC.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(SearchModel userInput)
        {
            var search = new Search();
            var results = search.searchYT(userInput.Keyword);
            var newModel = new SearchModel()
            {
                Results = results,
                Keyword = userInput.Keyword
            };
            return View(newModel);
        }
        [HttpGet]
        public IActionResult SearchResults(SearchModel userInput)
        {
            return View(userInput);
        }
    }
}