using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiBot.Models.SearchModel
{
    class SearchInfo
    {
        public Dictionary<string,string> Context { get; set; }
        public string Type { get; set; }
        public IList<ItemListElement> ItemListElement { get; set; }
    }
}
