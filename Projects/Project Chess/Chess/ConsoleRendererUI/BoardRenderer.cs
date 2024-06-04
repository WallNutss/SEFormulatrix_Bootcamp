using System;
using System.Text;
using Chess.Pieces;
using Chess.Players;
using Chess.Enums;
using Chess.PlayerDatas;

namespace Chess.Render;

public static class BoardRenderer{
    // private int _widthBoardDimension; 
    // private int _heightBoardDimension;
    // private int _widthBoardDimensionRender; 
    // private int _spaces;


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


    // internal string firstStringBoard = "      1    2    3    4    5    6    7    8\n";
    // internal string oddStringBoard =   "    + -- + -- + -- + -- + -- + -- + -- + -- +\n";
   
    // public BoardRenderer(int heightDimension, int widthDimension){
    //     _widthBoardDimension = widthDimension;
    //     _heightBoardDimension = heightDimension;
    //     _widthBoardDimensionRender = 41; // 45 Column Console
    //     _spaces = 4;
    // }
    public static void PrintBoard(List<Piece> playerDatas){
        
        for(int y=1,dataIndex=1;y<=(8*2)+1; y++){
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
        for(int x=1;x<=8;x++){
            int index =  data.FindIndex(p => p.pos.x == x);
            if(index==-1){
                StringBuilder temp = new("|    ");
                printRowBoard.Append(temp);
            }else{
                // string pieceChoose = ColorType.White == data[index].pieceColor? playerAChara[(int)pieceWithData[index].piecesType].ToString() : playerBChara[(int)pieceWithData[index].piecesType].ToString();
                // Console.WriteLine(data[index].piecesType);
                string pieceChoose = GetPieceSymbol(data[index]);
                StringBuilder temp = new($"| {pieceChoose} ");
                printRowBoard.Append(temp);
            }
        }
        Console.WriteLine($"{dataIndex}  "+printRowBoard.ToString()+ "|");
    }

    private static void PrintOddStringBoard(){
        StringBuilder first = new("   ");
        first.Append("+");
        for(int i=0;i<8;i++){
            for(int y=0;y<4;y++){
                if(y==0 || y==4-1){
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