namespace Chess.Boards;

using System;
using System.Text;

using Chess.Enums;
using Chess.Pieces;
using Chess.PlayerDatas;
using Chess.Players;
using Chess.Render;

/// <summary>
/// An Implementation of IBoard
/// </summary>
public class Board: IBoard{
    public int width { get; private set; }
    public int height { get; private set; }
    public List<IPosition> squares { get; set;}
    
    public Board(){
        this.squares = new List<IPosition>();
        this.width = 8;
        this.height = 8;
        InitializeCoordinate();
    }
    public void InitializeCoordinate(){
        List<IPosition> squares  = new List<IPosition>();
        for (int x = 1; x <= this.width; x++){
            for (int y = 1; y <= this.height; y++){
                squares.Add(new Square(_x:x, _y:y));
            }
        }
        this.squares = squares;
    }

    public string PrintEachRowBoard(List<Piece> pieceWithData, int X){

        string[] playerAChara = new string[6] {"KW", "QW", "RW", "BW", "HW", "PW"};
        string[] playerBChara = new string[6] {"KB", "QB", "RB", "BB", "HB", "PB"};
        StringBuilder printRowBoard = new();
        for(int x=1;x<=this.width;x++){
            int index =  pieceWithData.FindIndex(p => p.pos.x == x);
            if(index==-1){
                StringBuilder temp = new("|    ");
                printRowBoard.Append(temp);
            }else{
                string pieceChoose = ColorType.White == pieceWithData[index].pieceColor? playerAChara[(int)pieceWithData[index].piecesType].ToString() : playerBChara[(int)pieceWithData[index].piecesType].ToString();
                StringBuilder temp = new($"| {pieceChoose} ");
                printRowBoard.Append(temp);
            }
        }
        return $"{X}  "+printRowBoard.ToString()+ "|\n";
        // Console.WriteLine($"{X}  "+printRowBoard.ToString()+ "|");
    }
    public void PrintBoard(Dictionary <IPlayer, List<Piece>> playerDatas){

        
        List<Piece> allPieces = playerDatas.Values.SelectMany(pieces => pieces).ToList();
        BoardRenderer.PrintBoard(allPieces);
        // Get all pieces from the dictionary
        // StringBuilder printOut = new($"\r");
        // printOut.Append("      1    2    3    4    5    6    7    8\n");
        // // Console.WriteLine("      1    2    3    4    5    6    7    8");
        // for (int y = 1, data=1; y <= (this.height*2)+1; y++){
        //     // Print the upper part
        //     if(y%2==0){
        //         // Filter the points where X is 0
        //         List<Piece> pieceWithData = allPieces.Where(p => p.pos.y == data).ToList();
        //         string printRow = PrintEachRowBoard(pieceWithData,data);
        //         printOut.Append(printRow);
        //         data++; // This is to check each row that printable on
        //     }
        //     // Print the lower part
        //     else if(y%2==1){
        //         printOut.Append("   + -- + -- + -- + -- + -- + -- + -- + -- +\n");
        //         // Console.WriteLine("   + -- + -- + -- + -- + -- + -- + -- + -- +");
        //     }
        // }
        // Console.SetCursorPosition(0, 0);
        // Console.WriteLine(printOut);
    }
}