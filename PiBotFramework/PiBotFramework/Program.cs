
namespace PiBotFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Listener listener = new Listener();
            listener.StartListening();
            while (true) { }
        }
    }
} 
        
  
