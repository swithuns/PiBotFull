using Google.Cloud.Speech.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AudioReader
{
    public class SpeechRecogniser
    {
        public RecognitionConfig Config { get; set; }
        public SpeechClient Client { get; set; }
        public SpeechRecogniser()
        {
            //apikey = AIzaSyApSUkdJXbR29cccXDs7mmVbQYPval1F3Q
            var speech = new SpeechClientBuilder();
            speech.JsonCredentials = File.ReadAllText("../../../../AudioReader/key.json");
            var speechWriter = speech.Build();
            var config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                LanguageCode = LanguageCodes.English.UnitedKingdom,
                AudioChannelCount = 1

            };
            this.Config = config;
            this.Client = speechWriter;
        }
        public string GetTopResult(string filePath)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var audio = RecognitionAudio.FromFile(filePath);
            Console.WriteLine("GetAudio:" + stopwatch.ElapsedMilliseconds.ToString() + "ms");
            stopwatch.Restart();
            var audioResult = this.Client.Recognize(Config, audio);
            Console.WriteLine("RecognisedSpeechArray:" + stopwatch.ElapsedMilliseconds.ToString() + "ms");
            stopwatch.Restart();
            var fullResult = JsonSerializer.Deserialize<List<Sequence>>(audioResult.Results.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            Console.WriteLine("SerializeResult:" + stopwatch.ElapsedMilliseconds.ToString() + "ms");
            stopwatch.Restart();
            var result = fullResult[0].Alternatives[0].Transcript;
            Console.WriteLine("Return top:" + stopwatch.ElapsedMilliseconds.ToString() + "ms");
            return result;
        }
    }
}
