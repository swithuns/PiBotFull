using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using PiBot.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PiBot
{
    class Program
    {

        static void Main()
        {
            
            Responder responder = new Responder();
            while (true)
            {
                string text = Console.ReadLine();
                var response = responder.GetResponse(text);
                SpeechSynth.SynthesisToSpeakerAsync(response).Wait();
               
            }

            
        }
    }
}
