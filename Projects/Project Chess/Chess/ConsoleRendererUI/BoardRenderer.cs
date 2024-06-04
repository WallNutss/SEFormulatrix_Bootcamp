using System;
using System.Text;
using Chess.Pieces;
using Chess.Players;
using Chess.Enums;
using Chess.PlayerDatas;

namespace Chess.Render;

public static class BoardRenderer{
    private static int _widthBoardDimension = 8; 
    private static int _heightBoardDimension = 8;
    private static int _widthBoardDimensionRender = 17; 
    private static int _spaces = 4;


    private static string GetPieceSymbol(Piece piece)
        {
            return piece.piecesType switch
            {
                PiecesType.King   =>     "K",
                PiecesType.Queen  =>     "Q",
                PiecesType.Rook   =>     "R",
                PiecesType.Bishop =>     "B",
                PiecesType.Knight =>     "H",
                PiecesType.Pawn   =>     "P",
                _ => "N"
            };
        }
    private static string GetPieceColor(Piece piece)
        {
            return piece.pieceColor switch
            {
                ColorType.White   =>     "W",
                ColorType.Black   =>     "B",
                _ => "N"
            };
        }


    // internal string firstStringBoard = "      1    2    3    4    5    6    7    8\n";
    // internal string oddStringBoard =   "    + -- + -- + -- + -- + -- + -- + -- + -- +\n";
   
    // public staticBoardRenderer(int heightDimension, int widthDimension){
    //     _widthBoardDimension = widthDimension;
    //     _heightBoardDimension = heightDimension;
    //     _widthBoardDimensionRender = 41; // 45 Column Console
    //     _spaces = 4;
    // }
    public static void PrintBoard(List<Piece> playerDatas){
        
        for(int y=1,dataIndex=1;y<=(_heightBoardDimension*2)+1; y++){
            // List<Piece> Take all the pieces
            if(y%2==0){
                List<Piece> pieceWithData = playerDatas.Where(p => p.pos.y == dataIndex).ToList();
                foreach(var piece in pieceWithData){
                    //Console.WriteLine($"Piece type : {piece.piecesType}, ID : {piece.pieceID} with color is {piece.pieceColor} pos (xy) = {piece.pos.x},{piece.pos.y}");
                }
                PrintEvenStringBoard(pieceWithData, dataIndex);
                dataIndex++;
            }
            else if(y%2!=0){
                PrintOddStringBoard();
            }
        }

    }

    private static void PrintEvenStringBoard(List<Piece> data, int dataIndex){
        StringBuilder printRowBoard = new();
        for(int x=1;x<=_widthBoardDimension;x++){
            int index =  data.FindIndex(p => p.pos.x == x);
            if(index==-1){
                StringBuilder temp = new("|    ");
                printRowBoard.Append(temp);
            }else{
                // string pieceChoose = ColorType.White == data[index].pieceColor? playerAChara[(int)pieceWithData[index].piecesType].ToString() : playerBChara[(int)pieceWithData[index].piecesType].ToString();
                // Console.WriteLine(data[index].piecesType);
                string pieceType = GetPieceSymbol(data[index]);
                string pieceColor = GetPieceColor(data[index]);
                StringBuilder temp = new($"| {pieceType}{pieceColor} ");
                printRowBoard.Append(temp);
            }
        }
        Console.WriteLine($"{dataIndex}  "+printRowBoard.ToString()+ "|");
    }

    private static void PrintOddStringBoard(){
        StringBuilder first = new("   ");
        first.Append("+");
        for(int i=0;i<_widthBoardDimension;i++){
            for(int y=0;y<_spaces;y++){
                if(y==0 || y==_spaces-1){
                    first.Append(" ");
                }else{
                    first.Append("-");
                }
            }
            first.Append("+");
        }
        first.Append("");
        Console.WriteLine(first.ToString());
    }

}