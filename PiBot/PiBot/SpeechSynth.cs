using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Threading.Tasks;
using RestSharp;

namespace PiBot
{
    public static class SpeechSynth
    {
        public static async Task SynthesisToSpeakerAsync(string text)
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription("a36c16c465c34906a4deaf107b9fdea6", "uksouth");
            // Creates a speech synthesizer using the default speaker as audio output.
            using (var synthesizer = new SpeechSynthesizer(config))
            {
                text = @"<speak version='1.0' xmlns='https://www.w3.org/2001/10/synthesis' xml:lang='en-US'><voice name='en-GB-MiaNeural'>" + text + "</voice></speak>";
                using (var result = await synthesizer.SpeakSsmlAsync(text))
                //using (var result = await synthesizer.SpeakTextAsync(text))
                {
                    if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");
                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }
                    }
                }
            }
        }

       

        
    }
}
