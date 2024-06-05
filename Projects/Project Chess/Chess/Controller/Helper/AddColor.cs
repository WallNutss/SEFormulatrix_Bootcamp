using Chess.Enums;

static class AddColor
{
    private static readonly Dictionary<ConsoleColor, string> _colorMap = new(){
        {ConsoleColor.Black, "\u001b[30m"},
        {ConsoleColor.Red, "\u001b[31m"},
        {ConsoleColor.Green, "\u001b[32m"},
        {ConsoleColor.Yellow, "\u001b[33m"},
        {ConsoleColor.Blue, "\u001b[34m"},
        {ConsoleColor.Magenta, "\u001b[35m"},
        {ConsoleColor.Cyan, "\u001b[36m"},
        {ConsoleColor.White, "\u001b[37m"},
    };

    private static readonly Dictionary<ColorType, string> _pieceColorMap = new(){
        {ColorType.White, _colorMap[ConsoleColor.Cyan]},          
        {ColorType.Black, _colorMap[ConsoleColor.Green]},          
    };

    private static readonly Dictionary<PlayerType, string> _playerColorMap = new(){
        {PlayerType.PlayerA, _colorMap[ConsoleColor.Cyan]},          
        {PlayerType.PlayerB, _colorMap[ConsoleColor.Green]},          
    };

    public static string Message(string Message, ConsoleColor Color)
    {
        return
            $"{_colorMap[Color]}" + Message + "\u001b[0m";
    }
    public static string Message(string Message, ColorType colorType)
    {
        return
            $"{_pieceColorMap[colorType]}" + Message + "\u001b[0m";
    }
    public static string Message(string Message, PlayerType playerType)
    {
        return
            $"{_playerColorMap[playerType]}" + Message + "\u001b[0m";
    }
}