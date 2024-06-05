using System;
using System.Text;
using Chess.Pieces;
using Chess.Players;
using Chess.Enums;
using Chess.PlayerDatas;

namespace Chess.Render;

public class BoardRenderer{
    private static int _widthBoardDimension = 8; 
    private static int _heightBoardDimension = 8;
    private static int _widthBoardDimensionRender = 17; 
    private static int _spaces = 6;


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
    private static string GetPieceIDSuperscript(Piece piece)
        {
            return piece.pieceID switch
            {
                1    =>     "\xb9 ",
                2    =>     "\xb2 ",
                3    =>     "\xb3 ",
                4    =>     "\u2074 ",
                5    =>     "\u2075 ",
                6    =>     "\u2076 ",
                7    =>     "\u2077 ",
                8    =>     "\u2078 ",
                9    =>     "\u2079 ",
                10   =>     "\xb9\u2070",
                11   =>     "\xb9\xb9",
                12   =>     "\xb9\u00b2",
                13   =>     "\xb9\u00b3",
                14   =>     "\xb9\u2074",
                15   =>     "\xb9\u2075",
                16   =>     "\xb9\u2076",
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
        Console.WriteLine("      1    2    3    4    5    6    7    8");
        for(int y=1,dataIndex=1;y<=(_heightBoardDimension*2)+1; y++){
            // List<Piece> Take all the pieces
            if(y%2==0){
                List<Piece> pieceWithData = playerDatas.Where(p => p.pos.y == dataIndex).ToList();
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
            StringBuilder temp = new("|");
            if(index==-1){
                string temp2 = new string(' ',_spaces);
                temp.Append(temp2);
                printRowBoard.Append(temp);
            }else{
                for(int y=0;y<_spaces;y++){
                    if(y==0 || y==_spaces){
                        temp.Append(" ");
                    }
                    else if(y == _spaces/2){
                        string pieceType = GetPieceSymbol(data[index]);
                        string pieceColor = GetPieceColor(data[index]);
                        string pieceID = GetPieceIDSuperscript(data[index]);
                        StringBuilder temp3 = new($"{AddColor.Message($"{pieceType}{pieceColor}{pieceID}",data[index].pieceColor)} ");
                        temp.Append(temp3);
                        printRowBoard.Append(temp);
                    }
                }
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
        // Console.
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        // Console.
        Console.WriteLine(first.ToString());
    }

}