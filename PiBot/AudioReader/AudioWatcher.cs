
using System;
using System.IO;
using PiBot.Response;
using PiBot;
using System.Diagnostics;
namespace AudioReader
{
    public class AudioWatcher
    {
        public SpeechRecogniser speechRecogniser { get; set; }
        public Responder responder { get; set; }
        public AudioWatcher()
        {
            speechRecogniser = new SpeechRecogniser();
            responder = new Responder();
        }
        public void Run(string Directory)
        {
            FileSystemWatcher watcher = new FileSystemWatcher()
            {
                Path = Directory,
                NotifyFilter = NotifyFilters.LastAccess,
                Filter = "*.wav",
                EnableRaisingEvents = true,
            };
            watcher.Changed += OnChanged;
        }

        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var output = speechRecogniser.GetTopResult(e.FullPath);
            Console.WriteLine("RecognisedSpeech:" + stopwatch.ElapsedMilliseconds.ToString() + "ms");
            Console.WriteLine(output);
            stopwatch.Restart();
            var response = responder.GetResponse(output);
            Console.WriteLine("Responder:" + stopwatch.ElapsedMilliseconds.ToString() + "ms");
            stopwatch.Restart();
            SpeechSynth.SynthesisToSpeakerAsync(response).Wait();
            Console.WriteLine("SpeechSynthesiser:" + stopwatch.ElapsedMilliseconds.ToString() + "ms");
            File.Delete(e.FullPath);
        }
    }
}