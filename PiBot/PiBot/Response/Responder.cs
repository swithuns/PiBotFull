using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiBot.Response
{
    public class Responder
    {
        private bool LearningMode = true;
        public string PreviousMessage { get; private set; }
        public string CurrentMessage { get; private set; }
        public string Topic { get; private set; }
        public string LatestResponse { get; private set; }
        public ICollection<string> Topics { get; private set; }
        public ICollection<string> ConvoCancellers { get; private set; }
        public ICollection<string> ConvoKeywords { get; private set; }
        public ICollection<string> Dismissers { get; private set; }
        public ICollection<string> SearchQualifiers{ get; set; }
        
        public Responder()
        {
            Dismissers = new List<string>() { "I wasn't talking to you", "not you" };
            ConvoCancellers = new List<string>() { "never mind", "talk about something else"};
            SearchQualifiers = new List<string>() { "what", "who", "where", "how", "why" };
            Topics = new List<string>();
        }
 
        public string GetResponse(string input)
        {
            PreviousMessage = CurrentMessage;
            CurrentMessage = input;
            if(this.SearchInput(input,out string searchResponse))
            { return searchResponse; }
            if(this.CancelConversation(input))
            {
                return "Okay";
            }
            if(this.DismissLatest(input))
            {
                return "Okay, Sorry";
            }
            if (Topic == null)
            { 
                if(this.StartConversation(input, out string response))
                {
                    return response;
                }
                else { return response; }
            }
            else
            {
                if(this.ContinueConversation(input,out string response))
                {

                }
            }
            var splitSentence = input.Split(' ');
            foreach (string word in splitSentence)
            {
                
            }
            return "";
        }

        private bool SearchInput(string input, out string searchResponse)
        {
            foreach (string searchQual in SearchQualifiers)
            {
                if (input.Contains(searchQual))
                {
                    string ShortInput = input.Split(new string[] { "is ", "are " }, StringSplitOptions.RemoveEmptyEntries).Last();
                    if (!String.IsNullOrEmpty(ShortInput))
                    {
                        searchResponse = Search.GoogleDataAPI(ShortInput);
                        return true;
                    }
                }
            }
            searchResponse = null;
            return false;
        }

        private bool ContinueConversation(string input, out string response)
        {
            response = "nope";
            return false;
        }

        private bool StartConversation(string input, out string response)
        {
            if (input.Contains("talk about" ))
            {
                Topic = input.Split(new string[] { "about" }, StringSplitOptions.None).LastOrDefault();

            }
            foreach (string topic in Topics)
            {
                if (input.Contains(topic))
                {
                    Topic = topic;
                    response = this.GetResponse(input);
                    if (response == "")
                    {
                        response = "What would you like to know about" + Topic;
                    }
                    return true;
                }
            }
            response = "I don't know anything about that.";
            return false;
        }

        private bool DismissLatest(string input)
        {
            foreach (string Dismisser in Dismissers)
            {
                if (input.Contains(Dismisser))
                {
                    PreviousMessage = CurrentMessage;
                    return true;
                }
            }
            return false;
        }

        private bool CancelConversation(string input)
        {
            foreach (string canceller in ConvoCancellers)
            {
                if (input.Contains(canceller))
                    { 
                    Topic = null;
                    ConvoKeywords = null;
                    return true;
                }
            }
            return false;
        }
    }
}
