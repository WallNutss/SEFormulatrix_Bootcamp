using System;
using Chess.Players;

namespace Chess.Views;

    public class PlayerListView
    {
        public string ComponentName { get => "Header"; }
        public void Invoke(List<IPlayer> Title){
            string _header =
                    "==================WELCOME=====================\n" +
                    $"**  {AddColor.Message(Title[1].playerType.ToString(), ConsoleColor.Cyan)}  :  {AddColor.Message(Title[1].name, ConsoleColor.Cyan)}    **\n" +
                    $"**  {AddColor.Message(Title[0].playerType.ToString(), ConsoleColor.Green)}  :  {AddColor.Message(Title[0].name, ConsoleColor.Green)}    **\n" +
                    "==================PLAYERS!====================\n";
            Console.WriteLine(_header);
        }
    }
