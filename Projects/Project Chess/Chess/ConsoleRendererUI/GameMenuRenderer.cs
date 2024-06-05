using System;

namespace Chess.Views;

    public class GameMenuRenderer : IComponent
    {
        public string ComponentName { get => "Header"; }
        private string _header;

        public GameMenuRenderer(string Title)
        {

            _header =
                    "=============================================\n" +
                    $"**            {Title}                     **\n" +
                    "=============================================\n";
        }
        public void Invoke()
        {
            Console.WriteLine(_header);
        }
    }
