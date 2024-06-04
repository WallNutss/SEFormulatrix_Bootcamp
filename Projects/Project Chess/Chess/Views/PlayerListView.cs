using System;
using Chess.Players;

namespace Chess.Views;

    public class PlayerListView : IComponent
    {
        public string ComponentName { get => "Header"; }
        private string _header;

        public PlayerListView(List<IPlayer> Title)
        {

            _header =
                    "==================WELCOME=====================\n" +
                    $"**  {AddColor.Message(Title[1].playerType.ToString(), ConsoleColor.Cyan)}  :  {AddColor.Message(Title[1].name, ConsoleColor.Cyan)}    **\n" +
                    $"**  {AddColor.Message(Title[0].playerType.ToString(), ConsoleColor.Green)}  :  {AddColor.Message(Title[0].name, ConsoleColor.Green)}    **\n" +
                    "==================PLAYERS!====================\n";
        }
        public void Invoke()
        {
            Console.WriteLine(_header);
        }
    }
