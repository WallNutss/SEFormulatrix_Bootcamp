using System;

namespace Chess.Views;

    public class GameMenuRenderer
    {
        public string ComponentName { get => "Header"; }
        public void Invoke(string message)
        {
            string _header =
                    "=============================================\n" +
                    $"**            {message}                     **\n" +
                    "=============================================\n";
            Console.WriteLine(_header);
        }
    }
