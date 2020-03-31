using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiBotFramework
{
    class Listener
    {
        SpeechRecognitionEngine recognizer;
        public void StartListening()
        {
            recognizer = new SpeechRecognitionEngine();
            recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(new string[] { "Pi Bot" })) { Culture = Thread.CurrentThread.CurrentCulture }));
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognizedHandler);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            
        }

        private void SpeechRecognizedHandler(
          object sender, SpeechRecognizedEventArgs e)
        {
            recognizer.RecognizeAsyncStop();
            Audio audio = new Audio();
            audio.Record(3000);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}
