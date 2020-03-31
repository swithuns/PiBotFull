using Newtonsoft.Json;
using PiBot.Models.SearchModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PiBot.Response
{
    static class Search
    {
        public static string GoogleDataAPI(string searchQuery)
        {
            searchQuery.Replace(" ", "+");
            string apiKey = "AIzaSyAU0AFZFtQEOqsilnZHbD2U31a49PCQDIQ";
            using (var client = new WebClient())
            {
                var searchJson = client.DownloadString("https://kgsearch.googleapis.com/v1/entities:search?query=" + searchQuery + "&key=" + apiKey + "&limit=10&indent=True");
                var SearchOutput = JsonConvert.DeserializeObject<SearchInfo>(searchJson);
                if (SearchOutput != null)
                {
                    return SearchOutput.ItemListElement[0].Result.DetailedDescription.ArticleBody;
                }
                return null;
            }
        }
    }
}
