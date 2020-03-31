using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiBot.Response
{
    class Conversation
    {
        public ICollection<string> Triggers { get; set; }
        public string Response { get; set; }
    }
}
