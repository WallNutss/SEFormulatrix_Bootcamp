using System;

namespace Chess.Views;

    public class PreGameStartView : IComponent
    {
        public string ComponentName { get => "Header"; }
        private string _header;

        public PreGameStartView(string Title)
        {

            _header =
                    "=============================================\n" +
                    $"**            {Title}           **\n" +
                    "=============================================\n";
        }
        public void Invoke()
        {
            Console.WriteLine(_header);
        }
    }
