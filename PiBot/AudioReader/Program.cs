using System;
using System.IO;
using Google.Apis.Services;
using Google.Cloud.Speech.V1;
using System.Text.Json;
using System.Collections.Generic;

namespace AudioReader
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioWatcher audioWatcher = new AudioWatcher();
            audioWatcher.Run("D:/Recordings");
            while (true) { }
        }
    }
}
